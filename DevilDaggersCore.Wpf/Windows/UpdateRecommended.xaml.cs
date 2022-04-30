using System.Diagnostics;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows;

public partial class UpdateRecommendedWindow : Window
{
	private readonly string _fullDownloadUrl;
	private readonly string _applicationDisplayName;

	public UpdateRecommendedWindow(string onlineVersion, string localVersion, string fullDownloadUrl, string applicationDisplayName)
	{
		_fullDownloadUrl = fullDownloadUrl;
		_applicationDisplayName = applicationDisplayName;

		InitializeComponent();

		Text.Content = $"{_applicationDisplayName} {onlineVersion} is available. The current version is {localVersion}.";
	}

	private void DownloadButton_Click(object sender, RoutedEventArgs e)
	{
		Process.Start(new ProcessStartInfo(_fullDownloadUrl) { UseShellExecute = true });
		Close();
	}
}
