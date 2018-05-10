using TddKatas.Banking.Ports;
using System;

namespace TddKatas.Banking.Adapters
{
	public class SystemConsole : IAmConsole
	{
		public void WriteALineOf(string text)
		{
			Console.WriteLine(text);
		}
	}
}