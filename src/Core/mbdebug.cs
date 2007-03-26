
using System;

namespace MonoBenchmark.Core
{
#if DEBUG
	public class debug
	{
		
		public debug()
		{
		}
		
		[System.Diagnostics.ConditionalAttribute("DEBUG")]
		public static void writeln(string format,params object[] @params)
		{
			Console.WriteLine(format,@params);
		}
	}
#endif
}
