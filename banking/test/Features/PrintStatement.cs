using TddKatas.Banking.Adapters;
using TddKatas.Banking.Application.Services;
using TddKatas.Banking.Fakes;
using Xunit;
using System;

using static TddKatas.Banking.Fakes.FakeConsole;
using static TddKatas.Banking.Fakes.FakeDateProvider;

namespace TddKatas.Banking.Features
{
	public class PrintStatement
	{
		private static readonly DateTime FirstTransactionDate = new DateTime(2018, 5, 9);
		private static readonly DateTime SecondTransactionDate = new DateTime(2018, 5, 10);
		private static readonly DateTime ThirdTransactionDate = new DateTime(2018, 5, 11);

		private readonly FakeDateProvider dateProvider;
		private readonly FakeConsole console;
		private readonly Account account;

		public PrintStatement()
		{
			dateProvider = AFakeDateProvider;
			console = AFakeConsole;
			account = new Account(
				dateProvider,
				new InMemoryTransactionsStore(),
				console);
		}

		[Fact]
		public void Contains_all_transactions()
		{
			dateProvider.WhenAskedForTodaysDateReturns(FirstTransactionDate)
				.ThenReturns(SecondTransactionDate)
				.ThenReturns(ThirdTransactionDate);

			account.Deposit(1000.00m);
			account.Withdrawal(100.00m);
			account.Deposit(500.00m);

			account.PrintStatement();

			console.HasWroteLinesInOrderOf(
				"DATE | AMOUNT | BALANCE",
				"05/11/2018 | 500.00 | 1400.00",
				"05/10/2018 | -100.00 | 900.00",
				"05/09/2018 | 1000.00 | 1000.00");
		}
	}
}