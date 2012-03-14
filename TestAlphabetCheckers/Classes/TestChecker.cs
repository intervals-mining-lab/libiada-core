using AlphaberCheckers.Classes;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using NUnit.Framework;

namespace TestAlphabetCheckers.Classes
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestChecker
    {
        ///<summary>
        ///</summary>
        [Test]
        public void CheckTrue()
        {
            BaseChain ChainBase = new BaseChain(10);

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

            Alphabet AlBase = new Alphabet();
            AlBase.Add(new ValueChar('2'));
            AlBase.Add(new ValueChar('3'));
            AlBase.Add(new ValueChar('5'));
            AlBase.Add(new ValueChar('1'));
            AlBase.Add(new ValueChar('4'));
            AlBase.Add(new ValueChar('9'));
            AlBase.Add(new ValueChar('A'));
            AlBase.Add(new ValueChar('8'));
            AlBase.Add(new ValueChar('6'));
            AlBase.Add(new ValueChar('7'));

            Checker checker = new Checker(AlBase);
            Assert.AreEqual(true , checker.check(ChainBase));
        }
        ///<summary>
        ///</summary>
        [Test]
        public void CheckFalse()
        {
            BaseChain ChainBase = new BaseChain(10);

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

            Alphabet AlBase = new Alphabet();
            AlBase.Add(new ValueChar('2'));
            AlBase.Add(new ValueChar('3'));
            AlBase.Add(new ValueChar('5'));
            AlBase.Add(new ValueChar('1'));
            AlBase.Add(new ValueChar('4'));
            AlBase.Add(new ValueChar('9'));
            AlBase.Add(new ValueChar('A'));
            AlBase.Add(new ValueChar('8'));
            AlBase.Add(new ValueChar('6'));
            //AlBase.Add(new ValueChar('7'));

            Checker checker = new Checker(AlBase);
            Assert.AreEqual(false, checker.check(ChainBase));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CheckTrueLongAlphabet()
        {

            BaseChain ChainBase = new BaseChain(10);

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

            Alphabet AlBase = new Alphabet();

            BaseChain alph = new BaseChain(2);
            alph[0]=(new ValueChar('9'));
            alph[1] = (new ValueChar('A'));
            AlBase.Add(alph);
                        
            alph[0] = (new ValueChar('6'));
            alph[1] = (new ValueChar('7'));
            AlBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('8'));
            AlBase.Add(alph);

            alph = new BaseChain(3);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alph[2] = (new ValueChar('3'));
            AlBase.Add(alph);

            alph = new BaseChain(2);
            alph[0] = (new ValueChar('4'));
            alph[1] = (new ValueChar('5'));
            AlBase.Add(alph);

            Checker checker = new Checker(AlBase);
            Assert.AreEqual(true, checker.check(ChainBase));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CheckFalseLongAlphabet()
        {

            BaseChain ChainBase = new BaseChain(10);

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

            Alphabet AlBase = new Alphabet();

            BaseChain alph = new BaseChain(1);
            alph[0] = (new ValueChar('9'));
            //alph[1] = (new ValueChar('A'));
            AlBase.Add(alph);

            alph = new BaseChain(2);
            alph[0] = (new ValueChar('6'));
            alph[1] = (new ValueChar('7'));
            AlBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('8'));
            AlBase.Add(alph);

            alph = new BaseChain(3);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alph[2] = (new ValueChar('3'));
            AlBase.Add(alph);

            alph = new BaseChain(2);
            alph[0] = (new ValueChar('4'));
            alph[1] = (new ValueChar('5'));
            AlBase.Add(alph);

            Checker checker = new Checker(AlBase);
            Assert.AreEqual(false, checker.check(ChainBase));
        }
        ///<summary>
        ///</summary>
        [Test]
        public void CheckSuperLongAlphabet()
        {

            BaseChain ChainBase = new BaseChain(10);

            ChainBase[0] = new ValueChar('1');
            ChainBase[1] = new ValueChar('2');
            ChainBase[2] = new ValueChar('3');

            ChainBase[3] = new ValueChar('4');

            ChainBase[4] = new ValueChar('1');
            ChainBase[5] = new ValueChar('2');
            ChainBase[6] = new ValueChar('3');

            ChainBase[7] = new ValueChar('2');

            ChainBase[8] = new ValueChar('1');
            ChainBase[9] = new ValueChar('2');

            Alphabet AlBase = new Alphabet();

            BaseChain alph = new BaseChain(3);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            alph[2] = (new ValueChar('3'));
            AlBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('4'));
            AlBase.Add(alph);
            
            alph = new BaseChain(2);
            alph[0] = (new ValueChar('1'));
            alph[1] = (new ValueChar('2'));
            AlBase.Add(alph);

            alph = new BaseChain(1);
            alph[0] = (new ValueChar('2'));
            AlBase.Add(alph);

            Checker checker = new Checker(AlBase);
            Assert.AreEqual(true, checker.check(ChainBase));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void DivisionSuperLongAlphabet()
        {

            BaseChain ChainBase = new BaseChain(10);

            ChainBase[0] = new ValueChar('1');
            ChainBase[1] = new ValueChar('2');
            ChainBase[2] = new ValueChar('3');

            ChainBase[3] = new ValueChar('4');

            ChainBase[4] = new ValueChar('1');
            ChainBase[5] = new ValueChar('2');
            ChainBase[6] = new ValueChar('3');

            ChainBase[7] = new ValueChar('2');

            ChainBase[8] = new ValueChar('1');
            ChainBase[9] = new ValueChar('2');

            Alphabet AlBase = new Alphabet();

            BaseChain alph1 = new BaseChain(3);
            alph1[0] = (new ValueChar('1'));
            alph1[1] = (new ValueChar('2'));
            alph1[2] = (new ValueChar('3'));
            AlBase.Add(alph1);

            BaseChain alph2 = new BaseChain(1);
            alph2[0] = (new ValueChar('4'));
            AlBase.Add(alph2);

            BaseChain alph3 = new BaseChain(2);
            alph3[0] = (new ValueChar('1'));
            alph3[1] = (new ValueChar('2'));
            AlBase.Add(alph3);

            BaseChain alph4 = new BaseChain(1);
            alph4[0] = (new ValueChar('2'));
            AlBase.Add(alph4);

            Checker checker = new Checker(AlBase);
            BaseChain Result = checker.Divide(ChainBase);

            Assert.AreEqual(alph3, Result[4]);
            Assert.AreEqual(alph4, Result[3]);
            Assert.AreEqual(alph1, Result[2]);
            Assert.AreEqual(alph2, Result[1]);
            Assert.AreEqual(alph1, Result[0]);
        }
    }
}