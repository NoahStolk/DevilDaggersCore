namespace DevilDaggersCore.Spawnset
{
	/// <summary>
	/// Simplified version of the <see cref="Game.Enemy"/> class.
	/// Only meant for enemies used in spawnsets.
	/// </summary>
	public class SpawnsetEnemy
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Gems { get; set; }

		public SpawnsetEnemy(int id, string name, int gems)
		{
			ID = id;
			Name = name;
			Gems = gems;
		}
	}
}