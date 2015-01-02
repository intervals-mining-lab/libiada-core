namespace LibiadaMusic.Tests.ScoreModel
{
    using LibiadaMusic.ScoreModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The value note tests.
    /// </summary>
    [TestClass]
    public class ValueNoteTests
    {
        /// <summary>
        /// The value note equals first test.
        /// </summary>
        [TestMethod]
        public void ValueNoteEqualsFirstTest()
        {
            var note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);

            var note2 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Start);

            Assert.IsTrue(!note1.Equals(note2));
        }

        /// <summary>
        /// The value note equals second test.
        /// </summary>
        [TestMethod]
        public void ValueNoteEqualsSecondTest()
        {
            var note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);

            var note2 = new ValueNote(new Pitch(1, 'B', -2), new Duration(1, 4, false, 480), false, Tie.None);

            Assert.IsTrue(note1.Equals(note2));
        }

        /// <summary>
        /// The multi note equals test.
        /// </summary>
        [TestMethod]
        public void MultiNoteEqualsTest()
        {
            var note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);
            note1.AddPitch(new Pitch(1, 'B', 0));

            var note2 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.None);
            note2.AddPitch(new Pitch(1, 'B', 0));

            Assert.IsTrue(note1.Equals(note2));
        }

        /// <summary>
        /// The value note clone test.
        /// </summary>
        [TestMethod]
        public void ValueNoteCloneTest()
        {
            var note1 = new ValueNote(new Pitch(1, 'A', 0), new Duration(1, 4, false, 480), false, Tie.Stop);

            var note2 = (ValueNote)note1.Clone();

            Assert.IsTrue(note1.Equals(note2));

            Assert.AreNotSame(note1, note2);
        }
    }
}
