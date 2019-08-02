using Newtonsoft.Json;

namespace DevilDaggersCore.Game
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Death : DevilDaggersEntity
	{
		[JsonProperty]
		public int DeathType { get; set; }

		public Death(string name, string colorCode, int deathType)
			: base(name, colorCode)
		{
			DeathType = deathType;
		}
	}
}