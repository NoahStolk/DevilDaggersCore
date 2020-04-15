namespace DevilDaggersCore.CustomLeaderboards
{
	public class SubmissionInfo
	{
		public int TotalPlayers { get; set; }
		public CustomLeaderboardBase Leaderboard { get; set; }
		public CustomEntryBase[] Entries { get; set; }

		public int Rank { get; set; }
		public int RankDiff { get; set; }

		public float Time { get; set; }
		public float TimeDiff { get; set; }

		public int Kills { get; set; }
		public int KillsDiff { get; set; }

		public int Gems { get; set; }
		public int GemsDiff { get; set; }

		public int ShotsHit { get; set; }
		public int ShotsHitDiff { get; set; }

		public int ShotsFired { get; set; }
		public int ShotsFiredDiff { get; set; }

		public int EnemiesAlive { get; set; }
		public int EnemiesAliveDiff { get; set; }

		public int Homing { get; set; }
		public int HomingDiff { get; set; }

		public float LevelUpTime2 { get; set; }
		public float LevelUpTime2Diff { get; set; }

		public float LevelUpTime3 { get; set; }
		public float LevelUpTime3Diff { get; set; }

		public float LevelUpTime4 { get; set; }
		public float LevelUpTime4Diff { get; set; }
	}
}