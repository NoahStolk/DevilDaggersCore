using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Website
{
	public class WebStatsResult
	{
		public WebStatsResult(DateTime buildDateTime, List<TaskResult> taskResults)
		{
			WebsiteBuildDateTime = buildDateTime;
			TaskResults = taskResults;
		}

		public DateTime WebsiteBuildDateTime { get; }
		public List<TaskResult> TaskResults { get; }
	}
}