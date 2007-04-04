
using System;

namespace MonoBenchmark.Core
{
	public enum TestSessionState : byte
	{
		Stopped = 0,
		Running = 1,
		Finalized = 2
	}
}
