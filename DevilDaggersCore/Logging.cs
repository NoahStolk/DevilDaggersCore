using log4net;
using System.Reflection;

namespace DevilDaggersCore
{
	public static class Logging
	{
		public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}