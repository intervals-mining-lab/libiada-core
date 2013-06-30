using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestDescriptiveInformation : AbstractCalculatorTest
    {
        public TestDescriptiveInformation()
        {
            calc = new DescriptiveInformation();
        }

        [TestCase(0, LinkUp.None, 1.435)]
        [TestCase(0, LinkUp.Start, 1.435)]
        [TestCase(0, LinkUp.End, 1.435)]
        [TestCase(0, LinkUp.Both, 1.435)]
        [TestCase(0, LinkUp.Cycle, 1.435)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            TestUniformChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 2.971)]
        [TestCase(0, LinkUp.Start, 2.971)]
        [TestCase(0, LinkUp.End, 2.971)]
        [TestCase(0, LinkUp.Both, 2.971)]
        [TestCase(0, LinkUp.Cycle, 2.971)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}