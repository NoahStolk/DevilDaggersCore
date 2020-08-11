using System;
using System.Collections.Generic;
using System.Reflection;

namespace DevilDaggersCore.Game
{
	public static class GameInfo
	{
		public static GameVersion GetGameVersionFromDate(DateTime dateTime)
		{
			foreach (GameVersion e in (GameVersion[])Enum.GetValues(typeof(GameVersion)))
			{
				if (GetReleaseDate(e) < dateTime)
					return e;
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

		public static List<TEntity> GetEntities<TEntity>(GameVersion gameVersion)
			where TEntity : DevilDaggersEntity
		{
			List<TEntity> entities = new List<TEntity>();

			foreach (FieldInfo field in gameVersion.Type.GetFields())
			{
				if (field.FieldType == typeof(TEntity) || field.FieldType.IsSubclassOf(typeof(TEntity)))
				{
					bool add = true;
					TEntity entity = field.GetValue(field) as TEntity;
					foreach (TEntity e in entities)
					{
						if (e.Name == entity.Name)
						{
							add = false;
							break;
						}
					}

					if (add)
						entities.Add(entity);
				}
			}

			return entities;
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