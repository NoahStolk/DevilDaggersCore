using System;

namespace DevilDaggersCore.Extensions
{
	public static class EnumExtensions
	{
		public static bool HasFlagBothWays<TEnum>(this TEnum a, TEnum b)
			where TEnum : Enum
			=> a.HasFlag(b) || b.HasFlag(a);
	}
}
