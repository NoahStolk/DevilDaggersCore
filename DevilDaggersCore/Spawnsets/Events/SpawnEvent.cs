namespace DevilDaggersCore.Spawnsets.Events
{
	public class SpawnEvent : AbstractEvent
	{
		public SpawnsetEnemy Enemy { get; set; }

		public SpawnEvent(double seconds, string name, SpawnsetEnemy enemy)
			: base(seconds, name)
		{
			Enemy = enemy;
		}
	}
}