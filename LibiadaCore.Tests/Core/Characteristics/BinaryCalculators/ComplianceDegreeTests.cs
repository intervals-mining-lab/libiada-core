namespace LibiadaCore.Tests.Core.Characteristics.BinaryCalculators
{
    using NUnit.Framework;

    /// <summary>
    /// The compliance degree tests.
    /// </summary>
    [TestFixture]
    public class ComplianceDegreeTests : BinaryCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("ComplianceDegree");
        }

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
        [TestCase(0, 1.7321, 1)]
        public void ComplianceDegreeTest(int index, double firstValue, double secondValue)
        {
            CalculationTest(index, firstValue, secondValue);
        }
    }
}