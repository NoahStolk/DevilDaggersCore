using System.Collections.Generic;

namespace DevilDaggersCore.Leaderboards.History.Completions
{
	public class Completion
	{
		public bool Initialized { get; set; }

		public Dictionary<string, CompletionEntry> CompletionEntries { get; set; } = new Dictionary<string, CompletionEntry>();

		public float GetCompletionRate()
		{
			int total = CompletionEntries.Count;
			int missing = 0;
			foreach (KeyValuePair<string, CompletionEntry> kvp in CompletionEntries)
				if (kvp.Value == CompletionEntry.Missing)
					missing++;
			return 1f - missing / (float)total;
		}
	}
}