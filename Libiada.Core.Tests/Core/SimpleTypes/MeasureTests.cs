﻿namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The measure tests.
/// </summary>
[TestFixture]
public class MeasureTests
{
    /// <summary>
    /// The measure first test.
    /// </summary>
    [Test]
    public void MeasureFirstTest()
    {
        var notes = new List<ValueNote>();
        var notes2 = new List<ValueNote>();
        var attributes = new MeasureAttributes(new Size(4, 4), new Key(5));

        notes.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));
        notes.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));
        notes.Add(new ValueNote(new Pitch(3, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None));

        notes2.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));
        notes2.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));
        notes2.Add(new ValueNote(new Pitch(3, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None));

        var m1 = new Measure(notes, attributes);
        var m2 = new Measure(notes2, attributes);

        Assert.That(m1, Is.EqualTo(m2));
    }

    /// <summary>
    /// The measure second test.
    /// </summary>
    [Test]
    public void MeasureSecondTest()
    {
        var notes = new List<ValueNote>();
        var notes2 = new List<ValueNote>();
        var attributes = new MeasureAttributes(new Size(4, 4), new Key(5));
        var attributes2 = new MeasureAttributes(new Size(3, 4), new Key(5));

        notes.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));
        notes.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));
        notes.Add(new ValueNote(new Pitch(3, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None));

        notes2.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));
        notes2.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));
        notes2.Add(new ValueNote(new Pitch(3, NoteSymbol.D, 0), new Duration(1, 16, false), false, Tie.None));

        var m1 = new Measure(notes, attributes);
        var m2 = new Measure(notes2, attributes);
        var m3 = new Measure(notes2, attributes2);

        Assert.That(m1, Is.Not.EqualTo(m2));
        Assert.That(m2, Is.Not.EqualTo(m3));
    }
}
