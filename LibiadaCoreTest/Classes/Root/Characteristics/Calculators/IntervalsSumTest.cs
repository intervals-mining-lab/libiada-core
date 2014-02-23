namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    [TestFixture]
    public class IntervalsSumTest : AbstractCalculatorTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            calc = new IntervalsSum();
        }

        [TestCase(0, Link.None, 4)]
        [TestCase(0, Link.Start, 8)]
        [TestCase(0, Link.End, 7)]
        [TestCase(0, Link.Both, 11)]
        [TestCase(0, Link.Cycle, 10)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
        
        [TestCase(0, Link.None, 17)]
        [TestCase(0, Link.Start, 26)]
        [TestCase(0, Link.End, 24)]
        [TestCase(0, Link.Both, 33)]
        [TestCase(0, Link.Cycle, 30)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}