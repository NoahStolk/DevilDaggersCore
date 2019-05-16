﻿using System.Collections.Generic;
using System.Reflection;

namespace DevilDaggersCore.Game
{
	public abstract class DevilDaggersEntity
	{
		public string Name { get; set; }
		public string ColorCode { get; set; }

		public DevilDaggersEntity(string name, string colorCode)
		{
			Name = name;
			ColorCode = colorCode;
		}

		public IEnumerable<GameVersion> GetAppearances()
		{
			foreach (GameVersion gameVersion in Game.GameVersions.Values)
			{
				foreach (FieldInfo field in gameVersion.Type.GetFields())
				{
					if (field.FieldType == GetType())
					{
						DevilDaggersEntity dde = field.GetValue(field) as DevilDaggersEntity;
						if (dde.Name == Name)
							yield return gameVersion;
					}
				}
			}
		}
	}
}