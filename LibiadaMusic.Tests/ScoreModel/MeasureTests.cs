using System.Collections.Generic;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.ScoreModel
{
    [TestClass]
    public class MeasureTests
    {
        [TestMethod]
        public void MeasureFirstTest() 
        {
            var notes = new List<ValueNote>();
            var notes2 = new List<ValueNote>();
            var attrs = new Attributes(new Size(4, 4, 512), new Key(5));

            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false,128),false,Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 16, false, 32), false, Tie.None));

            notes2.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 16, false, 32), false, Tie.None));

            var m1 = new Measure(notes, attrs);
            var m2 = new Measure(notes2, attrs);

            Assert.IsTrue(m1.Equals(m2));
        }

        [TestMethod]
        public void MeasureSecondTest()
        {
            var notes = new List<ValueNote>();
            var notes2 = new List<ValueNote>();
            var attrs = new Attributes(new Size(4, 4, 512), new Key(5));
            var attrs2 = new Attributes(new Size(3, 4, 512), new Key(5));

            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes.Add(new ValueNote(new Pitch(3, 'C', 0), new Duration(1, 16, false, 32), false, Tie.None));

            notes2.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 4, false, 128), false, Tie.None));
            notes2.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 32), false, Tie.None));

            var m1 = new Measure(notes, attrs);
            var m2 = new Measure(notes2, attrs);
            var m3 = new Measure(notes2, attrs2);

            Assert.IsFalse(m1.Equals(m2));
            Assert.IsFalse(m2.Equals(m3));
        } 
    }
}
