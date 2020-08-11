using System;
using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Game
{
	public static class GameInfo
	{
		public static GameVersion GetGameVersionFromDate(DateTime dateTime)
		{
			foreach (GameVersion gameVersion in (GameVersion[])Enum.GetValues(typeof(GameVersion)))
			{
				if (GetReleaseDate(gameVersion) < dateTime)
					return gameVersion;
			}

			return GameVersion.None;
		}

		public static string[] GetEnemyInfo(Enemy enemy)
		{
			foreach (KeyValuePair<Enemy, string[]> kvp in GameData.EnemyInfo)
			{
				if (kvp.Key == enemy)
					return kvp.Value;
			}

			throw new Exception($"Could not find enemy info for {nameof(Enemy)} with name '{enemy.Name}'.");
		}

		public static List<TEntity> GetEntities<TEntity>(GameVersion? gameVersion = null)
			where TEntity : DevilDaggersEntity
		{
			IEnumerable<TEntity> entities = GameData.Entities.OfType<TEntity>();
			if (gameVersion != null)
				entities = entities.Where(e => e.GameVersion == gameVersion);

			return entities.ToList();
		}

		public static DateTime? GetReleaseDate(GameVersion gameVersion) => gameVersion switch
		{
			GameVersion.V1 => new DateTime(2016, 2, 18),
			GameVersion.V2 => new DateTime(2016, 7, 5),
			GameVersion.V3 => new DateTime(2016, 9, 19),
			_ => null,
		};
	}
}