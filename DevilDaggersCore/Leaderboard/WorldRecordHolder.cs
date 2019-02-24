﻿using System;

namespace DevilDaggersCore.Leaderboard
{
	public class WorldRecordHolder
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public TimeSpan TimeHeld { get; set; }
		public DateTime LastHeld { get; set; }

		public WorldRecordHolder(int id, string username, TimeSpan timeHeld, DateTime lastHeld)
		{
			ID = id;
			Username = username;
			TimeHeld = timeHeld;
			LastHeld = lastHeld;
		}
	}
}