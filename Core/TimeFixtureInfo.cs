
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
		
		internal TimeFixtureInfo(TimeFixtureAttribute attribute,
		                       Type fixtureType,ConstructorInfo constructor)
		{
			this.attribute = attribute;
			this.fixtureType = fixtureType;
			this.constructor = constructor;
			this.methods = new List<TestMethodInfo>();
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
	}
}
