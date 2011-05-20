using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIPTest.TestBorodaDivider
{
    [TestClass]
    public class TestFmotiv
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

    }

}