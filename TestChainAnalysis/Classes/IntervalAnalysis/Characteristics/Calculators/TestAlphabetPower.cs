using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestAlphabetPower
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

            // TextWriterTraceListener Lisen = new TextWriterTraceListener("Characteristic_log" + GetType() + ".txt");
            //Debug.Listeners.Add(Lisen);
        }


        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            Characteristic deltaA = new Characteristic(new AlphabetPower());
   

            Assert.AreEqual(1, deltaA.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(1, deltaA.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(1, deltaA.Value(TestUChain, LinkUp.Both));

            /*Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + deltaA.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + deltaA.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + deltaA.Value(TestUChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic deltaA = new Characteristic(new AlphabetPower());
            int Alphabet_power = 3;
            Assert.AreEqual(Alphabet_power, TestChain.Alpahbet.power);
            Assert.AreEqual(Alphabet_power, deltaA.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(Alphabet_power, deltaA.Value(TestChain, LinkUp.End));
            Assert.AreEqual(Alphabet_power, deltaA.Value(TestChain, LinkUp.Both));

            /* Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + deltaA.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + deltaA.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + deltaA.Value(TestChain, LinkUp.End));*/
        }
    }
}