﻿using DevilDaggersCore.Game;
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
		public const int SpawnBufferSize = 28; // The amount of bytes per spawn

		public const int ArenaWidth = 51;
		public const int ArenaHeight = 51;

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

		public Spawnset(int spawnVersion, int worldVersion, SortedDictionary<int, Spawn> spawns, float[,] arenaTiles, float shrinkStart, float shrinkEnd, float shrinkRate, float brightness, GameMode gameMode, byte hand, int additionalGems, float timerStart)
		{
			SpawnVersion = spawnVersion;
			WorldVersion = worldVersion;
			Spawns = spawns;
			ArenaTiles = arenaTiles;
			ShrinkStart = shrinkStart;
			ShrinkEnd = shrinkEnd;
			ShrinkRate = shrinkRate;
			Brightness = brightness;
			GameMode = gameMode;
			Hand = hand;
			AdditionalGems = additionalGems;
			TimerStart = timerStart;
		}

		public SortedDictionary<int, Spawn> Spawns { get; set; } = new();
		public float[,] ArenaTiles { get; set; } = new float[ArenaWidth, ArenaHeight];

		public int SpawnVersion { get; set; } = 6;
		public int WorldVersion { get; set; } = 9;

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

		public GameMode GameMode { get; set; }

		public byte Hand
		{
			get => _hand;
			set => _hand = Math.Clamp(value, (byte)1, (byte)4);
		}

		public int AdditionalGems
		{
			get => _additionalGems;

			// Gem collection will be "disabled" in-game when this field is set to int.MinValue.
			set => _additionalGems = value == int.MinValue ? int.MinValue : Math.Clamp(value, 0, 1000000);
		}

		public float TimerStart
		{
			get => _timerStart;
			set => _timerStart = Math.Clamp(value, 0, 1000000);
		}

		#region Utilities

		public static int GetSpawnsHeaderBufferSize(int worldVersion) => worldVersion switch
		{
			8 => 36,
			_ => 40,
		};

		public static int GetSettingsBufferSize(int spawnVersion) => spawnVersion switch
		{
			5 => 5,
			6 => 9,
			_ => 0,
		};

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

		public static bool IsEmptySpawn(int enemyType)
			=> enemyType < 0 || enemyType > 9;

		public int GetInitialGems() => Math.Clamp(AdditionalGems, 0, 1000000) + Hand switch
		{
			2 => 10,
			3 => 70,
			4 => 220,
			_ => 0,
		};

		public string GetGameVersionString()
			=> GetGameVersionString(WorldVersion, SpawnVersion);

		public static string GetGameVersionString(int worldVersion, int spawnVersion)
			=> worldVersion == 8 ? "V0 / V1" : spawnVersion == 4 ? "V2 / V3" : "V3.1";

		public (double LoopLength, double EndLoopSpawns) GetEndLoopData()
		{
			double loopLength = 0;
			int endLoopSpawns = 0;
			for (int i = Spawns.Count - 1; i >= 0; i--)
			{
				loopLength += Spawns[i].Delay;
				if (Spawns[i].Enemy == null || i == 0)
					break;

				endLoopSpawns++;
			}

			if (!Spawns.Any(s => s.Value.Enemy == null) && Spawns.Count > 0)
				endLoopSpawns++;

			return (loopLength, endLoopSpawns);
		}

		#endregion Utilities

		#region Parsing

		/// <summary>
		/// Tries to parse the contents of a spawnset file into a <see cref="Spawnset"/> instance.
		/// </summary>
		/// <param name="spawnsetFileBytes">The spawnset file contents.</param>
		/// <param name="spawnset">The parsed <see cref="Spawnset"/>.</param>
		public static bool TryParse(byte[] spawnsetFileBytes, out Spawnset spawnset)
		{
			try
			{
				// Read header.
				byte[] headerBuffer = new byte[HeaderBufferSize];
				Buffer.BlockCopy(spawnsetFileBytes, 0, headerBuffer, 0, HeaderBufferSize);
				int spawnVersion = BitConverter.ToInt32(headerBuffer, 0);
				int worldVersion = BitConverter.ToInt32(headerBuffer, 4);
				float shrinkEnd = BitConverter.ToSingle(headerBuffer, 8);
				float shrinkStart = BitConverter.ToSingle(headerBuffer, 12);
				float shrinkRate = BitConverter.ToSingle(headerBuffer, 16);
				float brightness = BitConverter.ToSingle(headerBuffer, 20);
				GameMode gameMode = (GameMode)BitConverter.ToInt32(headerBuffer, 24);

				// Read arena.
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize, arenaBuffer, 0, ArenaBufferSize);

				float[,] arenaTiles = new float[ArenaWidth, ArenaHeight];
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / 4 % ArenaHeight;
					int y = i / (ArenaWidth * 4);
					arenaTiles[x, y] = BitConverter.ToSingle(arenaBuffer, i);
				}

				// Read spawns header.
				int spawnsHeaderBufferSize = GetSpawnsHeaderBufferSize(worldVersion);
				byte[] spawnsHeaderBuffer = new byte[spawnsHeaderBufferSize];
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize, spawnsHeaderBuffer, 0, spawnsHeaderBufferSize);
				int spawnCount = BitConverter.ToInt32(spawnsHeaderBuffer, spawnsHeaderBufferSize - sizeof(int));

				// Read spawns.
				int spawnsBufferSize = SpawnBufferSize * spawnCount;
				byte[] spawnBuffer = new byte[spawnsBufferSize];
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize + spawnsHeaderBufferSize, spawnBuffer, 0, spawnsBufferSize);

				SortedDictionary<int, Spawn> spawns = new();
				int spawnIndex = 0;

				for (int i = 0; i < spawnCount; i++)
				{
					int enemyType = BitConverter.ToInt32(spawnBuffer, i * SpawnBufferSize);
					float delay = BitConverter.ToSingle(spawnBuffer, i * SpawnBufferSize + 4);
					spawns.Add(spawnIndex++, new(GameInfo.GetEnemies(GameVersion.V31).Find(e => e.SpawnsetType == enemyType), delay));
				}

				// Read settings.
				int settingsBufferSize = GetSettingsBufferSize(spawnVersion);
				byte[] practiceBuffer = new byte[settingsBufferSize];
				byte hand = 1;
				int additionalGems = 0;
				float timerStart = 0;
				if (spawnVersion >= 5)
				{
					Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize + spawnsHeaderBufferSize + spawnsBufferSize, practiceBuffer, 0, settingsBufferSize);
					hand = practiceBuffer[0];
					additionalGems = BitConverter.ToInt32(practiceBuffer, 1);

					if (spawnVersion >= 6)
						timerStart = BitConverter.ToSingle(practiceBuffer, 5);
				}

				spawnset = new(spawnVersion, worldVersion, spawns, arenaTiles, shrinkStart, shrinkEnd, shrinkRate, brightness, gameMode, hand, additionalGems, timerStart);

				return true;
			}
			catch (Exception ex)
			{
				LogUtils.Log.Error($"Could not parse {nameof(Spawnset)}.", ex);

				spawnset = new();

				return false;
			}
		}

		public static bool TryGetSpawnsetData(byte[] spawnsetFileBytes, out SpawnsetData spawnsetData)
		{
			try
			{
				int spawnVersion = BitConverter.ToInt32(spawnsetFileBytes, 0);
				int worldVersion = BitConverter.ToInt32(spawnsetFileBytes, 4);
				GameMode gameMode = (GameMode)BitConverter.ToInt32(spawnsetFileBytes, 24);
				int spawnsHeaderBufferSize = GetSpawnsHeaderBufferSize(worldVersion);
				byte[] spawnsHeaderBuffer = new byte[spawnsHeaderBufferSize];
				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize, spawnsHeaderBuffer, 0, spawnsHeaderBufferSize);
				int spawnCount = BitConverter.ToInt32(spawnsHeaderBuffer, spawnsHeaderBufferSize - sizeof(int));
				int spawnsBufferSize = SpawnBufferSize * spawnCount;
				byte[] spawnBuffer = new byte[spawnsBufferSize];

				Buffer.BlockCopy(spawnsetFileBytes, HeaderBufferSize + ArenaBufferSize + spawnsHeaderBufferSize, spawnBuffer, 0, spawnsBufferSize);

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

				byte? hand = null;
				int? additionalGems = null;
				float? timerStart = null;
				int settingsBufferSize = GetSettingsBufferSize(spawnVersion);
				int settingsBufferStart = spawnsetFileBytes.Length - settingsBufferSize;
				if (spawnVersion > 4)
				{
					hand = spawnsetFileBytes[settingsBufferStart];
					additionalGems = BitConverter.ToInt32(spawnsetFileBytes, settingsBufferStart + sizeof(byte));
					if (spawnVersion > 5)
						timerStart = BitConverter.ToSingle(spawnsetFileBytes, settingsBufferStart + sizeof(byte) + sizeof(int));
				}

				spawnsetData = new(spawnVersion, worldVersion, gameMode, nonLoopSpawns, loopSpawns, nonLoopSpawns == 0 ? null : nonLoopSeconds, loopSpawns == 0 ? null : loopSeconds, hand, additionalGems, timerStart);

				return true;
			}
			catch (Exception ex)
			{
				LogUtils.Log.Error($"Could not parse {nameof(SpawnsetData)}.", ex);

				spawnsetData = new(default, default, default, default, default, default, default, default, default, default);

				return false;
			}
		}

		#endregion Parsing

		#region Converting

		public bool TryGetBytes(out byte[] bytes)
		{
			try
			{
				// Create header.
				byte[] headerBuffer = new byte[HeaderBufferSize];
				Buffer.BlockCopy(BitConverter.GetBytes(SpawnVersion), 0, headerBuffer, 0, sizeof(int));
				Buffer.BlockCopy(BitConverter.GetBytes(WorldVersion), 0, headerBuffer, 4, sizeof(int));
				Buffer.BlockCopy(BitConverter.GetBytes(ShrinkEnd), 0, headerBuffer, 8, sizeof(float));
				Buffer.BlockCopy(BitConverter.GetBytes(ShrinkStart), 0, headerBuffer, 12, sizeof(float));
				Buffer.BlockCopy(BitConverter.GetBytes(ShrinkRate), 0, headerBuffer, 16, sizeof(float));
				Buffer.BlockCopy(BitConverter.GetBytes(Brightness), 0, headerBuffer, 20, sizeof(float));
				Buffer.BlockCopy(BitConverter.GetBytes((int)GameMode), 0, headerBuffer, 24, sizeof(int));
				headerBuffer[28] = 0x33;
				headerBuffer[32] = 0x01;

				// Create arena.
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / 4 % ArenaHeight;
					int y = i / (ArenaWidth * 4);

					byte[] tileBytes = BitConverter.GetBytes(ArenaTiles[x, y]);

					for (int j = 0; j < tileBytes.Length; j++)
						arenaBuffer[i + j] = tileBytes[j];
				}

				// Create spawns header.
				int spawnsHeaderBufferSize = GetSpawnsHeaderBufferSize(WorldVersion);
				byte[] spawnsHeaderBuffer = new byte[spawnsHeaderBufferSize];
				spawnsHeaderBuffer[12] = 0x01;
				spawnsHeaderBuffer[16] = WorldVersion == 8 ? (byte)0x90 : (byte)0xF4;
				spawnsHeaderBuffer[17] = 0x01;
				spawnsHeaderBuffer[20] = 0xFA;
				spawnsHeaderBuffer[24] = 0x78;
				spawnsHeaderBuffer[28] = 0x3C;
				Buffer.BlockCopy(BitConverter.GetBytes(Spawns.Count), 0, spawnsHeaderBuffer, spawnsHeaderBufferSize - sizeof(int), sizeof(int));

				// Create spawns.
				byte[] spawnsBuffer = new byte[Spawns.Count * SpawnBufferSize];
				foreach (KeyValuePair<int, Spawn> kvp in Spawns)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(kvp.Value.Enemy?.SpawnsetType ?? -1), 0, spawnsBuffer, kvp.Key * SpawnBufferSize, sizeof(int));
					Buffer.BlockCopy(BitConverter.GetBytes((float)kvp.Value.Delay), 0, spawnsBuffer, kvp.Key * SpawnBufferSize + 4, sizeof(float));

					spawnsBuffer[kvp.Key * SpawnBufferSize + 12] = 0x03;
					spawnsBuffer[kvp.Key * SpawnBufferSize + 22] = 0xF0;
					spawnsBuffer[kvp.Key * SpawnBufferSize + 23] = 0x41;
					spawnsBuffer[kvp.Key * SpawnBufferSize + 24] = 0x0A;
				}

				// Create settings.
				int settingsBufferSize = GetSettingsBufferSize(SpawnVersion);
				byte[] settingsBuffer = new byte[settingsBufferSize];

				if (SpawnVersion >= 5)
				{
					Buffer.BlockCopy(new[] { Hand }, 0, settingsBuffer, 0, sizeof(byte));
					Buffer.BlockCopy(BitConverter.GetBytes(AdditionalGems), 0, settingsBuffer, 1, sizeof(int));
					if (SpawnVersion >= 6)
						Buffer.BlockCopy(BitConverter.GetBytes(TimerStart), 0, settingsBuffer, 5, sizeof(float));
				}

				// Create the file buffer.
				byte[] fileBuffer = new byte[headerBuffer.Length + arenaBuffer.Length + spawnsHeaderBuffer.Length + spawnsBuffer.Length + settingsBuffer.Length];
				Buffer.BlockCopy(headerBuffer, 0, fileBuffer, 0, headerBuffer.Length);
				Buffer.BlockCopy(arenaBuffer, 0, fileBuffer, headerBuffer.Length, arenaBuffer.Length);
				Buffer.BlockCopy(spawnsHeaderBuffer, 0, fileBuffer, headerBuffer.Length + arenaBuffer.Length, spawnsHeaderBuffer.Length);
				Buffer.BlockCopy(spawnsBuffer, 0, fileBuffer, headerBuffer.Length + arenaBuffer.Length + spawnsHeaderBuffer.Length, spawnsBuffer.Length);
				Buffer.BlockCopy(settingsBuffer, 0, fileBuffer, headerBuffer.Length + arenaBuffer.Length + spawnsHeaderBuffer.Length + spawnsBuffer.Length, settingsBuffer.Length);

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

		#endregion Converting
	}
}
