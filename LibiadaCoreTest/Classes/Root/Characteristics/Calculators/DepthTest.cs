namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    [TestFixture]
    public class DepthTest : AbstractCalculatorTest
    {
        public DepthTest()
        {
            calc = new Depth();
        }

        [TestCase(0, Link.None, 1.585)]
        [TestCase(0, Link.Start, 3.585)]
        [TestCase(0, Link.End, 3.1699)]
        [TestCase(0, Link.Both, 5.1699)]
        [TestCase(0, Link.Cycle, 4.1699)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 7.1699)]
        [TestCase(0, Link.Start, 11.0768)]
        [TestCase(0, Link.End, 10.1699)]
        [TestCase(0, Link.Both, 14.0768)]
        [TestCase(0, Link.Cycle, 12.3399)]
        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}