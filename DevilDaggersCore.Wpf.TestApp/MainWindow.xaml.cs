using DevilDaggersCore.Wpf.Windows;
using System.Windows;

namespace DevilDaggersCore.Wpf.TestApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DebugWindow dw = new();
			dw.ShowDialog();
		}
	}
}
