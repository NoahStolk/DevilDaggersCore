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

		public CustomLeaderboardBase(string spawnsetFileName, float bronze, float silver, float golden, float devil, float homing)
		{
			SpawnsetFileName = spawnsetFileName;
			Bronze = bronze;
			Silver = silver;
			Golden = golden;
			Devil = devil;
			Homing = homing;
		}
	}
}