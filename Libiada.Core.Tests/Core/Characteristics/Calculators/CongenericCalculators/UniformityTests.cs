namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The uniformity calculator tests.
/// </summary>
[TestFixture]
public class UniformityTests : CongenericCalculatorsTests<Uniformity>
{
    /// <summary>
    /// The congeneric calculation test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 0.2075)]
    [TestCase(0, Link.Start, 0.22)]
    [TestCase(0, Link.End, 0.16569)]
    [TestCase(0, Link.Both, 0.1669)]
    [TestCase(0, Link.Cycle, 0.346965594)]

    [TestCase(2, Link.None, 0)]
    [TestCase(2, Link.Start, 0)]
    [TestCase(2, Link.End, 0)]
    [TestCase(2, Link.Both, 0)]
    [TestCase(2, Link.Cycle, 0)]

    [TestCase(3, Link.None, 0)]
    [TestCase(3, Link.Start, 0)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0.669925)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(5, Link.None, 0)]
    [TestCase(5, Link.Start, 0)]
    [TestCase(5, Link.End, 0)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericChainCharacteristicTest(index, link, value);
    }
}
