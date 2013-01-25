using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class CountTest
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();

            /* TextWriterTraceListener Lisen = new TextWriterTraceListener("Characteristic_log" + GetType() + ".txt");
            Debug.Listeners.Add(Lisen);*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CalculationTest()
        {
            Characteristic N = new Characteristic(new Count());
            int ElementCount = 3;
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.Both));
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
        public void CalculatorForChainTest()
        {
            Characteristic N = new Characteristic(new Count());
            int ElementCount = 10;
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.Both));
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.End));


            /*   Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + N.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + N.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + N.Value(TestChain, LinkUp.End));*/
        }
    }
}