using System;

namespace DevilDaggersCore.Spawnsets
{
	public class SvvSpawn
	{
		public byte Type { get; set; }
		public float Delay { get; set; }

		public bool[] GetBits()
		{
			bool[] typeBits = BitUtils.GetBits(Type, 4, 4);
			bool[] delayBits = BitUtils.GetBits(BitConverter.GetBytes(Delay));

			return typeBits.Concat(delayBits);
		}

		public static SvvSpawn CreateFromBits(bool[] bits)
		{
			throw new NotImplementedException();
		}
	}
}