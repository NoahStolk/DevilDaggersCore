using DevilDaggersCore.Game;

namespace DevilDaggersCore.Spawnsets
{
	public class Spawn
	{
		public Spawn(Enemy? enemy, double delay)
		{
			Enemy = enemy;
			Delay = delay;
		}

		/// <summary>
		/// Represents the enemy in this spawn, or <see langword="null"/> if it is an EMPTY spawn.
		/// </summary>
		public Enemy? Enemy { get; set; }

		public double Delay { get; set; }

		public Spawn Copy()
			=> new(Enemy, Delay);

		public override string ToString()
			=> $"{Delay:0.0000}: {Enemy?.Name ?? "EMPTY"}";
	}
}
