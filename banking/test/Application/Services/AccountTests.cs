using Xunit;
using System;

using static TddKatas.Banking.Fakes.FakeTransactionsStore;
using static TddKatas.Banking.Fakes.FakeDateProvider;
using static TddKatas.Banking.Fakes.FakeConsole;
using static TddKatas.Banking.Builders.TransactionBuilder;

namespace TddKatas.Banking.Application.Services
{
	public class AccountTests
	{
		private static readonly DateTime ADate = new DateTime(2018, 5, 9);

		[Fact]
		public void Stores_a_deposit_transaction()
		{
			var transactionsStore = AFakeTransactionsStore;
			var account = new Account(
				AFakeDateProvider
					.ForTodaysDateReturns(ADate),
				transactionsStore,
				AFakeConsole);

			account.Deposit(1000.00m);

			transactionsStore.HasSavedNew(
				ATransaction
					.On(ADate)
					.For(1000.00m));
		}
	}
}