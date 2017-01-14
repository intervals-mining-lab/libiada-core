namespace LibiadaMusic.Tests.BorodaDivider
{
    using LibiadaMusic.BorodaDivider;
    using LibiadaMusic.ScoreModel;

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
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);
            var fmotiv3 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 2);
            var fmotiv4 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 3);
            var fmotiv5 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 4);
            var fmotiv6 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 5);

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
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);
            fmchain1.FmotivList.Add(fmotiv4);
            fmchain1.FmotivList.Add(fmotiv5);
            fmchain1.FmotivList.Add(fmotiv6);

            var fmid = new FmotivIdentifier();
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[0].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[1].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[2].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[3].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[4].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[5].Id);
        }

        /// <summary>
        /// The fmotiv identification second test.
        /// </summary>
        [Test]
        public void FmotivIdentificationSecondTest()
        {
            // создание ф-мотивов
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);
            var fmotiv3 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 2);
            var fmotiv4 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 3);
            var fmotiv5 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 4);
            var fmotiv6 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 5);

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
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);
            fmchain1.FmotivList.Add(fmotiv4);
            fmchain1.FmotivList.Add(fmotiv5);
            fmchain1.FmotivList.Add(fmotiv6);

            var fmid = new FmotivIdentifier();

            // FmotivChain fmidentedchain = new FmotivChain();
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[0].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[1].Id);
            Assert.AreEqual(0, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[2].Id);
            Assert.AreEqual(1, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[3].Id);
            Assert.AreEqual(2, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[4].Id);
            Assert.AreEqual(3, fmid.GetIdentification(fmchain1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent).FmotivList[5].Id);
        }
    }
}
