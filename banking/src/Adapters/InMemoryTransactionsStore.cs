using TddKatas.Banking.Domain.Models;
using TddKatas.Banking.Ports;

namespace TddKatas.Banking.Adapters
{
	public class InMemoryTransactionsStore : IStoreTransactions
	{
		public void SaveNew(Transaction transaction)
		{
			throw new System.NotImplementedException();
		}
	}
}