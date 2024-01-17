using System.Windows;

namespace DevilDaggersCore.Wpf.Windows;

public partial class DebugWindow : Window
{
	public DebugWindow()
	{
		InitializeComponent();

		TestExceptionButton.Click += (_, _) => throw new("Test exception");

		ShowConfirmButton.Click += (_, _) => ShowWindow(new ConfirmWindow("Test confirm", "Confirm?", true));

		ShowErrorButton.Click += (_, _) => ShowWindow(new ErrorWindow("Test error", "Test error", null));

		ShowMessageButton.Click += (_, _) => ShowWindow(new MessageWindow("Test title", "Test message"));
	}

	private static void ShowWindow(Window window)
		=> window.ShowDialog();
}
