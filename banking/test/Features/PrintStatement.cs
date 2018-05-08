using TddKatas.Banking.Fakes;
using Xunit;

using static TddKatas.Banking.Fakes.FakeConsole;

namespace TddKatas.Banking.Features
{
	public class PrintStatement
	{
		private readonly FakeConsole console;
		private readonly Account account;

		public PrintStatement()
		{
			console = AFakeConsole;
			account = new Account(console);
		}

		[Fact]
		public void Contains_all_transactions()
		{
			account.Deposit(1000);
			account.Withdrawal(100);
			account.Deposit(500);

			account.PrintStatement();

			console.HasWroteALineOf("DATE | AMOUNT | BALANCE");
			console.HasWroteALineOf("10/04/2014 | 500.00 | 1400.00");
			console.HasWroteALineOf("02/04/2014 | -100.00 | 900.00");
			console.HasWroteALineOf("01/04/2014 | 1000.00 | 1000.00");
		}
	}
}