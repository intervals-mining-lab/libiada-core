namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness skewness tests.
/// </summary>
[TestFixture]
public class RemotenessSkewnessTests : FullCalculatorsTests<RemotenessSkewness>
{
    /// <summary>
    /// The remoteness skewness test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, -0.1447767)]
    [TestCase(0, Link.Start, -0.1898883)]
    [TestCase(0, Link.End, -0.0991305)]
    [TestCase(0, Link.Both, -0.1347675)]
    [TestCase(0, Link.Cycle, -0.1599169)]

    [TestCase(1, Link.None, -0.4961683303)]
    [TestCase(1, Link.Start, -0.2949014953)]
    [TestCase(1, Link.End, -0.258364351)]
    [TestCase(1, Link.Both, -0.2054047141)]
    [TestCase(1, Link.Cycle, -0.4660579801)]

    [TestCase(2, Link.None, 0.2300877488)]
    [TestCase(2, Link.Start, -0.0632986581)]
    [TestCase(2, Link.End, 0.1340349233)]
    [TestCase(2, Link.Both, -0.0406344674)]
    [TestCase(2, Link.Cycle, 0.1510267759)]

    [TestCase(3, Link.Start, 0)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, -0.2005956445)]
    [TestCase(5, Link.End, -0.2005956445)]
    [TestCase(5, Link.Both, -0.2005956445)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 0.6688715333)]
    [TestCase(6, Link.End, 0.3077841313)]
    [TestCase(6, Link.Both, 0.3198087858)]
    [TestCase(6, Link.Cycle, -0.4130639215)]

    [TestCase(30, Link.None, -0.0862228839)]
    [TestCase(30, Link.Start, -0.0075884574)]
    [TestCase(30, Link.End, -0.0075884574)]
    [TestCase(30, Link.Both, 0.0120652538)]
    [TestCase(30, Link.Cycle, -0.0942645986)]
    public void SequenceCalculationTest(int index, Link link, double value)
    {
        SequenceCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// No intervals test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
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
        SequenceCharacteristicTest(index, link, value);
    }
}
