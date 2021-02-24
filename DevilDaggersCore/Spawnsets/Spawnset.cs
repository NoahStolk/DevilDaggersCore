using DevilDaggersCore.Game;
using DevilDaggersCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Spawnsets
{
	public class Spawnset
	{
		public const int HeaderBufferSize = 36;
		public const int ArenaBufferSize = 10404; // ArenaWidth * ArenaHeight * TileBufferSize (51 * 51 * 4 = 10404)
		public const int SpawnsHeaderBufferSize = 40; // The amount of bytes in the spawns buffer header (no idea what they are used for)
		public const int SpawnBufferSize = 28; // The amount of bytes per spawn
		public const int PracticeBufferSize = 9; // Byte Hand, int AdditionalGems, float TimerStart

		public const int ArenaWidth = 51;
		public const int ArenaHeight = 51;

		private byte _version = 6;
		private float _shrinkStart = 50;
		private float _shrinkEnd = 20;
		private float _shrinkRate = 0.025f;
		private float _brightness = 60;
		private byte _hand = 1;
		private int _additionalGems;
		private float _timerStart;

		public Spawnset()
		{
		}

		public Spawnset(byte version, SortedDictionary<int, Spawn> spawns, float[,] arenaTiles, float shrinkStart, float shrinkEnd, float shrinkRate, float brightness, byte hand, int additionalGems, float timerStart)
		{
			Version = version;
			Spawns = spawns;
			ArenaTiles = arenaTiles;
			ShrinkStart = shrinkStart;
			ShrinkEnd = shrinkEnd;
			ShrinkRate = shrinkRate;
			Brightness = brightness;
			Hand = hand;
			AdditionalGems = additionalGems;
			TimerStart = timerStart;
		}

		public SortedDictionary<int, Spawn> Spawns { get; set; } = new();
		public float[,] ArenaTiles { get; set; } = new float[ArenaWidth, ArenaHeight];

		public byte Version
		{
			get => _version;
			set => _version = GetSupportedVersion(value);
		}

		public float ShrinkStart
		{
			get => _shrinkStart;
			set => _shrinkStart = Math.Clamp(value, 1, 100);
		}

		public float ShrinkEnd
		{
			get => _shrinkEnd;
			set => _shrinkEnd = Math.Clamp(value, 1, 100);
		}

		public float ShrinkRate
		{
			get => _shrinkRate;
			set => _shrinkRate = Math.Max(value, 0);
		}

		public float Brightness
		{
			get => _brightness;
			set => _brightness = Math.Max(value, 0);
		}

		public byte Hand
		{
			get => _hand;
			set => _hand = Math.Clamp(value, (byte)1, (byte)4);
		}

		public int AdditionalGems
		{
			get => _additionalGems;
			set => _additionalGems = Math.Clamp(value, 0, 1000000);
		}

		public float TimerStart
		{
			get => _timerStart;
			set => _timerStart = Math.Clamp(value, 0, 1000000);
		}

		/// <summary>
		/// Only support version 4 (original V3 spawnset) and version 6 (V3.1 updates). Version 5 is deprecated.
		/// </summary>
		public static byte GetSupportedVersion(byte version)
			=> version == 0x05 || version == 0x06 ? 0x06 : 0x04;

		public static bool IsEmptySpawn(int enemyType)
			=> enemyType < 0 || enemyType > 9;

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
				int spawnsBufferSize = spawnsetFileBytes.Length - (HeaderBufferSize + ArenaBufferSize + PracticeBufferSize);
				byte[] headerBuffer = new byte[HeaderBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnBuffer = new byte[spawnsBufferSize];
				byte[] practiceBuffer = new byte[PracticeBufferSize];

				// Read the file and write the data into the buffers, then close the file since we do not need it anymore.
				Buffer.BlockCopy(spawnsetFileBytes, 0, headerBuffer, 0, HeaderBufferSize);
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize, arenaBuffer, 0, ArenaBufferSize);
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize, spawnBuffer, 0, spawnsBufferSize);

				// Set the header values.
				byte version = GetSupportedVersion(headerBuffer[0]);
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
				SortedDictionary<int, Spawn> spawns = new();
				int spawnIndex = 0;

				int bytePosition = SpawnsHeaderBufferSize;
				while (bytePosition < spawnsBufferSize)
				{
					int enemyType = BitConverter.ToInt32(spawnBuffer, bytePosition);
					bytePosition += 4;
					float delay = BitConverter.ToSingle(spawnBuffer, bytePosition);
					bytePosition += 24;

					spawns.Add(spawnIndex++, new(GameInfo.GetEntities<Enemy>(GameVersion.V31).Find(e => e.SpawnsetType == enemyType), delay));
				}

				// Set the practice values.
				byte hand = 1;
				int additionalGems = 0;
				float timerStart = 0;
				if (version == 0x06)
				{
					Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize + spawnsBufferSize, practiceBuffer, 0, PracticeBufferSize);
					hand = practiceBuffer[0];
					additionalGems = BitConverter.ToInt32(practiceBuffer, 1);
					timerStart = BitConverter.ToSingle(practiceBuffer, 5);
				}

				spawnset = new(version, spawns, arenaTiles, shrinkStart, shrinkEnd, shrinkRate, brightness, hand, additionalGems, timerStart);

				return true;
			}
			catch (Exception ex)
			{
				LogUtils.Log.Error($"Could not parse {nameof(Spawnset)}.", ex);

				spawnset = new();

				return false;
			}
		}

		public static bool TryGetSpawnData(byte[] spawnsetFileBytes, out SpawnsetData spawnsetData)
		{
			try
			{
				byte version = GetSupportedVersion(spawnsetFileBytes[0]);

				int spawnBufferSize = spawnsetFileBytes.Length - (HeaderBufferSize + ArenaBufferSize + SpawnsHeaderBufferSize + (version == 0x06 ? PracticeBufferSize : 0));
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

				spawnsetData = new()
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

				spawnsetData = new();

				return false;
			}
		}

		public bool HasSpawns()
			=> Spawns.Values.Any(s => s.Enemy != null);

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

			foreach (Spawn spawn in Spawns.Values.Skip(GetEndLoopStartIndex()))
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

		public bool TryGetBytes(out byte[] bytes)
		{
			try
			{
				// Create the buffers.
				byte[] settingsBuffer = new byte[HeaderBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnsBuffer = new byte[SpawnsHeaderBufferSize + Spawns.Count * SpawnBufferSize];
				byte[] practiceBuffer = new byte[PracticeBufferSize];

				// Get the settings bytes and copy them into the header buffer.
				settingsBuffer[0] = Version;
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

				practiceBuffer[0] = Hand;
				byte[] additionalGemsBytes = BitConverter.GetBytes(AdditionalGems);
				for (int i = 0; i < additionalGemsBytes.Length; i++)
					practiceBuffer[1 + i] = additionalGemsBytes[i];

				// Create the file buffer.
				byte[] fileBuffer;
				if (Version == 0x04)
				{
					fileBuffer = new byte[settingsBuffer.Length + arenaBuffer.Length + spawnsBuffer.Length];

					Buffer.BlockCopy(settingsBuffer, 0, fileBuffer, 0, settingsBuffer.Length);
					Buffer.BlockCopy(arenaBuffer, 0, fileBuffer, settingsBuffer.Length, arenaBuffer.Length);
					Buffer.BlockCopy(spawnsBuffer, 0, fileBuffer, settingsBuffer.Length + arenaBuffer.Length, spawnsBuffer.Length);
				}
				else if (Version == 0x06)
				{
					fileBuffer = new byte[settingsBuffer.Length + arenaBuffer.Length + spawnsBuffer.Length + practiceBuffer.Length];

					Buffer.BlockCopy(settingsBuffer, 0, fileBuffer, 0, settingsBuffer.Length);
					Buffer.BlockCopy(arenaBuffer, 0, fileBuffer, settingsBuffer.Length, arenaBuffer.Length);
					Buffer.BlockCopy(spawnsBuffer, 0, fileBuffer, settingsBuffer.Length + arenaBuffer.Length, spawnsBuffer.Length);
					Buffer.BlockCopy(practiceBuffer, 0, fileBuffer, settingsBuffer.Length + arenaBuffer.Length + spawnsBuffer.Length, practiceBuffer.Length);
				}
				else
				{
					throw new($"The format version '{Version}' is unsupported. Please use either version 4 or 6.");
				}

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
	}
}
