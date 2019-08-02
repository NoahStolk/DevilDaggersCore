using System;

namespace DevilDaggersCore.CustomLeaderboards
{
	public class CustomEntryBase
	{
		public int PlayerID { get; set; }
		public string Username { get; set; }
		public float Time { get; set; }
		public int Gems { get; set; }
		public int Kills { get; set; }
		public int DeathType { get; set; }
		public int ShotsHit { get; set; }
		public int ShotsFired { get; set; }
		public int EnemiesAlive { get; set; }
		public int Homing { get; set; }
		public float LevelUpTime2 { get; set; }
		public float LevelUpTime3 { get; set; }
		public float LevelUpTime4 { get; set; }
		public DateTime SubmitDate { get; set; }
		public string ClientVersion { get; set; }

		public double Accuracy => ShotsFired == 0 ? 0 : ShotsHit / (double)ShotsFired;

		public CustomEntryBase(int playerID, string username, float time, int gems, int kills, int deathType, int shotsHit, int shotsFired, int enemiesAlive, int homing, float levelUpTime2, float levelUpTime3, float levelUpTime4, DateTime submitDate, string clientVersion)
		{
			PlayerID = playerID;
			Username = username;
			Time = time;
			Gems = gems;
			Kills = kills;
			DeathType = deathType;
			ShotsHit = shotsHit;
			ShotsFired = shotsFired;
			EnemiesAlive = enemiesAlive;
			Homing = homing;
			LevelUpTime2 = levelUpTime2;
			LevelUpTime3 = levelUpTime3;
			LevelUpTime4 = levelUpTime4;
			SubmitDate = submitDate;
			ClientVersion = clientVersion;
		}
	}
}