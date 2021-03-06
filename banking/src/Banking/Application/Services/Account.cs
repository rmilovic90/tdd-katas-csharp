using TddKatas.Banking.Domain.Models;
using TddKatas.Banking.Domain.Services;
using TddKatas.Banking.Ports;
using System;

namespace TddKatas.Banking.Application.Services
{
	public class Account
	{
		private readonly IProvideDate dateProvider;
		private readonly IStoreTransactions transactionsStore;
		private readonly IAmConsole console;

		public Account(
			IProvideDate dateProvider,
			IStoreTransactions transactionsStore,
			IAmConsole console)
		{
			this.dateProvider = dateProvider
				?? throw new ArgumentNullException(nameof(dateProvider));
			this.transactionsStore = transactionsStore
				?? throw new ArgumentNullException(nameof(transactionsStore));
			this.console = console
				?? throw new ArgumentNullException(nameof(console));
		}

		public void Deposit(decimal amount)
		{
			var transaction = new Transaction(dateProvider.TodaysDate, amount);
			transactionsStore.SaveNew(transaction);
		}

		public void Withdrawal(decimal amount)
		{
			var transaction = new Transaction(dateProvider.TodaysDate, -amount);
			transactionsStore.SaveNew(transaction);
		}

		public void PrintStatement()
		{
			var allTransactions = transactionsStore.All;

			var statementPrinter = new StatementPrinter(console);
			statementPrinter.PrintFor(allTransactions);
		}
	}
}