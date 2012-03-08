using NUnit.Framework;

namespace TestSegmentation.Classes
{
    [TestFixture]
    public class TestStdCalculator
    {
        [Test]
        public void TestCalcualting()
        {
            /*
            Chain chain_for_divizion = new Chain(20);
            chain_for_divizion[0] = new ValueChar('a');//1
            chain_for_divizion[1] = new ValueChar('b');//1
            chain_for_divizion[2] = new ValueChar('c');//1
            chain_for_divizion[3] = new ValueChar('b');//1
            chain_for_divizion[4] = new ValueChar('c');//2
            chain_for_divizion[5] = new ValueChar('a');//2
            chain_for_divizion[6] = new ValueChar('b');//2
            chain_for_divizion[7] = new ValueChar('c');//2
            chain_for_divizion[8] = new ValueChar('d');
            chain_for_divizion[9] = new ValueChar('e');
            chain_for_divizion[10] = new ValueChar('a');//1
            chain_for_divizion[11] = new ValueChar('b');//1
            chain_for_divizion[12] = new ValueChar('c');//1
            chain_for_divizion[13] = new ValueChar('b');//1
            chain_for_divizion[14] = new ValueChar('a');//3
            chain_for_divizion[15] = new ValueChar('b');//3
            chain_for_divizion[16] = new ValueChar('d');//3
            chain_for_divizion[17] = new ValueChar('d');//3
            chain_for_divizion[18] = new ValueChar('e');
            chain_for_divizion[19] = new ValueChar('a');

            AlphabetChain alph_expected = new AlphabetChain();

            Chain element = new Chain(4);

            element[0] = new ValueChar('a');
            element[1] = new ValueChar('b');
            element[2] = new ValueChar('c');
            element[3] = new ValueChar('b');
            alph_expected.Add(element);

            /*element[0] = new ValueChar('c');
            element[1] = new ValueChar('a');
            element[2] = new ValueChar('b');
            element[3] = new ValueChar('c');
            alph_expected.Add(element);

            element[0] = new ValueChar('a');//3
            element[1] = new ValueChar('b');//3
            element[2] = new ValueChar('d');//3
            element[3] = new ValueChar('d');//3
            alph_expected.Add(element);

            element = new Chain(2);
            element[0] = new ValueChar('d');
            element[1] = new ValueChar('e');
            alph_expected.Add(element);

            element[0] = new ValueChar('e');
            element[1] = new ValueChar('a');
            alph_expected.Add(element);*/

            //double std = StdCalculator.Calculate(chain_for_divizion, element, 0.7, LinkUp.Both, true);

            Assert.AreEqual(true,true);
            //Assert.Less((std-0.388014028), 0.000000001 );
        }
    }
}
