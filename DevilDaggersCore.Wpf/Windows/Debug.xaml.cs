using DevilDaggersCore.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class DebugWindow : Window
	{
		public DebugWindow()
		{
			InitializeComponent();

			TestExceptionButton.Click += (sender, e) => throw new Exception("Test exception");

			ShowChangelogButton.Click += (sender, e) => ShowWindow(new ChangelogWindow(new List<ChangelogEntry> { new ChangelogEntry(new Version(1, 0, 0, 0), DateTime.Now, new List<Change> { new Change("Initial release", new List<Change> { new Change("Test", null) }) }) }, new Version(1, 0, 0, 0)));

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
