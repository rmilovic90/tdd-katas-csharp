using TddKatas.Banking.Domain.Models;
using System;

namespace TddKatas.Banking.Builders
{
	internal class TransactionBuilder
	{
		public static TransactionBuilder ATransaction =>
			new TransactionBuilder();

		private DateTime date;
		private decimal amount;

		private TransactionBuilder() {}

		public TransactionBuilder On(DateTime date)
		{
			this.date = date;

			return this;
		}

		public TransactionBuilder For(decimal amount)
		{
			this.amount = amount;

			return this;
		}

		public Transaction Build() =>
			new Transaction(date, amount);

		public static implicit operator Transaction(TransactionBuilder builder) =>
			builder.Build();
	}
}