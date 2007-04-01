
using System;
using System.Collections.Generic;

namespace MonoBenchmark.Core
{
	// <summary>
	// A CLR Type Time Fixture Result.
	// <summary>
	public class TimeFixtureResult
	{
		private List<MethodTimeResult> results;
		private TimeFixtureInfo fixture;
		public TimeFixtureResult(TimeFixtureInfo fixture, List<MethodTimeResult> result)
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
		public List<MethodTimeResult> TestsResult
		{
			get
			{
				return this.results;
			}
		}
	}
}
