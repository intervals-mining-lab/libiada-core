using NUnit.Framework;

namespace TestPhantomChains.Classes.PhantomChains.Characteristics
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestPhantonChainsCount
    {
        private ObjectMotherPMessageTest Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            Mother = new ObjectMotherPMessageTest();
        }

        ///<summary>
        /// In this test we need to check count of different chains we could generate
        /// form our phantom chain
        ///</summary>
        [Test]
        public void TestCountOfAvaliablePhantomChains()
        {
            //Source chain 
            // Looks like
            // B_C|A|A|B_C|A|B_C|A|B_C|A|A
            // count of different chains we could generate
            // form our phantom chain is multipication of count elements in phantom message for each element of chain
            // So it would be 
            //B_C|A|A|B_C|A|B_C|A|B_C|A|A
            // 2 *1*1* 2 *1* 2 *1* 2 *1*1 

            NullRebuilder<Chain, BaseChain> Converter = new NullRebuilder<Chain, BaseChain>();
            // Convert from BaseChain to Chain (BaseChain does not have characteristics)
            Chain SourceChain = Converter.Rebuild(Mother.SourceChain);
            Assert.AreEqual(16, SourceChain.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.PhChainCount));

        }

    }
}
