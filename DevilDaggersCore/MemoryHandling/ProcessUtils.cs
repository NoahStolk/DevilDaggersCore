using System.Diagnostics;

namespace DevilDaggersCore.MemoryHandling
{
	public static class ProcessUtils
	{
		private const string ProcessNameToFind = "dd";
		private const string ProcessMainWindowTitle = "Devil Daggers";

		public static Process GetDevilDaggersProcess()
		{
			foreach (Process process in Process.GetProcessesByName(ProcessNameToFind))
				if (process.MainWindowTitle == ProcessMainWindowTitle)
					return process;
			return null;
		}
	}
}