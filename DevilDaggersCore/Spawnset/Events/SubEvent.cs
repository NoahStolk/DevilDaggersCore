namespace DevilDaggersCore.Spawnset.Events
{
	public class SubEvent : AbstractEvent
	{
		public SpawnEvent Parent { get; set; }

		public SubEvent(double seconds, string name, SpawnEvent parent)
			: base(seconds, name)
		{
			Parent = parent;
		}
	}
}