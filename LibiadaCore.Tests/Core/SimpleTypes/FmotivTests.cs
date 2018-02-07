namespace LibiadaCore.Tests.Core.SimpleTypes
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The fmotiv tests.
    /// </summary>
    [TestFixture]
    public class FmotivTests
    {
        /// <summary>
        /// The note.
        /// </summary>
        private readonly ValueNote note = new ValueNote(new Pitch(1, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.None);

        /// <summary>
        /// The a note.
        /// </summary>
        private readonly ValueNote aNote = new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 2, false, 960), false, 0);

        /// <summary>
        /// The fmotiv test.
        /// </summary>
        [Test]
        public void FmotivTest()
        {
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            var notelist = new List<ValueNote> { (ValueNote)note.Clone(), (ValueNote)aNote.Clone(), (ValueNote)note.Clone() };

            fmotiv.NoteList.Add((ValueNote)note.Clone());
            fmotiv.NoteList.Add((ValueNote)aNote.Clone());
            fmotiv.NoteList.Add((ValueNote)note.Clone());

            Assert.AreEqual(notelist[0], fmotiv.NoteList[0]);
            Assert.AreEqual(notelist[1], fmotiv.NoteList[1]);
            Assert.AreEqual(notelist[2], fmotiv.NoteList[2]);
            Assert.AreEqual(FmotifType.CompleteMinimalMeasure, fmotiv.Type);
            fmotiv.Type = FmotifType.CompleteMinimalMetrorhythmicGroup;
            Assert.AreEqual(FmotifType.CompleteMinimalMetrorhythmicGroup, fmotiv.Type);
            Assert.AreEqual(0, fmotiv.Id);
            fmotiv.Id = 1;
            Assert.AreEqual(1, fmotiv.Id);

            // проверка на идентичность нот проверяется только высота звучания и реальная длительность, не сравнивая приоритеты, лиги, триоли
        }

        /// <summary>
        /// The fmotiv without pauses first test.
        /// </summary>
        [Test]
        public void FmotivWithoutPausesFirstTest()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), только без пауз.
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList[0].Pitch[0].Step, NoteSymbol.A);
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList[1].Pitch[0].Step, NoteSymbol.A);
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList[2].Pitch[0].Step, NoteSymbol.A);
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList.Count, 3);
        }

        /// <summary>
        /// The fmotiv without pauses second test.
        /// </summary>
        [Test]
        public void FmotivWithoutPausesSecondTest()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), только без пауз.
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList[0].Pitch[0].Step, NoteSymbol.A);
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList[1].Pitch[0].Step, NoteSymbol.A);
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList[2].Pitch[0].Step, NoteSymbol.A);
            Assert.AreEqual(fmotiv.PauseTreatment((int)ParamPauseTreatment.Ignore).NoteList.Count, 3);
        }

        /// <summary>
        /// The fmotiv tie gathered first test.
        /// </summary>
        [Test]
        public void FmotivTieGatheredFirstTest()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Continue, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Continue, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.AreEqual(4, fmotiv.TieGathered().NoteList.Count);
            Assert.AreEqual(1920, fmotiv.TieGathered().NoteList[1].Duration.Ticks);
            Assert.AreEqual(1, fmotiv.TieGathered().NoteList[1].Duration.Numerator);
            Assert.AreEqual(2, fmotiv.TieGathered().NoteList[1].Duration.Denominator);
            Assert.AreEqual(2, fmotiv.TieGathered().NoteList[1].Priority);
        }

        /// <summary>
        /// The fmotiv tie gathered second test.
        /// </summary>
        [Test]
        public void FmotivTieGatheredSecondTest()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.AreEqual(4, fmotiv.TieGathered().NoteList.Count);
            Assert.AreEqual(1440, fmotiv.TieGathered().NoteList[1].Duration.Ticks);
            Assert.AreEqual(3, fmotiv.TieGathered().NoteList[1].Duration.Numerator);
            Assert.AreEqual(8, fmotiv.TieGathered().NoteList[1].Duration.Denominator);
            Assert.AreEqual(2, fmotiv.TieGathered().NoteList[1].Priority);
        }

        /// <summary>
        /// The fmotiv tie gathered third test.
        /// </summary>
        [Test]
        public void FmotivTieGatheredThirdTest()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            // старт лиги, потом опять старт лиги
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            try
            {
                fmotiv.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie note start after existing start note!")
                {
                    Assert.Fail();
                }
            }

            // после старта идет обычная нота без лиги
            fmotiv.NoteList.Clear();
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 960), false, Tie.Start, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 960), false, Tie.None, 0));
            try
            {
                fmotiv.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie started but (stop)/(startstop) note NOT following!")
                {
                    Assert.Fail();
                }
            }

            // лига без старта
            var fmotiv1 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Continue, 4));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Continue, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            try
            {
                fmotiv1.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie note (stopes and starts)/(stops), without previous note start!")
                {
                    Assert.Fail();
                }
            }

            // в знаке лиги не {-1,0,1,2}
            var fmotiv2 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, (Tie)9, 1));
            try
            {
                fmotiv2.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie is not valid!")
                {
                    Assert.Fail();
                }
            }

            // в знаке лиги не {-1,0,1,2}
            var fmotiv3 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Start, 1));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            try
            {
                fmotiv3.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Pitches of tie notes not equal!")
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// The fmotiv equals first test.
        /// </summary>
        [Test]
        public void FmotivEqualsFirstTest()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            var fmotiv1 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            var fmotiv2 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            var fmotiv3 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);

            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Continue, 4));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.Continue, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));

            fmotiv2.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv2.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 1920), false, Tie.None, 1));
            fmotiv2.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));

            fmotiv3.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 2, false, 1920), false, Tie.None, 1));
            fmotiv3.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.IsTrue(fmotiv1.Equals(fmotiv2));
            Assert.IsTrue(fmotiv1.Equals(fmotiv3));
            Assert.IsTrue(fmotiv2.Equals(fmotiv3));
            Assert.IsTrue(fmotiv3.Equals(fmotiv2));
            Assert.IsTrue(fmotiv3.Equals(fmotiv1));
            Assert.IsTrue(fmotiv2.Equals(fmotiv1));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));
            Assert.IsTrue(!fmotiv1.Equals(fmotiv2));
        }

        /// <summary>
        /// The fmotiv equals second test.
        /// </summary>
        [Test]
        public void FmotivEqualsSecondTest()
        {
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.IsTrue(fmotiv.Equals(fmotiv));
        }

        /// <summary>
        /// The fmotiv equals third test.
        /// </summary>
        [Test]
        public void FmotivEqualsThirdTest()
        {
            var fmotiv = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 1));
            fmotiv.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false, 480), false, Tie.None, 4));

            var fmotiv1 = new Fmotif(FmotifType.CompleteMinimalMeasure, ParamPauseTreatment.Ignore, 0);
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 0));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 1));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false, 320), false, Tie.Continue, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false, 480), false, Tie.End, 2));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, Accidental.DoubleFlat), new Duration(1, 2, false, 480), false, Tie.None, 5));

            Assert.IsTrue(fmotiv.FmEquals(fmotiv1, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent));
        }
    }
}
