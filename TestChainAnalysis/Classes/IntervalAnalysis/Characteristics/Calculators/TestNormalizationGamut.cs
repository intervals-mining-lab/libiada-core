using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestNomalizationGamut
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
            Characteristic nG = new Characteristic(new NomalizationGamut());

            double Theory = TestUChain.GetCharacteristic(LinkUp.Start, new Gamut())/
                        TestUChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestUChain, LinkUp.Start));

            Theory = TestUChain.GetCharacteristic(LinkUp.End, new Gamut()) /
                        TestUChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestUChain, LinkUp.End));

            Theory = TestUChain.GetCharacteristic(LinkUp.Both, new Gamut()) /
                        TestUChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic nG = new Characteristic(new NomalizationGamut());

            double Theory = TestChain.GetCharacteristic(LinkUp.Start, new Gamut()) /
                        TestChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestChain, LinkUp.Start));

            Theory = TestChain.GetCharacteristic(LinkUp.End, new Gamut()) /
                        TestChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestChain, LinkUp.End));

            Theory = TestChain.GetCharacteristic(LinkUp.Both, new Gamut()) /
                        TestChain.GetCharacteristic(LinkUp.Both, new Length());

            Assert.AreEqual(Theory, nG.Value(TestChain, LinkUp.Both));
        }
    }
}