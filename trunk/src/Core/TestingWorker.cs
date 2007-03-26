using System;
using System.Threading;

namespace MonoBenchmark.Core
{
	public class TestingWorker
	{
		//private TestingWorkerState state;
		private TimeFixtureInfo fixture;
		private TestMethodInfo testInfo;
		
		private TestingWorker(TimeFixtureInfo fixture,TestMethodInfo testInfo)
		{
			this.fixture = fixture;
			this.testInfo = testInfo;
		}
		
		internal static TestingWorker createForSession(TimeFixtureInfo fixture,TestMethodInfo testInfo)
		{
			TestingWorker worker = new TestingWorker(fixture,testInfo);
			return worker;
		}
		private TestTimeResult testResult;
		public TestTimeResult TestResult
		{
			get{
				return this.testResult;
			}
		}
		public void Run()
		{
			DateTime startTime = DateTime.Now;
			ThreadPool.QueueUserWorkItem(delegate
            {
				for(uint invokeCount =0;invokeCount < this.testInfo.TimeCount.InvokeTimes; invokeCount++)
				{
					this.testInfo.Method.Invoke(this.fixture.FixtureInstance,null);
				}
		
				//Calculate Time
				DateTime endTime = DateTime.Now;
				TimeSpan time = endTime - startTime;
				testResult = new TestTimeResult(this.testInfo,startTime,endTime,time);
				//debug.writeln("Worker ends!,Time={0}",time.ToString());
				this.fixture.notifyWorkerFinalization(this); //I have finished.
				//debug.writeln("After Notify!");
			});
		}
		
		/*public TestingWorkerState State
		{
			get
			{
				return this.state;
			}
		}*/
		/*
		public class StateChangedEventArgs
		{
			//TODO: Readonly Property.
			public readonly TestingWorkerState State;
		}
		
		public delegate void StateChangedEventHandler(TestingWorker worker,StateChangedEventArgs args);
		 * */
		//public StateChangedEventHandler StateChanged;
	}
}
