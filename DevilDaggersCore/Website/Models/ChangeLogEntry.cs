using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Website.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ChangeLogEntry
	{
		[JsonProperty]
		public Version VersionNumber { get; set; }

		[JsonProperty]
		public DateTime Date { get; set; }

		[JsonProperty]
		public List<Change> Changes { get; set; }
	}
}