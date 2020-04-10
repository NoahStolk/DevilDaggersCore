namespace DevilDaggersCore.Spawnsets
{
	public class Spawn
	{
		public SpawnsetEnemy SpawnsetEnemy { get; set; }
		public double Delay { get; set; }

		public Spawn(SpawnsetEnemy spawnsetEnemy, double delay)
		{
			SpawnsetEnemy = spawnsetEnemy;
			Delay = delay;
		}

		public Spawn Copy() => new Spawn(SpawnsetEnemy, Delay);
	}
}