using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;

namespace MDATest.OIP.ScoreModel
{
    [TestClass]
    public class TestMeasure
    {
        [TestMethod]
        public void MeasureTest1()
        {
            List<ValueNote> notes = new List<ValueNote>();
            List<ValueNote> notes2 = new List<ValueNote>();
            Attributes attrs = new Attributes(new Size(4, 4, 512), new Key(5));

            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 16, false, 32), false, Tie.None));

            notes2.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 16, false, 32), false, Tie.None));

            Measure m1 = new Measure(notes, attrs);
            Measure m2 = new Measure(notes2, attrs);

            Assert.IsTrue(m1.Equals((Measure) m2));
        }

        [TestMethod]
        public void MeasureTest2()
        {
            List<ValueNote> notes = new List<ValueNote>();
            List<ValueNote> notes2 = new List<ValueNote>();
            Attributes attrs = new Attributes(new Size(4, 4, 512), new Key(5));
            Attributes attrs2 = new Attributes(new Size(3, 4, 512), new Key(5));

            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 16, false, 32), false, Tie.None));

            notes2.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 32), false, Tie.None));

            Measure m1 = new Measure(notes, attrs);
            Measure m2 = new Measure(notes2, attrs);
            Measure m3 = new Measure(notes2, attrs2);

            Assert.IsFalse(m1.Equals((Measure) m2));
            Assert.IsFalse(m2.Equals((Measure) m3));
        }
    }
}
