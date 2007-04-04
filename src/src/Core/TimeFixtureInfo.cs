
using System;
using  MonoBenchmark.Framework;
using System.Reflection;
using System.Collections.Generic;

namespace  MonoBenchmark.Core
{
	//Information about a TimeFixture class.
	public sealed class TimeFixtureInfo
	{
		private TimeFixtureAttribute attribute;
		private Type fixtureType;
		private ConstructorInfo constructor;
		private List<TestMethodInfo> methods;
		private object fixtureInstance;
		private int pendingForFinalize =0;
		private object pendingForFinalizeLock = new Object();
		private TestSession session;
		private List<MethodTimeResult> testResult = null;
		private string fixtureName;
		internal TimeFixtureInfo(TestSession session,TimeFixtureAttribute attribute,
		                       Type fixtureType,ConstructorInfo constructor)
		{
			this.session = session;
			this.attribute = attribute;
			this.fixtureType = fixtureType;
			this.fixtureName = this.fixtureType.Name;
			this.constructor = constructor;
			this.methods = new List<TestMethodInfo>();
		}
		
		public string Name
		{
			get{
				return this.fixtureName;
			}
		}
		
		internal void initInstance()
		{
			this.fixtureInstance = Activator.CreateInstance(this.fixtureType);
		}
		
		public object FixtureInstance
		{
			get
			{
				return this.fixtureInstance;
			}
		}
		
		internal void addMethod(TestMethodInfo method)
		{
			this.methods.Add(method);
		}
		
		public TimeFixtureAttribute Attribute
		{
			get
			{
				return this.attribute;
			}
		}
		public Type FixtureType
		{
			get
			{
				return this.fixtureType;
			}
		}
		
		public ConstructorInfo @Constructor
		{
			get
			{
				return constructor;
			}
		}
		private int PendingForFinalize
		{
			get
			{
				lock(this.pendingForFinalizeLock)
					return this.pendingForFinalize;
			}set
			{
				lock(this.pendingForFinalizeLock)
					this.pendingForFinalize = value;
			}
		}
		private TimeFixtureResult result;
		public TimeFixtureResult Result
		{
			get
			{
				return this.result;
			}
		}
		
		internal void notifyWorkerFinalization(TestingWorker worker)
		{
			int pending = --this.PendingForFinalize;
			testResult.Add(worker.TestResult);
			debug.writeln("Pendings for finalizing in {0}:{1}",this.FixtureType.FullName,pending.ToString());
			if(pending == 0)
			{
				finalizeTest();
			}
		}
		
		void finalizeTest()
		{
			result = new TimeFixtureResult(this,testResult);
			this.session.notifyFixtureFinalized(this);
		}
		
		public void Run()
		{
			testResult = new List<MethodTimeResult>();
			
			//All the methods are pending for finalize.
			PendingForFinalize = this.methods.Count;
			foreach(TestMethodInfo method in this.methods)
			{
				TestingWorker worker = TestingWorker.createForSession(this,method);
				worker.Run();
			}
		}
	}
}
