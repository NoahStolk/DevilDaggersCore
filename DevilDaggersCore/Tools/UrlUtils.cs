//#define TESTING

namespace DevilDaggersCore.Tools
{
	public static class UrlUtils
	{
#if TESTING
		public static string BaseUrl = "http://localhost:2963";
#else
		public static string BaseUrl = "https://devildaggers.info";
#endif

		public static string ApiGetTools => $"{BaseUrl}/API/GetTools";
		public static string ApiGetSpawnsets => $"{BaseUrl}/API/GetSpawnsets";
		public static string ApiGetCustomLeaderboards => $"{BaseUrl}/API/GetCustomLeaderboards";
		public static string ApiGetSpawnset(string fileName) => $"{BaseUrl}/API/GetSpawnset?fileName={fileName}";
		public static string ApiGetTool(string toolName) => $"{BaseUrl}/API/GetTool?toolName={toolName}";

		public static string Spawnsets => $"{BaseUrl}/Spawnsets";
		public static string CustomLeaderboard(string spawnsetFileName) => $"{BaseUrl}/CustomLeaderboards/Leaderboard?spawnset={spawnsetFileName}";

		public static string DiscordInviteLink => "https://discord.gg/NF32j8S";

		public static string SourceCodeUrl(string toolName) => $"https://bitbucket.org/NoahStolk/{toolName}/src/master/";
	}
}