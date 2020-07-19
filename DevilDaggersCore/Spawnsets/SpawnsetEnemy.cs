using DevilDaggersCore.Game;
using System;
using System.Linq;

namespace DevilDaggersCore.Spawnsets
{
	/// <summary>
	/// Simplified version of the <see cref="Enemy"/> class.
	/// Only meant for enemies used in spawnsets.
	/// </summary>
	public class SpawnsetEnemy
	{
		public SpawnsetEnemy(string name, int noFarmGems)
		{
			Name = name;
			NoFarmGems = noFarmGems;
		}

		public string Name { get; }
		public int NoFarmGems { get; }

		public Enemy ToEnemy(params GameVersion[] gameVersions)
		{
			try
			{
				return GameInfo.GetEntities<Enemy>(gameVersions).Where(e => e.Name == Name).First();
			}
			catch
			{
				// If no game versions are specified, use all.
				if (gameVersions.Length == 0)
					gameVersions = GameInfo.GameVersions.Values.ToArray();

				throw new Exception($"No Enemy found for {nameof(SpawnsetEnemy)} '{Name}' in game versions '{string.Join(", ", gameVersions.Select(g => g.Type))}'.");
			}
		}
	}
}