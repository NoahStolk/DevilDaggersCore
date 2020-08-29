using System.Windows;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class ConfirmWindow : Window
	{
		public ConfirmWindow(string title, string question, bool includeDoNotAskAgainCheckBox)
		{
			InitializeComponent();

			Title = title;
			Question.Text = question;
			if (includeDoNotAskAgainCheckBox)
				DoNotAskAgainCheckBox.Visibility = Visibility.Visible;
		}

		public bool IsConfirmed { get; set; }
		public bool DoNotAskAgain { get; set; }

		private void YesButton_Click(object sender, RoutedEventArgs e)
		{
			IsConfirmed = true;
			DoNotAskAgain = DoNotAskAgainCheckBox.IsChecked ?? false;
			Close();
		}

		private void NoButton_Click(object sender, RoutedEventArgs e)
			=> Close();
	}
}