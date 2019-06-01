namespace DevilDaggersCore.Spawnset
{
	public class Spawn
	{
		public SpawnsetEnemy SpawnsetEnemy { get; set; }
		public double Delay { get; set; }
		public bool IsInLoop { get; set; }

		public Spawn(SpawnsetEnemy spawnsetEnemy, double delay, bool isInLoop = false)
		{
			SpawnsetEnemy = spawnsetEnemy;
			Delay = delay;
			IsInLoop = isInLoop;
		}
	}
}