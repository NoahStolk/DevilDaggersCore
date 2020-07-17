using System;

namespace DevilDaggersCore.Extensions
{
	public static class StringExtensions
	{
		public static string Reverse(this string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);

			return new string(charArray);
		}
	}
}