using NFluent;
using Xunit;
using System;

using static TddKatas.Banking.Builders.TransactionBuilder;

namespace TddKatas.Banking.Adapters
{
	public class InMemoryTransactionsStoreTests
	{
		private static readonly DateTime DepositTransactionDate = new DateTime(2018, 5, 10);
		private static readonly DateTime WithdrawalTransactionDate = new DateTime(2018, 5, 11);

		[Fact]
		public void Returns_transactions_in_the_same_order_they_were_saved()
		{
			var depositTransaction = ATransaction
				.On(DepositTransactionDate)
				.For(1000.0m)
				.Build();
			var withdrawalTransaction = ATransaction
				.On(WithdrawalTransactionDate)
				.For(-200.00m)
				.Build();
			var trasactionsStore = new InMemoryTransactionsStore();
			trasactionsStore.SaveNew(depositTransaction);
			trasactionsStore.SaveNew(withdrawalTransaction);

			var allTransactions = trasactionsStore.All;

			Check.That(allTransactions)
				.ContainsExactly(depositTransaction, withdrawalTransaction);
		}
	}
}