using DevilDaggersCore.Wpf.Utils;
using System;
using System.Windows;
using System.Windows.Media;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class DebugWindow : Window
	{
		public DebugWindow()
		{
			InitializeComponent();

			LabelSuccess.Foreground = new SolidColorBrush(ColorUtils.ColorSuccess);
			LabelSuggestion.Foreground = new SolidColorBrush(ColorUtils.ColorSuggestion);
			LabelWarning.Foreground = new SolidColorBrush(ColorUtils.ColorWarning);
			LabelError.Foreground = new SolidColorBrush(ColorUtils.ColorError);

			TestExceptionButton.Click += (sender, e) => throw new Exception("Test exception");

			ShowMessageButton.Click += (sender, e) =>
			{
				MessageWindow messageWindow = new MessageWindow("Test title", "Test message");
				messageWindow.ShowDialog();
			};
		}
	}
}