using System;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class DebugWindow : Window
	{
		public DebugWindow()
		{
			InitializeComponent();

			TestExceptionButton.Click += (sender, e) => throw new Exception("Test exception");

			ShowMessageButton.Click += (sender, e) =>
			{
				MessageWindow messageWindow = new MessageWindow("Test title", "Test message");
				messageWindow.ShowDialog();
			};

			ShowConfirmationButton.Click += (sender, e) =>
			{
				ConfirmWindow confirmWindow = new ConfirmWindow("Test confirm", "Confirm?", true);
				confirmWindow.ShowDialog();
			};
		}
	}
}