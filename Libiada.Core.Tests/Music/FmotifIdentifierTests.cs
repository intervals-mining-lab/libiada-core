namespace LibiadaCore.Tests.Music
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The fmotif identification tests.
    /// </summary>
    [TestFixture]
    public class FmotifIdentifierTests
    {
        /// <summary>
        /// The fmotif identification first test.
        /// </summary>
        [Test]
        public void FmotifIdentificationFirstTest()
        {
            // создание ф-мотивов
            var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
            var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
            var fmotif3 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 2);
            var fmotif4 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 3);
            var fmotif5 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 4);
            var fmotif6 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 5);

            fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotifChain();
            fmchain1.FmotifsList.Add(fmotif1);
            fmchain1.FmotifsList.Add(fmotif2);
            fmchain1.FmotifsList.Add(fmotif3);
            fmchain1.FmotifsList.Add(fmotif4);
            fmchain1.FmotifsList.Add(fmotif5);
            fmchain1.FmotifsList.Add(fmotif6);

            var fmid = new FmotifIdentifier();
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, true).FmotifsList[0].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, true).FmotifsList[1].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, true).FmotifsList[2].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, true).FmotifsList[3].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, true).FmotifsList[4].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, true).FmotifsList[5].Id);
        }

        /// <summary>
        /// The fmotif identification second test.
        /// </summary>
        [Test]
        public void FmotifIdentificationSecondTest()
        {
            // создание ф-мотивов
            var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
            var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
            var fmotif3 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 2);
            var fmotif4 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 3);
            var fmotif5 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 4);
            var fmotif6 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 5);

            fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.C, 0), new Duration(1, 4, false), false, Tie.None));

            fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
            fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.D, 0), new Duration(1, 4, false), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotifChain();
            fmchain1.FmotifsList.Add(fmotif1);
            fmchain1.FmotifsList.Add(fmotif2);
            fmchain1.FmotifsList.Add(fmotif3);
            fmchain1.FmotifsList.Add(fmotif4);
            fmchain1.FmotifsList.Add(fmotif5);
            fmchain1.FmotifsList.Add(fmotif6);

            var fmid = new FmotifIdentifier();

            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, true).FmotifsList[0].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, true).FmotifsList[1].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, true).FmotifsList[2].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, true).FmotifsList[3].Id);
            Assert.AreEqual(2, fmid.GetIdentification(fmchain1, true).FmotifsList[4].Id);
            Assert.AreEqual(3, fmid.GetIdentification(fmchain1, true).FmotifsList[5].Id);
        }
    }
}
