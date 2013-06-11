using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestCutLength
    {
        private ChainsForTests Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            Mother = new ChainsForTests();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCutLengthChain()
        {
            CutLength cutLength = new CutLength();

            Chain testChain = Mother.TestChain();

            Assert.AreEqual(3, cutLength.Calculate(testChain, LinkUp.Both));
            Assert.AreEqual(3, cutLength.Calculate(testChain, LinkUp.Start));
            Assert.AreEqual(3, cutLength.Calculate(testChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCutLengthUChain()
        {
            CutLength cutLength = new CutLength();

            UniformChain testChain = Mother.TestUniformChain();

            Assert.AreEqual(4, cutLength.Calculate(testChain, LinkUp.Both));
            Assert.AreEqual(4, cutLength.Calculate(testChain, LinkUp.Start));
            Assert.AreEqual(4, cutLength.Calculate(testChain, LinkUp.End));
        }
    }
}