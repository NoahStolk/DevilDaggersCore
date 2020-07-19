using System;

namespace DevilDaggersCore.CustomLeaderboards
{
	public class CustomLeaderboardBase
	{
		public CustomLeaderboardBase(string spawnsetFileName, int bronze, int silver, int golden, int devil, int homing, DateTime? dateLastPlayed, DateTime? dateCreated)
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

		public string SpawnsetFileName { get; set; }
		public int Bronze { get; set; }
		public int Silver { get; set; }
		public int Golden { get; set; }
		public int Devil { get; set; }
		public int Homing { get; set; }
		public DateTime? DateLastPlayed { get; set; }
		public DateTime? DateCreated { get; set; }
	}
}