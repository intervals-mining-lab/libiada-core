using System.Collections;
using AlphaberCheckers.Classes;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestAlphabetCheckers.Classes
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestAlpabetChains
    {
        private BaseChain ChainBase = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ChainBase = new BaseChain(10);
            ChainBase[0] = new ValueChar('1');
            ChainBase[1] = new ValueChar('2');
            ChainBase[2] = new ValueChar('3');
            ChainBase[3] = new ValueChar('4');
            ChainBase[4] = new ValueChar('5');
            ChainBase[5] = new ValueChar('6');
            ChainBase[6] = new ValueChar('7');
            ChainBase[7] = new ValueChar('8');
            ChainBase[8] = new ValueChar('9');
            ChainBase[9] = new ValueChar('A');
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestAddChain()
        {
            AlpabetChains temp = new AlpabetChains();
            temp.Add(ChainBase);
            BaseChain result = (BaseChain) temp[0];
            Assert.AreEqual(ChainBase, result);
        }
        ///<summary>
        ///</summary>
        [Test]
        public void TestAddValue()
        {
            AlpabetChains temp = new AlpabetChains();
            ValueChar a = new ValueChar('A');
            temp.Add(a);
            BaseChain b = (BaseChain)temp[0];
            Assert.AreEqual(1,b.Length);
            Assert.AreEqual(a ,b[0]);
        }
        ///<summary>
        ///</summary>
        [Test]
        public void TestSortList()
        {
            AlpabetChains temp = new AlpabetChains();
            BaseChain a = new BaseChain(2);
            for (int i = 0; i < a.Length; i++)
            {
                a.Add((ValueInt)i, i);
            }
            temp.Add(a);
            BaseChain b = new BaseChain(1);
            for (int i = 0; i < b.Length; i++)
            {
                b.Add((ValueInt)i, i);
            }
            temp.Add(b);
            BaseChain c = new BaseChain(5);
            for (int i = 0; i < c.Length; i++)
            {
                c.Add((ValueInt)i, i);
            }
            temp.Add(c);
            BaseChain d = new BaseChain(2);
            for (int i = 0; i < d.Length; i++)
            {
                d.Add((ValueInt)(i+1), i);
            }
            temp.Add(d);
            ArrayList list = temp.GetLengthList();
            Assert.AreEqual(5, list[2]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(1, list[0]);
        }
    }
}