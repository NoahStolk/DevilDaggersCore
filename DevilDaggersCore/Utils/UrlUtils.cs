// #define TESTING

using System;

namespace DevilDaggersCore.Utils
{
	public static class UrlUtils
	{
#if TESTING
		public static Uri BaseUrl { get; } = new Uri("http://localhost:2963");
#else
		public static Uri BaseUrl { get; } = new Uri("https://devildaggers.info");
#endif

		public static string ApiGetTools => $"{BaseUrl}/Api/GetTools";
		public static string ApiGetSpawnsets => $"{BaseUrl}/Api/GetSpawnsets";
		public static string ApiGetCustomLeaderboards => $"{BaseUrl}/Api/GetCustomLeaderboards";

		public static string Spawnsets => $"{BaseUrl}/Spawnsets";

		public static string DiscordInviteLink => "https://discord.gg/NF32j8S";

		public static string ApiGetSpawnset(string fileName) => $"{BaseUrl}/Api/GetSpawnset?fileName={fileName}";

		public static string ApiGetTool(string toolName) => $"{BaseUrl}/Api/GetTool?toolName={toolName}";

		public static string CustomLeaderboard(string spawnsetFileName) => $"{BaseUrl}/CustomLeaderboards/Leaderboard?spawnset={spawnsetFileName}";

		public static Uri SourceCodeUrl(string toolName) => new Uri($"https://github.com/NoahStolk/{toolName}");
	}
}