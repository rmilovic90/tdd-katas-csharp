using TddKatas.Banking.Fakes;
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

		private readonly FakeTransactionsStore transactionsStore;
		private readonly Account account;

		public AccountTests()
		{
			transactionsStore = AFakeTransactionsStore;
			account = new Account(
				AFakeDateProvider
					.ForTodaysDateReturns(ADate),
				transactionsStore,
				AFakeConsole);
		}

		[Fact]
		public void Stores_a_deposit_transaction()
		{
			account.Deposit(1000.00m);

			transactionsStore.HasSavedNew(
				ATransaction
					.On(ADate)
					.For(1000.00m));
		}

		[Fact]
		public void Stores_a_withdrawal_transaction()
		{
			account.Withdrawal(1000.00m);

			transactionsStore.HasSavedNew(
				ATransaction
					.On(ADate)
					.For(-1000.00m));
		}
	}
}