using Newtonsoft.Json;

namespace DevilDaggersCore.Spawnsets.Web
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SpawnsetFile
	{
		[JsonProperty]
		public SpawnsetFileSettings settings;
		[JsonProperty]
		public SpawnsetData spawnsetData;

		[JsonProperty]
		public string Path { get; set; }

		public string FileName => System.IO.Path.GetFileName(Path);
		public string Name => GetName(FileName);
		public string Author => GetAuthor(FileName);

		public static string GetName(string fileName) => fileName.Substring(0, fileName.LastIndexOf('_'));

		public static string GetAuthor(string fileName) => fileName.Substring(fileName.LastIndexOf('_') + 1);
	}
}