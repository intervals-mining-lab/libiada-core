namespace AlphabetCheckers.Tests.Classes
{
    using System.Collections;

    using AlphabetCheckers.Classes;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet chains test.
    /// </summary>
    [TestFixture]
    public class AlphabetChainsTests
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
            this.chainBase = new BaseChain(10);
            this.chainBase[0] = new ValueChar('1');
            this.chainBase[1] = new ValueChar('2');
            this.chainBase[2] = new ValueChar('3');
            this.chainBase[3] = new ValueChar('4');
            this.chainBase[4] = new ValueChar('5');
            this.chainBase[5] = new ValueChar('6');
            this.chainBase[6] = new ValueChar('7');
            this.chainBase[7] = new ValueChar('8');
            this.chainBase[8] = new ValueChar('9');
            this.chainBase[9] = new ValueChar('A');
        }

        /// <summary>
        /// The add chain test.
        /// </summary>
        [Test]
        public void AddChainTest()
        {
            var temp = new ChainsAlphabet { this.chainBase };
            var result = (BaseChain)temp[0];
            Assert.AreEqual(this.chainBase, result);
        }

        /// <summary>
        /// The add value test.
        /// </summary>
        [Test]
        public void AddValueTest()
        {
            var temp = new ChainsAlphabet();
            var a = new ValueChar('A');
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
                a.Add((ValueInt)i, i);
            }

            temp.Add(a);
            var b = new BaseChain(1);
            for (int i = 0; i < b.GetLength(); i++)
            {
                b.Add((ValueInt)i, i);
            }

            temp.Add(b);
            var c = new BaseChain(5);
            for (int i = 0; i < c.GetLength(); i++)
            {
                c.Add((ValueInt)i, i);
            }

            temp.Add(c);
            var d = new BaseChain(2);
            for (int i = 0; i < d.GetLength(); i++)
            {
                d.Add((ValueInt)(i + 1), i);
            }

            temp.Add(d);
            ArrayList list = temp.GetLengthList();
            Assert.AreEqual(5, list[2]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(1, list[0]);
        }
    }
}