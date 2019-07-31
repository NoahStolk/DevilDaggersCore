using Newtonsoft.Json;

namespace DevilDaggersCore.Spawnsets.Web
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SpawnsetFile
	{
		[JsonProperty]
		public string Path { get; set; }

		public string FileName => System.IO.Path.GetFileName(Path);
		public string Name => GetName(FileName);
		public string Author => GetAuthor(FileName);

		[JsonProperty]
		public SpawnsetFileSettings settings;
		[JsonProperty]
		public SpawnsetData spawnsetData;

		[JsonProperty]
		public bool HasLeaderboard { get; set; }

		public static string GetName(string fileName)
		{
			return fileName.Substring(0, fileName.LastIndexOf('_'));
		}

		public static string GetAuthor(string fileName)
		{
			return fileName.Substring(fileName.LastIndexOf('_') + 1);
		}
	}
}