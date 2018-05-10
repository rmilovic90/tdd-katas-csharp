using TddKatas.Banking.Ports;
using System;

namespace TddKatas.Banking.Adapters
{
	public class SystemDateProvider : IProvideDate
	{
		public DateTime TodaysDate => DateTime.Today.Date;
	}
}