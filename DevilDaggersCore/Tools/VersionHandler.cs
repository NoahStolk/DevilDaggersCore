using DevilDaggersCore.Website.Models;
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
		private const int Timeout = 7500;

		private static readonly Lazy<VersionHandler> lazy = new Lazy<VersionHandler>(() => new VersionHandler());
		public static VersionHandler Instance => lazy.Value;

		public VersionResult VersionResult { get; private set; } = new VersionResult(null, null, new Exception("Version has not yet been retrieved."));

		private VersionHandler()
		{
		}

		public static Version GetLocalVersion(Assembly assembly)
		{
			return Version.Parse(FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion);
		}

		public void GetOnlineVersion(string toolName, Version localVersion)
		{
			string url = UrlUtils.ApiGetTools;
			try
			{
				string downloadString = string.Empty;
				using (TimeoutWebClient client = new TimeoutWebClient(Timeout))
					downloadString = client.DownloadString(url);
				List<Tool> tools = JsonConvert.DeserializeObject<List<Tool>>(downloadString);

				Tool toolOnline = tools.Where(t => t.Name == toolName).FirstOrDefault();
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