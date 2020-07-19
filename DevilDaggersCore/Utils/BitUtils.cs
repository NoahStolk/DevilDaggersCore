using System;
using System.Collections;

namespace DevilDaggersCore
{
	public static class BitUtils
	{
		public static bool[] GetBits(byte[] bytes)
		{
			if (bytes == null)
				throw new ArgumentNullException(nameof(bytes));

			bool[] bits = new bool[bytes.Length * 8];
			for (int i = 0; i < bytes.Length; i++)
			{
				for (int j = 0; j < 8; j++)
					bits[i * bytes.Length + j] = GetBit(bytes[i], j);
			}

			return bits;
		}

		public static bool[] GetBits(byte b, int startIndex, int length)
		{
			if (startIndex < 0 || length < 0 || startIndex + length > 8)
				throw new ArgumentOutOfRangeException($"{nameof(startIndex)} or {nameof(length)}");

			bool[] bits = new bool[length];
			for (int i = 0; i < length; i++)
				bits[i] = GetBit(b, startIndex + i);
			return bits;
		}

		private static bool GetBit(byte b, int bitIndex) => (b & (1 << bitIndex)) != 0;

		public static T[] Concat<T>(this T[] original, T[] toAppend)
		{
			if (original == null)
				throw new ArgumentNullException(nameof(original));
			if (toAppend == null)
				throw new ArgumentNullException(nameof(toAppend));

			int originalLengthX = original.Length;
			Array.Resize(ref original, original.Length + toAppend.Length);
			Array.Copy(toAppend, 0, original, originalLengthX, toAppend.Length);
			return original;
		}

		public static byte[] BitArrayToByteArray(BitArray bitArray)
		{
			if (bitArray == null)
				throw new ArgumentNullException(nameof(bitArray));

			byte[] bytes = new byte[(bitArray.Length - 1) / 8 + 1];
			bitArray.CopyTo(bytes, 0);
			return bytes;
		}
	}
}