using System.Collections.Generic;

namespace DevilDaggersCore.Leaderboards.History.Completions
{
	public class CompletionCombined
	{
		public bool Initialized { get; set; }

		public Dictionary<string, CompletionEntryCombined> CompletionEntries { get; } = new Dictionary<string, CompletionEntryCombined>();
	}
}