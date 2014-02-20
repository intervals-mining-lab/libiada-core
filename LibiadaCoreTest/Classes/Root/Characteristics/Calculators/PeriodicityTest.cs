namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    [TestFixture]
    public class PeriodicityTest : AbstractCalculatorTest
    {
        public PeriodicityTest()
        {
            calc = new Periodicity();
        }

        [TestCase(0, Link.None, 0.8661)]
        [TestCase(0, Link.Start, 0.8585)]
        [TestCase(0, Link.End, 0.8915)]
        [TestCase(0, Link.Both, 0.8907)]
        [TestCase(0, Link.Cycle, 0.7862)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 0.8375)]
        [TestCase(0, Link.Start, 0.8288)]
        [TestCase(0, Link.End, 0.8432)]
        [TestCase(0, Link.Both, 0.8344)]
        [TestCase(0, Link.Cycle, 0.7841)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}