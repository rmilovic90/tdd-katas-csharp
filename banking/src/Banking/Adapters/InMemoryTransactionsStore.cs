using TddKatas.Banking.Domain.Models;
using TddKatas.Banking.Ports;
using System.Collections.Generic;

namespace TddKatas.Banking.Adapters
{
	public class InMemoryTransactionsStore : IStoreTransactions
	{
		private readonly List<Transaction> transactions = new List<Transaction>();

		public IReadOnlyList<Transaction> All => transactions.AsReadOnly();

		public void SaveNew(Transaction transaction)
		{
			transactions.Add(transaction);
		}
	}
}