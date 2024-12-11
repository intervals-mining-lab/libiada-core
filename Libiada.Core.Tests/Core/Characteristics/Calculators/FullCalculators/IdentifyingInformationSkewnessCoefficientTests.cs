namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The identifying informations (entropy) asymmetry coefficient test.
/// </summary>
[TestFixture]
public class IdentifyingInformationSkewnessCoefficientTests : FullCalculatorsTests<IdentifyingInformationSkewnessCoefficient>
{
    /// <summary>
    /// The identifying informations (entropy) asymmetry coefficient test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 0.2886751346)]
    [TestCase(0, Link.Start, 0.6128535448)]
    [TestCase(0, Link.End, -0.7044864198)]
    [TestCase(0, Link.Both, -0.474341649)]
    [TestCase(0, Link.Cycle, -0.4082482905)]

    [TestCase(1, Link.None, 0.1264522237)]
    [TestCase(1, Link.Start, 0.3623575326)]
    [TestCase(1, Link.End, 0.7446392945)]
    [TestCase(1, Link.Both, 0.2886751346)]
    [TestCase(1, Link.Cycle, 0.4082482905)]

    [TestCase(2, Link.None, 0.3258684199)]
    [TestCase(2, Link.Start, 0.0679609575)]
    [TestCase(2, Link.End, 1.1185300891)]
    [TestCase(2, Link.Both, 0.0562260608)]
    [TestCase(2, Link.Cycle, 0.4310471138)]

    [TestCase(3, Link.Start, 0)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, -0.4733901994)]
    [TestCase(5, Link.End, -0.4733901994)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 0.3195924049)]
    [TestCase(6, Link.End, -0.2511254465)]
    [TestCase(6, Link.Both, -0.1825741858)]
    [TestCase(6, Link.Cycle, 0.2886751346)]

    [TestCase(30, Link.None, 0.7071067812)]
    [TestCase(30, Link.Start, 0.4082482905)]
    [TestCase(30, Link.End, 0.4082482905)]
    [TestCase(30, Link.Both, 0.2886751346)]
    [TestCase(30, Link.Cycle, 0.4082482905)]
    public void ChainCalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// No intervals test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(3, Link.None, 0)]
    [TestCase(5, Link.None, 0)]
    [TestCase(7, Link.None, 0)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
