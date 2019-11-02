﻿using DevilDaggersCore.Game;
using DevilDaggersCore.Spawnsets.Events;
using NetBase.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevilDaggersCore.Spawnsets
{
	public class Spawnset
	{
		public const int SettingsBufferSize = 36;
		public const int ArenaBufferSize = 10404; // ArenaWidth * ArenaHeight * TileBufferSize (51 * 51 * 4 = 10404)
		public const int SpawnsHeaderBufferSize = 40; // The amount of bytes in the spawns buffer header (no idea what they are used for)
		public const int SpawnBufferSize = 28; // The amount of bytes per spawn

		public const int ArenaWidth = 51;
		public const int ArenaHeight = 51;

		public static Dictionary<int, SpawnsetEnemy> Enemies { get; set; } = new Dictionary<int, SpawnsetEnemy>
		{
			{ -1, new SpawnsetEnemy("EMPTY", 0) },
			{ 0, new SpawnsetEnemy("Squid I", 2) },
			{ 1, new SpawnsetEnemy("Squid II", 3) },
			{ 2, new SpawnsetEnemy("Centipede", 25) },
			{ 3, new SpawnsetEnemy("Spider I", 1) },
			{ 4, new SpawnsetEnemy("Leviathan", 6) },
			{ 5, new SpawnsetEnemy("Gigapede", 50) },
			{ 6, new SpawnsetEnemy("Squid III", 3) },
			{ 7, new SpawnsetEnemy("Thorn", 0) },
			{ 8, new SpawnsetEnemy("Spider II", 1) },
			{ 9, new SpawnsetEnemy("Ghostpede", 10) }
		};

		public SortedDictionary<int, Spawn> Spawns { get; set; } = new SortedDictionary<int, Spawn>();
		public float[,] ArenaTiles { get; set; } = new float[ArenaWidth, ArenaHeight];

		private float shrinkStart = 50;
		public float ShrinkStart
		{
			get => shrinkStart;
			set
			{
				shrinkStart = MathUtils.Clamp(value, 1, 100);
			}
		}

		private float shrinkEnd = 20;
		public float ShrinkEnd
		{
			get => shrinkEnd;
			set
			{
				shrinkEnd = MathUtils.Clamp(value, 1, 100);
			}
		}

		private float shrinkRate = 0.025f;
		public float ShrinkRate
		{
			get => shrinkRate;
			set
			{
				shrinkRate = Math.Max(value, 0);
			}
		}

		private float brightness = 60;
		public float Brightness
		{
			get => brightness;
			set
			{
				brightness = Math.Max(value, 0);
			}
		}

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

		public static bool IsEmptySpawn(int enemyType)
		{
			return enemyType < 0 || enemyType > 9;
		}

		public static SpawnsetEnemy GetEnemyByName(string name)
		{
			return Enemies.Values.Where(e => e.Name == name).FirstOrDefault();
		}

		public static int GetEnemyID(SpawnsetEnemy enemy)
		{
			return Enemies.Where(e => e.Value == enemy).FirstOrDefault().Key;
		}

		/// <summary>
		/// Tries to parse the contents of a spawnset file into a <see cref="Spawnset"/> instance.
		/// This only works for V3 spawnsets.
		/// </summary>
		/// <param name="filePath">The path to the spawnset file.</param>
		/// <returns>The <see cref="Spawnset"/>.</returns>
		public static bool TryParse(Stream stream, out Spawnset spawnset)
		{
			try
			{
				// Set the file values for reading V3 spawnsets.
				int spawnBufferSize = (int)stream.Length - (SettingsBufferSize + ArenaBufferSize);
				byte[] headerBuffer = new byte[SettingsBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnBuffer = new byte[spawnBufferSize];

				// Read the file and write the data into the buffers, then close the file since we do not need it anymore.
				stream.Read(headerBuffer, 0, SettingsBufferSize);
				stream.Read(arenaBuffer, 0, ArenaBufferSize);
				stream.Read(spawnBuffer, 0, spawnBufferSize);

				stream.Close();

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

					spawns.Add(spawnIndex++, new Spawn(Enemies[IsEmptySpawn(enemyType) ? -1 : enemyType], delay));
				}

				// Set the spawnset.
				spawnset = new Spawnset(spawns, arenaTiles, shrinkStart, shrinkEnd, shrinkRate, brightness);

				return true;
			}
			catch (Exception ex)
			{
				Logging.Log.Error($"Could not parse {nameof(Spawnset)}.", ex);

				// Set an empty spawnset.
				spawnset = new Spawnset();

				return false;
			}
		}

		public static bool TryGetSpawnData(Stream stream, out SpawnsetData spawnsetData)
		{
			try
			{
				int spawnBufferSize = (int)stream.Length - (SettingsBufferSize + ArenaBufferSize + SpawnsHeaderBufferSize);
				byte[] spawnBuffer = new byte[spawnBufferSize];

				stream.Position += SettingsBufferSize + ArenaBufferSize + SpawnsHeaderBufferSize;
				stream.Read(spawnBuffer, 0, spawnBufferSize);
				stream.Close();

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
					NonLoopSpawns = nonLoopSpawns,
					LoopSpawns = loopSpawns,
					NonLoopLengthNullable = nonLoopSpawns == 0 ? null : (float?)nonLoopSeconds,
					LoopLengthNullable = loopSpawns == 0 ? null : (float?)loopSeconds
				};

				return true;
			}
			catch (Exception ex)
			{
				Logging.Log.Error($"Could not parse {nameof(SpawnsetData)}.", ex);

				spawnsetData = new SpawnsetData();

				return false;
			}
		}

		public bool IsEmpty()
		{
			if (Spawns.Count == 0)
				return true;

			foreach (Spawn spawn in Spawns.Values)
				if (spawn.SpawnsetEnemy != Enemies[-1])
					return false;

			return true;
		}

		public int GetEndLoopStartIndex()
		{
			for (int i = Spawns.Count - 1; i >= 0; i--)
				if (Spawns[i].SpawnsetEnemy == Enemies[-1])
					return i;

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
					enemyTimer += (1f / 60f) + (1f / 60f / 8f * waveIndex);
				}
				yield return endGameSecond;
			}
		}

		// TODO
		public List<AbstractEvent> GenerateSpawnsetEventList(int gushes, int beckons, int maxWaves, GameVersion gameVersion)
		{
			List<AbstractEvent> events = new List<AbstractEvent>();

			double seconds = 0;
			int totalGems = 0;
			List<Spawn> endLoop = new List<Spawn>();

			foreach (Spawn spawn in Spawns.Values)
			{
				seconds += spawn.Delay;
				if (spawn.SpawnsetEnemy != Enemies[-1])
					events.Add(new SpawnEvent(seconds, $"{spawn.SpawnsetEnemy.Name} spawns", spawn.SpawnsetEnemy));

				endLoop.Add(spawn);
				if (spawn.SpawnsetEnemy == Enemies[-1])
				{
					foreach (Spawn s in endLoop)
					{
						seconds += s.Delay;
						if (s.SpawnsetEnemy != Enemies[-1])
						{
							int gems = s.SpawnsetEnemy.NoFarmGems;
							totalGems += gems;
						}
					}
					seconds -= spawn.Delay;
					endLoop.Clear();
					endLoop.Add(spawn);
				}
			}

			if (endLoop.Count != 1 || (endLoop.Count == 1 && endLoop[0].SpawnsetEnemy != Enemies[-1]))
			{
				double waveMod = 0;
				double endGameSecond = seconds;
				for (int i = 0; i < maxWaves; i++)
				{
					double enemyTimer = 0;
					double delay = 0;
					foreach (Spawn spawn in endLoop)
					{
						delay += spawn.Delay;
						while (enemyTimer < delay)
						{
							endGameSecond += 1f / 60f;
							enemyTimer += (1f / 60f) + waveMod;
						}

						if (spawn.SpawnsetEnemy != Enemies[-1])
						{
							events.Add(new SpawnEvent(endGameSecond, $"{spawn.SpawnsetEnemy.Name} spawns", spawn.SpawnsetEnemy));
							SpawnsetEnemy finalEnemy = spawn.SpawnsetEnemy;

							if (i % 3 == 2 && gameVersion == GameInfo.GameVersions["V3"] && finalEnemy == Enemies[5])
								finalEnemy = Enemies[9];

							int gems = finalEnemy.NoFarmGems;
							totalGems += gems;
						}
					}
					waveMod += 1f / 60f / 8f;
				}
			}

			//double totalSeconds = 0;
			//foreach (Spawn spawn in Spawns.Values)
			//{
			//totalSeconds += spawn.Delay;
			//events.Add(new SpawnEvent(totalSeconds, $"{spawn.SpawnsetEnemy.Name} spawns", spawn.SpawnsetEnemy));
			//}

			List<SpawnEvent> spawnEvents = events.Where(s => s.GetType() == typeof(SpawnEvent)).Cast<SpawnEvent>().ToList();
			List<SpawnEvent> squids = spawnEvents.Where(s => s.Enemy == Enemies[0] || s.Enemy == Enemies[1] || s.Enemy == Enemies[6]).ToList();
			List<SpawnEvent> leviathans = spawnEvents.Where(s => s.Enemy == Enemies[4]).ToList();
			List<SpawnEvent> spider1s = spawnEvents.Where(s => s.Enemy == Enemies[3]).ToList();
			List<SpawnEvent> spider2s = spawnEvents.Where(s => s.Enemy == Enemies[8]).ToList();
			List<SpawnEvent> emergers = spawnEvents.Where(s => s.Enemy == Enemies[2] || s.Enemy == Enemies[5] || s.Enemy == Enemies[7] || s.Enemy == Enemies[9]).ToList();

			foreach (SpawnEvent squid in squids)
			{
				Dictionary<Enemy, int> skulls = new Dictionary<Enemy, int>();
				if (squid.Enemy == Enemies[0])
				{
					skulls.Add(GameInfo.V3.Skull1, 10);
					skulls.Add(GameInfo.V3.Skull2, 1);
				}
				else if (squid.Enemy == Enemies[1])
				{
					skulls.Add(GameInfo.V3.Skull1, 10);
					skulls.Add(GameInfo.V3.Skull3, 1);
				}
				else if (squid.Enemy == Enemies[6])
				{
					skulls.Add(GameInfo.V3.Skull1, 15);
					skulls.Add(GameInfo.V3.Skull4, 1);
				}
				StringBuilder gushText = new StringBuilder();
				foreach (KeyValuePair<Enemy, int> kvp in skulls)
					gushText.Append($"{kvp.Value} {kvp.Key.Name}{(kvp.Value == 1 ? "" : "s")} and ");

				for (int i = 0; i < gushes; i++)
				{
					events.Add(new GushEvent(squid.Seconds + 3 + i * 20, $"{squid.Enemy.Name} gushes {gushText.ToString().Substring(0, gushText.Length - " and ".Length)}", squid, skulls));
				}
			}

			foreach (SpawnEvent leviathan in leviathans)
				for (int i = 0; i < beckons; i++)
					events.Add(new SubEvent(leviathan.Seconds + 13.5333f + i * 20, $"{leviathan.Enemy.Name} beckons", leviathan));

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
				byte[] settingsBuffer = new byte[SettingsBufferSize];
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
					int enemyType = -1;
					for (int i = 0; i < Enemies.Count - 1; i++)
					{
						if (kvp.Value.SpawnsetEnemy == Enemies[i])
						{
							enemyType = i;
							break;
						}
					}
					byte[] enemyBytes = BitConverter.GetBytes(enemyType);
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
				Logging.Log.Error($"Could not convert {nameof(Spawnset)} to binary.", ex);

				bytes = new byte[0];

				return false;
			}
		}

		/// <summary>
		/// Creates a unique and constant string for this spawnset instance. Each value has a constant order and is separated using the ';' character.
		/// WARNING: Modifying this method in such a way that it returns different values will require a re-compile or re-publish of every application that uses it and render any older versions as obsolete.
		/// </summary>
		public string GetUniqueString()
		{
			CultureInfo culture = new CultureInfo("en-US");
			string floatFormat = "0.0000";
			char separator = ';';

			StringBuilder sb = new StringBuilder();
			foreach (Spawn spawn in Spawns.Values)
				sb.Append($"{GetEnemyID(spawn.SpawnsetEnemy)}{separator}{spawn.Delay.ToString(floatFormat, culture)}{separator}");

			for (int i = 0; i < ArenaWidth; i++)
				for (int j = 0; j < ArenaHeight; j++)
					sb.Append($"{ArenaTiles[i, j].ToString(floatFormat, culture)}{separator}");

			sb.Append($"{ShrinkStart.ToString(floatFormat, culture)}{separator}");
			sb.Append($"{ShrinkEnd.ToString(floatFormat, culture)}{separator}");
			sb.Append($"{ShrinkRate.ToString(floatFormat, culture)}{separator}");
			sb.Append($"{Brightness.ToString(floatFormat, culture)}{separator}");

			return sb.ToString();
		}

		private byte[] GetHash()
		{
			using (HashAlgorithm algorithm = SHA256.Create())
				return algorithm.ComputeHash(Encoding.UTF8.GetBytes(GetUniqueString()));
		}

		public string GetHashString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash())
				sb.Append(b.ToString("X2"));
			return sb.ToString();
		}
	}
}