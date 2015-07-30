using NUnit.Framework;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{

    [TestFixture]
    public class MutualComplianceDegreeTests : AccordanceCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("MutualComplianceDegree");
        }

        [TestCase(6, 7, 0.5481)]
        [TestCase(7, 6, 0.5481)]
        [TestCase(8, 9, 0.8755)]
        [TestCase(9, 8, 0.8755)]
        [TestCase(10, 11, 0.2724)]
        [TestCase(11, 10, 0.2724)]
        [TestCase(12, 13, 0.3841)]
        [TestCase(13, 12, 0.3841)]
        [TestCase(14, 15, 0.835)]
        [TestCase(15, 14, 0.835)]
        [TestCase(16, 17, 0.835)]
        [TestCase(17, 16, 0.835)]
        public void MutualComplianceDegreeTest(int firstIndex, int secondIndex, double firstValue)
        {
            CalculationTest(firstIndex, secondIndex, firstValue);
        }
    }
}