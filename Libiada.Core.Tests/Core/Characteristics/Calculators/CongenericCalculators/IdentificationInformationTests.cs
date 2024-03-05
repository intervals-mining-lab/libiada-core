namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The identification information test.
/// </summary>
[TestFixture]
public class IdentificationInformationTests : CongenericCalculatorsTests<IdentificationInformation>
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
    [TestCase(0, Link.None, 0.5)]
    [TestCase(0, Link.Start, 0.5306)]
    [TestCase(0, Link.End, 0.5239)]
    [TestCase(0, Link.Both, 0.5307)]
    [TestCase(0, Link.Cycle, 0.5211)]

    [TestCase(2, Link.None, 0)]
    [TestCase(2, Link.Start, 0)]
    [TestCase(2, Link.End, 0)]
    [TestCase(2, Link.Both, 0)]
    [TestCase(2, Link.Cycle, 0)]

    [TestCase(3, Link.None, 0)]
    [TestCase(3, Link.Start, 0.375)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0.4822)]
    [TestCase(3, Link.Cycle, 0.375)]

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
