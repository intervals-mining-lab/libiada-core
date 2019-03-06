namespace LibiadaCore.Tests.Core
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The fmotif chain tests.
    /// </summary>
    [TestFixture]
    public class FmotifChainTests
    {
        /// <summary>
        /// The fmotif chain test.
        /// </summary>
        [Test]
        public void FmotifChainTest()
        {
            var chain = new FmotifChain();
            chain.FmotifsList.Add(new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0));
            chain.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.A, 0), new Duration(1, 4, false, 480), false, Tie.None));
            chain.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.B, 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual(0, chain.FmotifsList[0].Id);
            Assert.AreEqual(NoteSymbol.A, chain.FmotifsList[0].NoteList[0].Pitches[0].Step);
            Assert.AreEqual(NoteSymbol.B, chain.FmotifsList[0].NoteList[1].Pitches[0].Step);
        }

        /// <summary>
        /// The fmotif chain equals test.
        /// </summary>
        [Test]
        public void FmotifChainEqualsTest()
        {
            var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
            var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

            fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            var firstChain = new FmotifChain();
            firstChain.FmotifsList.Add(fmotif1);
            firstChain.FmotifsList.Add(fmotif2);

            var secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotif1);
            secondChain.FmotifsList.Add(fmotif2);
            Assert.IsTrue(firstChain.Equals(secondChain));

            secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotif2);
            secondChain.FmotifsList.Add(fmotif1);
            Assert.IsFalse(firstChain.Equals(secondChain));

            secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotif2);
            secondChain.FmotifsList.Add(fmotif2);
            Assert.IsFalse(firstChain.Equals(secondChain));

            firstChain = new FmotifChain();
            firstChain.FmotifsList.Add(fmotif1);
            firstChain.FmotifsList.Add(fmotif1);
            firstChain.FmotifsList.Add(fmotif2);
            firstChain.FmotifsList.Add(fmotif1);

            secondChain = new FmotifChain();
            secondChain.FmotifsList.Add(fmotif1);
            secondChain.FmotifsList.Add(fmotif1);
            secondChain.FmotifsList.Add(fmotif2);
            secondChain.FmotifsList.Add(fmotif1);
            Assert.IsTrue(firstChain.Equals(secondChain));
        }
    }
}
