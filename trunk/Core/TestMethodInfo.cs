using System;
using System.Reflection;
using MonoBenchmark.Framework;

namespace MonoBenchmark.Core
{
	//Information about a test method.
	public class TestMethodInfo
	{
		private MethodInfo method;
		private TimeCountAttribute timeCountAtt;
		
		public TestMethodInfo(MethodInfo method, TimeCountAttribute timeCountAtt)
		{
			this.method = method;
			this.timeCountAtt = timeCountAtt;
		}
		public MethodInfo Method
		{
			get{
				return this.method;
			}
		}
		public TimeCountAttribute TimeCount
		{
			get
			{
				return this.timeCountAtt;
			}
		}
	}
}
