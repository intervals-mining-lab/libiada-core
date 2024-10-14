namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The congeneric score track tests.
/// </summary>
[TestFixture]
public class CongenericScoreTrackTests
{
    /// <summary>
    /// The value note order first test.
    /// </summary>
    [Test]
    public void ValueNoteOrderFirstTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes2 =
        [
            new(new Pitch(3, NoteSymbol.B, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 4, false), false, Tie.None, 1),
            new( new Duration(1, 4, false), false, Tie.None, 1),
            new(new Duration(1, 4, false), false, Tie.None, 1),
            new(new Duration(1, 16, false), false, Tie.None, 1),
            new(new Duration(1, 16, false), false, Tie.None, 1)
        ];

        MeasureAttributes attr = new(new Size(4, 4), new Key(5));

        Measure m1 = new(notes, attr);
        Measure m2 = new(notes2, attr);

        List<Measure> measuresList = [m1, m2];

        CongenericScoreTrack uni = new(measuresList);

        Assert.That(uni.NoteOrder()[0].Id, Is.Not.EqualTo(1));

        Assert.That(uni.NoteOrder()[0].Id, Is.EqualTo(0));
        Assert.That(uni.NoteOrder()[1].Id, Is.EqualTo(1));
        Assert.That(uni.NoteOrder()[2].Id, Is.EqualTo(1));

        Assert.That(uni.NoteOrder()[3].Id, Is.EqualTo(2));
        Assert.That(uni.NoteOrder()[4].Id, Is.EqualTo(3));
        Assert.That(uni.NoteOrder()[5].Id, Is.EqualTo(4));

        Assert.That(uni.NoteOrder()[6].Id, Is.EqualTo(0));
        Assert.That(uni.NoteOrder()[7].Id, Is.EqualTo(2));
        Assert.That(uni.NoteOrder()[8].Id, Is.EqualTo(2));

        Assert.That(uni.NoteOrder()[9].Id, Is.EqualTo(0));
        Assert.That(uni.NoteOrder()[10].Id, Is.EqualTo(0));
        Assert.That(uni.NoteOrder()[11].Id, Is.EqualTo(1));

        Assert.That(uni.NoteOrder()[12].Id, Is.EqualTo(1));
        Assert.That(uni.NoteOrder()[13].Id, Is.EqualTo(2));
        Assert.That(uni.NoteOrder()[14].Id, Is.EqualTo(3));

        Assert.That(uni.NoteOrder()[15].Id, Is.EqualTo(5));
        Assert.That(uni.NoteOrder()[16].Id, Is.EqualTo(0));
        Assert.That(uni.NoteOrder()[17].Id, Is.EqualTo(6));

