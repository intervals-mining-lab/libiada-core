using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestIdentificationInformation
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
        public void TestCalculationForUniformChain()
        {
            Characteristic pIdentificationInformation = new Characteristic(new IdentificationInformation());

            double pLength = 10;
            double ElementsCount = 3;

            double deltaA = pLength/ElementsCount;
            double IInformation = Math.Log(deltaA, 2);
            Assert.AreEqual(IInformation, pIdentificationInformation.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(IInformation, pIdentificationInformation.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(IInformation, pIdentificationInformation.Value(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic pIdentificationInformation = new Characteristic(new IdentificationInformation());

            double pLength = 10;
            double ElementsACount = 4;
            double ElementsBCount = 3;
            double ElementsCCount = 3;

            double deltaAA = pLength/ElementsACount;
            double deltaAB = pLength/ElementsBCount;
            double deltaAC = pLength/ElementsCCount;


            double PA = ElementsACount/pLength;
            double PB = ElementsBCount/pLength;
            double PC = ElementsCCount/pLength;


            double IInformationA = PA*Math.Log(deltaAA, 2);
            double IInformationB = PB*Math.Log(deltaAB, 2);
            double IInformationC = PC*Math.Log(deltaAC, 2);


            double IInformation = (IInformationA + IInformationB + IInformationC);

            Assert.AreEqual(IInformation, pIdentificationInformation.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(IInformation, pIdentificationInformation.Value(TestChain, LinkUp.End));
            Assert.AreEqual(IInformation, pIdentificationInformation.Value(TestChain, LinkUp.Both));
        }
    }
}