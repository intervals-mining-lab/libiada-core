using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestBinaryGeometricMean : AbstractBinaryCalculatorTest
    {
        [TestCase(0, 1.7321, 1)]
        public void TestSpatialDependence(int index, double firstValue, double secondValue)
        {
            BinaryGeometricMean calculator = new BinaryGeometricMean();

            CalculationTest(calculator, index, firstValue, secondValue);
        }
    }
}