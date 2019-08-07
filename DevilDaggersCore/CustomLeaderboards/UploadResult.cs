namespace DevilDaggersCore.CustomLeaderboards
{
	public class UploadResult
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public int TryCount { get; set; }

		public UploadResult(bool success, string message, int tryCount = 0)
		{
			Success = success;
			Message = message;
			TryCount = tryCount;
		}
	}
}