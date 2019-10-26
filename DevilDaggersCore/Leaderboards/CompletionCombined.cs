using System.Collections.Generic;

namespace DevilDaggersCore.Leaderboards
{
	public class CompletionCombined
	{
		public bool Initialized { get; set; }

		public Dictionary<string, CompletionEntryCombined> CompletionEntries { get; set; } = new Dictionary<string, CompletionEntryCombined>();
	}
}