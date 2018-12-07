namespace DevilDaggersCore.Game
{
	public class Dagger : DevilDaggersEntity
	{
		public int? UnlockSecond { get; set; }

		public Dagger(string name, string colorCode, int? unlockSecond)
			: base(name, colorCode)
		{
			UnlockSecond = unlockSecond;
		}
	}
}