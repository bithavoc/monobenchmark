using System;
using System.Collections.Generic;

namespace MonoBenchmark.Core
{
	public class SessionCompareResult
	{
		private string name;
		private List<SessionCompareResult> childs = null;
		public SessionCompareResult(string name)
		{
			this.name = name;
		}
		public IEnumerable<SessionCompareResult> Childs
		{
			get
			{
				return this.childs;
			}
		}
		public string Name
		{
			get
			{
				return this.name;
			}
		}
	}
}
