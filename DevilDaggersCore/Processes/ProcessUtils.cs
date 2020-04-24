using System.Diagnostics;

namespace DevilDaggersCore.Processes
{
	public static class ProcessUtils
	{
		private const string processNameToFind = "dd";
		private const string processMainWindowTitle = "Devil Daggers";

		public static Process GetDevilDaggersProcess()
		{
			foreach (Process process in Process.GetProcessesByName(processNameToFind))
				if (process.MainWindowTitle == processMainWindowTitle)
					return process;
			return null;
		}
	}
}