using FakeItEasy;
using TddKatas.Banking.Ports;
using System;
using System.Collections.Generic;

namespace TddKatas.Banking.Fakes
{
	internal class FakeDateProvider : IProvideDate
	{
		public static FakeDateProvider AFakeDateProvider =>
			new FakeDateProvider();

		private readonly IProvideDate mockDateProvider;

		private readonly List<DateTime> preConfiguredDateResponses = new List<DateTime>();

		private FakeDateProvider()
		{
			mockDateProvider = A.Fake<IProvideDate>();

			A.CallTo(() => mockDateProvider.TodaysDate)
				.Returns(DateTime.Today);
		}

		public FakeDateProvider WhenAskedForTodaysDateReturns(DateTime date)
		{
			preConfiguredDateResponses.Add(date);

			A.CallTo(() => mockDateProvider.TodaysDate)
				.ReturnsNextFromSequence(preConfiguredDateResponses.ToArray());

			return this;
		}

		public FakeDateProvider ThenReturns(DateTime date) =>
			WhenAskedForTodaysDateReturns(date);

		public DateTime TodaysDate => mockDateProvider.TodaysDate;
	}
}