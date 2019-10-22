using System.Collections.Generic;

namespace DevilDaggersCore.Tools
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