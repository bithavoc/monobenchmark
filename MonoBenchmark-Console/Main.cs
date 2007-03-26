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
		static TestSession session;
		public static void Main(string[] args)
		{
			bg("Creating Session");
			
			session = new TestSession();
			session.LoadFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
			bg("Session Created");
			bg("Session Has Fixtures?=" + session.HasFixtures);
			session.Finalized+=delegate
			{
				debug.writeln("Finalizing...");
				                           
				foreach(TimeFixtureResult fixResult in session.TestResult.Result)
				{
					Console.WriteLine("Fixture {0}",fixResult.Fixture.FixtureType.Name);
					foreach(TestTimeResult testResult in fixResult.TestsResult)
					{
						Console.WriteLine("Test:{0}\n\tTime:{1},",testResult.TestInfo.Method.Name,testResult.Time.ToString());
					}					
				}
				debug.writeln("Finalized");
			};
			session.Run();
			Console.ReadLine();
		}
	}
}