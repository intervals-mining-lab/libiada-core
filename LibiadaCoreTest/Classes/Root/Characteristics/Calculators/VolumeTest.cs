namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    [TestFixture]
    public class VolumeTest : AbstractCalculatorTest
    {
        public VolumeTest()
        {
            calc = new Volume();
        }

        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 12)]
        [TestCase(0, Link.End, 9)]
        [TestCase(0, Link.Both, 36)]
        [TestCase(0, Link.Cycle, 18)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 144)]
        [TestCase(0, Link.Start, 2160)]
        [TestCase(0, Link.End, 1152)]
        [TestCase(0, Link.Both, 17280)]
        [TestCase(0, Link.Cycle, 5184)]
        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}