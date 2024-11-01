namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness dispersion tests.
/// </summary>
[TestFixture]
public class RemotenessDispersionTests : CongenericCalculatorsTests<RemotenessDispersion>
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
    [TestCase(0, Link.Start, 0.74270612)]

    [TestCase(2, Link.None, 0)]

    [TestCase(3, Link.None, 0)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericChainCharacteristicTest(index, link, value);
    }
    
}
