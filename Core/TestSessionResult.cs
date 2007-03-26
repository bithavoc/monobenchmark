
using System;
using System.Collections.Generic;

namespace MonoBenchmark.Core
{
	public class TestSessionResult
	{
		private List<TimeFixtureResult> result;  
		
		public TestSessionResult( List<TimeFixtureResult> result)
		{
			this.result = result;
		}
		
		public List<TimeFixtureResult> Result
		{
			get
			{
				lock(this)
				{
				return this.result;
				}
			}
		}
	}
}
