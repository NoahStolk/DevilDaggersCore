using System;
using System.ComponentModel;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class CheckingForUpdatesWindow : Window
	{
		public CheckingForUpdatesWindow(Func<bool> getOnlineToolFunction)
		{
			InitializeComponent();

			using BackgroundWorker thread = new BackgroundWorker();
			thread.DoWork += (sender, e) => getOnlineToolFunction();
			thread.RunWorkerCompleted += (sender, e) => Close();

			thread.RunWorkerAsync();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
			=> Close();
	}
}
