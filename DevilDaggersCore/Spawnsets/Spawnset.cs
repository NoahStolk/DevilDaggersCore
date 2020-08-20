using DevilDaggersCore.Game;
using DevilDaggersCore.Spawnsets.Events;
using DevilDaggersCore.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevilDaggersCore.Spawnsets
{
	public class Spawnset
	{
		public const int HeaderBufferSize = 36;
		public const int ArenaBufferSize = 10404; // ArenaWidth * ArenaHeight * TileBufferSize (51 * 51 * 4 = 10404)
		public const int SpawnsHeaderBufferSize = 40; // The amount of bytes in the spawns buffer header (no idea what they are used for)
		public const int SpawnBufferSize = 28; // The amount of bytes per spawn

		public const int ArenaWidth = 51;
		public const int ArenaHeight = 51;

		private float shrinkStart = 50;
		private float shrinkEnd = 20;
		private float shrinkRate = 0.025f;
		private float brightness = 60;

		public Spawnset()
		{
		}

		public Spawnset(SortedDictionary<int, Spawn> spawns, float[,] arenaTiles, float shrinkStart, float shrinkEnd, float shrinkRate, float brightness)
		{
			Spawns = spawns;
			ArenaTiles = arenaTiles;
			ShrinkStart = shrinkStart;
			ShrinkEnd = shrinkEnd;
			ShrinkRate = shrinkRate;
			Brightness = brightness;
		}

		public SortedDictionary<int, Spawn> Spawns { get; set; } = new SortedDictionary<int, Spawn>();
		public float[,] ArenaTiles { get; set; } = new float[ArenaWidth, ArenaHeight];

		public float ShrinkStart
		{
			get => shrinkStart;
			set => shrinkStart = MathUtils.Clamp(value, 1, 100);
		}

		public float ShrinkEnd
		{
			get => shrinkEnd;
			set => shrinkEnd = MathUtils.Clamp(value, 1, 100);
		}

		public float ShrinkRate
		{
			get => shrinkRate;
			set => shrinkRate = Math.Max(value, 0);
		}

		public float Brightness
		{
			get => brightness;
			set => brightness = Math.Max(value, 0);
		}

		public static bool IsEmptySpawn(int enemyType) => enemyType < 0 || enemyType > 9;

		/// <summary>
		/// Tries to parse the contents of a spawnset file into a <see cref="Spawnset"/> instance.
		/// This only works for V3 spawnsets.
		/// </summary>
		/// <param name="spawnsetFileBytes">The spawnset file contents.</param>
		/// <param name="spawnset">The parsed <see cref="Spawnset"/>.</param>
		public static bool TryParse(byte[] spawnsetFileBytes, out Spawnset spawnset)
		{
			try
			{
				// Set the file values for reading V3 spawnsets.
				int spawnBufferSize = spawnsetFileBytes.Length - (HeaderBufferSize + ArenaBufferSize);
				byte[] headerBuffer = new byte[HeaderBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnBuffer = new byte[spawnBufferSize];

				// Read the file and write the data into the buffers, then close the file since we do not need it anymore.
				Buffer.BlockCopy(spawnsetFileBytes, 0, headerBuffer, 0, HeaderBufferSize);
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize, arenaBuffer, 0, ArenaBufferSize);
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize, spawnBuffer, 0, spawnBufferSize);

				// Set the header values.
				float shrinkEnd = BitConverter.ToSingle(headerBuffer, 8);
				float shrinkStart = BitConverter.ToSingle(headerBuffer, 12);
				float shrinkRate = BitConverter.ToSingle(headerBuffer, 16);
				float brightness = BitConverter.ToSingle(headerBuffer, 20);

				// Set the arena values.
				float[,] arenaTiles = new float[ArenaWidth, ArenaHeight];
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / 4 % ArenaHeight;
					int y = i / (ArenaWidth * 4);
					arenaTiles[x, y] = BitConverter.ToSingle(arenaBuffer, i);
				}

				// Set the spawn values.
				SortedDictionary<int, Spawn> spawns = new SortedDictionary<int, Spawn>();
				int spawnIndex = 0;

				int bytePosition = SpawnsHeaderBufferSize;
				while (bytePosition < spawnBufferSize)
				{
					int enemyType = BitConverter.ToInt32(spawnBuffer, bytePosition);
					bytePosition += 4;
					float delay = BitConverter.ToSingle(spawnBuffer, bytePosition);
					bytePosition += 24;

					spawns.Add(spawnIndex++, new Spawn(GameInfo.GetEntities<Enemy>(GameVersion.V3).FirstOrDefault(e => e.SpawnsetType == enemyType), delay));
				}

				spawnset = new Spawnset(spawns, arenaTiles, shrinkStart, shrinkEnd, shrinkRate, brightness);

				return true;
			}
			catch (Exception ex)
			{
				LogUtils.Log.Error($"Could not parse {nameof(Spawnset)}.", ex);

				spawnset = new Spawnset();

				return false;
			}
		}

		public static bool TryGetSpawnData(byte[] spawnsetFileBytes, out SpawnsetData spawnsetData)
		{
			try
			{
				int spawnBufferSize = spawnsetFileBytes.Length - (HeaderBufferSize + ArenaBufferSize + SpawnsHeaderBufferSize);
				byte[] spawnBuffer = new byte[spawnBufferSize];

				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize + SpawnsHeaderBufferSize, spawnBuffer, 0, spawnBufferSize);

				int loopBegin = 0;
				for (int i = spawnBuffer.Length - SpawnBufferSize; i > 0; i -= SpawnBufferSize)
				{
					if (IsEmptySpawn(BitConverter.ToInt32(spawnBuffer, i)))
					{
						loopBegin = i / SpawnBufferSize;
						break;
					}
				}

				int nonLoopSpawns = 0;
				int loopSpawns = 0;
				float nonLoopSeconds = 0;
				float loopSeconds = 0;
				for (int j = 0; j < spawnBuffer.Length; j += SpawnBufferSize)
				{
					if (j < loopBegin * SpawnBufferSize)
						nonLoopSeconds += BitConverter.ToSingle(spawnBuffer, j + 4); // TODO: Trim EMPTY spawns at the end (test with Delirium_Stop)
					else
						loopSeconds += BitConverter.ToSingle(spawnBuffer, j + 4);

					if (!IsEmptySpawn(BitConverter.ToInt32(spawnBuffer, j)))
					{
						if (j < loopBegin * SpawnBufferSize)
							nonLoopSpawns++;
						else
							loopSpawns++;
					}
				}

				spawnsetData = new SpawnsetData
				{
					NonLoopSpawnCount = nonLoopSpawns,
					LoopSpawnCount = loopSpawns,
					NonLoopLength = nonLoopSpawns == 0 ? null : (float?)nonLoopSeconds,
					LoopLength = loopSpawns == 0 ? null : (float?)loopSeconds,
				};

				return true;
			}
			catch (Exception ex)
			{
				LogUtils.Log.Error($"Could not parse {nameof(SpawnsetData)}.", ex);

				spawnsetData = new SpawnsetData();

				return false;
			}
		}

		public bool IsEmpty()
		{
			if (Spawns.Count == 0)
				return true;

			foreach (Spawn spawn in Spawns.Values)
			{
				if (spawn.Enemy != null)
					return false;
			}

			return true;
		}

		public int GetEndLoopStartIndex()
		{
			for (int i = Spawns.Count - 1; i >= 0; i--)
			{
				if (Spawns[i].Enemy == null)
					return i;
			}

			return 0;
		}

		public IEnumerable<double> GenerateEndWaveTimes(double endGameSecond, int waveIndex)
		{
			double enemyTimer = 0;
			double delay = 0;

			IEnumerable<Spawn> endLoop = Spawns.Values.Skip(GetEndLoopStartIndex());
			foreach (Spawn spawn in endLoop)
			{
				delay += spawn.Delay;
				while (enemyTimer < delay)
				{
					endGameSecond += 1f / 60f;
					enemyTimer += 1f / 60f + 1f / 60f / 8f * waveIndex;
				}

				yield return endGameSecond;
			}
		}

		public List<AbstractEvent> GenerateSpawnsetEventList(int gushes, int beckons, int maxWaves)
		{
			List<AbstractEvent> events = new List<AbstractEvent>();

			double seconds = 0;
			int totalGems = 0;
			List<Spawn> endLoop = new List<Spawn>();

			foreach (Spawn spawn in Spawns.Values)
			{
				seconds += spawn.Delay;
				if (spawn.Enemy != null)
					events.Add(new SpawnEvent(seconds, $"{spawn.Enemy.Name} spawns", spawn.Enemy));

				endLoop.Add(spawn);
				if (spawn.Enemy == null)
				{
					foreach (Spawn s in endLoop)
					{
						if (s.Enemy != null)
							totalGems += s.Enemy.NoFarmGems;
					}

					endLoop.Clear();
					endLoop.Add(spawn);
				}
			}

			if (endLoop.Count != 1 || endLoop.Count == 1 && endLoop[0].Enemy != null)
			{
				double endGameSecond = seconds;
				for (int i = 1; i < maxWaves; i++)
				{
					double waveMod = GetWaveMod(i);
					double enemyTimer = 0;
					double delay = 0;
					foreach (Spawn spawn in endLoop)
					{
						delay += spawn.Delay;
						while (enemyTimer < delay)
						{
							endGameSecond += 1f / 60f;
							enemyTimer += 1f / 60f + waveMod;
						}

						if (spawn.Enemy != null)
						{
							Enemy finalEnemy = spawn.Enemy;
							if (i % 3 == 2 && finalEnemy == GameInfo.V3Gigapede)
								finalEnemy = GameInfo.V3Ghostpede;

							totalGems += finalEnemy.NoFarmGems;

							events.Add(new SpawnEvent(endGameSecond, $"{finalEnemy.Name} spawns", finalEnemy));
						}
					}
				}

				static double GetWaveMod(int waveIndex)
					=> 1f / 60f / 8f * waveIndex;
			}

			List<SpawnEvent> spawnEvents = events.OfType<SpawnEvent>().ToList();
			List<SpawnEvent> squids = spawnEvents.Where(s => s.Enemy.Name.Contains("Squid", StringComparison.InvariantCulture)).ToList();
			List<SpawnEvent> leviathans = spawnEvents.Where(s => s.Enemy.Name == "Leviathan").ToList();
			List<SpawnEvent> spider1s = spawnEvents.Where(s => s.Enemy.Name == "Spider I").ToList();
			List<SpawnEvent> spider2s = spawnEvents.Where(s => s.Enemy.Name == "Spider II").ToList();
			List<SpawnEvent> emergers = spawnEvents.Where(s => s.Enemy.Name == "Thorn" || s.Enemy.Name.Contains("pede", StringComparison.InvariantCulture)).ToList();

			foreach (SpawnEvent squid in squids)
			{
				Dictionary<Enemy, int> skulls = new Dictionary<Enemy, int>();
				if (squid.Enemy.Name == "Squid I")
				{
					skulls.Add(GameInfo.V3Skull1, 10);
					skulls.Add(GameInfo.V3Skull2, 1);
				}
				else if (squid.Enemy.Name == "Squid II")
				{
					skulls.Add(GameInfo.V3Skull1, 10);
					skulls.Add(GameInfo.V3Skull3, 1);
				}
				else if (squid.Enemy.Name == "Squid III")
				{
					skulls.Add(GameInfo.V3Skull1, 15);
					skulls.Add(GameInfo.V3Skull4, 1);
				}

				StringBuilder gushText = new StringBuilder();
				foreach (KeyValuePair<Enemy, int> kvp in skulls)
					gushText.Append($"{kvp.Value} {kvp.Key.Name}{(kvp.Value == 1 ? string.Empty : "s")} and ");

				for (int i = 0; i < gushes; i++)
					events.Add(new GushEvent(squid.Seconds + 3 + i * 20, $"{squid.Enemy.Name} gushes {gushText.ToString().Substring(0, gushText.Length - " and ".Length)}", squid, skulls));
			}

			foreach (SpawnEvent leviathan in leviathans)
			{
				for (int i = 0; i < beckons; i++)
					events.Add(new SubEvent(leviathan.Seconds + 13.5333f + i * 20, $"{leviathan.Enemy.Name} beckons", leviathan));
			}

			foreach (SpawnEvent spider1 in spider1s)
				events.Add(new SubEvent(spider1.Seconds + 3, $"{spider1.Enemy.Name} lifts head", spider1));
			foreach (SpawnEvent spider2 in spider2s)
				events.Add(new SubEvent(spider2.Seconds + 9, $"{spider2.Enemy.Name} lifts head", spider2));

			foreach (SpawnEvent emerger in emergers)
				events.Add(new SubEvent(emerger.Seconds + 3, $"{emerger.Enemy.Name} emerges", emerger));

			return events.OrderBy(e => e.Seconds).ToList();
		}

		public bool TryGetBytes(out byte[] bytes)
		{
			try
			{
				// Create the buffers.
				byte[] settingsBuffer = new byte[HeaderBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnsBuffer = new byte[SpawnsHeaderBufferSize + Spawns.Count * SpawnBufferSize];

				// Get the settings bytes and copy them into the header buffer.
				settingsBuffer[0] = 0x04;
				settingsBuffer[4] = 0x09;
				settingsBuffer[28] = 0x33;
				settingsBuffer[32] = 0x01;

				byte[] shrinkEndBytes = BitConverter.GetBytes(ShrinkEnd);
				for (int i = 0; i < shrinkEndBytes.Length; i++)
					settingsBuffer[8 + i] = shrinkEndBytes[i];

				byte[] shrinkStartBytes = BitConverter.GetBytes(ShrinkStart);
				for (int i = 0; i < shrinkStartBytes.Length; i++)
					settingsBuffer[12 + i] = shrinkStartBytes[i];

				byte[] shrinkRateBytes = BitConverter.GetBytes(ShrinkRate);
				for (int i = 0; i < shrinkRateBytes.Length; i++)
					settingsBuffer[16 + i] = shrinkRateBytes[i];

				byte[] brightnessBytes = BitConverter.GetBytes(Brightness);
				for (int i = 0; i < brightnessBytes.Length; i++)
					settingsBuffer[20 + i] = brightnessBytes[i];

				// Get the arena bytes and copy them into the arena buffer.
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / 4 % ArenaHeight;
					int y = i / (ArenaWidth * 4);

					byte[] tileBytes = BitConverter.GetBytes(ArenaTiles[x, y]);

					for (int j = 0; j < tileBytes.Length; j++)
						arenaBuffer[i + j] = tileBytes[j];
				}

				// Get the spawn bytes and copy them into the spawn buffer.
				spawnsBuffer[12] = 0x01;
				spawnsBuffer[16] = 0xF4;
				spawnsBuffer[17] = 0x01;
				spawnsBuffer[20] = 0xFA;
				spawnsBuffer[24] = 0x78;
				spawnsBuffer[28] = 0x3C;

				byte[] spawnCountBytes = BitConverter.GetBytes(Spawns.Count);
				for (int i = 0; i < spawnCountBytes.Length; i++)
					spawnsBuffer[36 + i] = spawnCountBytes[i];

				foreach (KeyValuePair<int, Spawn> kvp in Spawns)
				{
					byte[] enemyBytes = BitConverter.GetBytes(kvp.Value.Enemy?.SpawnsetType ?? -1);
					for (int i = 0; i < enemyBytes.Length; i++)
						spawnsBuffer[SpawnsHeaderBufferSize + kvp.Key * SpawnBufferSize + i] = enemyBytes[i];

					byte[] delayBytes = BitConverter.GetBytes((float)kvp.Value.Delay);
					for (int i = 0; i < delayBytes.Length; i++)
						spawnsBuffer[SpawnsHeaderBufferSize + kvp.Key * SpawnBufferSize + 4 + i] = delayBytes[i];
				}

				// Create the file buffer.
				byte[] fileBuffer = new byte[settingsBuffer.Length + arenaBuffer.Length + spawnsBuffer.Length];

				Buffer.BlockCopy(settingsBuffer, 0, fileBuffer, 0, settingsBuffer.Length);
				Buffer.BlockCopy(arenaBuffer, 0, fileBuffer, settingsBuffer.Length, arenaBuffer.Length);
				Buffer.BlockCopy(spawnsBuffer, 0, fileBuffer, settingsBuffer.Length + arenaBuffer.Length, spawnsBuffer.Length);

				bytes = fileBuffer;
				return true;
			}
			catch (Exception ex)
			{
				LogUtils.Log.Error($"Could not convert {nameof(Spawnset)} to binary.", ex);

				bytes = Array.Empty<byte>();

				return false;
			}
		}

		/// <summary>
		/// Creates a unique and constant string for this spawnset instance. Each value has a constant order and is separated using the ';' character.
		/// WARNING: Modifying this method in such a way that it returns different values will require a re-compile or re-publish of every application that uses it and render any older versions as obsolete.
		/// </summary>
		private string GetUniqueString()
		{
			CultureInfo culture = CultureInfo.InvariantCulture;
			string floatFormat = "0.0000"; // Keep this variable local to preserve integrity of the method.
			char separator = ';';

			StringBuilder sb = new StringBuilder();
			foreach (Spawn spawn in Spawns.Values)
				sb.Append($"{spawn.Enemy?.SpawnsetType ?? -1}{separator}{spawn.Delay.ToString(floatFormat, culture)}{separator}");

			for (int i = 0; i < ArenaWidth; i++)
			{
				for (int j = 0; j < ArenaHeight; j++)
					sb.Append($"{ArenaTiles[i, j].ToString(floatFormat, culture)}{separator}");
			}

			sb.Append($"{ShrinkStart.ToString(floatFormat, culture)}{separator}");
			sb.Append($"{ShrinkEnd.ToString(floatFormat, culture)}{separator}");
			sb.Append($"{ShrinkRate.ToString(floatFormat, culture)}{separator}");
			sb.Append($"{Brightness.ToString(floatFormat, culture)}{separator}");

			return sb.ToString();
		}

		private byte[] GetHash()
		{
			using HashAlgorithm algorithm = SHA256.Create();
			return algorithm.ComputeHash(Encoding.UTF8.GetBytes(GetUniqueString()));
		}

		public string GetHashString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash())
				sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
			return sb.ToString();
		}
	}
}