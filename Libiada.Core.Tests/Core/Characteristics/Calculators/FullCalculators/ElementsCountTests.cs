namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The elements count test.
/// </summary>
[TestFixture]
public class ElementsCountTests : FullCalculatorsTests<ElementsCount>
{
    /// <summary>
    /// The chain calculation test.
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
    [TestCase(0, 10)]
    [TestCase(1, 10)]
    [TestCase(2, 10)]
    [TestCase(3, 2)]
    [TestCase(4, 4)]
    [TestCase(5, 4)]
    [TestCase(6, 7)]
    [TestCase(7, 2)]
    [TestCase(8, 4)]
    [TestCase(9, 9)]
    [TestCase(10, 9)]
    [TestCase(11, 9)]
    [TestCase(12, 9)]
    [TestCase(13, 9)]
    [TestCase(14, 9)]
    [TestCase(15, 9)]
    [TestCase(16, 9)]
    [TestCase(17, 9)]
    [TestCase(18, 0)]
    [TestCase(19, 1)]
    [TestCase(20, 1)]
    [TestCase(21, 2)]
    [TestCase(22, 2)]
    [TestCase(24, 2)]
    [TestCase(26, 3)]
    [TestCase(28, 3)]
    public void ChainCalculationTest(int index, double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
