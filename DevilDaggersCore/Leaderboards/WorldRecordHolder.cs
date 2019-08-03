using System;

namespace DevilDaggersCore.Leaderboards
{
	public class WorldRecordHolder
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public TimeSpan TotalTimeHeld { get; set; }
		public TimeSpan LongestTimeHeldConsecutively { get; set; }
		public int WorldRecordCount { get; set; }
		public DateTime LastHeld { get; set; }

		public WorldRecordHolder(int id, string username, TimeSpan totalTimeHeld, TimeSpan longestTimeHeldConsecutively, int worldRecordCount, DateTime lastHeld)
		{
			ID = id;
			Username = username;
			TotalTimeHeld = totalTimeHeld;
			LongestTimeHeldConsecutively = longestTimeHeldConsecutively;
			WorldRecordCount = worldRecordCount;
			LastHeld = lastHeld;
		}
	}
}