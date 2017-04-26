namespace LibiadaCore.Tests.Core.Characteristics.Calculators.BinaryCalculators
{
    using LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The binary geometric mean test.
    /// </summary>
    [TestFixture]
    public class GeometricMeanTests : BinaryCalculatorsTests<GeometricMean>
    {
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
