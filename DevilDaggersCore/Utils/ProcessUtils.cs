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

#pragma warning disable CA1054 // Uri parameters should not be strings

		public static void OpenUrl(string url)
			=> Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

#pragma warning restore CA1054 // Uri parameters should not be strings
	}
}
