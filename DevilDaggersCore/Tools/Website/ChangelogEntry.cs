using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Tools.Website
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ChangelogEntry
	{
		[JsonProperty]
		public Version VersionNumber { get; set; }

		[JsonProperty]
		public DateTime Date { get; set; }

		[JsonProperty]
		public IReadOnlyList<Change> Changes { get; set; }
	}
}