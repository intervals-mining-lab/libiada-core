using LibiadaCore.Core.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCore.Tests.Core.SimpleTypes
{
    /// <summary>
    /// The value note tests.
    /// </summary>
    [TestFixture]
    public class ValueNoteTests
    {
        /// <summary>
        /// The value note equals first test.
        /// </summary>
        [Test]
        public void ValueNoteEqualsFirstTest()
        {
            var note1 = new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.None);

            var note2 = new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.Start);

            Assert.IsTrue(!note1.Equals(note2));
        }

        /// <summary>
        /// The value note equals second test.
        /// </summary>
        [Test]
        public void ValueNoteEqualsSecondTest()
        {
            var note1 = new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.None);

            var note2 = new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.DoubleFlat), new Duration(1, 4, false, 480), false, Tie.None);

            Assert.IsTrue(note1.Equals(note2));
        }

        /// <summary>
        /// The multi note equals test.
        /// </summary>
        [Test]
        public void MultiNoteEqualsTest()
        {
            var note1 = new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.None);
            note1.AddPitch(new Pitch(1, NoteSymbol.B, Accidental.Bekar));

            var note2 = new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.None);
            note2.AddPitch(new Pitch(1, NoteSymbol.B, Accidental.Bekar));

            Assert.IsTrue(note1.Equals(note2));
        }

        /// <summary>
        /// The value note clone test.
        /// </summary>
        [Test]
        public void ValueNoteCloneTest()
        {
            var note1 = new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false, 480), false, Tie.End);

            var note2 = (ValueNote)note1.Clone();

            Assert.IsTrue(note1.Equals(note2));

            Assert.AreNotSame(note1, note2);
        }
    }
}
