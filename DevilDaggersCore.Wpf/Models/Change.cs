using System.Collections.Generic;

namespace DevilDaggersCore.Wpf.Models
{
	public class Change
	{
		public Change(string description, List<Change>? subChanges)
		{
			Description = description;
			SubChanges = subChanges;
		}

		public string Description { get; }
		public List<Change>? SubChanges { get; }
	}
}