using TddKatas.Banking.Domain.Models;

namespace TddKatas.Banking.Ports
{
	public interface IStoreTransactions
	{
		void SaveNew(Transaction transaction);
	}
}