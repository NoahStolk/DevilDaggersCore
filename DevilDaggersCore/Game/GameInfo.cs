using System;
using System.Collections.Generic;
using System.Globalization;
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

		public static Death GetDeathByType(int deathType)
			=> GetEntities<Death>().FirstOrDefault(e => e.DeathType == deathType);

		public static Death GetDeathByName(string deathName)
			=> GetEntities<Death>().FirstOrDefault(e => e.Name.ToLower(CultureInfo.InvariantCulture) == deathName.ToLower(CultureInfo.InvariantCulture));

		public static DateTime? GetReleaseDate(GameVersion gameVersion) => gameVersion switch
		{
			GameVersion.V1 => new DateTime(2016, 2, 18),
			GameVersion.V2 => new DateTime(2016, 7, 5),
			GameVersion.V3 => new DateTime(2016, 9, 19),
			_ => null,
		};

		public static Dagger GetDaggerFromTime(int timeInTenthsOfMilliseconds)
		{
			List<Dagger> daggers = GetEntities<Dagger>(GameVersion.V3);
			for (int i = daggers.Count - 1; i >= 0; i--)
			{
				if (timeInTenthsOfMilliseconds >= (daggers[i].UnlockSecond ?? 0) * 10000)
					return daggers[i];
			}

			throw new Exception($"Could not determine dagger based on time '{timeInTenthsOfMilliseconds}'.");
		}

		public static IEnumerable<GameVersion> GetAppearances(string entityName)
			=> GameData.Entities.Where(e => e.Name == entityName).Select(e => e.GameVersion);
	}
}