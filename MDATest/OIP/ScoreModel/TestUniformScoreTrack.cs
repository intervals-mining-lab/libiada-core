﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;

namespace MDATest.OIP.ScoreModel
{
    [TestClass]
    public class TestUniformScoreTrack
    {
        [TestMethod]
        public void TestNoteOrder1()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None, 2));
            notes.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));

            List<ValueNote> notes2 = new List<ValueNote>();
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes2.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 128), false, Tie.None, 2));
            notes2.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 4, false, 128), false, Tie.None, 1));

            notes2.Add(new ValueNote(null, new Duration(1, 4, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(null, new Duration(1, 4, false, 128), false, Tie.None, 1));

            notes2.Add(new ValueNote(null, new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(null, new Duration(1, 16, false, 128), false, Tie.None, 1));


            Attributes attr = new Attributes(new Size(4, 4), new Key(5));

            Measure m1 = new Measure(notes, attr);
            Measure m2 = new Measure(notes2, attr);

            List<Measure> mlist = new List<Measure>();

            mlist.Add(m1);
            mlist.Add(m2);

            UniformScoreTrack uni = new UniformScoreTrack("a1", mlist);

            Assert.AreNotEqual(((ValueNote) uni.NoteOrder()[0]).Id, 1);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[0]).Id, 0);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[1]).Id, 1);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[2]).Id, 1);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[3]).Id, 2);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[4]).Id, 3);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[5]).Id, 4);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[6]).Id, 0);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[7]).Id, 2);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[8]).Id, 2);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[9]).Id, 0);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[10]).Id, 0);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[11]).Id, 1);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[12]).Id, 1);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[13]).Id, 2);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[14]).Id, 3);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[15]).Id, 5);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[16]).Id, 0);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[17]).Id, 6);

            Assert.AreEqual(((ValueNote) uni.NoteOrder()[18]).Id, 7);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[19]).Id, 7);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[20]).Id, 8);
            Assert.AreEqual(((ValueNote) uni.NoteOrder()[21]).Id, 8);
        }

        [TestMethod]
        public void TestNoteOrder2()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None, 2));
            notes.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));

            List<ValueNote> notes2 = new List<ValueNote>();
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes2.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 128), false, Tie.None, 2));
            notes2.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 4, false, 128), false, Tie.None, 1));

            notes2.Add(new ValueNote(null, new Duration(1, 4, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(null, new Duration(1, 4, false, 128), false, Tie.None, 1));

            notes2.Add(new ValueNote(null, new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(null, new Duration(1, 16, false, 128), false, Tie.None, 1));


            Attributes attr = new Attributes(new Size(4, 4), new Key(5));

            Measure m1 = new Measure(notes, attr);
            Measure m2 = new Measure(notes2, attr);

            List<Measure> mlist = new List<Measure>();

            mlist.Add(m1);
            mlist.Add(m2);

            UniformScoreTrack uni = new UniformScoreTrack("a1", mlist);

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
        public void TestMeasureOrder1()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));

            List<ValueNote> notes3 = new List<ValueNote>();
            notes3.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes3.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes3.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes3.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));

            List<ValueNote> notes2 = new List<ValueNote>();
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes2.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes2.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes2.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1));

            List<ValueNote> notes4 = new List<ValueNote>();
            notes4.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes4.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 4, false, 128), false, Tie.None, 2));
            notes4.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3));
            notes4.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 4, false, 128), false, Tie.None, 1));

            List<ValueNote> notes5 = new List<ValueNote>();
            notes5.Add(new ValueNote(null, new Duration(1, 4, false, 128), false, Tie.None, 1));
            notes5.Add(new ValueNote(null, new Duration(1, 4, false, 128), false, Tie.None, 1));

            List<ValueNote> notes6 = new List<ValueNote>();
            notes6.Add(new ValueNote(null, new Duration(1, 16, false, 128), false, Tie.None, 1));
            notes6.Add(new ValueNote(null, new Duration(1, 16, false, 128), false, Tie.None, 1));


            Attributes attr = new Attributes(new Size(4, 4, 128), new Key(5));

            Measure m1 = new Measure(notes, attr);
            Measure m2 = new Measure(notes2, attr);
            Measure m3 = new Measure(notes3, attr);
            Measure m4 = new Measure(notes4, attr);
            Measure m5 = new Measure(notes5, attr);
            Measure m6 = new Measure(notes6, attr);

            List<Measure> mlist = new List<Measure>();

            mlist.Add(m1);
            mlist.Add(m2);
            mlist.Add(m3);
            mlist.Add(m4);
            mlist.Add(m5);
            mlist.Add(m5);
            mlist.Add(m2);
            mlist.Add(m3);
            mlist.Add(m6);

            UniformScoreTrack uni = new UniformScoreTrack("a1", mlist);


            Assert.AreEqual(((Measure) uni.MeasureOrder()[0]).Id, 0);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[1]).Id, 1);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[2]).Id, 0);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[3]).Id, 2);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[4]).Id, 3);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[5]).Id, 3);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[6]).Id, 1);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[7]).Id, 0);
            Assert.AreEqual(((Measure) uni.MeasureOrder()[8]).Id, 4);

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
