using System;

namespace DevilDaggersCore.Extensions
{
	public static class StringExtensions
	{
		public static string TrimEnd(this string s, string value)
		{
			if (!s.EndsWith(value, StringComparison.InvariantCulture))
				return s;

			return s.Remove(s.LastIndexOf(value, StringComparison.InvariantCulture));
		}

		public static string Reverse(this string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);

			return new string(charArray);
		}
	}
}