namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using NUnit.Framework;

/// <summary>
/// The remoteness kurtosis tests.
/// </summary>
[TestFixture]
public class RemotenessKurtosisTests : CongenericCalculatorsTests<RemotenessKurtosis>
{
    /// <summary>
    /// The average remoteness dispersion test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Redundant parameter, not used in calculations.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.Start, 0.82742)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericChainCharacteristicTest(index, link, value);
    }
}
