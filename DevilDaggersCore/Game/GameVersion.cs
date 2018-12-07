using System;

namespace DevilDaggersCore.Game
{
	public class GameVersion
	{
		public Type Type { get; set; }
		public DateTime ReleaseDate { get; set; }

		public GameVersion(Type type, DateTime releaseDate)
		{
			Type = type;
			ReleaseDate = releaseDate;
		}
	}
}