using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Leaderboards.History
{
	public class WorldRecordHolder
	{
		public int ID { get; set; }
		public List<string> Usernames { get; } = new List<string>();
		public TimeSpan TotalTimeHeld { get; set; }
		public TimeSpan LongestTimeHeldConsecutively { get; set; }
		public int WorldRecordCount { get; set; }
		public DateTime LastHeld { get; set; }

		public string MostRecentUsername { get; set; }

		public WorldRecordHolder(int id, string username, TimeSpan totalTimeHeld, TimeSpan longestTimeHeldConsecutively, int worldRecordCount, DateTime lastHeld)
		{
			ID = id;
			Usernames.Add(username);
			TotalTimeHeld = totalTimeHeld;
			LongestTimeHeldConsecutively = longestTimeHeldConsecutively;
			WorldRecordCount = worldRecordCount;
			LastHeld = lastHeld;

			MostRecentUsername = username;
		}
	}
}