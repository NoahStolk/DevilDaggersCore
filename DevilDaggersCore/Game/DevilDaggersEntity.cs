using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DevilDaggersCore.Game
{
	[JsonObject(MemberSerialization.OptIn)]
	public abstract class DevilDaggersEntity
	{
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string ColorCode { get; set; }

		[JsonProperty]
		public string[] Appearances => GetAppearances().Select(g => g.Type.Name).ToArray();

		public DevilDaggersEntity(string name, string colorCode)
		{
			Name = name;
			ColorCode = colorCode;
		}

		public IEnumerable<GameVersion> GetAppearances()
		{
			foreach (GameVersion gameVersion in GameInfo.GameVersions.Values)
			{
				foreach (FieldInfo field in gameVersion.Type.GetFields())
				{
					if (field.FieldType == GetType())
					{
						DevilDaggersEntity entity = field.GetValue(field) as DevilDaggersEntity;
						if (entity.Name == Name)
							yield return gameVersion;
					}
				}
			}
		}
	}
}