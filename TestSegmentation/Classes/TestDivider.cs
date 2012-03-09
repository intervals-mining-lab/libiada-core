using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;
using Segmentation.Classes;
using Segmentation.Classes.Criteria;

namespace TestSegmentation.Classes
{
    [TestFixture]
    public class TestDivider
    {
        [Test]
        public void TestDivide()
        {
            Chain chain_for_divizion = new Chain(20);
            chain_for_divizion[0] = new ValueChar('a');
            chain_for_divizion[1] = new ValueChar('b');
            chain_for_divizion[2] = new ValueChar('c');
            chain_for_divizion[3] = new ValueChar('b');
            chain_for_divizion[4] = new ValueChar('c');
            chain_for_divizion[5] = new ValueChar('a');
            chain_for_divizion[6] = new ValueChar('b');
            chain_for_divizion[7] = new ValueChar('c');
            chain_for_divizion[8] = new ValueChar('d');
            chain_for_divizion[9] = new ValueChar('e');
            chain_for_divizion[10] = new ValueChar('a');
            chain_for_divizion[11] = new ValueChar('b');
            chain_for_divizion[12] = new ValueChar('c');
            chain_for_divizion[13] = new ValueChar('b');
            chain_for_divizion[14] = new ValueChar('a');
            chain_for_divizion[15] = new ValueChar('b');
            chain_for_divizion[16] = new ValueChar('d');
            chain_for_divizion[17] = new ValueChar('d');
            chain_for_divizion[18] = new ValueChar('e');
            chain_for_divizion[19] = new ValueChar('a');

            Divider diver = new Divider(chain_for_divizion, 0.7,4,LinkUp.Both,Method.Convoluted,100,0.001);

            diver.Divizion_with_inspection();
            AlphabetChain alph = diver.full_alphabet;
            
            double l= diver.best_level;
            
            Assert.AreEqual(true,true);
        }
    }
}
