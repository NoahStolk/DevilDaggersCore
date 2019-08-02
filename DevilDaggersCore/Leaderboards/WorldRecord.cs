using System;

namespace DevilDaggersCore.Leaderboards
{
	public class WorldRecord
	{
		public DateTime DateTime { get; set; }
		public Entry Entry { get; set; }

		public WorldRecord(DateTime dateTime, Entry entry)
		{
			DateTime = dateTime;
			Entry = entry;
		}
	}
}