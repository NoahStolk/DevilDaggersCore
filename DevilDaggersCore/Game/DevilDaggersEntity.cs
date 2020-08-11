using Newtonsoft.Json;

namespace DevilDaggersCore.Game
{
	[JsonObject(MemberSerialization.OptIn)]
	public abstract class DevilDaggersEntity
	{
		public DevilDaggersEntity(GameVersion gameVersion, string name, string colorCode)
		{
			GameVersion = gameVersion;
			Name = name;
			ColorCode = colorCode;
		}

		[JsonProperty]
		public GameVersion GameVersion { get; set; }

		[JsonProperty]
		public string Name { get; set; }

		[JsonProperty]
		public string ColorCode { get; set; }
	}
}