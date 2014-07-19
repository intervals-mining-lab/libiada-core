namespace AlphabetCheckers.Tests
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The checker test.
    /// </summary>
    [TestFixture]
    public class CheckerTests
    {
        /// <summary>
        /// The check true.
        /// </summary>
        [Test]
        public void CheckTrue()
        {
            var chainBase = new BaseChain(10);

            chainBase[0] = new ValueChar('1');
            chainBase[1] = new ValueChar('2');
            chainBase[2] = new ValueChar('3');
            chainBase[3] = new ValueChar('4');
            chainBase[4] = new ValueChar('5');
            chainBase[5] = new ValueChar('6');
            chainBase[6] = new ValueChar('7');
            chainBase[7] = new ValueChar('8');
            chainBase[8] = new ValueChar('9');
            chainBase[9] = new ValueChar('A');

            var alphabet = new Alphabet
                {
                    new ValueChar('2'),
                    new ValueChar('3'),
                    new ValueChar('5'),
                    new ValueChar('1'),
                    new ValueChar('4'),
                    new ValueChar('9'),
                    new ValueChar('A'),
                    new ValueChar('8'),
                    new ValueChar('6'),
                    new ValueChar('7')
                };

            var checker = new Checker(alphabet);
            Assert.AreEqual(true, checker.Check(chainBase));
        }

        /// <summary>
        /// The check false.
        /// </summary>
        [Test]
        public void CheckFalse()
        {
            var chainBase = new BaseChain(10);

            chainBase[0] = new ValueChar('1');
            chainBase[1] = new ValueChar('2');
            chainBase[2] = new ValueChar('3');
            chainBase[3] = new ValueChar('4');
            chainBase[4] = new ValueChar('5');
            chainBase[5] = new ValueChar('6');
            chainBase[6] = new ValueChar('7');
            chainBase[7] = new ValueChar('8');
            chainBase[8] = new ValueChar('9');
            chainBase[9] = new ValueChar('A');

            var alphabet = new Alphabet
                {
                    new ValueChar('2'),
                    new ValueChar('3'),
                    new ValueChar('5'),
                    new ValueChar('1'),
                    new ValueChar('4'),
                    new ValueChar('9'),
                    new ValueChar('A'),
                    new ValueChar('8'),
                    new ValueChar('6')
                };
            var checker = new Checker(alphabet);
            Assert.AreEqual(false, checker.Check(chainBase));
        }

        /// <summary>
        /// The check true long alphabet.
        /// </summary>
        [Test]
        public void CheckTrueLongAlphabet()
        {
            var chainBase = new BaseChain(10);

            chainBase[0] = new ValueChar('1');
            chainBase[1] = new ValueChar('2');
            chainBase[2] = new ValueChar('3');
            chainBase[3] = new ValueChar('4');
            chainBase[4] = new ValueChar('5');
            chainBase[5] = new ValueChar('6');
            chainBase[6] = new ValueChar('7');
            chainBase[7] = new ValueChar('8');
            chainBase[8] = new ValueChar('9');
            chainBase[9] = new ValueChar('A');

            var alphabet = new Alphabet();

            var chain = new BaseChain(2);
            chain[0] = new ValueChar('9');
            chain[1] = new ValueChar('A');
            alphabet.Add(chain);
                        
            chain[0] = new ValueChar('6');
            chain[1] = new ValueChar('7');
            alphabet.Add(chain);

            chain = new BaseChain(1);
            chain[0] = new ValueChar('8');
            alphabet.Add(chain);

            chain = new BaseChain(3);
            chain[0] = new ValueChar('1');
            chain[1] = new ValueChar('2');
            chain[2] = new ValueChar('3');
            alphabet.Add(chain);

            chain = new BaseChain(2);
            chain[0] = new ValueChar('4');
            chain[1] = new ValueChar('5');
            alphabet.Add(chain);

            var checker = new Checker(alphabet);
            Assert.AreEqual(true, checker.Check(chainBase));
        }

        /// <summary>
        /// The check false long alphabet.
        /// </summary>
        [Test]
        public void CheckFalseLongAlphabet()
        {
            var chainBase = new BaseChain(10);

            chainBase[0] = new ValueChar('1');
            chainBase[1] = new ValueChar('2');
            chainBase[2] = new ValueChar('3');
            chainBase[3] = new ValueChar('4');
            chainBase[4] = new ValueChar('5');
            chainBase[5] = new ValueChar('6');
            chainBase[6] = new ValueChar('7');
            chainBase[7] = new ValueChar('8');
            chainBase[8] = new ValueChar('9');
            chainBase[9] = new ValueChar('A');

            var alphabet = new Alphabet();

            var chain = new BaseChain(1);
            chain[0] = new ValueChar('9');
            alphabet.Add(chain);

            chain = new BaseChain(2);
            chain[0] = new ValueChar('6');
            chain[1] = new ValueChar('7');
            alphabet.Add(chain);

            chain = new BaseChain(1);
            chain[0] = new ValueChar('8');
            alphabet.Add(chain);

            chain = new BaseChain(3);
            chain[0] = new ValueChar('1');
            chain[1] = new ValueChar('2');
            chain[2] = new ValueChar('3');
            alphabet.Add(chain);

            chain = new BaseChain(2);
            chain[0] = new ValueChar('4');
            chain[1] = new ValueChar('5');
            alphabet.Add(chain);

            var checker = new Checker(alphabet);
            Assert.AreEqual(false, checker.Check(chainBase));
        }

        /// <summary>
        /// The check super long alphabet.
        /// </summary>
        [Test]
        public void CheckSuperLongAlphabet()
        {
            var chainBase = new BaseChain(10);

            chainBase[0] = new ValueChar('1');
            chainBase[1] = new ValueChar('2');
            chainBase[2] = new ValueChar('3');

            chainBase[3] = new ValueChar('4');

            chainBase[4] = new ValueChar('1');
            chainBase[5] = new ValueChar('2');
            chainBase[6] = new ValueChar('3');

            chainBase[7] = new ValueChar('2');

            chainBase[8] = new ValueChar('1');
            chainBase[9] = new ValueChar('2');

            var alphabet = new Alphabet();
            
            var chain = new BaseChain(3);
            chain[0] = new ValueChar('1');
            chain[1] = new ValueChar('2');
            chain[2] = new ValueChar('3');
            alphabet.Add(chain);

            chain = new BaseChain(1);
            chain[0] = new ValueChar('4');
            alphabet.Add(chain);
            
            chain = new BaseChain(2);
            chain[0] = new ValueChar('1');
            chain[1] = new ValueChar('2');
            alphabet.Add(chain);

            chain = new BaseChain(1);
            chain[0] = new ValueChar('2');
            alphabet.Add(chain);

            var checker = new Checker(alphabet);
            Assert.AreEqual(true, checker.Check(chainBase));
        }

        /// <summary>
        /// The division super long alphabet.
        /// </summary>
        [Test]
        public void DivisionSuperLongAlphabet()
        {
            var chainBase = new BaseChain(10);

            chainBase[0] = new ValueChar('1');
            chainBase[1] = new ValueChar('2');
            chainBase[2] = new ValueChar('3');

            chainBase[3] = new ValueChar('4');

            chainBase[4] = new ValueChar('1');
            chainBase[5] = new ValueChar('2');
            chainBase[6] = new ValueChar('3');

            chainBase[7] = new ValueChar('2');

            chainBase[8] = new ValueChar('1');
            chainBase[9] = new ValueChar('2');

            var alphabet = new Alphabet();

            var chain = new BaseChain(3);
            chain[0] = new ValueChar('1');
            chain[1] = new ValueChar('2');
            chain[2] = new ValueChar('3');
            alphabet.Add(chain);

            var chain2 = new BaseChain(1);
            chain2[0] = new ValueChar('4');
            alphabet.Add(chain2);

            var chain3 = new BaseChain(2);
            chain3[0] = new ValueChar('1');
            chain3[1] = new ValueChar('2');
            alphabet.Add(chain3);

            var chain4 = new BaseChain(1);
            chain4[0] = new ValueChar('2');
            alphabet.Add(chain4);

            var checker = new Checker(alphabet);
            BaseChain result = checker.Divide(chainBase);

            Assert.AreEqual(chain3, result[4]);
            Assert.AreEqual(chain4, result[3]);
            Assert.AreEqual(chain, result[2]);
            Assert.AreEqual(chain2, result[1]);
            Assert.AreEqual(chain, result[0]);
        }
    }
}