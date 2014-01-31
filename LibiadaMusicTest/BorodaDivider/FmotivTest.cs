using System;
using System.Collections.Generic;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.BorodaDivider
{
    [TestClass]
    public class FmotivTest
    {
        private Note note = new Note(new Pitch(1, 'E', 0), new Duration(1, 4, false, 480), false, Tie.None);
        private Note anote = new Note(new Pitch(1, 'B', 0), new Duration(1, 2, false, 960), false, 0);
        private Attributes attributes = new Attributes(new Size(4, 4, 480), new Key(0, "minor"));

        [TestMethod]
        public void TestFmotiv1() 
        {
            Fmotiv fmotiv = new Fmotiv(0,"ПМТ");
            List<Note> notelist = new List<Note>();
            notelist.Add((Note)note.Clone());
            notelist.Add((Note)anote.Clone());
            notelist.Add((Note)note.Clone());
            
            fmotiv.NoteList.Add((Note)note.Clone());
            fmotiv.NoteList.Add((Note)anote.Clone());
            fmotiv.NoteList.Add((Note)note.Clone());

            Assert.AreEqual((Note)notelist[0], (Note)fmotiv.NoteList[0]);
            Assert.AreEqual((Note)notelist[1], (Note)fmotiv.NoteList[1]);
            Assert.AreEqual((Note)notelist[2], (Note)fmotiv.NoteList[2]);
            Assert.AreEqual("ПМТ",fmotiv.Type);
            fmotiv.Type = "ПМТВП";
            Assert.AreEqual("ПМТВП", fmotiv.Type);
            Assert.AreEqual(0, fmotiv.Id);
            fmotiv.Id = 1;
            Assert.AreEqual(1, fmotiv.Id);
            // проверка на идентичность нот проверяется только высота звучания и реальная длительность, не сравнивая приоритеты, лиги, триоли
        }

        [TestMethod]
        public void TestFmotivWithoutPauses1()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), только без пауз.
            Fmotiv fmotiv = new Fmotiv(0,"ПМТ");
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList[0].Pitch[0].Step, 'A');
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList[1].Pitch[0].Step, 'A');
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList[2].Pitch[0].Step, 'A');
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList.Count, 3);
        }

        [TestMethod]
        public void TestFmotivWithoutPauses2()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), только без пауз.
            Fmotiv fmotiv = new Fmotiv(0, "ПМТ");
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList[0].Pitch[0].Step, 'A');
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList[1].Pitch[0].Step, 'A');
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList[2].Pitch[0].Step, 'A');
            Assert.AreEqual((fmotiv.PauseTreatment(ParamPauseTreatment.Ignore)).NoteList.Count, 3);

        }

        [TestMethod]
        public void TestFmotivTieGathered1()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            Fmotiv fmotiv = new Fmotiv(0, "ПМТ");
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start,2));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop,4));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop,3));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop,1));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None,4));

            Assert.AreEqual(4, fmotiv.TieGathered().NoteList.Count);
            Assert.AreEqual(1920, fmotiv.TieGathered().NoteList[1].Duration.Ticks);
            Assert.AreEqual(1, fmotiv.TieGathered().NoteList[1].Duration.Numerator);
            Assert.AreEqual(2, fmotiv.TieGathered().NoteList[1].Duration.Denominator);
            Assert.AreEqual(2, fmotiv.TieGathered().NoteList[1].Priority);
        }

        [TestMethod]
        public void TestFmotivTieGathered2()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            Fmotiv fmotiv = new Fmotiv(0, "ПМТ");
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 4));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.AreEqual(4, fmotiv.TieGathered().NoteList.Count);
            Assert.AreEqual(1440, fmotiv.TieGathered().NoteList[1].Duration.Ticks);
            Assert.AreEqual(3, fmotiv.TieGathered().NoteList[1].Duration.Numerator);
            Assert.AreEqual(8, fmotiv.TieGathered().NoteList[1].Duration.Denominator);
            Assert.AreEqual(2, fmotiv.TieGathered().NoteList[1].Priority);
        }

        [TestMethod]
        public void TestFmotivTieGathered3()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.

            // старт лиги, потом опять старт лиги
            Fmotiv fmotiv = new Fmotiv(0, "ПМТ");
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            try
            {
                Fmotiv testfm = fmotiv.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie note start after existing start note!") { Assert.Fail(); }
            }

            // после старта идет обычная нота без лиги
            fmotiv.NoteList.Clear();
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 960), false, Tie.Start, 0));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 960), false, Tie.None, 0));
            try
            {
                Fmotiv testfm = fmotiv.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie started but (stop)/(startstop) note NOT following!") { Assert.Fail(); }
            }

            // лига без старта
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 4));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 3));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            try
            {
                Fmotiv testfm = fmotiv1.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie note (stopes and starts)/(stops), without previous note start!") { Assert.Fail(); }
            }

            // в знаке лиги не {-1,0,1,2}
            Fmotiv fmotiv2 = new Fmotiv(0, "ПМТ");
            fmotiv2.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, 9, 1));
            try
            {
                Fmotiv testfm = fmotiv2.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Tie is not valid!") { Assert.Fail(); }
            }

            // в знаке лиги не {-1,0,1,2}
            Fmotiv fmotiv3 = new Fmotiv(0, "ПМТ");
            fmotiv3.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false,Tie.Start, 1));
            fmotiv3.NoteList.Add(new Note(new Pitch(1, 'B', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            try
            {
                Fmotiv testfm = fmotiv3.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "LibiadaMusic: Pitches of tie notes not equal!") { Assert.Fail(); }
            }

            
        }

        [TestMethod]
        public void TestFmotivEquals1()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv2 = new Fmotiv(0, "ПМТ");
            Fmotiv fmotiv3 = new Fmotiv(0, "ПМТ");


            fmotiv1.NoteList.Add(new Note((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 4));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 3));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv1.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv1.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            fmotiv2.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv2.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv2.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 1920), false, Tie.None, 1));
            fmotiv2.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv2.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            fmotiv3.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv3.NoteList.Add(new Note(new Pitch(1, 'B', 0), new Duration(1, 2, false, 1920), false, Tie.None, 1));
            fmotiv3.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv3.NoteList.Add(new Note(new Pitch(1, 'A', 2), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.IsTrue(fmotiv1.Equals(((Fmotiv)fmotiv2)));
            Assert.IsTrue(fmotiv1.Equals(((Fmotiv)fmotiv3)));
            Assert.IsTrue(fmotiv2.Equals(((Fmotiv)fmotiv3)));
            Assert.IsTrue(fmotiv3.Equals(((Fmotiv)fmotiv2)));
            Assert.IsTrue(fmotiv3.Equals(((Fmotiv)fmotiv1)));
            Assert.IsTrue(fmotiv2.Equals(((Fmotiv)fmotiv1)));

            fmotiv2.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));
            Assert.IsTrue(!fmotiv1.Equals(((Fmotiv)fmotiv2)));

        }

        [TestMethod]
        public void TestFmotivEquals2()
        {
            Fmotiv fmotiv = new Fmotiv(0, "ПМТ");
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 4));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));


            Assert.IsTrue(fmotiv.Equals(((Fmotiv)fmotiv)));
        }

        [TestMethod]
        public void TestFmotivEquals3()
        {
            Fmotiv fmotiv = new Fmotiv(0, "ПМТ");
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 4));
            fmotiv.NoteList.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv.NoteList.Add(new Note((Pitch)null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Fmotiv fmotiv1 = new Fmotiv(0, "ПМТ");
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 0));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 1));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 2));
            fmotiv1.NoteList.Add(new Note(new Pitch(3, 'B', -2), new Duration(1, 2, false, 480), false, Tie.None, 5));

            Assert.IsTrue(fmotiv.FmEquals(((Fmotiv)fmotiv1),ParamPauseTreatment.Ignore,ParamEqualFM.Sequent));
        }
    }

}