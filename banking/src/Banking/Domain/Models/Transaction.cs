using System;

namespace TddKatas.Banking.Domain.Models
{
	public sealed class Transaction
	{
		public Transaction(DateTime date, decimal amount)
		{
			Amount = amount;
			Date = date;
		}

		public DateTime Date { get; }
		public decimal Amount { get; }

		public override bool Equals(object obj) =>
			obj is Transaction other
				&& Date == other.Date
				&& Amount == other.Amount;

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Date.GetHashCode();
				hashCode = (hashCode * 397) ^ Amount.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(Transaction)} {{ {nameof(Date)}: {Date}, {nameof(Amount)}: {Amount} }}";

		public static bool operator ==(Transaction left, Transaction right) =>
			left is null
				? right is null
				: left.Equals(right);

		public static bool operator !=(Transaction left, Transaction right) =>
			!(left == right);
	}
}