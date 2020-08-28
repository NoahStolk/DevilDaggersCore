using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class CheckingForUpdatesWindow : Window
	{
		public CheckingForUpdatesWindow(Func<Task<bool>> getOnlineToolFunction)
		{
			InitializeComponent();

			using BackgroundWorker thread = new BackgroundWorker();
			thread.DoWork += async (sender, e) => await getOnlineToolFunction();
			thread.RunWorkerCompleted += (sender, e) => Close();

			thread.RunWorkerAsync();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
			=> Close();
	}
}