
using System;

namespace  MonoBenchmark.Framework
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TimeFixtureAttribute : Attribute
	{
		
	}
	
	//Indica que debe tomarse en cuenta el tiempo de ejecucion del metodo.
	[AttributeUsageAttribute( AttributeTargets.Method)]
	public class TimeCountAttribute : Attribute
	{
		private uint callsCount = 1;
		public TimeCountAttribute()
		{
			
		}
		
		public uint InvokeTimes
		{
			get{
				return this.callsCount;
			}
			set{
				this.callsCount = value;
			}
		}
	}
}
