using Newtonsoft.Json;

namespace DevilDaggersCore.Spawnsets
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SpawnsetData
	{
		[JsonProperty]
		public int NonLoopSpawns { get; set; }
		[JsonProperty]
		public int LoopSpawns { get; set; }

		[JsonProperty]
		public float? NonLoopLength { get; set; }
		[JsonProperty]
		public float? LoopLength { get; set; }
	}
}