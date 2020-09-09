using System;
using System.Windows.Media;

namespace DevilDaggersCore.Wpf.Utils
{
	public static class ColorUtils
	{
		public static Color ColorSuccess { get; } = Color.FromRgb(0, 127, 63);
		public static Color ColorSuggestion { get; } = Color.FromRgb(127, 127, 0);
		public static Color ColorWarning { get; } = Color.FromRgb(191, 63, 0);
		public static Color ColorError { get; } = Color.FromRgb(255, 0, 0);

		/// <summary>
		/// Returns an integer between 0 and 255 representing the perceived brightness of the color.
		/// </summary>
		/// <param name="c">The color.</param>
		/// <returns>The perceived brightness between 0 and 255.</returns>
		public static int GetPerceivedBrightness(Color c)
			=> (int)Math.Sqrt(
				c.R * c.R * 0.299 +
				c.G * c.G * 0.587 +
				c.B * c.B * 0.114);
	}
}