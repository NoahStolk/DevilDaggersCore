﻿namespace DevilDaggersCore.Spawnsets
{
	public class Spawn
	{
		public Spawn(SpawnsetEnemy spawnsetEnemy, double delay)
		{
			SpawnsetEnemy = spawnsetEnemy;
			Delay = delay;
		}

		public SpawnsetEnemy SpawnsetEnemy { get; set; }
		public double Delay { get; set; }

		public Spawn Copy()
			=> new Spawn(SpawnsetEnemy, Delay);

		public override string ToString()
			=> $"{Delay:0.0000}: {SpawnsetEnemy.Name}";
	}
}