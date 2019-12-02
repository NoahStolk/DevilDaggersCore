using System;
using System.Collections.Generic;

namespace DevilDaggersCore.Website
{
	public class WebStatsResult
	{
		public DateTime WebsiteBuildDateTime { get; set; }
		public List<TaskResult> TaskResults { get; set; }

		public WebStatsResult(DateTime buildDateTime, List<TaskResult> taskResults)
		{
			WebsiteBuildDateTime = buildDateTime;
			TaskResults = taskResults;
		}
	}
}