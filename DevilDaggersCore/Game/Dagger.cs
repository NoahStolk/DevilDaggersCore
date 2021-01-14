namespace DevilDaggersCore.Game
{
	public class Dagger : DevilDaggersEntity
	{
		public Dagger(GameVersion gameVersion, string name, string colorCode, int? unlockSecond)
			: base(gameVersion, name, colorCode)
		{
			UnlockSecond = unlockSecond;
		}

		public int? UnlockSecond { get; set; }
	}
}
