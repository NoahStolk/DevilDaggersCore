using System;
using System.Globalization;

namespace DevilDaggersCore.Utils
{
	public static class HistoryUtils
	{
		public static DateTime HistoryJsonFileNameToDateTime(string dateString)
		{
			int year = int.Parse(dateString.Substring(0, 4), CultureInfo.InvariantCulture);
			int month = int.Parse(dateString.Substring(4, 2), CultureInfo.InvariantCulture);
			int day = int.Parse(dateString.Substring(6, 2), CultureInfo.InvariantCulture);
			int hour = int.Parse(dateString.Substring(8, 2), CultureInfo.InvariantCulture);
			int minute = int.Parse(dateString.Substring(10, 2), CultureInfo.InvariantCulture);

			if (dateString.Length == 14)
			{
				int second = int.Parse(dateString.Substring(12, 2), CultureInfo.InvariantCulture);
				return new DateTime(year, month, day, hour, minute, second);
			}

			return new DateTime(year, month, day, hour, minute, 0);
		}

		public static string DateTimeToHistoryJsonFileName(DateTime dateTime)
			=> $"{dateTime.Year:0000}{dateTime.Month:00}{dateTime.Day:00}{dateTime.Hour:00}{dateTime.Minute:00}";
	}
}
