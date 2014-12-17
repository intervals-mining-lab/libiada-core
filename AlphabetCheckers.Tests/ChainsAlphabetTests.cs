namespace AlphabetCheckers.Tests
{
    using System.Collections;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet chains test.
    /// </summary>
    [TestFixture]
    public class ChainsAlphabetTests
    {
        /// <summary>
        /// The chain base.
        /// </summary>
        private BaseChain chainBase;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            chainBase = new BaseChain(10);
            chainBase[0] = new ValueString('1');
            chainBase[1] = new ValueString('2');
            chainBase[2] = new ValueString('3');
            chainBase[3] = new ValueString('4');
            chainBase[4] = new ValueString('5');
            chainBase[5] = new ValueString('6');
            chainBase[6] = new ValueString('7');
            chainBase[7] = new ValueString('8');
            chainBase[8] = new ValueString('9');
            chainBase[9] = new ValueString('A');
        }

        /// <summary>
        /// The add chain test.
        /// </summary>
        [Test]
        public void AddChainTest()
        {
            var temp = new ChainsAlphabet { chainBase };
            var result = (BaseChain)temp[0];
            Assert.AreEqual(chainBase, result);
        }

        /// <summary>
        /// The add value test.
        /// </summary>
        [Test]
        public void AddValueTest()
        {
            var temp = new ChainsAlphabet();
            var a = new ValueString('A');
            temp.Add(a);
            var b = (BaseChain)temp[0];
            Assert.AreEqual(1, b.GetLength());
            Assert.AreEqual(a, b[0]);
        }

        /// <summary>
        /// The sort list test.
        /// </summary>
        [Test]
        public void SortListTest()
        {
            var temp = new ChainsAlphabet();
            var a = new BaseChain(2);
            for (int i = 0; i < a.GetLength(); i++)
            {
                a.Set((ValueInt)i, i);
            }

            temp.Add(a);
            var b = new BaseChain(1);
            for (int i = 0; i < b.GetLength(); i++)
            {
                b.Set((ValueInt)i, i);
            }

            temp.Add(b);
            var c = new BaseChain(5);
            for (int i = 0; i < c.GetLength(); i++)
            {
                c.Set((ValueInt)i, i);
            }

            temp.Add(c);
            var d = new BaseChain(2);
            for (int i = 0; i < d.GetLength(); i++)
            {
                d.Set((ValueInt)(i + 1), i);
            }

            temp.Add(d);
            ArrayList list = temp.GetLengthList();
            Assert.AreEqual(5, list[2]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(1, list[0]);
        }
    }
}