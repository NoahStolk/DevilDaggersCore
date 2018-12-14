using DevilDaggersCore.Game;
using System;
using System.Linq;

namespace DevilDaggersCore.Spawnset
{
	/// <summary>
	/// Simplified version of the <see cref="Enemy"/> class.
	/// Only meant for enemies used in spawnsets.
	/// </summary>
	public class SpawnsetEnemy
	{
		public string Name { get; set; }
		public int NoFarmGems { get; set; }

		public Enemy ToEnemy(params GameVersion[] gameVersions)
		{
			try
			{
				return Game.Game.GetEntities<Enemy>(gameVersions).Where(e => e.Name == Name).First();
			}
			catch
			{
				throw new Exception($"No Enemy found for SpawnsetEnemy '{Name}' in game versions '{gameVersions[0].Type.Name/*.ItemsAppended<string>()*/}'.");
			}
		}

		public SpawnsetEnemy(string name, int noFarmGems)
		{
			Name = name;
			NoFarmGems = noFarmGems;
		}
	}
}