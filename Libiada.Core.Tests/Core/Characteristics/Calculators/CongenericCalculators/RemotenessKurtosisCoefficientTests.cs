namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness kurtosis coefficient tests.
/// </summary>
[TestFixture]
public class RemotenessKurtosisCoefficientTests : CongenericCalculatorsTests<RemotenessKurtosisCoefficient>
{
    /// <summary>
    /// The remoteness kurtosis coefficient test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.Start, 1.5)]

    [TestCase(2, Link.None, 0)]

    [TestCase(3, Link.None, 0)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericSequenceCharacteristicTest(index, link, value);
    }
}
