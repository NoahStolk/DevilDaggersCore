using System.Diagnostics;

namespace DevilDaggersCore.Utils
{
	public static class ProcessUtils
	{
		private const string processNameToFind = "dd";
		private const string processMainWindowTitle = "Devil Daggers";

		public static Process? GetDevilDaggersProcess()
		{
			foreach (Process process in Process.GetProcessesByName(processNameToFind))
			{
				if (process.MainWindowTitle == processMainWindowTitle)
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