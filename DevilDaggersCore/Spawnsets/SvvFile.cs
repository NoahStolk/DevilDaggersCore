using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Spawnsets
{
	public class SvvFile
	{
		public float ShrinkStart { get; set; }
		public float ShrinkEnd { get; set; }
		public float ShrinkRate { get; set; }
		public float Brightness { get; set; }

		public List<SvvSpawn> Spawns { get; } = new List<SvvSpawn>();

		public float[,] ArenaTiles { get; }

		public byte[] ToBytes()
		{
			List<bool[]> bitsCollections = new List<bool[]>
			{
				BitUtils.GetBits(BitConverter.GetBytes(ShrinkStart)),
				BitUtils.GetBits(BitConverter.GetBytes(ShrinkEnd)),
				BitUtils.GetBits(BitConverter.GetBytes(ShrinkRate)),
				BitUtils.GetBits(BitConverter.GetBytes(Brightness)),
			};

			for (int i = 0; i < Spawns.Count; i++)
				bitsCollections.Add(Spawns[i].GetBits());

			for (int i = 0; i < ArenaTiles.GetLength(0); i++)
			{
				for (int j = 0; j < ArenaTiles.GetLength(1); j++)
					bitsCollections.Add(BitUtils.GetBits(BitConverter.GetBytes(ArenaTiles[i, j])));
			}

			BitArray bitArray = new BitArray(bitsCollections.SelectMany(b => b).ToArray());

			return BitUtils.BitArrayToByteArray(bitArray);
		}
	}
}