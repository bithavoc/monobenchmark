using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Core
{
	public class TestSession
	{	
		private List<TimeFixtureInfo> fixtures;
		public TestSession()
		{
			this.fixtures = new List<Core.TimeFixtureInfo>();
		}
		public void LoadFromAssembly(string assemblyPath)
		{
			//Check file.
			if(!System.IO.File.Exists(assemblyPath))
			{
				throw new ArgumentException(string.Format("Assembly '{0}' does not exists",assemblyPath));
			}
			
			Assembly asm = Assembly.LoadFile(assemblyPath);
			Type[] types = asm.GetTypes();
			
			//Search for fixtures.
			foreach(Type type in types)
			{
				Framework.TimeFixtureAttribute[] timeFixtures =
					(Framework.TimeFixtureAttribute[])type.GetCustomAttributes(typeof(Framework.TimeFixtureAttribute),true);
				if(timeFixtures.Length == 0)
					continue; //skip this class, is not a fixture.
				
				Framework.TimeFixtureAttribute fixtureAtt = timeFixtures[0];
				
				//Create a instance in order to hold fixture information.
				TimeFixtureInfo fixtureInfo = new TimeFixtureInfo(fixtureAtt,type);
				
				//Add the fixture info to the fixtures list.
				this.fixtures.Add(fixtureInfo);
			}//foreach
			
		}
	}
}
