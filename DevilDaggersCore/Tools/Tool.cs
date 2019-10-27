using Newtonsoft.Json;
using System.Collections.Generic;

namespace DevilDaggersCore.Tools
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Tool
	{
		[JsonProperty]
		public string Name { get; set; }

		[JsonProperty]
		public string VersionNumber { get; set; }

		/// <summary>
		/// Indicates the oldest version of the tool which is still fully compatible with the website.
		/// </summary>
		[JsonProperty]
		public string VersionNumberRequired { get; set; }

		[JsonProperty]
		public List<ChangeLogEntry> ChangeLog { get; set; }
	}
}