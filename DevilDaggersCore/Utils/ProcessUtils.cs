using System.Diagnostics;

namespace DevilDaggersCore.Utils
{
	public static class ProcessUtils
	{
		private const string _processNameToFind = "dd";
		private const string _processMainWindowTitle = "Devil Daggers";

		public static Process? GetDevilDaggersProcess()
		{
			foreach (Process process in Process.GetProcessesByName(_processNameToFind))
			{
				if (process.MainWindowTitle == _processMainWindowTitle)
					return process;
			}

			return null;
		}

		public static void OpenUrl(string url)
			=> Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
	}
}
