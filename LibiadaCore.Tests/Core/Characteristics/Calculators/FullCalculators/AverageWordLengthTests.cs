namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    [TestFixture]
    public class AverageWordLengthTests : FullCalculatorsTests<AverageWordLength>
    {
        /// <summary>
        /// The chain calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public void ChainCalculationTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }

        [Test]
        public void CalculationTest()
        {
            var sequence = new Chain(5)
            {
                [0] = new ValueString("bla"),
                [1] = new ValueString("blablab"),
                [2] = new ValueString("blablabla"),
                [3] = new ValueString("bla"),
                [4] = new ValueString("bla")
            };
            double actual = Calculator.Calculate(sequence, Link.NotApplied);
            Assert.AreEqual(5, actual, 0.0001);
        }
    }
}