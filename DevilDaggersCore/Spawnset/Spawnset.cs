using DevilDaggersCore.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace DevilDaggersCore.Spawnset
{
	public class Spawnset
	{
		public const int HEADER_BUFFER_SIZE = 36;
		public const int ARENA_BUFFER_SIZE = 10404;

		public const int ARENA_WIDTH = 51;
		public const int ARENA_HEIGHT = 51;

		public static List<SpawnsetEnemy> Enemies { get; set; } = new List<SpawnsetEnemy>
		{
			new SpawnsetEnemy(-1, "EMPTY", 0),
			new SpawnsetEnemy(0, "Squid I", 2),
			new SpawnsetEnemy(1, "Squid II", 3),
			new SpawnsetEnemy(2, "Centipede", 25),
			new SpawnsetEnemy(3, "Spider I", 1),
			new SpawnsetEnemy(4, "Leviathan", 6),
			new SpawnsetEnemy(5, "Gigapede", 50),
			new SpawnsetEnemy(6, "Squid III", 3),
			new SpawnsetEnemy(7, "Thorn", 0),
			new SpawnsetEnemy(8, "Spider II", 1),
			new SpawnsetEnemy(9, "Ghostpede", 10)
		};

		public SortedDictionary<int, Spawn> Spawns { get; set; }
		public float[,] ArenaTiles { get; set; }
		public float ShrinkStart { get; set; }
		public float ShrinkEnd { get; set; }
		public float ShrinkRate { get; set; }
		public float Brightness { get; set; }

		public Spawnset()
		{
			Spawns = new SortedDictionary<int, Spawn>();
			ArenaTiles = new float[ARENA_WIDTH, ARENA_HEIGHT];
			ShrinkStart = 50;
			ShrinkEnd = 20;
			ShrinkRate = 0.025f;
			Brightness = 60;

			byte[] defaultArenaBuffer = new byte[ARENA_BUFFER_SIZE];
			FileStream fs = new FileStream(Constants.SurvivalPath, FileMode.Open, FileAccess.Read)
			{
				Position = HEADER_BUFFER_SIZE
			};
			fs.Read(defaultArenaBuffer, 0, ARENA_BUFFER_SIZE);
			fs.Close();

			for (int i = 0; i < defaultArenaBuffer.Length; i += 4)
			{
				int x = i / (ARENA_WIDTH * 4);
				int y = i / 4 % ARENA_HEIGHT;
				ArenaTiles[x, y] = BitConverter.ToSingle(defaultArenaBuffer, i);
			}
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

		public byte[] GetBytes()
		{
			// Open the original spawnset file
			FileStream fs = new FileStream(Constants.SurvivalPath, FileMode.Open, FileAccess.Read);

			// Set the file values for reading V3 spawnsets
			byte[] headerBuffer = new byte[HEADER_BUFFER_SIZE];
			byte[] arenaBuffer = new byte[ARENA_BUFFER_SIZE];
			byte[] spawnBuffer = new byte[40 + Spawns.Count * 28];

			// Read the file and write the data into the buffers, then close the file since we do not need it anymore
			fs.Read(headerBuffer, 0, HEADER_BUFFER_SIZE);
			fs.Read(arenaBuffer, 0, ARENA_BUFFER_SIZE);
			fs.Read(spawnBuffer, 0, 40);

			fs.Close();

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
				int x = i / (ARENA_WIDTH * 4);
				int y = i / 4 % ARENA_HEIGHT;

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
					spawnBuffer[40 + kvp.Key * 28 + i] = enemyBytes[i];

				byte[] delayBytes = BitConverter.GetBytes((float)kvp.Value.Delay);
				for (int i = 0; i < delayBytes.Length; i++)
					spawnBuffer[40 + kvp.Key * 28 + 4 + i] = delayBytes[i];
			}

			// Create the file buffer and return it
			byte[] fileBuffer = new byte[headerBuffer.Length + arenaBuffer.Length + spawnBuffer.Length];

			Buffer.BlockCopy(headerBuffer, 0, fileBuffer, 0, headerBuffer.Length);
			Buffer.BlockCopy(arenaBuffer, 0, fileBuffer, headerBuffer.Length, arenaBuffer.Length);
			Buffer.BlockCopy(spawnBuffer, 0, fileBuffer, headerBuffer.Length + arenaBuffer.Length, spawnBuffer.Length);

			return fileBuffer;
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
				int spawnBufferSize = (int)stream.Length - (HEADER_BUFFER_SIZE + ARENA_BUFFER_SIZE);
				byte[] headerBuffer = new byte[HEADER_BUFFER_SIZE];
				byte[] arenaBuffer = new byte[ARENA_BUFFER_SIZE];
				byte[] spawnBuffer = new byte[spawnBufferSize];

				// Read the file and write the data into the buffers, then close the file since we do not need it anymore
				stream.Read(headerBuffer, 0, HEADER_BUFFER_SIZE);
				stream.Read(arenaBuffer, 0, ARENA_BUFFER_SIZE);
				stream.Read(spawnBuffer, 0, spawnBufferSize);

				stream.Close();

				// Set the header values
				float shrinkEnd = BitConverter.ToSingle(headerBuffer, 8);
				float shrinkStart = BitConverter.ToSingle(headerBuffer, 12);
				float shrinkRate = BitConverter.ToSingle(headerBuffer, 16);
				float brightness = BitConverter.ToSingle(headerBuffer, 20);

				// Set the arena values
				float[,] arenaTiles = new float[ARENA_WIDTH, ARENA_HEIGHT];
				for (int i = 0; i < arenaBuffer.Length; i += 4)
				{
					int x = i / (ARENA_WIDTH * 4);
					int y = (i / 4) % ARENA_HEIGHT;
					arenaTiles[x, y] = BitConverter.ToSingle(arenaBuffer, i);
				}

				// Set the spawn values
				SortedDictionary<int, Spawn> spawns = new SortedDictionary<int, Spawn>();
				int spawnIndex = 0;

				int bytePosition = 40;
				while (bytePosition < spawnBufferSize)
				{
					int enemyType = BitConverter.ToInt32(spawnBuffer, bytePosition);
					bytePosition += 4;
					float delay = BitConverter.ToSingle(spawnBuffer, bytePosition) * 0.75f;
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
	}
}