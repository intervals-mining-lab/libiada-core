namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using NUnit.Framework;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class GCSkewTests : FullCalculatorsTests<GCSkew>
{
    /// <summary>
    /// The calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(1, 0)]
    public void CalculationTest(int index, double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }

    /// <summary>
    /// Sequence without Guanine or Cytozine calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(7, 0)]
    [TestCase(8, 0)]
    public void SequenceWithoutGCTest(int index, double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
