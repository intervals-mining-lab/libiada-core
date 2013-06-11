using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestDescriptiveInformation
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ChainsForTests mother = new ChainsForTests();
            TestUChain = mother.TestUniformChain();
            TestChain = mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForUniformChain()
        {
            DescriptiveInformation descriptiveInformation = new DescriptiveInformation();

            const double length = 10;
            const double elementsCount = 3;
            const double arithmeticMean = length/elementsCount;
            const double propability = elementsCount/length;

            Assert.AreEqual(Math.Pow(arithmeticMean, propability)*Math.Pow(1/(1 - propability), 1 - propability),
                            descriptiveInformation.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(Math.Pow(arithmeticMean, propability)*Math.Pow(1/(1 - propability), 1 - propability),
                            descriptiveInformation.Calculate(TestUChain, LinkUp.End));
            Assert.AreEqual(Math.Pow(arithmeticMean, propability)*Math.Pow(1/(1 - propability), 1 - propability),
                            descriptiveInformation.Calculate(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            DescriptiveInformation descriptiveInformation = new DescriptiveInformation();

            const double length = 10;
            const double elementsACount = 4;
            const double elementsBCount = 3;
            const double elementsCCount = 3;

            const double arithmeticMeanA = length/elementsACount;
            const double arithmeticMeanB = length/elementsBCount;
            const double arithmeticMeanC = length/elementsCCount;

            const double propabilityA = elementsACount/length;
            const double propabilityB = elementsBCount/length;
            const double propabilityC = elementsCCount/length;

            double DA = Math.Pow(arithmeticMeanA, propabilityA);
            double DB = Math.Pow(arithmeticMeanB, propabilityB);
            double DC = Math.Pow(arithmeticMeanC, propabilityC);

            double DTheoretical = DA*DB*DC;

            Assert.AreEqual(DTheoretical, descriptiveInformation.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(DTheoretical, descriptiveInformation.Calculate(TestChain, LinkUp.End));
            Assert.AreEqual(DTheoretical, descriptiveInformation.Calculate(TestChain, LinkUp.Both));
        }
    }
}