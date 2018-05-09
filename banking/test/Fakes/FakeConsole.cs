using FakeItEasy;
using TddKatas.Banking.Ports;

namespace TddKatas.Banking.Fakes
{
	internal class FakeConsole : IAmConsole
	{
		public static FakeConsole AFakeConsole => new FakeConsole();

		private readonly IAmConsole consoleMock;

		private FakeConsole()
		{
			consoleMock = A.Fake<IAmConsole>();
		}

		public void WriteALineOf(string text)
		{
			consoleMock.WriteALineOf(text);
		}

		public void HasWroteALineOf(string text)
		{
			A.CallTo(() => consoleMock.WriteALineOf(text))
				.MustHaveHappenedOnceExactly();
		}
	}
}