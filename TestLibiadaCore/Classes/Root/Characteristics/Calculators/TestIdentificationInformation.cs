using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestIdentificationInformation : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculationForUniformChain()
        {
            IdentificationInformation identificationInformation = new IdentificationInformation();

            double pLength = 10;
            double elementsCount = 3;

            double deltaA = pLength/elementsCount;
            double information = Math.Log(deltaA, 2);
            Assert.AreEqual(information, identificationInformation.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(information, identificationInformation.Calculate(uniformChains[0], LinkUp.End));
            Assert.AreEqual(information, identificationInformation.Calculate(uniformChains[0], LinkUp.Both));
        }

        [Test]
        public void TestCalculationForChain()
        {
            IdentificationInformation identificationInformation = new IdentificationInformation();

            double pLength = 10;
            const double elementsACount = 4;
            const double elementsBCount = 3;
            const double elementsCCount = 3;

            double deltaAA = pLength/elementsACount;
            double deltaAB = pLength/elementsBCount;
            double deltaAC = pLength/elementsCCount;


            double PA = elementsACount/pLength;
            double PB = elementsBCount/pLength;
            double PC = elementsCCount/pLength;


            double informationA = PA*Math.Log(deltaAA, 2);
            double informationB = PB*Math.Log(deltaAB, 2);
            double informationC = PC*Math.Log(deltaAC, 2);


            double information = (informationA + informationB + informationC);

            Assert.AreEqual(information, identificationInformation.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(information, identificationInformation.Calculate(Chains[0], LinkUp.End));
            Assert.AreEqual(information, identificationInformation.Calculate(Chains[0], LinkUp.Both));
        }
    }
}