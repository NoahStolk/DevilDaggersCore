namespace DevilDaggersCore.Spawnset
{
	public class SpawnsetEvent
	{
		public SpawnsetEventType Type { get; set; }

		public string Name { get; set; }

		/// <summary>
		/// Unlike the <see cref="Spawn">Spawn</see> class, use the total second here. Using <see cref="Spawn.Delay">Delay</see> is going to be unnecessarily complex as events will be overlapping a lot.
		/// </summary>
		public double Seconds { get; set; }

		public int NoFarmGems { get; set; }

		public SpawnsetEvent Parent { get; set; }

		public SpawnsetEvent(SpawnsetEventType type, string name, double seconds, int noFarmGems, SpawnsetEvent parent)
		{
			Type = type;
			Name = name;
			Seconds = seconds;
			NoFarmGems = noFarmGems;
			Parent = parent;
		}
	}
}