namespace Libiada.Core.Tests.Core.Characteristics.Calculators.AccordanceCalculators;

using Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

/// <summary>
/// The mutual compliance degree tests.
/// </summary>
[TestFixture]
public class MutualComplianceDegreeTests : AccordanceCalculatorsTests<MutualComplianceDegree>
{
    /// <summary>
    /// The mutual compliance degree test.
    /// </summary>
    /// <param name="firstIndex">
    /// The first index.
    /// </param>
    /// <param name="secondIndex">
    /// The second index.
    /// </param>
    /// <param name="firstValue">
    /// The first value.
    /// </param>
    [TestCase(6, 7, 0.5481)]
    [TestCase(7, 6, 0.5481)]
    [TestCase(8, 9, 0.8755)]
    [TestCase(9, 8, 0.8755)]
    [TestCase(10, 11, 0.2724)]
    [TestCase(11, 10, 0.2724)]
    [TestCase(12, 13, 0.3841)]
    [TestCase(13, 12, 0.3841)]
    [TestCase(14, 15, 0.8352)]
    [TestCase(15, 14, 0.8352)]
    [TestCase(16, 17, 0.8350)]
    [TestCase(17, 16, 0.8350)]
    public void MutualComplianceDegreeTest(int firstIndex, int secondIndex, double firstValue)
    {
        CalculationTest(firstIndex, secondIndex, firstValue);
    }
}
