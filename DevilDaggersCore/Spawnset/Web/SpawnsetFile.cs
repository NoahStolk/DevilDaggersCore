using Newtonsoft.Json;

namespace DevilDaggersCore.Spawnset.Web
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SpawnsetFile
	{
		public string Path { get; set; }

		public string FileName => System.IO.Path.GetFileName(Path);

		[JsonProperty]
		public string Name => GetName(FileName);
		[JsonProperty]
		public string Author => GetAuthor(FileName);
		[JsonProperty]
		public SpawnsetFileSettings settings;
		[JsonProperty]
		public SpawnsetData spawnsetData;

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