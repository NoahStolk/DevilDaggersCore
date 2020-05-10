using NetBase.Extensions;
using System;

namespace DevilDaggersCore
{
	public static class FormatUtils
	{
		public static readonly string LeaderboardTimeFormat = "0.0000";
		public static readonly string LeaderboardTimeLargeFormat = "###,###,###,##0.0000";
		public static readonly string LeaderboardIntFormat = "N0";
		public static readonly string DateFormat = "yyyy-MM-dd";
		public static readonly string SpawnTimeFormat = "0.0000";
		public static readonly string MouseSensitivityFormat = "0.000";
		public static readonly string AccuracyFormat = "0.00%";

		// TODO: Improve performance.
		public static string FormatTimeInteger(this int time)
		{
			string timeStr = time.ToString();
			timeStr = $"{new string(' ', Math.Max(0, 5 - timeStr.Length))}{timeStr}";
			return timeStr.Reverse().Insert(4, ".").Reverse();
		}
	}
}