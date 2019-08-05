using Newtonsoft.Json;

namespace DevilDaggersCore.Tools
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Tool
	{
		[JsonProperty]
		public string Name { get; set; }
		[JsonProperty]
		public string VersionNumber { get; set; }
		[JsonProperty]
		public string VersionNumberRequired { get; set; }
	}
}