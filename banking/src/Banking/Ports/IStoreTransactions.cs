using TddKatas.Banking.Domain.Models;
using System.Collections.Generic;

namespace TddKatas.Banking.Ports
{
	public interface IStoreTransactions
	{
		IReadOnlyList<Transaction> All { get; }
		void SaveNew(Transaction transaction);
	}
}