namespace DevilDaggersCore.Spawnsets.Events
{
	public abstract class AbstractEvent
	{
		public AbstractEvent(double seconds, string name)
		{
			Seconds = seconds;
			Name = name;
		}

		/// <summary>
		/// Unlike the <see cref="Spawn"/> class, use the total second here. Using <see cref="Spawn.Delay"/> is going to be unnecessarily complex as events will be overlapping a lot.
		/// </summary>
		public double Seconds { get; set; }

		public string Name { get; set; }
	}
}
