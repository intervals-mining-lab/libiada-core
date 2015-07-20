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
        public void ComplianceDegreeTest(int firstIndex, int secondIndex, double firstValue)
        {
            CalculationTest(firstIndex, secondIndex, firstValue);
        }
    }
}