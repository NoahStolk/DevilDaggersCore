using System;

namespace DevilDaggersCore.CustomLeaderboards
{
	public class CustomLeaderboardBase
	{
		public string SpawnsetFileName { get; set; }
		public float Bronze { get; set; }
		public float Silver { get; set; }
		public float Golden { get; set; }
		public float Devil { get; set; }
		public float Homing { get; set; }
		public DateTime? DateLastPlayed { get; set; }
		public DateTime? DateCreated { get; set; }

		public CustomLeaderboardBase(string spawnsetFileName, float bronze, float silver, float golden, float devil, float homing, DateTime? dateLastPlayed, DateTime? dateCreated)
		{
			SpawnsetFileName = spawnsetFileName;
			Bronze = bronze;
			Silver = silver;
			Golden = golden;
			Devil = devil;
			Homing = homing;
			DateLastPlayed = dateLastPlayed;
			DateCreated = dateCreated;
		}
	}
}