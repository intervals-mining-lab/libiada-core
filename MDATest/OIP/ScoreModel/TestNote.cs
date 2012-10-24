using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;

namespace MDATest.OIPTest.ScoreModel
{
    [TestClass]
    public class TestNote
    {
        [TestMethod]
        public void TestNoteEquals1()
        {
            ValueNote note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);

            ValueNote note2 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Start);

            Assert.IsTrue(!note1.Equals(note2));
        }

        [TestMethod]
        public void TestNoteEquals2()
        {
            ValueNote note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);

            ValueNote note2 = new ValueNote(new Pitch(1, 'B', -2), new Duration(1, 4, false, 480), false, Tie.None);

            Assert.IsTrue(note1.Equals(note2));
        }

        [TestMethod]
        public void TestNoteClone1()
        {
            ValueNote note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Stop);

            ValueNote note2 = (ValueNote) note1.Clone();

            Assert.IsTrue(note1.Equals(note2));
        }
    }
}
