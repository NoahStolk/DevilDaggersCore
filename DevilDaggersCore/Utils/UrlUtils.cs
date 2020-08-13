// #define TESTING

using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Utils
{
	public static class UrlUtils
	{
#if TESTING
		public static Uri BaseUrl { get; } = new Uri("http://localhost:2963");
#else
		public static Uri BaseUrl { get; } = new Uri("https://devildaggers.info");
#endif

		public static string ApiGetTools => $"{BaseUrl}api/tools";
		public static string ApiGetSpawnsets => $"{BaseUrl}api/spawnsets";
		public static string ApiGetCustomLeaderboards => $"{BaseUrl}api/custom-leaderboards";

		public static string Spawnsets => $"{BaseUrl}Spawnsets";

		public static string DiscordInviteLink => "https://discord.gg/NF32j8S";

		public static string ApiGetSpawnset(string fileName) => $"{BaseUrl}api/spawnsets/{fileName}";

		public static string ApiGetTool(string toolName) => $"{BaseUrl}api/tools/{toolName}";

		public static string CustomLeaderboard(string spawnsetFileName) => $"{BaseUrl}CustomLeaderboards/Leaderboard?spawnset={spawnsetFileName}";

		public static string UploadCustomEntry(List<string> queryValues) => $"{BaseUrl}CustomLeaderboards/Upload?{string.Join("&", queryValues)}";

		public static Uri SourceCodeUrl(string toolName) => new Uri($"https://github.com/NoahStolk/{toolName}");
	}
}