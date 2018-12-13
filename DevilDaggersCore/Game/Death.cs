namespace DevilDaggersCore.Game
{
	public class Death : DevilDaggersEntity
	{
		public int DeathType { get; set; }

		public Death(string name, string colorCode, int deathType)
			: base(name, colorCode)
		{
			DeathType = deathType;
		}
	}
}