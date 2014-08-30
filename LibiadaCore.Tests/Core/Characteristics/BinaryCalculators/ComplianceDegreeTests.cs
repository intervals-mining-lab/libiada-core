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
        [TestCase(1, 0.9428, 0)]
        [TestCase(2, 0.9428, 0)]
        [TestCase(4, 0.9938, 0)]
        [TestCase(5, 0.9991, 0)]
        [TestCase(6, 0.5151, 0)]
        [TestCase(12, 0.9710, 0.5)]
        [TestCase(15, 0.3563, 0)]
        public void ComplianceDegreeTest(int index, double firstValue, double secondValue)
        {
            CalculationTest(index, firstValue, secondValue);
        }
    }
}