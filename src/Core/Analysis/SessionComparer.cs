
using System;

namespace MonoBenchmark.Core
{
	public class SessionComparer
	{		
		private TestSessionResult sourceData,targetData;
		public SessionComparer(TestSessionResult source,TestSessionResult target)
		{
			this.sourceData = source;
			this.targetData = target;
		}
		public TestSessionResult Source
		{
			get
			{
				return this.sourceData;
			}
		}
		public TestSessionResult Target
		{
			get
			{
				return this.targetData;
			}
		}
	}
}
