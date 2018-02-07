namespace LibiadaCore.Tests.Music
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The fmotiv identification tests.
    /// </summary>
    [TestFixture]
    public class FmotivIdentifierTests
    {
        /// <summary>
        /// The fmotiv identification first test.
        /// </summary>
        [Test]
        public void FmotivIdentificationFirstTest()
        {
            // создание ф-мотивов
            var fmotiv1 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            var fmotiv2 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 1);
            var fmotiv3 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 2);
            var fmotiv4 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 3);
            var fmotiv5 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 4);
            var fmotiv6 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 5);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotifChain { Id = 0, Name = "track1" };
            fmchain1.FmotifsList.Add(fmotiv1);
            fmchain1.FmotifsList.Add(fmotiv2);
            fmchain1.FmotifsList.Add(fmotiv3);
            fmchain1.FmotifsList.Add(fmotiv4);
            fmchain1.FmotifsList.Add(fmotiv5);
            fmchain1.FmotifsList.Add(fmotiv6);

            var fmid = new FmotivIdentifier();
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[0].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[1].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[2].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[3].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[4].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[5].Id);
        }

        /// <summary>
        /// The fmotiv identification second test.
        /// </summary>
        [Test]
        public void FmotivIdentificationSecondTest()
        {
            // создание ф-мотивов
            var fmotiv1 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            var fmotiv2 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 1);
            var fmotiv3 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 2);
            var fmotiv4 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 3);
            var fmotiv5 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 4);
            var fmotiv6 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 5);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.C, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.D, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotifChain { Id = 0, Name = "track1" };
            fmchain1.FmotifsList.Add(fmotiv1);
            fmchain1.FmotifsList.Add(fmotiv2);
            fmchain1.FmotifsList.Add(fmotiv3);
            fmchain1.FmotifsList.Add(fmotiv4);
            fmchain1.FmotifsList.Add(fmotiv5);
            fmchain1.FmotifsList.Add(fmotiv6);

            var fmid = new FmotivIdentifier();

            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[0].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[1].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[2].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[3].Id);
            Assert.AreEqual(2, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[4].Id);
            Assert.AreEqual(3, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotifsList[5].Id);
        }
    }
}
