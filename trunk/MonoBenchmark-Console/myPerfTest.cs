using System;
using MonoBenchmark;

using MonoBenchmark.Framework; //That's it.

namespace MonoBenchmarkConsole
{
	[TimeFixture]
	public class myPerfTest
	{
		public myPerfTest()
		{
			
		}
		
		[TimeCount]
		public void PruebaUno()
		{
		 global::System.Console.WriteLine("what the matter??");
		}
		
		[TimeCount]
		public void PruebaDos()
		{
		 global::System.Console.WriteLine("what the matter TWO??");
			System.Threading.Thread.Sleep(2000);
		}
	}
}
