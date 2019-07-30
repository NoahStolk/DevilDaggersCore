namespace DevilDaggersCore.Spawnsets.Events
{
	public abstract class AbstractEvent
	{
		/// <summary>
		/// Unlike the <see cref="Spawn">Spawn</see> class, use the total second here. Using <see cref="Spawn.Delay">Delay</see> is going to be unnecessarily complex as events will be overlapping a lot.
		/// </summary>
		public double Seconds { get; set; }

		public string Name { get; set; }

		public AbstractEvent(double seconds, string name)
		{
			Seconds = seconds;
			Name = name;
		}
	}
}