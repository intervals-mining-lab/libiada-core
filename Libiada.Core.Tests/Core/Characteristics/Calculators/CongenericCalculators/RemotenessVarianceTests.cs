namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness variance tests.
/// </summary>
[TestFixture]
public class RemotenessVarianceTests : CongenericCalculatorsTests<RemotenessVariance>
{
    /// <summary>
    /// The remoteness variance test.
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
    [TestCase(0, Link.Start, 0.74270612)]

    [TestCase(2, Link.None, 0)]

    [TestCase(3, Link.None, 0)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericSequenceCharacteristicTest(index, link, value);
    }
    
}
