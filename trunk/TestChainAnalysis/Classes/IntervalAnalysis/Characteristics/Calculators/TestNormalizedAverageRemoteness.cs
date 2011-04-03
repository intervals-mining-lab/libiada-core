using System;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis.Characteristics.Calculators
{
    [TestFixture]
    public class TestNormalizedAverageRemoteness
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            Characteristic ARemoteness = new Characteristic(new NormalizedAverageRemoteness());

            double Interval1 = 4;
            double Interval2 = 1;
            double Interval3 = 3;
            double Interval4 = 3;

            double pIntervalsCount = 3;

            double deltaG = Math.Pow(Interval1 * Interval2 * Interval3, 1 / pIntervalsCount);
            double pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, ARemoteness.Value(TestUChain, LinkUp.Start));


            pIntervalsCount = 3;

            deltaG = Math.Pow(Interval2 * Interval3 * Interval4, 1 / pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, ARemoteness.Value(TestUChain, LinkUp.End));


            pIntervalsCount = 4;

            deltaG = Math.Pow(Interval1 * Interval2 * Interval3 * Interval4, 1 / pIntervalsCount);
            pAverageRemoteness = Math.Log(deltaG, 2);

            Assert.AreEqual(pAverageRemoteness, ARemoteness.Value(TestUChain, LinkUp.Both));
        }
    }
}