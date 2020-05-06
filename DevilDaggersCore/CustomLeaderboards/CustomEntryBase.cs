﻿using System;

namespace DevilDaggersCore.CustomLeaderboards
{
	public class CustomEntryBase
	{
		public int PlayerId { get; set; }
		public string Username { get; set; }
		public int Time { get; set; }
		public int Gems { get; set; }
		public int Kills { get; set; }
		public int DeathType { get; set; }
		public int ShotsHit { get; set; }
		public int ShotsFired { get; set; }
		public int EnemiesAlive { get; set; }
		public int Homing { get; set; }
		public int LevelUpTime2 { get; set; }
		public int LevelUpTime3 { get; set; }
		public int LevelUpTime4 { get; set; }
		public DateTime SubmitDate { get; set; }
		public string ClientVersion { get; set; }

		public double Accuracy => ShotsFired == 0 ? 0 : ShotsHit / (double)ShotsFired;

		public CustomEntryBase(int playerId, string username, int time, int gems, int kills, int deathType, int shotsHit, int shotsFired, int enemiesAlive, int homing, int levelUpTime2, int levelUpTime3, int levelUpTime4, DateTime submitDate, string clientVersion)
		{
			PlayerId = playerId;
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

		public string FormatShots() => $"{ShotsHit:N0} / {ShotsFired:N0}";
	}
}