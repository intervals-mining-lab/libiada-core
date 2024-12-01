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
    [TestCase(0, Link.None, 1)]
    [TestCase(0, Link.Start, 1.415037499)]
    [TestCase(0, Link.End, 1.222392421336)]
    [TestCase(0, Link.Both, 1.459431618637297)]
    [TestCase(0, Link.Cycle, 1.736965594)]

    [TestCase(2, Link.None, 0)]
    [TestCase(2, Link.Start, 0)]
    [TestCase(2, Link.End, 0)]
    [TestCase(2, Link.Both, 0)]
    [TestCase(2, Link.Cycle, 0)]

    [TestCase(3, Link.None, 0)]
    [TestCase(3, Link.Start, 3)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 2.169925)]
    [TestCase(3, Link.Cycle, 3)]

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
