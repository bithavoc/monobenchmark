using System;
using System.Collections.Generic;

namespace MonoBenchmark.Core
{
	public class MethodTimeResult
	{
		private List<TestTimeResult> results;
		private TestMethodInfo testInfo;

		public MethodTimeResult(TestMethodInfo info)
		{
			this.results = new List<TestTimeResult>();
			this.testInfo = info;
		}

		public List<TestTimeResult> Results
		{
			get
			{
				return this.results;
			}
		}

		public TestMethodInfo TestInfo
		{
			get
			{
				return this.testInfo;
			}
		}
	}
}
