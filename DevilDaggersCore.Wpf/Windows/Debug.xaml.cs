using System;
using System.Threading.Tasks;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class DebugWindow : Window
	{
		public DebugWindow()
		{
			InitializeComponent();

			TestExceptionButton.Click += (sender, e) => throw new("Test exception");

			ShowChangelogButton.Click += (sender, e) => ShowWindow(new ChangelogWindow(new() { new(new(1, 0, 0, 0), DateTime.Now, new() { new("Initial release", new() { new("Test", null) }) }) }, new(1, 0, 0, 0)));

			ShowCheckingForUpdatesButton.Click += (sender, e) => ShowWindow(new CheckingForUpdatesWindow(SimulateCheckingForUpdates));

			ShowConfirmButton.Click += (sender, e) => ShowWindow(new ConfirmWindow("Test confirm", "Confirm?", true));

			ShowErrorButton.Click += (sender, e) => ShowWindow(new ErrorWindow("Test error", "Test error", null));

			ShowMessageButton.Click += (sender, e) => ShowWindow(new MessageWindow("Test title", "Test message"));

			ShowUpdateRecommendedButton.Click += (sender, e) => ShowWindow(new UpdateRecommendedWindow("1.0.0.1", "1.0.0.0", "TestApp", "Test App"));
		}

		private static void ShowWindow(Window window)
			=> window.ShowDialog();

		private static bool SimulateCheckingForUpdates()
		{
			Task.Delay(1000).Wait();

			return true;
		}
	}
}
