using System;
using System.Collections.Generic;
using System.Linq;

namespace DevilDaggersCore.Utils
{
	public static class EnumUtils
	{
		public static TEnum[] GetEnumValues<TEnum>()
			where TEnum : Enum
			=> (TEnum[])Enum.GetValues(typeof(TEnum));

		public static string[] GetEnumFlagValues<TEnum>(TEnum flags, bool useUserFriendlyCasing = false)
			where TEnum : Enum
		{
			List<int> flagsAsInts = new List<int>();
			int type = (int)(object)flags;
			for (int i = GetMaxEnumValue<TEnum>() << 1; i > 0; i >>= 1)
			{
				if ((type & i) != 0)
					flagsAsInts.Add(i);
			}

			return flagsAsInts.Select(f => useUserFriendlyCasing ? ((TEnum)(object)f).ToString() : ((TEnum)(object)f).ToString()).ToArray();
		}

		public static string[] GetEnumNamesWithValues<TEnum>()
			where TEnum : Enum
			=> ((TEnum[])Enum.GetValues(typeof(TEnum))).Select(e => $"{e} = {(int)(object)e}").ToArray();

		public static int GetMaxEnumValue<TEnum>()
			where TEnum : Enum
			=> Enum.GetValues(typeof(TEnum)).Cast<int>().Max();
	}
}