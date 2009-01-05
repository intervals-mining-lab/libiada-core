using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    ///<summary>
    /// Тестирует класс-метод изменябщий пространство методом разбиения на блоки.
    ///</summary>
    [TestFixture]
    public class TestSpaceBuilderFromChainbyBlock
    {
        private Chain From = null;
        private Chain NotDivCorrect = null;
        private Chain Empty = null;
//        private Event NotChain = null;
        private ActionType Act = null;
        private SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain> Builder = null;


        ///<summary>
        /// Инициализирующая часть.
        ///</summary>
        [SetUp]
        public void init()
        {
            From = new Chain(12);
            Place FromPlace = From.GetPlacePattern();
            From.AddItem(new ValueChar('a'), FromPlace.SetValues(new long[] {0}));
            From.AddItem(new ValueChar('c'), FromPlace.SetValues(new long[] {1}));

            From.AddItem(new ValueChar('t'), FromPlace.SetValues(new long[] {2}));
            From.AddItem(new ValueChar('a'), FromPlace.SetValues(new long[] {3}));

            From.AddItem(new ValueChar('g'), FromPlace.SetValues(new long[] {4}));
            From.AddItem(new ValueChar('g'), FromPlace.SetValues(new long[] {5}));

            From.AddItem(new ValueChar('g'), FromPlace.SetValues(new long[] {6}));
            From.AddItem(new ValueChar('t'), FromPlace.SetValues(new long[] {7}));

            From.AddItem(new ValueChar('a'), FromPlace.SetValues(new long[] {8}));
            From.AddItem(new ValueChar('c'), FromPlace.SetValues(new long[] {9}));

            From.AddItem(new ValueChar('g'), FromPlace.SetValues(new long[] {10}));
            From.AddItem(new ValueChar('a'), FromPlace.SetValues(new long[] {11}));

            NotDivCorrect = new Chain(11);
            Place NotDivCorrectPlace = NotDivCorrect.GetPlacePattern();
            NotDivCorrect.AddItem(new ValueChar('a'), NotDivCorrectPlace.SetValues(new long[] {0}));
            NotDivCorrect.AddItem(new ValueChar('c'), NotDivCorrectPlace.SetValues(new long[] {1}));

            NotDivCorrect.AddItem(new ValueChar('t'), NotDivCorrectPlace.SetValues(new long[] {2}));
            NotDivCorrect.AddItem(new ValueChar('a'), NotDivCorrectPlace.SetValues(new long[] {3}));

            NotDivCorrect.AddItem(new ValueChar('g'), NotDivCorrectPlace.SetValues(new long[] {4}));
            NotDivCorrect.AddItem(new ValueChar('g'), NotDivCorrectPlace.SetValues(new long[] {5}));

            NotDivCorrect.AddItem(new ValueChar('g'), NotDivCorrectPlace.SetValues(new long[] {6}));
            NotDivCorrect.AddItem(new ValueChar('t'), NotDivCorrectPlace.SetValues(new long[] {7}));

            NotDivCorrect.AddItem(new ValueChar('a'), NotDivCorrectPlace.SetValues(new long[] {8}));
            NotDivCorrect.AddItem(new ValueChar('c'), NotDivCorrectPlace.SetValues(new long[] {9}));

            NotDivCorrect.AddItem(new ValueChar('g'), NotDivCorrectPlace.SetValues(new long[] {10}));

            Empty = new Chain(11);

/*            NotChain = new Event();
            NotChain.AddDimension(new Dimension(0,3));
            NotChain.AddDimension(new Dimension(0, 3));
            Place NotChainPlace = NotChain.GetPlacePattern();


            NotChain.AddItem(new ValueChar('a'), NotChainPlace.SetValues(new long[] { 0,0 }));
            NotChain.AddItem(new ValueChar('c'), NotChainPlace.SetValues(new long[] { 0,1 }));
            NotChain.AddItem(new ValueChar('t'), NotChainPlace.SetValues(new long[] { 0,2 }));
            NotChain.AddItem(new ValueChar('a'), NotChainPlace.SetValues(new long[] { 0,3 }));

            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 1,0 }));
            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 1,1 }));
            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 1,2 }));
            NotChain.AddItem(new ValueChar('t'), NotChainPlace.SetValues(new long[] { 1,3 }));

            NotChain.AddItem(new ValueChar('a'), NotChainPlace.SetValues(new long[] { 2,0 }));
            NotChain.AddItem(new ValueChar('c'), NotChainPlace.SetValues(new long[] { 2,1 }));
            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 2,2 }));
            NotChain.AddItem(new ValueChar('c'), NotChainPlace.SetValues(new long[] { 2, 3 }));

            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 3, 0 }));
            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 3, 1 }));
            NotChain.AddItem(new ValueChar('g'), NotChainPlace.SetValues(new long[] { 3, 2 }));
            NotChain.AddItem(new ValueChar('t'), NotChainPlace.SetValues(new long[] { 3, 3 }));
 */

            Act = ActionType.CreateAlphabetByBlock;
        }

        ///<summary>
        ///</summary>
        [TearDown]
        public void deinit()
        {
        }

        ///<summary>
        /// Тестриует попытку перестроить null событие. 
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestNull()
        {
            Act.BlockSize = 2;
            Act.LinkUp = LinkUp.Start;

            Builder = new SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain>(Act);

            Builder.Rebuild(null);
        }

        /*      ///<summary>
        /// Тестирует ситуацию когда мы пытаемся преобразовать не одномерное пространство с помощью 
        /// преобразование с помощью SpaceRebuilderFromChainToChainByBlock
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception))]
        public void TestNotChain()
        {
            Act.MetaInfo.Add("blocksize", 2);
            Act.MetaInfo.Add("LinkUp", LinkUp.Start);

            Builder = new SpaceRebuilderFromChainToChainByBlock(Act);

            Builder.Rebuild(NotChain);  
        }
*/

        ///<summary>
        /// Тестирует перестроение цепи путем разбиения на блоки.
        /// Разбиение в данном тесте без остатка.
        /// Привязка к началу
        ///</summary>
        [Test]
        public void TestinWorkModeLinkStart()
        {
            Act.BlockSize = 2;
            Act.LinkUp = LinkUp.Start;

            Builder = new SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain>(Act);

            From = Builder.Rebuild(From);
            Chain El = new Chain(2);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('c');

            MessagePhantom m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(From[0], m1);

            El[0] = new ValueChar('t');
            El[1] = new ValueChar('a');

            m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(From[1], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('g');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[2], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('t');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[3], m1);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('c');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[4], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('a');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[5], m1);
        }

        ///<summary>
        /// Тестирует перестроение цепи путем разбиения на блоки.
        /// Разбиение в данном тесте без остатка.
        /// Привязка к началу
        ///</summary>
        [Test]
        public void TestinWorkModeLinkEnd()
        {
            Act.BlockSize = 2;
            Act.LinkUp = LinkUp.End;

            Builder = new SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain>(Act);

            From = Builder.Rebuild(From);
            Chain El = new Chain(2);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('c');

            MessagePhantom m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(From[0], m1);


            El[0] = new ValueChar('t');
            El[1] = new ValueChar('a');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[1], m1);


            El[0] = new ValueChar('g');
            El[1] = new ValueChar('g');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[2], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('t');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[3], m1);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('c');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[4], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('a');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(From[5], m1);
        }

        ///<summary>
        /// Тестирует ситуацию когда длинна цепи не кратна длинна блока
        /// Остаток отбрасывается
        /// Привязка к началу
        ///</summary>
        public void TestNotDivCorrectLinkStart()
        {
            Act.BlockSize = 2;
            Act.LinkUp = LinkUp.Start;

            Builder = new SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain>(Act);

            NotDivCorrect = Builder.Rebuild(NotDivCorrect);
            Chain El = new Chain(2);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('c');

            MessagePhantom m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(NotDivCorrect[0], m1);

            El[0] = new ValueChar('t');
            El[1] = new ValueChar('a');

            m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(NotDivCorrect[1], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('g');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(NotDivCorrect[2], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('t');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(NotDivCorrect[3], m1);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('c');
            m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(NotDivCorrect[4], m1);

            Assert.AreEqual(5, NotDivCorrect.Length);
        }

        ///<summary>
        /// Тестирует ситуацию когда длинна цепи не кратна длинна блока
        /// Остаток отбрасывается
        /// Привязка к началу
        ///</summary>
        public void TestNotDivCorrectLinkEnd()
        {
            Act.BlockSize = 2;
            Act.LinkUp = LinkUp.End;

            Builder = new SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain>(Act);

            NotDivCorrect = Builder.Rebuild(NotDivCorrect);
            Chain El = new Chain(2);

            El[0] = new ValueChar('c');
            El[1] = new ValueChar('t');

            MessagePhantom m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(NotDivCorrect[0], m1);

            El[0] = new ValueChar('a');
            El[1] = new ValueChar('g');

            m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(NotDivCorrect[1], m1);

            El[0] = new ValueChar('g');
            El[1] = new ValueChar('g');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(NotDivCorrect[2], m1);

            El[0] = new ValueChar('t');
            El[1] = new ValueChar('a');
            m1 = new MessagePhantom();
            m1.Add(El);


            Assert.AreEqual(NotDivCorrect[3], m1);

            El[0] = new ValueChar('c');
            El[1] = new ValueChar('g');
            m1 = new MessagePhantom();
            m1.Add(El);

            Assert.AreEqual(NotDivCorrect[4], m1);

            Assert.AreEqual(5, NotDivCorrect.Length);
        }

        ///<summary>
        /// Передаем пустую цепь
        ///</summary>
        [Test]
        public void TestEmpty()
        {
            Act.BlockSize = 2;
            Act.LinkUp = LinkUp.End;

            Builder = new SpaceRebuilderFromChainToChainByBlockPM<Chain, Chain>(Act);

            Empty = Builder.Rebuild(Empty);

            Assert.AreEqual(0, Empty.Alpahbet.power);
        }
    }
}