namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;


/// <summary>
/// The periodicity test.
/// </summary>
[TestFixture]
public class PeriodicityTests : CongenericCalculatorsTests<Periodicity>
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
    [TestCase(0, Link.None, 0.8661)]
    [TestCase(0, Link.Start, 0.8585)]
    [TestCase(0, Link.End, 0.8915)]
    [TestCase(0, Link.Both, 0.8907)]
    [TestCase(0, Link.Cycle, 0.7862)]

    [TestCase(2, Link.None, 0)]
    [TestCase(3, Link.None, 0)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericSequenceCharacteristicTest(index, link, value);
    }
}
