namespace DevilDaggersCore.Game
{
	public class Death : DevilDaggersEntity
	{
		public int LeaderboardType { get; set; }

		public Death(string name, string colorCode, int leaderboardType)
			: base(name, colorCode)
		{
			LeaderboardType = leaderboardType;
		}
	}
}