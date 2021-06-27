using System;

namespace DevilDaggersCore.Extensions
{
	public static class StringExtensions
	{
		public static string TrimEnd(this string s, string value)
		{
			if (!s.EndsWith(value))
				return s;

			return s.Remove(s.LastIndexOf(value));
		}

		public static string Reverse(this string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);

			return new string(charArray);
		}

		public static string TrimAfter(this string s, int count, bool includeThreePeriods = false)
		{
			if (s.Length <= count)
				return s;

			string subString = s.Substring(0, count);
			return includeThreePeriods ? $"{subString}..." : subString;
		}
	}
}
