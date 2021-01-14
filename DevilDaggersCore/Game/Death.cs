using Newtonsoft.Json;

namespace DevilDaggersCore.Game
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Death : DevilDaggersEntity
	{
		public Death(GameVersion gameVersion, string name, string colorCode, int deathType)
			: base(gameVersion, name, colorCode)
		{
			DeathType = deathType;
		}

		[JsonProperty]
		public int DeathType { get; set; }
	}
}
