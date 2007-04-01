using System;
using MonoBenchmark;

using MonoBenchmark.Framework; //That's it.

namespace MonoBenchmarkConsole
{
#if DEBUG
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

//		int u_val = 0;
const int SLEEP_VAL = 5000;
		[TimeCount(Workers=1000)]
		public void Retardado()
		{
//		u_val+=10;
//		int val = SLEEP_VAL + u_val;
		int val = SLEEP_VAL;
		 global::System.Console.WriteLine("Probando al retardado");
			System.Threading.Thread.Sleep(val);
		}
	}
#endif
}
