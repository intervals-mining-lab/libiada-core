using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.ScoreModel
{
    [TestClass]
    public class NoteTest
    {
        [TestMethod]
        public void TestNoteEquals1() 
        {
            var note1 = new Note(new Pitch(1,'A',0),new Duration(1,4,false,480),false,Tie.None);

            var note2 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Start);

            Assert.IsTrue(!note1.Equals(note2));
        }

        [TestMethod]
        public void TestNoteEquals2()
        {
            var note1 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);

            var note2 = new Note(new Pitch(1, 'B', -2), new Duration(1, 4, false, 480), false, Tie.None);

            Assert.IsTrue(note1.Equals(note2));
        }

        [TestMethod]
        public void TestMultiNoteEquals1()
        {
            var note1 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);
            note1.AddPitch(new Pitch(1, 'B', 0));

            var note2 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);
            note2.AddPitch(new Pitch(1, 'B', 0));

            Assert.IsTrue(note1.Equals(note2));
        }

        [TestMethod]
        public void TestNoteClone1()
        {
            var note1 = new Note(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Stop);

            var note2 =  (Note)note1.Clone();

            Assert.IsTrue(note1.Equals(note2));
        }
    }
}
