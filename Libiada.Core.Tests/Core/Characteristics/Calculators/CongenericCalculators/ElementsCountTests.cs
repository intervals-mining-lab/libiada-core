namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The elements count test.
    /// </summary>
    [TestFixture]
    public class ElementsCountTests : CongenericCalculatorsTests<ElementsCount>
    {
        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        /// <param name="index">
        /// The congeneric sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 3)]
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 3)]
        [TestCase(4, 3)]
        [TestCase(5, 3)]
        public void CongenericCalculationTest(int index, double value)
        {
            CongenericChainCharacteristicTest(0, Link.NotApplied, value);
        }
    }
}
