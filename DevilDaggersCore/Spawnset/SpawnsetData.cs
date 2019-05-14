namespace DevilDaggersCore.Spawnset
{
	public class SpawnsetData
	{
		public int NonLoopSpawns { get; set; }
		public int LoopSpawns { get; set; }

		public float NonLoopLength { get; set; }
		public float LoopLength { get; set; }

		public float LoopStart => LoopSpawns == 0 ? 0 : NonLoopLength;
	}
}