using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Tools
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ChangeLogEntry
	{
		[JsonProperty]
		public string VersionNumber { get; set; }

		[JsonProperty]
		public DateTime Date { get; set; }

		[JsonProperty]
		public List<Change> Changes { get; set; }
	}
}