namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using NUnit.Framework;

/// <summary>
/// The length test.
/// </summary>
[TestFixture]
public class LengthTests : CongenericCalculatorsTests<Length>
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
    [TestCase(0, 10)]
    [TestCase(1, 15)]
    [TestCase(2, 1)]
    [TestCase(3, 8)]
    [TestCase(4, 1000000)]
    [TestCase(5, 5)]
    public void CongenericCalculationTest(int index, double value)
    {
        CongenericChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
