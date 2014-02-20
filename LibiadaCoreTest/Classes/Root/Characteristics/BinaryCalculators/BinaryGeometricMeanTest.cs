namespace LibiadaCoreTest.Classes.Root.Characteristics.BinaryCalculators
{
    using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;

    using NUnit.Framework;

    [TestFixture]
    public class BinaryGeometricMeanTest : AbstractBinaryCalculatorTest
    {
        [TestCase(0, 1.7321, 1)]
        public void SpatialDependenceTest(int index, double firstValue, double secondValue)
        {
            var calculator = new BinaryGeometricMean();

            CalculationTest(calculator, index, firstValue, secondValue);
        }
    }
}