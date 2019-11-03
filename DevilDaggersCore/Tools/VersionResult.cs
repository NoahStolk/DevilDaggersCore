using System;
using DevilDaggersCore.Tools.Website;

namespace DevilDaggersCore.Tools
{
	public class VersionResult
	{
		/// <summary>
		/// True if the application is up to date, false if not, null if not known.
		/// </summary>
		public bool? IsUpToDate { get; set; }

		/// <summary>
		/// The Tool retrieved from the website, or null if failed.
		/// </summary>
		public Tool Tool { get; set; }

		/// <summary>
		/// The Exception that occurred if attempting to retrieve the version number failed.
		/// </summary>
		public Exception Exception { get; set; }

		public VersionResult(bool? isUpToDate, Tool tool, Exception exception = null)
		{
			IsUpToDate = isUpToDate;
			Tool = tool;
			Exception = exception;
		}
	}
}