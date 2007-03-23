using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using MonoBenchmark.Framework;


namespace MonoBenchmark.Core
{
	public class TestSession
	{	
		private List<TimeFixtureInfo> fixtures;
		public TestSession()
		{
			this.fixtures = new List<Core.TimeFixtureInfo>();
		}
		
		//Get if there is fixtures in this session.
		public bool HasFixtures
		{
			get
			{
				return this.fixtures.Count != 0;
			}
		}
		public void LoadFromAssembly(string assemblyPath)
		{
			//Check file.
			if(!System.IO.File.Exists(assemblyPath))
			{
				throw new ArgumentException(string.Format("Assembly '{0}' does not exists",assemblyPath));
			}
			
			Assembly asm = Assembly.LoadFile(assemblyPath);
			LoadFromAssembly(asm);
		}
		public void LoadFromAssembly(Assembly asm)
		{
			Type[] types = asm.GetTypes();
			
			//Search for fixtures.
			foreach(Type type in types)
			{
				Framework.TimeFixtureAttribute[] timeFixtures =
					(Framework.TimeFixtureAttribute[])type.GetCustomAttributes(typeof(Framework.TimeFixtureAttribute),true);
				if(timeFixtures.Length == 0)
					continue; //skip this class, is not a fixture.
				
				Framework.TimeFixtureAttribute fixtureAtt = timeFixtures[0];
				
				ConstructorInfo ctor = checkTypeCtor(type);
				
				//Create a instance in order to hold fixture information.
				TimeFixtureInfo fixtureInfo = new TimeFixtureInfo(fixtureAtt,type,ctor);
				FillTestMethods(fixtureInfo);
				//Add the fixture info to the fixtures list.
				this.fixtures.Add(fixtureInfo);
			}//foreach
		}
		
		static void FillTestMethods(TimeFixtureInfo fixtureInfo)
		{
			Type fixType = fixtureInfo.FixtureType;
			MethodInfo[] methods = fixType.GetMethods();
			foreach(MethodInfo method in methods)
			{
				TestMethodInfo methodInfo = getMethodInfo(method);
				if(methodInfo != null)
					fixtureInfo.addMethod(methodInfo);
			}
		}
		
		//Returns null if the method is not test. Throws exception if the test method is not well formed.
		//Returns a instance if the testmethod is ok.
		static TestMethodInfo getMethodInfo(MethodInfo method)
		{
			bool isTest;
			
			TimeCountAttribute[] timeAtts =  (TimeCountAttribute[])method.GetCustomAttributes(typeof(TimeCountAttribute),true);
			isTest = timeAtts.Length != 0;
			
			if(!isTest) return null;//skip this method.
			
			bool isPublic = method.IsPublic;
			bool returnTypeIsVoid = method.ReturnType.FullName == "System.Void";
			
			if(!(isPublic && returnTypeIsVoid))
				throw new ApplicationException(string.Format("Test Method {0} must be public and returns Void",method.Name));
			
			TestMethodInfo testInfo = new TestMethodInfo(method,timeAtts[0]);
			return testInfo;
		}
		
		static ConstructorInfo checkTypeCtor(Type target)
		{
			//1) Ctor must be default.
			//2) Accesible.(public)
			ConstructorInfo[] ctors = target.GetConstructors();
			foreach(ConstructorInfo ctor in ctors)
			{
				//Rule 1
				bool isPublic =ctor.IsPublic;
				
				//Rule 2
				bool isZeroParams = ctor.GetParameters().Length == 0;
				
				if(isPublic && isZeroParams)
				{
					return ctor;
				}
			}
			throw new ApplicationException(string.Format("No suitable constructor found for type {0}",target.FullName));
		}
		
	}
}
