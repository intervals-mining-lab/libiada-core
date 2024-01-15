namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using NUnit.Framework;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class SWSkewTests : FullCalculatorsTests<SWSkew>
{
    /// <summary>
    /// The calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(1, -0.2)]

    public void CalculationTest(int index, double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
