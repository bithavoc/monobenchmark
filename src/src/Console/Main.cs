// project created on 3/25/2007 at 7:12 PM
using System;
using MonoBenchmark;
using MonoBenchmark.Core;
using MonoBenchmark.Framework;

using System.Reflection;
using System.Xml;

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
			if(args.Length != 2)
			{
				Console.WriteLine("Missing options");
				ShowUsage();
				System.Environment.Exit(1);
			}
			debug.writeln("Creating Session");
			
			session = new TestSession();


			string assemblyName;
			GetArgValue(args[0],out assemblyName);
			if(string.IsNullOrEmpty(assemblyName))
			{
				writeErrorAndExit("Assembly file missing. Use -a:filename.dll");
				ShowUsage();
			}

			if(!System.IO.File.Exists(assemblyName))
			{
				writeErrorAndExit(string.Format("Assembly '{0}' not found",assemblyName));
			}

			string outputFile;
			GetArgValue(args[1],out outputFile);
			if(string.IsNullOrEmpty(outputFile))
			{
				writeErrorAndExit("Output file missing. Use -o:output.xml");
			}
			
			session.LoadFromAssembly(assemblyName);
			if(!session.HasFixtures)
			{
				writeErrorAndExit("The Assembly has not time-fixtures defined. Use another assembly.");
			}

			Console.WriteLine("Loaded Test");
			debug.writeln("Session Created");
			debug.writeln("Session Has Fixtures?=" + session.HasFixtures);
			
			session.Finalized+=delegate
			{
				Console.WriteLine("Test Finalized\n\tSummary:");                     
				foreach(TimeFixtureResult fixResult in session.TestResult.Result)
				{
					Console.WriteLine("\tFixture {0}",fixResult.Fixture.Name);
					foreach(MethodTimeResult mTestResult in fixResult.TestsResult)				
					{
						Console.WriteLine("\t\tTest :{0}",mTestResult.TestInfo.Name);
						foreach(TestTimeResult testResult in mTestResult.Results)
						{
							Console.WriteLine("\t\t\t{0}. Time: {1},",(testResult.Index + 1),testResult.Time.ToString());
						}					
					}
				}
				Console.WriteLine("\tSummary End");
				WriteOutXml(outputFile);
			};
			Console.WriteLine("Running tests, please wait...");
			session.Run();
			Console.ReadLine();
		}
		static void writeErrorAndExit(string error)
		{
			Console.WriteLine("Error: " + error);
			System.Environment.Exit(2);
		}
		static void GetArgValue(string input,out string value)
		{
			value = null;
			string[] split =input.Split(':');

			if(split.Length < 2)
			{
				value= null;
			}
			else
			{
				value = split[1].Trim();
			}
		}
		
		static void ShowUsage()
		{
			const string separador="\t\t";
			Console.WriteLine("Usage Guide");
			Console.WriteLine("-a:tests.dll{0}Assembly with compiled test",separador);
			Console.WriteLine("-o:summary.xml{0}Writes the result to xml for summary or late analisys",separador);
		}
		
		static void ShowIntro()
		{
			Console.WriteLine("{0} {1} - Johan.Hernandez <thepumpkin1979@gmail.com>",ApplicationDescription,ApplicationVersion);
		}
		
		static void WriteOutXml(string filename)
		{
			XmlDocument doc = new XmlDocument();
			XmlElement testSummaryElement = doc.CreateElement("testSummary");
			doc.AppendChild(testSummaryElement);
			
			XmlAttribute asmNameAtt = doc.CreateAttribute("assemblyName");
			asmNameAtt.Value = session.AssemblyName;
			testSummaryElement.Attributes.Append(asmNameAtt);
			
			XmlElement fixturesEle = doc.CreateElement("fixtures");
			testSummaryElement.AppendChild(fixturesEle);
			
			foreach(TimeFixtureResult fixResult in session.TestResult.Result)
			{
				XmlElement fixtureEle = doc.CreateElement("fixture");
				fixturesEle.AppendChild(fixtureEle);
				
				XmlAttribute att = doc.CreateAttribute("name");
				att.Value = fixResult.Fixture.Name;
				fixtureEle.Attributes.Append(att);
				foreach(MethodTimeResult mTestResult in fixResult.TestsResult)				
				{
						XmlElement testEle = doc.CreateElement("test");
						fixtureEle.AppendChild(testEle);
						
						att = doc.CreateAttribute("name");
						att.Value = mTestResult.TestInfo.Name;
						testEle.Attributes.Append(att);
					foreach(TestTimeResult testResult in mTestResult.Results)
					{
						XmlElement timeEle = doc.CreateElement("time");
						testEle.AppendChild(timeEle);
						addAtt(timeEle,"id",testResult.Index.ToString());
						addAtt(timeEle,"startTime",formatDateTimeXml(testResult.StartTime));
						addAtt(timeEle,"endTime",formatDateTimeXml(testResult.EndTime));
						addAtt(timeEle,"time",testResult.Time.ToString());
						
					}		
				}	
			}
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.Encoding = System.Text.Encoding.UTF8;
			using(XmlWriter writer = XmlWriter.Create(filename,settings ))
			{
				doc.WriteContentTo( writer);
				Console.WriteLine("Output '{0}' has been written",filename);
#if DEBUG
				System.Diagnostics.Process.Start("gedit " + filename);
#endif
			}
		}
		
		static string formatDateTimeXml(DateTime time)
		{
			return time.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat); 
		}
		
		static XmlAttribute addAtt(XmlElement element,string name,string value)
		{
			XmlAttribute att = element.OwnerDocument.CreateAttribute(name);
			att.Value = value;
			element.Attributes.Append(att);
			return att;
		}
	}
}
