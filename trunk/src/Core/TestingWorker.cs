using System;
using System.Threading;

namespace MonoBenchmark.Core
{
	public class TestingWorker
	{
		//private TestingWorkerState state;
		private TimeFixtureInfo fixture;
		private TestMethodInfo testInfo;
		private MethodTimeResult testMethodResult = null;
		
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


		public MethodTimeResult TestResult
		{
			get
			{
				return this.testMethodResult;
			}
		}

		private int workers = 0;
		private object workers_lock = new object();
		private int WorkersCount
		{
			get
			{
				lock(workers_lock)
				{
					return workers;
				}
			}
			set
			{
				lock(workers_lock)
				{
					workers = value;
				}
			}
		}

		public void Run()
		{
			this.testMethodResult = new MethodTimeResult(this.testInfo);
				for(uint invokeCount =0;invokeCount < this.testInfo.TimeCount.Workers; invokeCount++)
				{
					ThreadPool.QueueUserWorkItem(delegate
				            	{

							DateTime startTime = DateTime.Now;
							this.testInfo.Method.Invoke(this.fixture.FixtureInstance,null);
					
							//Calculate Time
							DateTime endTime = DateTime.Now;
							TimeSpan time = endTime - startTime;
							TestTimeResult testResult = new TestTimeResult(WorkersCount,testMethodResult,startTime,endTime,time);
							this.TestResult.Results.Add(testResult);
//debug.writeln("Worker ends!,Time={0}",time.ToString());
							WorkersCount++;
							if(WorkersCount == this.testInfo.TimeCount.Workers)
							{
								this.fixture.notifyWorkerFinalization(this); //I have finished.
							}
							//debug.writeln("After Notify!");
						});
			}
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
