﻿using System.Collections.Generic;

namespace DevilDaggersCore.Tools.Website
{
	public class Change
	{
		public Change(string description)
		{
			Description = description;
		}

		public string Description { get; set; }

		public IReadOnlyList<Change> SubChanges { get; set; }
	}
}