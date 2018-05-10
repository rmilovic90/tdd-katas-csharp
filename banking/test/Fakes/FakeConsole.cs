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

		public void HasWroteLinesInOrderOf(params string[] texts)
		{
			var orderedAssertion = A.CallTo(() => consoleMock.WriteALineOf(texts[0]))
				.MustHaveHappenedOnceExactly()
				// HACK: workaround for ordered assertions on a array of values
				.Then(A.CallTo(() => consoleMock.WriteALineOf(""))
						.MustHaveHappened(Repeated.Never));

			for (int index = 1; index < texts.Length; index++)
			{
				orderedAssertion.Then(
					A.CallTo(() => consoleMock.WriteALineOf(texts[index]))
						.MustHaveHappenedOnceExactly());
			}
		}
	}
}