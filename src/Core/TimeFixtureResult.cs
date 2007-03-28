
using System;
using System.Collections.Generic;

namespace MonoBenchmark.Core
{
	public class TimeFixtureResult
	{
		private List<TestTimeResult> results;
		private TimeFixtureInfo fixture;
		public TimeFixtureResult(TimeFixtureInfo fixture, List<TestTimeResult> result)
		{
			this.results = result; 
			this.fixture = fixture;
		}
		public TimeFixtureInfo Fixture
		{
			get
			{
				return this.fixture;
			}
		}
		public List<TestTimeResult> TestsResult
		{
			get
			{
				return this.results;
			}
		}
	}
}
