using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The cut length test.
    /// </summary>
    [TestFixture]
    public class CuttingLengthTests : CongenericCalculatorsTests<CuttingLength>
    {
        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 4)]
        public void CongenericCalculationTest(int index, double value)
        {
            CongenericChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
