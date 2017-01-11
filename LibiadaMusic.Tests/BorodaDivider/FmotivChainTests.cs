namespace LibiadaMusic.Tests.BorodaDivider
{
    using LibiadaMusic.BorodaDivider;
    using LibiadaMusic.ScoreModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The fmotiv chain tests.
    /// </summary>
    [TestClass]
    public class FmotivChainTests
    {
        /// <summary>
        /// The fmotiv chain test.
        /// </summary>
        [TestMethod]
        public void FmotivChainTest()
        {
            var chain = new FmotivChain { Id = 0 };
            chain.FmotivList.Add(new Fmotiv(FmotivType.CompleteMinimalMeasure, 0));
            chain.FmotivList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.A, 0), new Duration(1, 4, false, 480), false, Tie.None));
            chain.FmotivList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.B, 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual(0, chain.FmotivList[0].Id);
            Assert.AreEqual(NoteSymbol.A, chain.FmotivList[0].NoteList[0].Pitch[0].Step);
            Assert.AreEqual(NoteSymbol.B, chain.FmotivList[0].NoteList[1].Pitch[0].Step);
        }

        /// <summary>
        /// The fmotiv chain equals test.
        /// </summary>
        [TestMethod]
        public void FmotivChainEqualsTest()
        {
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var firstChain = new FmotivChain { Id = 0 };
            firstChain.FmotivList.Add(fmotiv1);
            firstChain.FmotivList.Add(fmotiv2);

            var secondChain = new FmotivChain { Id = 0 };
            secondChain.FmotivList.Add(fmotiv1);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(firstChain.Equals(secondChain));

            secondChain = new FmotivChain { Id = 1 };
            secondChain.FmotivList.Add(fmotiv1);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsFalse(firstChain.Equals(secondChain));

            secondChain = new FmotivChain { Id = 0 };
            secondChain.FmotivList.Add(fmotiv2);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsTrue(firstChain.Equals(secondChain));

            secondChain = new FmotivChain { Id = 1 };
            secondChain.FmotivList.Add(fmotiv2);
            secondChain.FmotivList.Add(fmotiv2);
            Assert.IsFalse(firstChain.Equals(secondChain));
        }
    }
}
