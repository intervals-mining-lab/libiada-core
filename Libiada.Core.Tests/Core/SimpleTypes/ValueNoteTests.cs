namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

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
        ValueNote note1 = new(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None);

        ValueNote note2 = new(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false), false, Tie.Start);

        Assert.That(note1, Is.Not.EqualTo(note2));
    }

    /// <summary>
    /// The value note equals second test.
    /// </summary>
    [Test]
    public void ValueNoteEqualsSecondTest()
    {
        ValueNote note1 = new(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None);

        ValueNote note2 = new(new Pitch(1, NoteSymbol.B, Accidental.DoubleFlat), new Duration(1, 4, false), false, Tie.None);

        Assert.That(note1, Is.EqualTo(note2));
    }

    /// <summary>
    /// The multi note equals test.
    /// </summary>
    [Test]
    public void MultiNoteEqualsTest()
    {
        ValueNote note1 = new(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None);
        note1.AddPitch(new Pitch(1, NoteSymbol.B, Accidental.Bekar));

        ValueNote note2 = new(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None);
        note2.AddPitch(new Pitch(1, NoteSymbol.B, Accidental.Bekar));

        Assert.That(note1, Is.EqualTo(note2));
    }

    /// <summary>
    /// The value note clone test.
    /// </summary>
    [Test]
    public void ValueNoteCloneTest()
    {
        ValueNote note1 = new(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 4, false), false, Tie.End);

        ValueNote note2 = (ValueNote)note1.Clone();

        Assert.That(note1, Is.EqualTo(note2));

        Assert.That(note1, Is.Not.SameAs(note2));
    }
}
