using TddKatas.Banking.Domain.Models;
using TddKatas.Banking.Ports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TddKatas.Banking.Domain.Services
{
	public class StatementPrinter
	{
		private const string Header = "DATE | AMOUNT | BALANCE";

		private readonly IAmConsole console;

		public StatementPrinter(IAmConsole console)
		{
			this.console = console
				?? throw new ArgumentNullException(nameof(console));
		}

		public void PrintFor(IReadOnlyList<Transaction> transactions)
		{
			PrintHeader();
			PrintStatementLinesFor(transactions);
		}

		private void PrintHeader()
		{
			console.WriteALineOf(Header);
		}

		private void PrintStatementLinesFor(IReadOnlyList<Transaction> transactions)
		{
			var statementLines = FormatStatementLinesFor(transactions);
			statementLines.Reverse();
			statementLines.ForEach(console.WriteALineOf);
		}

		private List<string> FormatStatementLinesFor(IReadOnlyList<Transaction> transactions)
		{
			var runningBalance = 0.00m;
			return transactions.Select(transaction =>
			{
				runningBalance += transaction.Amount;

				return FormatStatementLine(transaction.Date, transaction.Amount, runningBalance);
			}).ToList();
		}

		private string FormatStatementLine(DateTime date, decimal amount, decimal runningBalance) =>
			$"{date:MM/dd/yyyy} | {amount:F2} | {runningBalance:F2}";
	}
}