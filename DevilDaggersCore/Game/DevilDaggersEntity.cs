using System.Collections.Generic;
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
			foreach (GameVersion gameVersion in Game.GameVersions)
			{
				foreach (PropertyInfo prop in gameVersion.Type.GetProperties())
				{
					if (prop.PropertyType == GetType())
					{
						DevilDaggersEntity dde = prop.GetValue(prop) as DevilDaggersEntity;
						if (dde.Name == Name)
							yield return gameVersion;
					}
				}
			}
		}
	}
}