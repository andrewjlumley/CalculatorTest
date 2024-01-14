using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SimpleCalculator;

namespace UnitTests
{
	[TestClass]
	public class TestCalculator
	{
		private ISimpleCalculator? Calculator;

		[TestInitialize()]
		public void Initialise()
		{
			// Create instance of SimpleCalculator from object factory
			Calculator = SimpleCalculator.ObjectFactory.Instance().CreateSimpleCalcultor();
		}

		[TestCleanup()]
		public void Cleanup()
		{
			Calculator = null;
		}

		[TestMethod]
		public void TestAdditionAndSubtraction()
		{
			// We need a suquence of varying numbers to test with. The Fibonacci Sequence delivers this.
			var fibonacciSequence = new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181 };

			// Running the additions and subtracts on the same Fibonacci Sequence should return to an originating starting point.
			// Start from negative position to make sure this is covered.
			var originalStart = -12;
			var start = originalStart;

			// Test addition on Fibonacci Sequence
			foreach (var amount in fibonacciSequence)
			{
				var expectectResult = start + amount;
				var actualResult = Calculator?.Add(start, amount);
				Assert.AreEqual(expectectResult, actualResult);
			}

			// Test subtraction on Fibonacci Sequence
			foreach (var amount in fibonacciSequence)
			{
				var expectectResult = start - amount;
				var actualResult = Calculator?.Subtract(start, amount);
				Assert.AreEqual(expectectResult, actualResult);
			}

			// Test start is back at original starting position
			Assert.AreEqual(originalStart, start);
		}
	}
}