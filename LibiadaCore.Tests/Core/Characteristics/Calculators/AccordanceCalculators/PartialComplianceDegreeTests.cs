using LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.AccordanceCalculators
{
    using NUnit.Framework;

    /// <summary>
    /// The compliance degree tests.
    /// </summary>
    [TestFixture]
    public class PartialComplianceDegreeTests : AccordanceCalculatorsTests<PartialComplianceDegree>
    {
        /// <summary>
        /// The compliance degree test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="firstValue">
        /// The first value.
        /// </param>
        /// <param name="secondValue">
        /// The second value.
        /// </param>
        [TestCase(1, 0.9428, 0)]
        [TestCase(2, 0.9428, 0)]
        [TestCase(4, 0.9938, 0)]
        [TestCase(5, 0.9991, 0)]
        [TestCase(6, 0.5151, 0)]
        [TestCase(12, 0.9710, 0.5)]
        [TestCase(15, 0.3563, 0)]
        public void PartialComplianceDegreeTest(int index, double firstValue, double secondValue)
        {
            CalculationTest(index, firstValue, secondValue);
        }

        /// <summary>
        /// The partial compliance degree test.
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
        [TestCase(6, 7, 0.6008)]
        [TestCase(7, 6, 0.5)]
        [TestCase(8, 9, 0.9843)]
        [TestCase(9, 8, 0.7787)]
        [TestCase(10, 11, 0.4131)]
        [TestCase(11, 10, 0.1796)]
        [TestCase(12, 13, 0.4401)]
        [TestCase(13, 12, 0.3353)]
        [TestCase(14, 15, 0.9428)]
        [TestCase(15, 14, 0.7399)]
        [TestCase(16, 17, 0.9428)]
        [TestCase(17, 16, 0.7394)]
        public void PartialComplianceDegreeTest(int firstIndex, int secondIndex, double firstValue)
        {
            CalculationTest(firstIndex, secondIndex, firstValue);
        }
    }
}
