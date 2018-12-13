using DevilDaggersCore.Game;
using System.Linq;

namespace DevilDaggersCore.Spawnset
{
	/// <summary>
	/// Simplified version of the <see cref="Game.Enemy"/> class.
	/// Only meant for enemies used in spawnsets.
	/// </summary>
	public class SpawnsetEnemy
	{
		public string Name { get; set; }
		public int Gems { get; set; }

		public Enemy Enemy { get { return Game.Game.GetEntities<Enemy>().Where(e => e.Name == Name).FirstOrDefault(); } }

		public SpawnsetEnemy(string name, int gems)
		{
			Name = name;
			Gems = gems;
		}
	}
}