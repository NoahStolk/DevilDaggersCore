namespace DevilDaggersCore.Spawnsets.Events
{
	public class SubEvent : AbstractEvent
	{
		public SubEvent(double seconds, string name, SpawnEvent parent)
			: base(seconds, name)
		{
			Parent = parent;
		}

		public SpawnEvent Parent { get; set; }
	}
}
