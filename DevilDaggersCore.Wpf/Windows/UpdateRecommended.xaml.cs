using DevilDaggersCore.Utils;
using System.Windows;

namespace DevilDaggersCore.Wpf.Windows;

public partial class UpdateRecommendedWindow : Window
{
	private readonly string _applicationName;
	private readonly string _applicationDisplayName;

	public UpdateRecommendedWindow(string onlineVersion, string localVersion, string applicationName, string applicationDisplayName)
	{
		_applicationName = applicationName;
		_applicationDisplayName = applicationDisplayName;

		InitializeComponent();

		Text.Content = $"{_applicationDisplayName} {onlineVersion} is available. The current version is {localVersion}.";
	}

	private void DownloadButton_Click(object sender, RoutedEventArgs e)
	{
		ProcessUtils.OpenUrl(UrlUtils.ApiGetTool(_applicationName));
		Close();
	}
}
