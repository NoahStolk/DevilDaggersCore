using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevilDaggersCore.Spawnset
{
	public class Spawnset
	{
		public const int HeaderBufferSize = 36;
		public const int ArenaBufferSize = 10404;
		public const int SpawnsOffsetBufferSize = 40; // The amount of bytes between the arena and the spawns, no idea what they are used for.
		public const int SpawnLength = 28; // The amount of bytes per spawn.

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

		public static SpawnsetEnemy GetEnemyByName(string name)
		{
			return Enemies.Values.Where(e => e.Name == name).FirstOrDefault();
		}

		public SortedDictionary<int, Spawn> Spawns { get; set; } = new SortedDictionary<int, Spawn>();
		public float[,] ArenaTiles { get; set; } = new float[ArenaWidth, ArenaHeight];
		public float ShrinkStart { get; set; } = 50;
		public float ShrinkEnd { get; set; } = 20;
		public float ShrinkRate { get; set; } = 0.025f;
		public float Brightness { get; set; } = 60;

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

		public bool TryGetBytes(out byte[] bytes)
		{
			try
			{
				// Set the file values for reading V3 spawnsets
				byte[] headerBuffer = new byte[HeaderBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnBuffer = new byte[SpawnsOffsetBufferSize + Spawns.Count * SpawnLength];

				// Get the settings bytes and copy them into the header buffer
				byte[] shrinkEndBytes = BitConverter.GetBytes(ShrinkEnd);
				byte[] shrinkStartBytes = BitConverter.GetBytes(ShrinkStart);
				byte[] shrinkRateBytes = BitConverter.GetBytes(ShrinkRate);
				byte[] brightnessBytes = BitConverter.GetBytes(Brightness);

				for (int i = 0; i < shrinkEndBytes.Length; i++)
					headerBuffer[8 + i] = shrinkEndBytes[i];
				for (int i = 0; i < shrinkStartBytes.Length; i++)
					headerBuffer[12 + i] = shrinkStartBytes[i];
				for (int i = 0; i < shrinkRateBytes.Length; i++)
					headerBuffer[16 + i] = shrinkRateBytes[i];
				for (int i = 0; i < brightnessBytes.Length; i++)
					headerBuffer[20 + i] = brightnessBytes[i];

				// Get the arena bytes and copy them into the arena buffer
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / (ArenaWidth * 4);
					int y = i / 4 % ArenaHeight;

					byte[] tileBytes = BitConverter.GetBytes(ArenaTiles[x, y]);

					for (int j = 0; j < tileBytes.Length; j++)
						arenaBuffer[i + j] = tileBytes[j];
				}

				// Get the spawn bytes and copy them into the spawn buffer
				byte[] spawnCountBytes = BitConverter.GetBytes(Spawns.Count);

				for (int i = 0; i < spawnCountBytes.Length; i++)
					spawnBuffer[36 + i] = spawnCountBytes[i];

				foreach (KeyValuePair<int, Spawn> kvp in Spawns)
				{
					int enemyType = -1;
					for (int i = 0; i < Enemies.Count - 1; i++)
					{
						if (kvp.Value.Enemy == Enemies[i])
						{
							enemyType = i;
							break;
						}
					}
					byte[] enemyBytes = BitConverter.GetBytes(enemyType);
					for (int i = 0; i < enemyBytes.Length; i++)
						spawnBuffer[SpawnsOffsetBufferSize + kvp.Key * SpawnLength + i] = enemyBytes[i];

					byte[] delayBytes = BitConverter.GetBytes((float)kvp.Value.Delay);
					for (int i = 0; i < delayBytes.Length; i++)
						spawnBuffer[SpawnsOffsetBufferSize + kvp.Key * SpawnLength + 4 + i] = delayBytes[i];
				}

				// Create the file buffer
				byte[] fileBuffer = new byte[headerBuffer.Length + arenaBuffer.Length + spawnBuffer.Length];

				Buffer.BlockCopy(headerBuffer, 0, fileBuffer, 0, headerBuffer.Length);
				Buffer.BlockCopy(arenaBuffer, 0, fileBuffer, headerBuffer.Length, arenaBuffer.Length);
				Buffer.BlockCopy(spawnBuffer, 0, fileBuffer, headerBuffer.Length + arenaBuffer.Length, spawnBuffer.Length);

				bytes = fileBuffer;
				return true;
			}
			catch
			{
				bytes = new byte[0];
				return false;
			}
		}

		/// <summary>
		/// Tries to parse the contents of a spawnset file into a Spawnset instance.
		/// This only works for V3 spawnsets.
		/// </summary>
		/// <param name="filePath">The path to the spawnset file.</param>
		/// <returns>The <see cref="Spawnset">Spawnset</see>.</returns>
		public static bool TryParse(Stream stream, out Spawnset spawnset)
		{
			try
			{
				// Set the file values for reading V3 spawnsets
				int spawnBufferSize = (int)stream.Length - (HeaderBufferSize + ArenaBufferSize);
				byte[] headerBuffer = new byte[HeaderBufferSize];
				byte[] arenaBuffer = new byte[ArenaBufferSize];
				byte[] spawnBuffer = new byte[spawnBufferSize];

				// Read the file and write the data into the buffers, then close the file since we do not need it anymore
				stream.Read(headerBuffer, 0, HeaderBufferSize);
				stream.Read(arenaBuffer, 0, ArenaBufferSize);
				stream.Read(spawnBuffer, 0, spawnBufferSize);

				stream.Close();

				// Set the header values
				float shrinkEnd = BitConverter.ToSingle(headerBuffer, 8);
				float shrinkStart = BitConverter.ToSingle(headerBuffer, 12);
				float shrinkRate = BitConverter.ToSingle(headerBuffer, 16);
				float brightness = BitConverter.ToSingle(headerBuffer, 20);

				// Set the arena values
				float[,] arenaTiles = new float[ArenaWidth, ArenaHeight];
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / (ArenaWidth * 4);
					int y = (i / 4) % ArenaHeight;
					arenaTiles[x, y] = BitConverter.ToSingle(arenaBuffer, i);
				}

				// Set the spawn values
				SortedDictionary<int, Spawn> spawns = new SortedDictionary<int, Spawn>();
				int spawnIndex = 0;

				int bytePosition = SpawnsOffsetBufferSize;
				while (bytePosition < spawnBufferSize)
				{
					int enemyType = BitConverter.ToInt32(spawnBuffer, bytePosition);
					bytePosition += 4;
					float delay = BitConverter.ToSingle(spawnBuffer, bytePosition);
					bytePosition += 24;

					if (enemyType > 9)
						enemyType = -1;

					// Disable the loop for all previous spawns when we reach an empty spawn
					// The empty spawn is part of the new loop (until we find another empty spawn)
					if (enemyType == -1)
						foreach (KeyValuePair<int, Spawn> kvp in spawns)
							kvp.Value.IsInLoop = false;

					spawns.Add(spawnIndex, new Spawn(Enemies[enemyType], delay, true));
					spawnIndex++;
				}

				// Set the spawnset
				spawnset = new Spawnset(spawns, arenaTiles, shrinkStart, shrinkEnd, shrinkRate, brightness);

				// Success
				return true;
			}
			catch
			{
				// Set an empty spawnset
				spawnset = new Spawnset();

				// Failure
				return false;
			}
		}

		public static bool TryGetSpawnData(Stream stream, out SpawnsetData spawnsetData)
		{
			try
			{
				int spawnBufferSize = (int)stream.Length - (HeaderBufferSize + ArenaBufferSize + SpawnsOffsetBufferSize);
				byte[] spawnBuffer = new byte[spawnBufferSize];

				stream.Position += HeaderBufferSize + ArenaBufferSize + SpawnsOffsetBufferSize;
				stream.Read(spawnBuffer, 0, spawnBufferSize);
				stream.Close();

				int loopBegin = 0;
				for (int i = spawnBuffer.Length - SpawnLength; i > 0; i -= SpawnLength)
				{
					if (BitConverter.ToInt32(spawnBuffer, i) == -1)
					{
						loopBegin = i / SpawnLength;
						break;
					}
				}

				int nonLoopSpawns = 0;
				int loopSpawns = 0;
				float nonLoopSeconds = 0;
				float loopSeconds = 0;
				for (int j = 0; j < spawnBuffer.Length; j += SpawnLength)
				{
					if (j < loopBegin * SpawnLength)
						nonLoopSeconds += BitConverter.ToSingle(spawnBuffer, j + 4);
					else
						loopSeconds += BitConverter.ToSingle(spawnBuffer, j + 4);

					if (BitConverter.ToInt32(spawnBuffer, j) != -1)
					{
						if (j < loopBegin * SpawnLength)
							nonLoopSpawns++;
						else
							loopSpawns++;
					}
				}

				spawnsetData = new SpawnsetData
				{
					NonLoopSpawns = nonLoopSpawns,
					LoopSpawns = loopSpawns,
					NonLoopLength = nonLoopSpawns == 0 ? 0 : nonLoopSeconds,
					LoopLength = loopSpawns == 0 ? 0 : loopSeconds
				};

				return true;
			}
			catch
			{
				spawnsetData = new SpawnsetData();

				return false;
			}
		}
	}
}