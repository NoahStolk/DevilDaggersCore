using DevilDaggersCore.Tools.Website;
using DevilDaggersCore.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;

namespace DevilDaggersCore.Tools
{
	public sealed class VersionHandler
	{
		/// <summary>
		/// Timeout in milliseconds.
		/// </summary>
		private const int timeout = 7500;

		public VersionResult VersionResult { get; private set; } = new VersionResult(null, null, new Exception("Version has not yet been retrieved."));

		private static readonly Lazy<VersionHandler> lazy = new Lazy<VersionHandler>(() => new VersionHandler());
		public static VersionHandler Instance => lazy.Value;

		private VersionHandler()
		{
		}

		public static Version GetLocalVersion(Assembly assembly) => Version.Parse(FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion);

		public void GetOnlineVersion(string toolName, Version localVersion)
		{
			string url = UrlUtils.ApiGetTools;
			try
			{
				string downloadString = string.Empty;
				using (TimeoutWebClient client = new TimeoutWebClient(timeout))
					downloadString = client.DownloadString(url);
				List<Tool> tools = JsonConvert.DeserializeObject<List<Tool>>(downloadString);

				Tool toolOnline = tools.FirstOrDefault(t => t.Name == toolName);
				if (toolOnline != null)
					VersionResult = new VersionResult(toolOnline.VersionNumber <= localVersion, toolOnline);
				else
					VersionResult = new VersionResult(null, null, new Exception($"{toolName} not found in '{url}'."));
			}
			catch (WebException ex)
			{
				VersionResult = new VersionResult(null, null, new Exception($"Could not connect to '{url}'.", ex));
			}
			catch (Exception ex)
			{
				VersionResult = new VersionResult(null, null, new Exception($"An unexpected error occurred while trying to retrieve the version number for '{toolName}' from '{url}'.", ex));
			}
		}
	}
}