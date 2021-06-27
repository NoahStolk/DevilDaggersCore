namespace DevilDaggersCore.Game
{
	public class Death : DevilDaggersEntity
	{
		public Death(GameVersion gameVersion, string name, string colorCode, int deathType)
			: base(gameVersion, name, colorCode)
		{
			DeathType = deathType;
		}

		public int DeathType { get; set; }
	}
}
