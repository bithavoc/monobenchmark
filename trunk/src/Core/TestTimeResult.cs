
using System;

namespace MonoBenchmark.Core
{
	public class TestTimeResult
	{
		private DateTime startTime;
		private DateTime endTime;
		private TimeSpan time;
		private TestMethodInfo methodInfo;
		public TestTimeResult(TestMethodInfo methodInfo,DateTime startTime,DateTime endTime,TimeSpan time)
		{
			this.methodInfo = methodInfo;
			this.startTime = startTime;
			this.endTime = endTime;
			this.time = time;
		}
		public TestMethodInfo TestInfo
		{
			get{
				return this.methodInfo;
			}
		}
		
		public  DateTime StartTime
		{
			get{
				return this.startTime;
			}
		}
		public  DateTime EndTime
		{
			get{
				return this.endTime;
			}
		}
		public TimeSpan Time
		{
			get{
			return this.time;
			}
		}
	}
}
