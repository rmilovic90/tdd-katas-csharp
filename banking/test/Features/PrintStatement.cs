using TddKatas.Banking.Adapters;
using TddKatas.Banking.Application.Services;
using TddKatas.Banking.Fakes;
using Xunit;

using static TddKatas.Banking.Fakes.FakeConsole;
using static TddKatas.Banking.Fakes.FakeDateProvider;

namespace TddKatas.Banking.Features
{
	public class PrintStatement
	{
		private readonly FakeConsole console;
		private readonly Account account;

		public PrintStatement()
		{
			console = AFakeConsole;
			account = new Account(
				AFakeDateProvider,
				new InMemoryTransactionsStore(),
				console);
		}

		[Fact]
		public void Contains_all_transactions()
		{
			account.Deposit(1000);
			account.Withdrawal(100);
			account.Deposit(500);

			account.PrintStatement();

			console.HasWroteALineOf("DATE | AMOUNT | BALANCE");
			console.HasWroteALineOf("05/09/2018 | 500.00 | 1400.00");
			console.HasWroteALineOf("05/10/2018 | -100.00 | 900.00");
			console.HasWroteALineOf("05/11/2018 | 1000.00 | 1000.00");
		}
	}
}