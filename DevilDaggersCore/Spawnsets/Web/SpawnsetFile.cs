using Newtonsoft.Json;

namespace DevilDaggersCore.Spawnsets.Web
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SpawnsetFile
	{
		[JsonProperty]
		public string Path { get; set; }

		public string FileName => System.IO.Path.GetFileName(Path);
		[JsonProperty] // TODO: JsonProperty is redundant, but still used in DDSE 1...
		public string Name => GetName(FileName);
		[JsonProperty] // TODO: JsonProperty is redundant, but still used in DDSE 1...
		// TODO: Should actually be called AuthorName but I don't want to break anything
		public string Author => GetAuthor(FileName);

		[JsonProperty]
		public SpawnsetFileSettings settings;
		[JsonProperty]
		public SpawnsetData spawnsetData;

		[JsonProperty]
		public bool HasLeaderboard { get; set; }

		public static string GetName(string fileNameOrPath)
		{
			return fileNameOrPath.Substring(0, fileNameOrPath.LastIndexOf('_'));
		}

		public static string GetAuthor(string fileNameOrPath)
		{
			return fileNameOrPath.Substring(fileNameOrPath.LastIndexOf('_') + 1);
		}
	}
}