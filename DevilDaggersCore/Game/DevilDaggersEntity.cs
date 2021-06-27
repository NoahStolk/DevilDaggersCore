namespace DevilDaggersCore.Game
{
	public abstract class DevilDaggersEntity
	{
		protected DevilDaggersEntity(GameVersion gameVersion, string name, string colorCode)
		{
			GameVersion = gameVersion;
			Name = name;
			ColorCode = colorCode;
		}

		public GameVersion GameVersion { get; set; }

		public string Name { get; set; }

		public string ColorCode { get; set; }
	}
}
