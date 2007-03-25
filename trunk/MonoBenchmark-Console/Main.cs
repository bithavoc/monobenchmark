// project created on 3/25/2007 at 7:12 PM
using System;
using MonoBenchmark;
using MonoBenchmark.Core;
using MonoBenchmark.Framework;

namespace MonoBenchmarkConsole
{
	class MainClass
	{
		static void bg(string val)
		{
			Console.WriteLine(val);
		}
		public static void Main(string[] args)
		{
			bg("Creating Session");
			
			TestSession session = new TestSession();
			session.LoadFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
			bg("Session Created");
			bg("Session Has Fixtures?=" + session.HasFixtures);
			
			
			
			
			bg("Ending Session");
			
		}
	}
}