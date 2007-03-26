// project created on 3/25/2007 at 7:12 PM
using System;
using MonoBenchmark;
using MonoBenchmark.Core;
using MonoBenchmark.Framework;

using System.Reflection;

namespace MonoBenchmarkConsole
{
	
	public class MainClass
	{
		public const string ApplicationVersion = "0.1.0.0";
		public const string ApplicationDescription = "MonoBenchmark";
		

		static TestSession session;
		public static void Main(string[] args)
		{
			ShowIntro();
			debug.writeln("Creating Session");
			
			session = new TestSession();
			session.LoadFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
			debug.writeln("Session Created");
			debug.writeln("Session Has Fixtures?=" + session.HasFixtures);
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
		
		static void ShowIntro()
		{
			Console.WriteLine("{0} {1} - Johan.Hernandez <thepumpkin1979@gmail.com>",ApplicationDescription,ApplicationVersion);
		}
	}
}