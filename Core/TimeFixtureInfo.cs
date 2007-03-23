
using System;
using Framework;
namespace Core
{
	//Information about a TimeFixture class.
	public class TimeFixtureInfo
	{
		private TimeFixtureAttribute attribute;
		private Type fixtureType;
		
		public TimeFixtureInfo(TimeFixtureAttribute attribute,
		                       Type fixtureType)
		{
			this.attribute = attribute;
			this.fixtureType = fixtureType;
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
	}
}
