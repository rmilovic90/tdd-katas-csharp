using TddKatas.Banking.Adapters;
using TddKatas.Banking.Application.Services;
using System;

namespace TddKatas.Banking.Application
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var account = new Account(
				new SystemDateProvider(),
				new InMemoryTransactionsStore(),
				new SystemConsole());

			account.Deposit(1000.00m);
			account.Withdrawal(100.00m);
			account.Deposit(500.00m);

			account.PrintStatement();

			Console.ReadLine();
		}
	}
}