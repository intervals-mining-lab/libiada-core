namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The descriptive information test.
/// </summary>
[TestFixture]
public class DescriptiveInformationTests : CongenericCalculatorsTests<DescriptiveInformation>
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
    [TestCase(0, Link.None, 1.4142)]
    [TestCase(0, Link.Start, 1.4445)]
    [TestCase(0, Link.End, 1.4378)]
    [TestCase(0, Link.Both, 1.4446)]
    [TestCase(0, Link.Cycle, 1.435)]

    [TestCase(1, Link.None, 1.4445)]
    [TestCase(1, Link.Start, 1.4422)]
    [TestCase(1, Link.End, 1.4422)]
    [TestCase(1, Link.Both, 1.4383)]
    [TestCase(1, Link.Cycle, 1.4226)]

    [TestCase(2, Link.None, 1)]
    [TestCase(2, Link.Start, 1)]
    [TestCase(2, Link.End, 1)]
    [TestCase(2, Link.Both, 1)]
    [TestCase(2, Link.Cycle, 1)]

    [TestCase(3, Link.None, 1)]
    [TestCase(3, Link.Start, 1.2968)]
    [TestCase(3, Link.End, 1)]
    [TestCase(3, Link.Both, 1.3969)]
    [TestCase(3, Link.Cycle, 1.2968)]

    [TestCase(4, Link.None, 1)]
    [TestCase(4, Link.Start, 1.0001)]
    [TestCase(4, Link.End, 1)]
    [TestCase(4, Link.Both, 1)]
    [TestCase(4, Link.Cycle, 1)]

    [TestCase(5, Link.None, 1)]
    [TestCase(5, Link.Start, 1)]
    [TestCase(5, Link.End, 1)]
    [TestCase(5, Link.Both, 1)]
    [TestCase(5, Link.Cycle, 1)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericChainCharacteristicTest(index, link, value);
    }
}
