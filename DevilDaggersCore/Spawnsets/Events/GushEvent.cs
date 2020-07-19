using DevilDaggersCore.Game;
using System.Collections.Generic;

namespace DevilDaggersCore.Spawnsets.Events
{
	public class GushEvent : SubEvent
	{
		public GushEvent(double seconds, string name, SpawnEvent parent, Dictionary<Enemy, int> enemies)
			: base(seconds, name, parent)
		{
			Enemies = enemies;
		}

		public Dictionary<Enemy, int> Enemies { get; }
	}
}