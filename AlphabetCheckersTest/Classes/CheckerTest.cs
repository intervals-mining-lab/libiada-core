using AlphaberCheckers.Classes;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using NUnit.Framework;

namespace AlphabetCheckersTest.Classes
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class CheckerTest
    {
        ///<summary>
        ///</summary>
        [Test]
        public void CheckTrue()
        {
            BaseChain chainBase = new BaseChain(10);

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

            Alphabet alBase = new Alphabet
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

            Checker checker = new Checker(alBase);
            Assert.AreEqual(true , checker.Check(chainBase));
        }
        ///<summary>
        ///</summary>
        [Test]
        public void CheckFalse()
        {
            BaseChain chainBase = new BaseChain(10);

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

            Alphabet alBase = new Alphabet
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
            //alBase.Add(new ValueChar('7'));

            Checker checker = new Checker(alBase);
            Assert.AreEqual(false, checker.Check(chainBase));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CheckTrueLongAlphabet()
        {

            BaseChain chainBase = new BaseChain(10);

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

            Alphabet alBase = new Alphabet();

            BaseChain alph = new BaseChain(2);
            alph[0]=(new ValueChar('9'));
            alph[1] = (new ValueChar('A'));
            alBase.Add(alph);
                        
            alph[0] = (new ValueChar('6'));
            alph[1] = (new ValueChar('7'));
            alBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('8'));
            alBase.Add(alph);

            alph = new BaseChain(3);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alph[2] = (new ValueChar('3'));
            alBase.Add(alph);

            alph = new BaseChain(2);
            alph[0] = (new ValueChar('4'));
            alph[1] = (new ValueChar('5'));
            alBase.Add(alph);

            Checker checker = new Checker(alBase);
            Assert.AreEqual(true, checker.Check(chainBase));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CheckFalseLongAlphabet()
        {

            BaseChain chainBase = new BaseChain(10);

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

            Alphabet alBase = new Alphabet();

            BaseChain alph = new BaseChain(1);
            alph[0] = (new ValueChar('9'));
            //alph[1] = (new ValueChar('A'));
            alBase.Add(alph);

            alph = new BaseChain(2);
            alph[0] = (new ValueChar('6'));
            alph[1] = (new ValueChar('7'));
            alBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('8'));
            alBase.Add(alph);

            alph = new BaseChain(3);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alph[2] = (new ValueChar('3'));
            alBase.Add(alph);

            alph = new BaseChain(2);
            alph[0] = (new ValueChar('4'));
            alph[1] = (new ValueChar('5'));
            alBase.Add(alph);

            Checker checker = new Checker(alBase);
            Assert.AreEqual(false, checker.Check(chainBase));
        }
        ///<summary>
        ///</summary>
        [Test]
        public void CheckSuperLongAlphabet()
        {

            BaseChain chainBase = new BaseChain(10);

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

            Alphabet alBase = new Alphabet();

            BaseChain alph = new BaseChain(3);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alph[2] = (new ValueChar('3'));
            alBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('4'));
            alBase.Add(alph);
            
            alph = new BaseChain(2);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('2'));
            alBase.Add(alph);

            Checker checker = new Checker(alBase);
            Assert.AreEqual(true, checker.Check(chainBase));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void DivisionSuperLongAlphabet()
        {

            BaseChain chainBase = new BaseChain(10);

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

            Alphabet alBase = new Alphabet();

            BaseChain alph1 = new BaseChain(3);
            alph1[0] = (new ValueChar('1'));
            alph1[1] = (new ValueChar('2'));
            alph1[2] = (new ValueChar('3'));
            alBase.Add(alph1);

            BaseChain alph2 = new BaseChain(1);
            alph2[0] = (new ValueChar('4'));
            alBase.Add(alph2);

            BaseChain alph3 = new BaseChain(2);
            alph3[0] = (new ValueChar('1'));
            alph3[1] = (new ValueChar('2'));
            alBase.Add(alph3);

            BaseChain alph4 = new BaseChain(1);
            alph4[0] = (new ValueChar('2'));
            alBase.Add(alph4);

            Checker checker = new Checker(alBase);
            BaseChain result = checker.Divide(chainBase);

            Assert.AreEqual(alph3, result[4]);
            Assert.AreEqual(alph4, result[3]);
            Assert.AreEqual(alph1, result[2]);
            Assert.AreEqual(alph2, result[1]);
            Assert.AreEqual(alph1, result[0]);
        }
    }
}