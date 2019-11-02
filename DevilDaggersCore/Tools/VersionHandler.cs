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

		private VersionHandler()
		{
		}

		public Version GetLocalVersion(Assembly assembly)
		{
			return Version.Parse(FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion);
		}

		public VersionResult GetOnlineVersion(string toolName, Version localVersion)
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
					return new VersionResult(toolOnline.VersionNumber <= localVersion, toolOnline);
				else
					return Error(new Exception($"{toolName} not found in '{url}'."));
			}
			catch (WebException ex)
			{
				return Error(new Exception($"Could not connect to '{url}'.", ex));
			}
			catch (Exception ex)
			{
				return Error(new Exception($"An unexpected error occurred while trying to retrieve the version number for '{toolName}' from '{url}'.", ex));
			}

			VersionResult Error(Exception ex = null)
			{
				return new VersionResult(null, null, ex);
			}
		}
	}
}