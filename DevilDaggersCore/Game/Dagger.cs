namespace DevilDaggersCore.Game
{
	public class Dagger : DevilDaggersEntity
	{
		public Dagger(string name, string colorCode, int? unlockSecond)
			: base(name, colorCode)
		{
			UnlockSecond = unlockSecond;
		}

		public int? UnlockSecond { get; set; }
	}
}