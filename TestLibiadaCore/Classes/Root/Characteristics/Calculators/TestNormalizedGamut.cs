using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestNormalizedGamut
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
            Characteristic nG = new Characteristic(new NormalizedGamut());

            double Theory = TestUChain.GetCharacteristic(LinkUp.Start, new Depth())/
                        TestUChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestUChain, LinkUp.Start));

            Theory = TestUChain.GetCharacteristic(LinkUp.End, new Depth()) /
                        TestUChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestUChain, LinkUp.End));

            Theory = TestUChain.GetCharacteristic(LinkUp.Both, new Depth()) /
                        TestUChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic nG = new Characteristic(new NormalizedGamut());

            double Theory = TestChain.GetCharacteristic(LinkUp.Start, new Depth()) /
                        TestChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestChain, LinkUp.Start));

            Theory = TestChain.GetCharacteristic(LinkUp.End, new Depth()) /
                        TestChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestChain, LinkUp.End));

            Theory = TestChain.GetCharacteristic(LinkUp.Both, new Depth()) /
                        TestChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestChain, LinkUp.Both));
        }
    }
}