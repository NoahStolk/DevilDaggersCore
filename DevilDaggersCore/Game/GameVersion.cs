using System;

namespace DevilDaggersCore.Game
{
	public class GameVersion
	{
		public GameVersion(Type type, DateTime releaseDate)
		{
			Type = type;
			ReleaseDate = releaseDate;
		}

		public Type Type { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}