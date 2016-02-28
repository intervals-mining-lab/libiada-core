namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core.Characteristics;

    using NUnit.Framework;

    /// <summary>
    /// The binary geometric mean test.
    /// </summary>
    [TestFixture]
    public class BinaryGeometricMeanTests : BinaryCalculatorsTests
    {
        /// <summary>
        /// Calculator initialization method.
        /// </summary>
        [OneTimeSetUp]
        public override void Initialization()
        {
            Calculator = CalculatorsFactory.CreateBinaryCalculator("GeometricMean");
        }

        /// <summary>
        /// The spatial dependence test.
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
        public void SpatialDependenceTest(int index, double firstValue, double secondValue)
        {
            CalculationTest(index, firstValue, secondValue);
        }
    }
}
