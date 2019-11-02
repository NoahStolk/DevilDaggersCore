using System.Collections.Generic;

namespace DevilDaggersCore.Website.Models
{
	public class Change
	{
		public string Description { get; set; }
		public List<Change> SubChanges { get; set; }

		public Change(string description)
		{
			Description = description;
		}
	}
}