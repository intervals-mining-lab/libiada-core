using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;
using MDA.OIP;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIPTest.TestBorodaDivider
{
    [TestClass]
    public class TestPriorityDiscover
    {
        private Note note = new Note(new Pitch(1, 'E', 0), new Duration(1, 4, false, 480), false, Tie.None);
        private Note anote = new Note(new Pitch(1, 'B', 0), new Duration(1, 2, false, 960), false, 0);
        private Note bnote = new Note(null, new Duration(1, 4, false, 480), false, 0);
        private Note сnote = new Note(new Pitch(1, 'A', 0), new Duration(1,4,2,3,false,200),true,0);
        private Note ccnote = new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 2, 3, false, 200), true, 0);
        private Note сccnote = new Note(new Pitch(1, 'A', 0), new Duration(1, 8, 4, 7, false, 200), true, 0);
        private Note dnote = new Note(new Pitch(1, 'B', 0), new Duration(1, 16, false, 240), false, 0);
        private Attributes attributes = new Attributes(new Size(4, 4, 480), new Key(0, "minor"));
        private Attributes attributes1 = new Attributes(new Size(3, 4, 480), new Key(0, "minor"));
        private Attributes attributes2 = new Attributes(new Size(12, 8, 480), new Key(0, "minor"));
        private Attributes attributes3 = new Attributes(new Size(13, 16, 480), new Key(0, "minor"));

        [TestMethod]
        public void TestPriorityGetSet()
        {
            note.Priority = 0;
            anote.Priority = -1;
            bnote.Priority = 3;

            Assert.AreEqual(0, note.Priority);
            Assert.AreEqual(3, bnote.Priority);
            Assert.AreEqual(-1, anote.Priority);
        }

        [TestMethod]
        public void TestPriorityMinDuration()
        {
            PriorityDiscover pd = new PriorityDiscover();

            List<Note> notes = new List<Note>();
            notes.Add(note);
            notes.Add(bnote);
            notes.Add(dnote);
            notes.Add(anote);
            Measure measure = new Measure(notes, attributes);
            //минимальнвя длительность ноты в такте measure 1/16 = 0.0625 у ноты dnote
            Assert.IsTrue((pd.minDuration(measure) - 0.0625) < 0.00001);
            // когда такт передается пустой, должен выкинуться эксепшн
            measure.NoteList.Clear();
            try 
            {
                Assert.IsTrue((pd.minDuration(measure) - 0.0625) < 0.00001);
                Assert.Fail("нет эксепшна при пустом такте");
            }
            catch (Exception e)
            {
                if (e.Message != "MDA.OIP: обнаружен пустой такт при выявлении приоритета!") Assert.Fail(); 
            }
            
        }

        [TestMethod]
        public void TestPriorityMaskCalculation1()
        {
            PriorityDiscover pd = new PriorityDiscover();

            List<Note> notes = new List<Note>();
            notes.Add(note);
            notes.Add(bnote);
            notes.Add(dnote);
            notes.Add(anote);
            Measure measure = new Measure(notes, attributes);
            pd.CalcPriorityMask(measure);
            // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/16
            Assert.AreEqual(0, pd.PriorityMask.NoteList[0].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[1].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[2].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[3].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[4].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[5].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[6].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[7].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[8].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[9].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[10].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[11].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[12].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[13].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[14].Priority);
            Assert.AreEqual(4, pd.PriorityMask.NoteList[15].Priority);
            // проверка длительностей
            foreach (Note lnote in pd.PriorityMask.NoteList)
            {
                Assert.AreEqual(1, lnote.Duration.Numerator);
                Assert.AreEqual(16, lnote.Duration.Denominator);
            }
        }

        [TestMethod]
        public void TestPriorityMaskCalculation2()
        {
            PriorityDiscover pd = new PriorityDiscover();

            List<Note> notes = new List<Note>();
            notes.Add(note);
            notes.Add(bnote);
            notes.Add(dnote);
            notes.Add(anote);
            Measure measure = new Measure(notes, attributes2);
            pd.CalcPriorityMask(measure);
            // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/16
            // размер 12/8, поэтому будет считаться приоритет для 24/16 нот
            Assert.AreEqual(0, pd.PriorityMask.NoteList[0].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[1].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[2].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[3].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[4].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[5].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[6].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[7].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[8].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[9].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[10].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[11].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[12].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[13].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[14].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[15].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[16].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[17].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[18].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[19].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[20].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[21].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[22].Priority);
            Assert.AreEqual(3, pd.PriorityMask.NoteList[23].Priority);
            // проверка длительностей
            foreach (Note lnote in pd.PriorityMask.NoteList)
            {
                Assert.AreEqual(1, lnote.Duration.Numerator);
                Assert.AreEqual(16, lnote.Duration.Denominator);
            }
        }

        [TestMethod]
        public void TestPriorityMaskCalculation3()
        {
            PriorityDiscover pd = new PriorityDiscover();

            List<Note> notes = new List<Note>();
            notes.Add(note);
            notes.Add(bnote);
            notes.Add(dnote);
            notes.Add(anote);
            Measure measure = new Measure(notes, attributes3);
            pd.CalcPriorityMask(measure);
            // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/16
            // размер 13/16, поэтому будет считаться приоритет для 13/16 нот
            Assert.AreEqual(0, pd.PriorityMask.NoteList[0].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[1].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[2].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[3].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[4].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[5].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[6].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[7].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[8].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[9].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[10].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[11].Priority);
            Assert.AreEqual(2, pd.PriorityMask.NoteList[12].Priority);
            // проверка длительностей
            foreach (Note lnote in pd.PriorityMask.NoteList) 
            {
                Assert.AreEqual(1,lnote.Duration.Numerator);
                Assert.AreEqual(16,lnote.Duration.Denominator);
            }
        }

        [TestMethod]
        public void TestPriorityMaskCalculation4()
        {
            PriorityDiscover pd = new PriorityDiscover();

            List<Note> notes = new List<Note>();
            notes.Add(note);
            notes.Add(anote);
            Measure measure = new Measure(notes, attributes1);
            pd.CalcPriorityMask(measure);
            // так как минимальная длительность ноты в такте 1/4 то маска приоритетов должна разложиться (посчитаться) до 1/4
            // размер 3/4, поэтому будет считаться приоритет для 3/4 нот
            Assert.AreEqual(0, pd.PriorityMask.NoteList[0].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[1].Priority);
            Assert.AreEqual(1, pd.PriorityMask.NoteList[2].Priority);

            // проверка длительностей
            foreach (Note lnote in pd.PriorityMask.NoteList)
            {
                Assert.AreEqual(1, lnote.Duration.Numerator);
                Assert.AreEqual(4, lnote.Duration.Denominator);
            }
        }

        [TestMethod]
        public void TestPriorityDiscover1()
        {
            List<Note> notes = new List<Note>();
            notes.Add(note);
            notes.Add(bnote);
            notes.Add(anote);

            List<Note> notes1 = new List<Note>();
            notes1.Add(note);
            notes1.Add(note);
            notes1.Add(note);

            List<Note> notes2 = new List<Note>();
            notes2.Add(anote);
            notes2.Add(note);
            notes2.Add(bnote);
            notes2.Add(note);
            notes2.Add(bnote);

            List<Note> notes3 = new List<Note>();
            notes3.Add(note);
            notes3.Add(dnote);
            notes3.Add(note);
            notes3.Add(note);

            List<Note> notes4 = new List<Note>();
            notes4.Add(сnote);
            notes4.Add(сnote);
            notes4.Add(сnote);
            notes4.Add(ccnote);
            notes4.Add(ccnote);
            notes4.Add(ccnote);

            List<Note> notes5 = new List<Note>();
            notes5.Add(сccnote);
            notes5.Add(сccnote);
            notes5.Add(сccnote);
            notes5.Add(сccnote);
            notes5.Add(сccnote);
            notes5.Add(сccnote);
            notes5.Add(сccnote);
            notes5.Add(note);
            notes5.Add(note);


            Measure measure = new Measure(notes, attributes);
            Measure measure1 = new Measure(notes1, attributes1);
            Measure measure2 = new Measure(notes2, attributes2);
            Measure measure3 = new Measure(notes3, attributes3);
            Measure measure4 = new Measure(notes4, attributes1);
            Measure measure5 = new Measure(notes5, attributes);

            PriorityDiscover prioritydiscover = new PriorityDiscover();

            Assert.AreEqual(-1, measure.NoteList[0].Priority);
            Assert.AreEqual(-1, measure.NoteList[1].Priority);
            Assert.AreEqual(-1, measure.NoteList[2].Priority);

            prioritydiscover.Calculate(measure);
            prioritydiscover.Calculate(measure1);
            prioritydiscover.Calculate(measure2);
            prioritydiscover.Calculate(measure3);
            prioritydiscover.Calculate(measure4);
            prioritydiscover.Calculate(measure5);

            Assert.AreEqual(0, measure.NoteList[0].Priority);
            Assert.AreEqual(2, measure.NoteList[1].Priority);
            Assert.AreEqual(1, measure.NoteList[2].Priority);

            Assert.AreEqual(0, measure1.NoteList[0].Priority);
            Assert.AreEqual(1, measure1.NoteList[1].Priority);
            Assert.AreEqual(1, measure1.NoteList[2].Priority);

            Assert.AreEqual(0, measure2.NoteList[0].Priority);
            Assert.AreEqual(1, measure2.NoteList[1].Priority);
            Assert.AreEqual(1, measure2.NoteList[2].Priority);
            Assert.AreEqual(1, measure2.NoteList[3].Priority);
            Assert.AreEqual(1, measure2.NoteList[4].Priority);

            Assert.AreEqual(0, measure3.NoteList[0].Priority);
            Assert.AreEqual(1, measure3.NoteList[1].Priority);
            Assert.AreEqual(2, measure3.NoteList[2].Priority);
            Assert.AreEqual(2, measure3.NoteList[3].Priority);

            Assert.AreEqual(0, measure4.NoteList[0].Priority);
            Assert.AreEqual(1, measure4.NoteList[1].Priority);
            Assert.AreEqual(1, measure4.NoteList[2].Priority);
            Assert.AreEqual(1, measure4.NoteList[3].Priority);
            Assert.AreEqual(2, measure4.NoteList[4].Priority);
            Assert.AreEqual(2, measure4.NoteList[5].Priority);

            Assert.AreEqual(0, measure5.NoteList[0].Priority);
            Assert.AreEqual(3, measure5.NoteList[1].Priority);
            Assert.AreEqual(2, measure5.NoteList[2].Priority);
            Assert.AreEqual(3, measure5.NoteList[3].Priority);
            Assert.AreEqual(3, measure5.NoteList[4].Priority);
            Assert.AreEqual(3, measure5.NoteList[5].Priority);
            Assert.AreEqual(3, measure5.NoteList[6].Priority);
            Assert.AreEqual(1, measure5.NoteList[7].Priority);
            Assert.AreEqual(2, measure5.NoteList[8].Priority);
                        
            Assert.AreEqual(-1, note.Priority);
            Assert.AreEqual(-1, bnote.Priority);
            Assert.AreEqual(-1, anote.Priority);
            
        }
    }
}
