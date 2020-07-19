using System;

namespace DevilDaggersCore.Website
{
	public class TaskResult
	{
		public TaskResult(string typeName, DateTime lastTriggered, DateTime lastFinished, TimeSpan executionTime, string schedule)
		{
			TypeName = typeName;
			LastTriggered = lastTriggered;
			LastFinished = lastFinished;
			ExecutionTime = executionTime;
			Schedule = schedule;
		}

		public string TypeName { get; private set; }
		public DateTime LastTriggered { get; private set; }
		public DateTime LastFinished { get; private set; }
		public TimeSpan ExecutionTime { get; private set; }
		public string Schedule { get; private set; }
	}
}