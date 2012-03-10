using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestArithmeticMean
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
            Characteristic deltaA = new Characteristic(new ArithmeticMean());
            double n = 10;
            double n_j = 3;

            Assert.AreEqual(n/n_j, deltaA.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(n/n_j, deltaA.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(n/n_j, deltaA.Value(TestUChain, LinkUp.Both));

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
            Characteristic deltaA = new Characteristic(new ArithmeticMean());
            double n = 10;
            double n_A = 3;
            double n_B = 4;
            double n_C = 3;
            double sum_ariphmetical = (n/n_A) + (n/n_B) + (n/n_C);
            int Alphabet_power = 3;
            Assert.AreEqual(Alphabet_power, TestChain.Alpahbet.power);
            Assert.AreEqual(sum_ariphmetical/Alphabet_power, deltaA.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(sum_ariphmetical/Alphabet_power, deltaA.Value(TestChain, LinkUp.End));
            Assert.AreEqual(sum_ariphmetical/Alphabet_power, deltaA.Value(TestChain, LinkUp.Both));

            /* Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + deltaA.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + deltaA.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + deltaA.Value(TestChain, LinkUp.End));*/
        }
    }
}