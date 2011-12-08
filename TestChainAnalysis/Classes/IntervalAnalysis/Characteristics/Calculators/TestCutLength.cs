using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestCutLength
    {
        private ObjectMother Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            Mother = new ObjectMother();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCutLengthChain()
        {
            Characteristic Characteristic = new Characteristic(new CutLength());

            Chain TestChain = Mother.TestChain();

            Assert.AreEqual(3, Characteristic.Value(TestChain, LinkUp.Both));
            Assert.AreEqual(3, Characteristic.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(3, Characteristic.Value(TestChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCutLengthUChain()
        {
            Characteristic Characteristic = new Characteristic(new CutLength());

            UniformChain TestChain = Mother.TestUniformChain();

            Assert.AreEqual(4, Characteristic.Value(TestChain, LinkUp.Both));
            Assert.AreEqual(4, Characteristic.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(4, Characteristic.Value(TestChain, LinkUp.End));
        }
    }
}