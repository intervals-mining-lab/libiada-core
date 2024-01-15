namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The length test.
/// </summary>
[TestFixture]
public class LengthTests : FullCalculatorsTests<Length>
{
    /// <summary>
    /// The chain calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, 10)]
    public void ChainCalculationTest(int index,  double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
