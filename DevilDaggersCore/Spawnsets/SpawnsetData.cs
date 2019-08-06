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
		public float? NonLoopLengthNullable { get; set; }
		[JsonProperty]
		public float? LoopLengthNullable { get; set; }

		// TODO: Remove these 3 properties (will break DDSE versions 2.0.0.0 to 2.4.0.0)
		[JsonProperty]
		public float NonLoopLength => NonLoopLengthNullable ?? 0;
		[JsonProperty]
		public float LoopLength => LoopLengthNullable ?? 0;
		[JsonProperty]
		public float LoopStart => NonLoopLength;
	}
}