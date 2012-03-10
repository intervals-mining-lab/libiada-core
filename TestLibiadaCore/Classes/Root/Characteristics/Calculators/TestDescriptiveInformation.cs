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
    public class TestDescriptiveInformation
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

            /*  TextWriterTraceListener Lisen = new TextWriterTraceListener("Characteristic_log" + GetType() + ".txt");
            Debug.Listeners.Add(Lisen);*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForUniformChain()
        {
            Characteristic D = new Characteristic(new DescriptiveInformation());

            double Length = 10;
            double ElementsCount = 3;
            double ArithmeticMean = Length/ElementsCount;
            double Propability = ElementsCount/Length;

            Assert.AreEqual(Math.Pow(ArithmeticMean, Propability) * Math.Pow(1/(1-Propability), 1-Propability), D.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(Math.Pow(ArithmeticMean, Propability) * Math.Pow(1 / (1 - Propability), 1 - Propability), D.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(Math.Pow(ArithmeticMean, Propability) * Math.Pow(1 / (1 - Propability), 1 - Propability), D.Value(TestUChain, LinkUp.Both));


            /*    Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start + " : " + D.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both + " : " + D.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End + " : " + D.Value(TestUChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic D = new Characteristic(new DescriptiveInformation());

            double Length = 10;
            double ElementsACount = 4;
            double ElementsBCount = 3;
            double ElementsCCount = 3;

            double ArithmeticMeanA = Length/ElementsACount;
            double ArithmeticMeanB = Length/ElementsBCount;
            double ArithmeticMeanC = Length/ElementsCCount;

            double PropabilityA = ElementsACount/Length;
            double PropabilityB = ElementsBCount/Length;
            double PropabilityC = ElementsCCount/Length;

            double DA = Math.Pow(ArithmeticMeanA, PropabilityA);
            double DB = Math.Pow(ArithmeticMeanB, PropabilityB);
            double DC = Math.Pow(ArithmeticMeanC, PropabilityC);

            double DTheoretical = DA*DB*DC;

            Assert.AreEqual(DTheoretical, D.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(DTheoretical, D.Value(TestChain, LinkUp.End));
            Assert.AreEqual(DTheoretical, D.Value(TestChain, LinkUp.Both));


            /*   Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start + " : " + D.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both + " : " + D.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End + " : " + D.Value(TestChain, LinkUp.End));*/
        }
    }
}