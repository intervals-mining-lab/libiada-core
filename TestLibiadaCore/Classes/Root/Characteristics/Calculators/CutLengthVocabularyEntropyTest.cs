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
    public class CutLengthVocabularyEntropyTest
    {
        private ObjectMother Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            Mother = new ObjectMother();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CutLengthVocabularyEntropyChainTest()
        {
            Characteristic Characteristic = new Characteristic(new CutLengthVocabularyEntropy());

            Chain TestChain = Mother.TestChain();

            int Count = (int) (TestChain.Length - TestChain.GetCharacteristic(LinkUp.Start,new CutLength())+1);
            Assert.AreEqual(Math.Log(Count, 2), Characteristic.Value(TestChain, LinkUp.Both));
            Assert.AreEqual(Math.Log(Count, 2), Characteristic.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(Math.Log(Count, 2), Characteristic.Value(TestChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CutLengthVocabularyEntropyUChainTest()
        {
            Characteristic Characteristic = new Characteristic(new CutLengthVocabularyEntropy());

            UniformChain TestChain = Mother.TestUniformChain();

            int Count = (int)(TestChain.Length - TestChain.GetCharacteristic(LinkUp.Start, new CutLength()) + 1);
            Assert.AreEqual(Math.Log(Count ,2), Characteristic.Value(TestChain, LinkUp.Both));
            Assert.AreEqual(Math.Log(Count, 2), Characteristic.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(Math.Log(Count, 2), Characteristic.Value(TestChain, LinkUp.End));
        }
    }
}