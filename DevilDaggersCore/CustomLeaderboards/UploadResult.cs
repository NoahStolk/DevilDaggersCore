namespace DevilDaggersCore.CustomLeaderboards
{
	public class UploadResult
	{
		public UploadResult(bool success, string message, int tryCount = 0, SubmissionInfo submissionInfo = null)
		{
			Success = success;
			Message = message;
			TryCount = tryCount;
			SubmissionInfo = submissionInfo;
		}

		public bool Success { get; set; }
		public string Message { get; set; }
		public int TryCount { get; set; }
		public SubmissionInfo SubmissionInfo { get; set; }
	}
}