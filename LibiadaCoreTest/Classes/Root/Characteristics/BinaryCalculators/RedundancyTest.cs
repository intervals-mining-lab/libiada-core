using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class RedundancyTest : AbstractBinaryCalculatorTest
    {
        [TestCase(1, 0, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(3, 0, 0.7282)]
        [TestCase(4, 0.75, 0)]
        [TestCase(5, 0.9091, 0)]
        [TestCase(6, -11, 0)]
        [TestCase(7, -0.5492, 0.9333)]
        [TestCase(8, 0.3563, 0.2615)]
        [TestCase(9, 0.0227, 0.9222)]
        [TestCase(10, 0.6139, 0.5358)]
        [TestCase(11, 0.6898, 0.079)]
        [TestCase(12, 0.2929, 0.5)]
        [TestCase(13, 0.5347, 0.6607)]
        [TestCase(14, 0.7741, 0.2789)]
        [TestCase(15, 0.8571, 0.875)]
        [TestCase(16, 0.4369, 0.6938)]
        [TestCase(17, 0.6072, 0.5636)]
        public void ChainCalculationTest(int index, double firstValue, double secondValue)
        {
            Redundancy calculator = new Redundancy();

            CalculationTest(calculator, index, firstValue, secondValue);
        }
    }
}