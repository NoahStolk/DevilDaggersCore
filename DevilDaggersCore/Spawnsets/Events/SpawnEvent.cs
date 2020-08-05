namespace DevilDaggersCore.Spawnsets.Events
{
	public class SpawnEvent : AbstractEvent
	{
		public SpawnEvent(double seconds, string name, SpawnsetEnemy enemy)
			: base(seconds, name)
		{
			Enemy = enemy;
		}

		public SpawnsetEnemy Enemy { get; set; }

		public override string ToString()
			=> $"{Seconds:0.0000}: {Name}";
	}
}