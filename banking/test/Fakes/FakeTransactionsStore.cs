using FakeItEasy;
using TddKatas.Banking.Domain.Models;
using TddKatas.Banking.Ports;
using System.Collections.Generic;

namespace TddKatas.Banking.Fakes
{
	internal class FakeTransactionsStore : IStoreTransactions
	{
		public static FakeTransactionsStore AFakeTransactionsStore =>
			new FakeTransactionsStore();

		private readonly IStoreTransactions transactionsStoreMock;

		private FakeTransactionsStore()
		{
			transactionsStoreMock = A.Fake<IStoreTransactions>();

			A.CallTo(() => transactionsStoreMock.All)
				.Returns(new List<Transaction>());
		}

		public IReadOnlyList<Transaction> All =>
			transactionsStoreMock.All;

		public void SaveNew(Transaction transaction)
		{
			transactionsStoreMock.SaveNew(transaction);
		}

		public void HasSavedNew(Transaction transaction)
		{
			A.CallTo(() => transactionsStoreMock.SaveNew(transaction))
				.MustHaveHappenedOnceExactly();
		}
	}
}