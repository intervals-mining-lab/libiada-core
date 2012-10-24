using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;
using MDA.ICL;

namespace MDATest.ICL
{
    [TestClass]
    public class TestNoteRemoteness
    {
        [TestMethod]
        public void TestNoteRemoteness1()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(fmchain1))<0.000001);
        }
        [TestMethod]
        public void TestNoteRemoteness1pause()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(fmchain1)) < 0.000001);
        }
        [TestMethod]
        public void TestNoteRemoteness1Tie()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 2, false, 512), false, (int)Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.Start));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, (int)Tie.Stop));
            
            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(0.75 - NoteCharacteristic.CalculateRemoteness(fmchain1)) < 0.000001);
        }

        [TestMethod]
        public void TestNoteRemoteness1Oct()
        {
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(2, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 2, false, 512), false, (int)Tie.None));

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, (int)Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(4, 'A', 0), new Duration(1, 2, false, 512), false, (int)Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            Assert.IsTrue(Math.Abs(1.14624062 - NoteCharacteristic.CalculateRemoteness(fmchain1)) < 0.000001);
        }
    }
}
