namespace LibiadaCore.Tests.Core
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The fmotiv chain tests.
    /// </summary>
    [TestFixture]
    public class FmotifChainTests
    {
        /// <summary>
        /// The fmotiv chain test.
        /// </summary>
        [Test]
        public void FmotivChainTest()
        {
            var chain = new FmotifChain();
            chain.FmotifsList.Add(new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0));
            chain.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.A, 0), new Duration(1, 4, false, 480), false, Tie.None));
            chain.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.B, 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual(0, chain.FmotifsList[0].Id);
            Assert.AreEqual(NoteSymbol.A, chain.FmotifsList[0].NoteList[0].Pitches[0].Step);
            Assert.AreEqual(NoteSymbol.B, chain.FmotifsList[0].NoteList[1].Pitches[0].Step);
        }

        /// <summary>
        /// The fmotiv chain equals test.
        /// </summary>
        [Test]
        public void FmotivChainEqualsTest()
        {
            var fmotiv1 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            var fmotiv2 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            var firstChain = new FmotifChain();
            firstChain.FmotifsList.Add(fmotiv1);
            firstChain.FmotifsList.Add(fmotiv2);

            var secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotiv1);
            secondChain.FmotifsList.Add(fmotiv2);
            Assert.IsTrue(firstChain.Equals(secondChain));

            secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotiv2);
            secondChain.FmotifsList.Add(fmotiv1);
            Assert.IsFalse(firstChain.Equals(secondChain));

            secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotiv2);
            secondChain.FmotifsList.Add(fmotiv2);
            Assert.IsFalse(firstChain.Equals(secondChain));

            firstChain = new FmotifChain();
            firstChain.FmotifsList.Add(fmotiv1);
            firstChain.FmotifsList.Add(fmotiv1);
            firstChain.FmotifsList.Add(fmotiv2);
            firstChain.FmotifsList.Add(fmotiv1);

            secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotiv1);
            secondChain.FmotifsList.Add(fmotiv1);
            secondChain.FmotifsList.Add(fmotiv2);
            secondChain.FmotifsList.Add(fmotiv1);
            Assert.IsTrue(firstChain.Equals(secondChain));
        }
    }
}
