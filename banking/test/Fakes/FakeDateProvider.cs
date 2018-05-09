using FakeItEasy;
using TddKatas.Banking.Ports;
using System;

namespace TddKatas.Banking.Fakes
{
	internal class FakeDateProvider : IProvideDate
	{
		public static FakeDateProvider AFakeDateProvider =>
			new FakeDateProvider();

		private readonly IProvideDate mockDateProvider;

		private FakeDateProvider()
		{
			mockDateProvider = A.Fake<IProvideDate>();

			A.CallTo(() => mockDateProvider.TodaysDate)
				.Returns(DateTime.Today);
		}

		public FakeDateProvider ForTodaysDateReturns(DateTime date)
		{
			A.CallTo(() => mockDateProvider.TodaysDate)
				.Returns(date);

			return this;
		}

		public DateTime TodaysDate => mockDateProvider.TodaysDate;
	}
}