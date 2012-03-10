using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestProbability
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
            Characteristic P = new Characteristic(new Probability());
            int ElementCount = 3;
            double Length = 10;
            Assert.AreEqual(ElementCount/Length, P.Value(TestUChain, LinkUp.Both));
            Assert.AreEqual(ElementCount/Length, P.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(ElementCount/Length, P.Value(TestUChain, LinkUp.End));


            /* Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + P.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + P.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + P.Value(TestUChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic P = new Characteristic(new Probability());
            Assert.AreEqual(1, P.Value(TestChain, LinkUp.Both));
            Assert.AreEqual(1, P.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(1, P.Value(TestChain, LinkUp.End));


/*            Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + P.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + P.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + P.Value(TestChain, LinkUp.End));*/
        }
    }
}