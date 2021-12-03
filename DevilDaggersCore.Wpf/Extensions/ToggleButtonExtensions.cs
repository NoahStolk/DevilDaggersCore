using System.Windows.Controls.Primitives;

namespace DevilDaggersCore.Wpf.Extensions;

public static class ToggleButtonExtensions
{
	public static bool IsChecked(this ToggleButton toggleButton)
		=> toggleButton.IsChecked == true;
}
