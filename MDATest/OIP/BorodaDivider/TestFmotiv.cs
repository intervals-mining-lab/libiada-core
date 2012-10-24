using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIPTest.BorodaDivider
{
    [TestClass]
    public class TestFmotiv
    {
        private ValueNote note = new ValueNote(new Pitch(1, 'E', 0), new Duration(1, 4, false, 480), false, Tie.None);
        private ValueNote anote = new ValueNote(new Pitch(1, 'B', 0), new Duration(1, 2, false, 960), false, 0);
        private Attributes attributes = new Attributes(new Size(4, 4, 480), new Key(0, "minor"));

        [TestMethod]
        public void TestFmotiv1() 
        {
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            List<ValueNote> notelist = new List<ValueNote>();
            notelist.Add((ValueNote)note.Clone());
            notelist.Add((ValueNote)anote.Clone());
            notelist.Add((ValueNote)note.Clone());
            
            fmotiv.NoteList.Add((ValueNote)note.Clone());
            fmotiv.NoteList.Add((ValueNote)anote.Clone());
            fmotiv.NoteList.Add((ValueNote)note.Clone());

            Assert.AreEqual(notelist[0], fmotiv.NoteList[0]);
            Assert.AreEqual(notelist[1], fmotiv.NoteList[1]);
            Assert.AreEqual(notelist[2], fmotiv.NoteList[2]);
            Assert.AreEqual("ПМТ",fmotiv.Type);
            fmotiv.Type = "ПМТВП";
            Assert.AreEqual("ПМТВП", fmotiv.Type);
            // проверка на идентичность нот проверяется только высота звучания и реальная длительность, не сравнивая приоритеты, лиги, триоли
        }

        [TestMethod]
        public void TestFmotivWithoutPauses1()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), только без пауз.
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList[0].Pitch.Step, 'A');
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList[1].Pitch.Step, 'A');
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList[2].Pitch.Step, 'A');
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList.Count, 3);
        }

        [TestMethod]
        public void TestFmotivWithoutPauses2()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), только без пауз.
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None));
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList[0].Pitch.Step, 'A');
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList[1].Pitch.Step, 'A');
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList[2].Pitch.Step, 'A');
            Assert.AreEqual((fmotiv.Clone(PauseTreatment.Ignore)).NoteList.Count, 3);

        }

        [TestMethod]
        public void TestFmotivTieGathered1()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 2, false, 960), false, Tie.None,0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start,2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop,4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop,3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop,1));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None,3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None,4));

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
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

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
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            try
            {
                Fmotiv testfm = fmotiv.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "MDA: Tie note start after existing start note!") { Assert.Fail(); }
            }

            // после старта идет обычная нота без лиги
            fmotiv.NoteList.Clear();
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 960), false, Tie.Start, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 960), false, Tie.None, 0));
            try
            {
                Fmotiv testfm = fmotiv.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "MDA: Tie started but (stop)/(startstop) note NOT following!") { Assert.Fail(); }
            }

            // лига без старта
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 4));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            try
            {
                Fmotiv testfm = fmotiv1.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "MDA: Tie note (stopes and starts)/(stops), without previous note start!") { Assert.Fail(); }
            }

            // в знаке лиги не {-1,0,1,2}
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, 9, 1));
            try
            {
                Fmotiv testfm = fmotiv2.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "MDA: Tie is not valid!") { Assert.Fail(); }
            }

            // в знаке лиги не {-1,0,1,2}
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false,Tie.Start, 1));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, 'B', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            try
            {
                Fmotiv testfm = fmotiv3.TieGathered();
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.Message != "MDA: Pitches of tie notes not equal!") { Assert.Fail(); }
            }

            
        }

        [TestMethod]
        public void TestFmotivEquals1()
        {
            // проверка работы метода, который возвращает копию объекта (Fmotiv), c собранными залигованными нотами.
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");


            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Start, 2));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 4));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.StartStop, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            fmotiv2.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv2.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 1920), false, Tie.None, 1));
            fmotiv2.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            fmotiv3.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 0));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, 'B', 0), new Duration(1, 2, false, 1920), false, Tie.None, 1));
            fmotiv3.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(1, 'A', 2), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Assert.IsTrue(fmotiv1.Equals(fmotiv2));
            Assert.IsTrue(fmotiv1.Equals(fmotiv3));
            Assert.IsTrue(fmotiv2.Equals(fmotiv3));
            Assert.IsTrue(fmotiv3.Equals(fmotiv2));
            Assert.IsTrue(fmotiv3.Equals(fmotiv1));
            Assert.IsTrue(fmotiv2.Equals(fmotiv1));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));
            Assert.IsTrue(!fmotiv1.Equals(fmotiv2));

        }

        [TestMethod]
        public void TestFmotivEquals2()
        {
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));


            Assert.IsTrue(fmotiv.Equals(fmotiv));
        }

        [TestMethod]
        public void TestFmotivEquals3()
        {
            Fmotiv fmotiv = new Fmotiv("ПМТ");
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 2, false, 960), false, Tie.None, 0));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 2));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 4));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 1));
            fmotiv.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 480), false, Tie.None, 3));
            fmotiv.NoteList.Add(new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 2, false, 480), false, Tie.None, 4));

            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.Start, 0));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 1));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 320), false, Tie.StartStop, 3));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 480), false, Tie.Stop, 2));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', -2), new Duration(1, 2, false, 480), false, Tie.None, 5));

            Assert.IsTrue(fmotiv.FmEquals((fmotiv1),PauseTreatment.Ignore,FMSequentEquality.Sequent));
        }
    }

}