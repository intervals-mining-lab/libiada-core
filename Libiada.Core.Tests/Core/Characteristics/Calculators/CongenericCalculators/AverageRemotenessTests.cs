namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The average remoteness test.
/// </summary>
[TestFixture]
public class AverageRemotenessTests : CongenericCalculatorsTests<AverageRemoteness>
{
    /// <summary>
    /// The congeneric calculation test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 0.7925)]
    [TestCase(0, Link.Start, 1.195)]
    [TestCase(0, Link.End, 1.0567)]
    [TestCase(0, Link.Both, 1.2925)]
    [TestCase(0, Link.Cycle, 1.39)]

    [TestCase(1, Link.None, 1.1073)]
    [TestCase(1, Link.Start, 1.3305)]
    [TestCase(1, Link.End, 1.3305)]
    [TestCase(1, Link.Both, 1.4644)]
    [TestCase(1, Link.Cycle, 1.5323)]

    [TestCase(2, Link.None, 0)]
    [TestCase(2, Link.Start, 0)]
    [TestCase(2, Link.End, 0)]
    [TestCase(2, Link.Both, 0)]
    [TestCase(2, Link.Cycle, 0)]

    [TestCase(3, Link.None, 0)]
    [TestCase(3, Link.Start, 3)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 1.5)]
    [TestCase(3, Link.Cycle, 3)]

    [TestCase(5, Link.None, 0)]
    [TestCase(5, Link.Start, 0)]
    [TestCase(5, Link.End, 0)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericSequenceCharacteristicTest(index, link, value);
    }
}
