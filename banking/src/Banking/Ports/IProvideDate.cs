using System;

namespace TddKatas.Banking.Ports
{
	public interface IProvideDate
	{
		DateTime TodaysDate { get; }
	}
}