        Assert.That(uni.NoteOrder()[18].Id, Is.EqualTo(7));
        Assert.That(uni.NoteOrder()[19].Id, Is.EqualTo(7));
        Assert.That(uni.NoteOrder()[20].Id, Is.EqualTo(8));
        Assert.That(uni.NoteOrder()[21].Id, Is.EqualTo(8));
    }

    /// <summary>
    /// The value note order second test.
    /// </summary>
    [Test]
    public void ValueNoteOrderSecondTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes2 =
        [
            new(new Pitch(3, NoteSymbol.B, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 4, false), false, Tie.None, 1),
            new(new Duration(1, 4, false), false, Tie.None, 1),
            new(new Duration(1, 4, false), false, Tie.None, 1),
            new(new Duration(1, 16, false), false, Tie.None, 1),
            new(new Duration(1, 16, false), false, Tie.None, 1)
        ];

        MeasureAttributes attr = new(new Size(4, 4), new Key(5));

        Measure m1 = new(notes, attr);
        Measure m2 = new(notes2, attr);

        List<Measure> measuresList = [m1, m2];

        CongenericScoreTrack uni = new(measuresList);

        Assert.That(uni.NoteIdOrder()[0], Is.Not.EqualTo(1));

        Assert.That(uni.NoteIdOrder()[0], Is.EqualTo(0));
        Assert.That(uni.NoteIdOrder()[1], Is.EqualTo(1));
        Assert.That(uni.NoteIdOrder()[2], Is.EqualTo(1));

        Assert.That(uni.NoteIdOrder()[3], Is.EqualTo(2));
        Assert.That(uni.NoteIdOrder()[4], Is.EqualTo(3));
        Assert.That(uni.NoteIdOrder()[5], Is.EqualTo(4));

        Assert.That(uni.NoteIdOrder()[6], Is.EqualTo(0));
        Assert.That(uni.NoteIdOrder()[7], Is.EqualTo(2));
        Assert.That(uni.NoteIdOrder()[8], Is.EqualTo(2));

        Assert.That(uni.NoteIdOrder()[9], Is.EqualTo(0));
        Assert.That(uni.NoteIdOrder()[10], Is.EqualTo(0));
        Assert.That(uni.NoteIdOrder()[11], Is.EqualTo(1));

        Assert.That(uni.NoteIdOrder()[12], Is.EqualTo(1));
        Assert.That(uni.NoteIdOrder()[13], Is.EqualTo(2));
        Assert.That(uni.NoteIdOrder()[14], Is.EqualTo(3));

        Assert.That(uni.NoteIdOrder()[15], Is.EqualTo(5));
        Assert.That(uni.NoteIdOrder()[16], Is.EqualTo(0));
        Assert.That(uni.NoteIdOrder()[17], Is.EqualTo(6));

        Assert.That(uni.NoteIdOrder()[18], Is.EqualTo(7));
        Assert.That(uni.NoteIdOrder()[19], Is.EqualTo(7));
        Assert.That(uni.NoteIdOrder()[20], Is.EqualTo(8));
        Assert.That(uni.NoteIdOrder()[21], Is.EqualTo(8));
    }

    /// <summary>
    /// The measure order test.
    /// </summary>
    [Test]
    public void MeasureOrderTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes3 =
        [
            new(new Pitch(3, NoteSymbol.B, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes2 =
        [
            new(new Pitch(3, NoteSymbol.B, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes4 =
        [
            new(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 4, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes5 =
        [
            new(new Duration(1, 4, false), false, Tie.None, 1),
            new(new Duration(1, 4, false), false, Tie.None, 1)
        ];

        List<ValueNote> notes6 =
        [
            new(new Duration(1, 16, false), false, Tie.None, 1),
            new(new Duration(1, 16, false), false, Tie.None, 1)
        ];

        MeasureAttributes attr = new(new Size(4, 4), new Key(5));

        Measure m1 = new(notes, attr);
        Measure m2 = new(notes2, attr);
        Measure m3 = new(notes3, attr);
        Measure m4 = new(notes4, attr);
        Measure m5 = new(notes5, attr);
        Measure m6 = new(notes6, attr);

        List<Measure> measuresList = [m1, m2, m3, m4, m5, m5, m2, m3, m6];

        CongenericScoreTrack uni = new(measuresList);

        Assert.That(uni.MeasureOrder()[0].Id, Is.EqualTo(0));
        Assert.That(uni.MeasureOrder()[1].Id, Is.EqualTo(1));
        Assert.That(uni.MeasureOrder()[2].Id, Is.EqualTo(0));
        Assert.That(uni.MeasureOrder()[3].Id, Is.EqualTo(2));
        Assert.That(uni.MeasureOrder()[4].Id, Is.EqualTo(3));
        Assert.That(uni.MeasureOrder()[5].Id, Is.EqualTo(3));
        Assert.That(uni.MeasureOrder()[6].Id, Is.EqualTo(1));
        Assert.That(uni.MeasureOrder()[7].Id, Is.EqualTo(0));
        Assert.That(uni.MeasureOrder()[8].Id, Is.EqualTo(4));

        Assert.That(uni.MeasureIdOrder()[0], Is.EqualTo(0));
        Assert.That(uni.MeasureIdOrder()[1], Is.EqualTo(1));
        Assert.That(uni.MeasureIdOrder()[2], Is.EqualTo(0));
        Assert.That(uni.MeasureIdOrder()[3], Is.EqualTo(2));
        Assert.That(uni.MeasureIdOrder()[4], Is.EqualTo(3));
        Assert.That(uni.MeasureIdOrder()[5], Is.EqualTo(3));
        Assert.That(uni.MeasureIdOrder()[6], Is.EqualTo(1));
        Assert.That(uni.MeasureIdOrder()[7], Is.EqualTo(0));
        Assert.That(uni.MeasureIdOrder()[8], Is.EqualTo(4));
    }
}
