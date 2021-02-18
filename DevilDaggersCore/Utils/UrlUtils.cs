using System;

namespace DevilDaggersCore.Utils
{
	public static class UrlUtils
	{
#if TESTING
		public static Uri BaseUrl { get; } = new("http://localhost:2963");
#else
		public static Uri BaseUrl { get; } = new("https://devildaggers.info");
#endif

		public static string DiscordInviteLink => "https://discord.gg/NF32j8S";

		public static string SpawnsetsPage => $"{BaseUrl}Spawnsets";

		public static string ApiGetTool(string toolName) => $"{BaseUrl}api/tools/{toolName}/file";

		public static Uri SourceCodeUrl(string toolName) => new($"https://github.com/NoahStolk/{toolName}");

		public static string CustomLeaderboardPage(string spawnsetFileName) => $"{BaseUrl}CustomLeaderboards/Leaderboard?spawnset={spawnsetFileName}";
	}
}
