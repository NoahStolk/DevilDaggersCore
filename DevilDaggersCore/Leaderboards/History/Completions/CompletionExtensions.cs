namespace DevilDaggersCore.Leaderboards.History.Completions
{
	public static class CompletionExtensions
	{
		public static string ToHtmlString(this CompletionEntry ce)
		{
			switch (ce)
			{
				case CompletionEntry.Missing:
					return "<span style='color: #f00'>(Missing)</span>";
				default:
					return string.Empty;
			}
		}

		public static string ToHtmlString(this CompletionEntryCombined cec)
		{
			switch (cec)
			{
				case CompletionEntryCombined.PartiallyMissing:
					return "<span style='color: #f80'>(Partially missing)</span>";
				case CompletionEntryCombined.Missing:
					return "<span style='color: #f00'>(Missing)</span>";
				default:
					return string.Empty;
			}
		}
	}
}