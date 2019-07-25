using DevilDaggersCore.Game;
using NetBase.Utils;
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
		public string Name { get; }
		public int NoFarmGems { get; }

		public SpawnsetEnemy(string name, int noFarmGems)
		{
			Name = name;
			NoFarmGems = noFarmGems;
		}

		public Enemy ToEnemy(params GameVersion[] gameVersions)
		{
			try
			{
				return Game.Game.GetEntities<Enemy>(gameVersions).Where(e => e.Name == Name).First();
			}
			catch
			{
				// If no game versions are specified, use all
				if (gameVersions.Length == 0)
					gameVersions = Game.Game.GameVersions.Values.ToArray();

				throw new Exception($"No Enemy found for {nameof(SpawnsetEnemy)} '{Name}' in game versions '{string.Join(", ", gameVersions.GetMemberValues<GameVersion, Type>("type", false))}'.");
			}
		}
	}
}