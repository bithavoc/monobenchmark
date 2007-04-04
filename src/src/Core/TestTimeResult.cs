
using System;

namespace MonoBenchmark.Core
{
	public class TestTimeResult
	{
		private DateTime startTime;
		private DateTime endTime;
		private TimeSpan time;
		private MethodTimeResult methodResult;
		private int index;
		public TestTimeResult(int index,MethodTimeResult methodResult,DateTime startTime,DateTime endTime,TimeSpan time)
		{
			this.index = index;
			this.methodResult = methodResult;
			this.startTime = startTime;
			this.endTime = endTime;
			this.time = time;
		}

		public MethodTimeResult TestResult
		{
			get
			{
				return this.methodResult;
			}
		}
		
		public  DateTime StartTime
		{
			get
			{
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
		public int Index
		{
			get{
				return this.index;
			}
		}
	}
}
