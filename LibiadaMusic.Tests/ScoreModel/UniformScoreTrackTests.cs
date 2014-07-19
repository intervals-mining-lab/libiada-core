using System.Collections.Generic;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.ScoreModel
{
    [TestClass]
    public class CongenericScoreTrackTests
    {
        [TestMethod]
        public void ValueNoteOrderFirstTest() 
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1)
            };

            var notes2 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 16, false, 128), false, Tie.None, 1)
            };


            var attr = new Attributes(new Size(4, 4), new Key(5));

            var m1 = new Measure(notes, attr);
            var m2 = new Measure(notes2, attr);

            var mlist = new List<Measure> {m1, m2};

            var uni = new CongenericScoreTrack("a1", mlist);

            Assert.AreNotEqual(uni.NoteOrder()[0].Id, 1);

            Assert.AreEqual(uni.NoteOrder()[0].Id, 0);
            Assert.AreEqual(uni.NoteOrder()[1].Id, 1);
            Assert.AreEqual(uni.NoteOrder()[2].Id, 1);

            Assert.AreEqual(uni.NoteOrder()[3].Id, 2);
            Assert.AreEqual(uni.NoteOrder()[4].Id, 3);
            Assert.AreEqual(uni.NoteOrder()[5].Id, 4);

            Assert.AreEqual(uni.NoteOrder()[6].Id, 0);
            Assert.AreEqual(uni.NoteOrder()[7].Id, 2);
            Assert.AreEqual(uni.NoteOrder()[8].Id, 2);

            Assert.AreEqual(uni.NoteOrder()[9].Id, 0);
            Assert.AreEqual(uni.NoteOrder()[10].Id, 0);
            Assert.AreEqual(uni.NoteOrder()[11].Id, 1);

            Assert.AreEqual(uni.NoteOrder()[12].Id, 1);
            Assert.AreEqual(uni.NoteOrder()[13].Id, 2);
            Assert.AreEqual(uni.NoteOrder()[14].Id, 3);

            Assert.AreEqual(uni.NoteOrder()[15].Id, 5);
            Assert.AreEqual(uni.NoteOrder()[16].Id, 0);
            Assert.AreEqual(uni.NoteOrder()[17].Id, 6);

            Assert.AreEqual(uni.NoteOrder()[18].Id, 7);
            Assert.AreEqual(uni.NoteOrder()[19].Id, 7);
            Assert.AreEqual(uni.NoteOrder()[20].Id, 8);
            Assert.AreEqual(uni.NoteOrder()[21].Id, 8);
        }

        [TestMethod]
        public void ValueNoteOrderSecondTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1)
            };

            var notes2 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 16, false, 128), false, Tie.None, 1)
            };


            var attr = new Attributes(new Size(4, 4), new Key(5));

            var m1 = new Measure(notes, attr);
            var m2 = new Measure(notes2, attr);

            var mlist = new List<Measure> {m1, m2};

            var uni = new CongenericScoreTrack("a1", mlist);

            Assert.AreNotEqual(uni.NoteIdOrder()[0], 1);

            Assert.AreEqual(uni.NoteIdOrder()[0], 0);
            Assert.AreEqual(uni.NoteIdOrder()[1], 1);
            Assert.AreEqual(uni.NoteIdOrder()[2], 1);

            Assert.AreEqual(uni.NoteIdOrder()[3], 2);
            Assert.AreEqual(uni.NoteIdOrder()[4], 3);
            Assert.AreEqual(uni.NoteIdOrder()[5], 4);

            Assert.AreEqual(uni.NoteIdOrder()[6], 0);
            Assert.AreEqual(uni.NoteIdOrder()[7], 2);
            Assert.AreEqual(uni.NoteIdOrder()[8], 2);

            Assert.AreEqual(uni.NoteIdOrder()[9], 0);
            Assert.AreEqual(uni.NoteIdOrder()[10], 0);
            Assert.AreEqual(uni.NoteIdOrder()[11], 1);

            Assert.AreEqual(uni.NoteIdOrder()[12], 1);
            Assert.AreEqual(uni.NoteIdOrder()[13], 2);
            Assert.AreEqual(uni.NoteIdOrder()[14], 3);

            Assert.AreEqual(uni.NoteIdOrder()[15], 5);
            Assert.AreEqual(uni.NoteIdOrder()[16], 0);
            Assert.AreEqual(uni.NoteIdOrder()[17], 6);

            Assert.AreEqual(uni.NoteIdOrder()[18], 7);
            Assert.AreEqual(uni.NoteIdOrder()[19], 7);
            Assert.AreEqual(uni.NoteIdOrder()[20], 8);
            Assert.AreEqual(uni.NoteIdOrder()[21], 8);
        }

        [TestMethod]
        public void MeasureOrderTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1)
            };

            var notes3 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1)
            };

            var notes2 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1)
            };

            var notes4 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 4, false, 128), false, Tie.None, 1)
            };

            var notes5 = new List<ValueNote>
            {
                new ValueNote((Pitch) null, new Duration(1, 4, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 4, false, 128), false, Tie.None, 1)
            };

            var notes6 = new List<ValueNote>
            {
                new ValueNote((Pitch) null, new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote((Pitch) null, new Duration(1, 16, false, 128), false, Tie.None, 1)
            };


            var attr = new Attributes(new Size(4, 4, 128), new Key(5));

            var m1 = new Measure(notes, attr);
            var m2 = new Measure(notes2, attr);
            var m3 = new Measure(notes3, attr);
            var m4 = new Measure(notes4, attr);
            var m5 = new Measure(notes5, attr);
            var m6 = new Measure(notes6, attr);

            var mlist = new List<Measure> {m1, m2, m3, m4, m5, m5, m2, m3, m6};

            var uni = new CongenericScoreTrack("a1", mlist);

            
            Assert.AreEqual(uni.MeasureOrder()[0].Id, 0);
            Assert.AreEqual(uni.MeasureOrder()[1].Id, 1);
            Assert.AreEqual(uni.MeasureOrder()[2].Id, 0);
            Assert.AreEqual(uni.MeasureOrder()[3].Id, 2);
            Assert.AreEqual(uni.MeasureOrder()[4].Id, 3);
            Assert.AreEqual(uni.MeasureOrder()[5].Id, 3);
            Assert.AreEqual(uni.MeasureOrder()[6].Id, 1);
            Assert.AreEqual(uni.MeasureOrder()[7].Id, 0);
            Assert.AreEqual(uni.MeasureOrder()[8].Id, 4);

            Assert.AreEqual(uni.MeasureIdOrder()[0], 0);
            Assert.AreEqual(uni.MeasureIdOrder()[1], 1);
            Assert.AreEqual(uni.MeasureIdOrder()[2], 0);
            Assert.AreEqual(uni.MeasureIdOrder()[3], 2);
            Assert.AreEqual(uni.MeasureIdOrder()[4], 3);
            Assert.AreEqual(uni.MeasureIdOrder()[5], 3);
            Assert.AreEqual(uni.MeasureIdOrder()[6], 1);
            Assert.AreEqual(uni.MeasureIdOrder()[7], 0);
            Assert.AreEqual(uni.MeasureIdOrder()[8], 4);
        }
    }
}
