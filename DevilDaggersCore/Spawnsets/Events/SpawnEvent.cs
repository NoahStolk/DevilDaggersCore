using DevilDaggersCore.Game;

namespace DevilDaggersCore.Spawnsets.Events
{
	public class SpawnEvent : AbstractEvent
	{
		public SpawnEvent(double seconds, string name, Enemy enemy)
			: base(seconds, name)
		{
			Enemy = enemy;
		}

		public Enemy Enemy { get; set; }

		public override string ToString()
			=> $"{Seconds:0.0000}: {Name}";
	}
}