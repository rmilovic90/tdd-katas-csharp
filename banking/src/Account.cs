using System;

namespace TddKatas.Banking
{
	public class Account
	{
		private readonly IAmConsole console;

		public Account(IAmConsole console)
		{
			this.console = console
				?? throw new ArgumentNullException(nameof(console));
		}

		public void Deposit(int amount)
		{
			throw new NotImplementedException();
		}

		public void Withdrawal(int amount)
		{
			throw new NotImplementedException();
		}

		public void PrintStatement()
		{
			throw new NotImplementedException();
		}
	}
}