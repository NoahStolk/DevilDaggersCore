namespace DevilDaggersCore.Spawnset
{
	public class Spawn
	{
		public SpawnsetEnemy Enemy { get; set; }
		public double Delay { get; set; }
		public bool IsInLoop { get; set; }

		public Spawn(SpawnsetEnemy enemy, double delay, bool isInLoop = false)
		{
			Enemy = enemy;
			Delay = delay;
			IsInLoop = IsInLoop;
		}
	}
}