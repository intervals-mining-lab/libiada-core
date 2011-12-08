using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestIntervalsCount
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
        public void TestCalculation()
        {
            Characteristic N = new Characteristic(new IntervalsCount());
            int ElementCount = 4;
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.Both));

            ElementCount = 3;
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.End));


            /*  Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + N.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + N.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + N.Value(TestUChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic N = new Characteristic(new IntervalsCount());
            int ElementCount = 13;
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.Both));

            ElementCount = 10;
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.End));

            /*  Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + N.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + N.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + N.Value(TestChain, LinkUp.End));*/
        }
    }
}