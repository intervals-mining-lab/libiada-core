namespace Libiada.Core.Tests.Music;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The midi number manager tests.
/// </summary>
[TestFixture]
public class MidiNumberManagerTests
{
    /// <summary>
    /// The get octave from midi number test.
    /// </summary>
    [Test]
    public void GetOctaveFromMidiNumberTest()
    {
        Pitch initialPitch = new(1, NoteSymbol.A, 0);
        var octave = MidiNumberManager.GetOctaveFromMidiNumber(initialPitch.MidiNumber);
        Assert.That(octave, Is.EqualTo(initialPitch.Octave));

        initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
        octave = MidiNumberManager.GetOctaveFromMidiNumber(initialPitch.MidiNumber);
        Assert.That(octave, Is.EqualTo(initialPitch.Octave));
    }

    /// <summary>
    /// Test for GetNoteSymbolFromMidiNumber method.
    /// </summary>
    [Test]
    public void GetNoteSymbolFromMidiNumberTest()
    {
        Pitch initialPitch = new(1, NoteSymbol.A, Accidental.Bekar);
        var step = MidiNumberManager.GetNoteSymbolFromMidiNumber(initialPitch.MidiNumber);
        Assert.That(step, Is.EqualTo(initialPitch.Step));

        initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
        step = MidiNumberManager.GetNoteSymbolFromMidiNumber(initialPitch.MidiNumber);
        Assert.That(step, Is.EqualTo(initialPitch.Step));
    }

    /// <summary>
    /// The get alter from midi number test.
    /// </summary>
    [Test]
    public void GetAlterFromMidiNumberTest()
    {
        Pitch initialPitch = new(1, NoteSymbol.A, Accidental.Bekar);
        var alter = MidiNumberManager.GetAlterFromMidiNumber(initialPitch.MidiNumber);
        Assert.That(alter, Is.EqualTo(initialPitch.Alter));

        initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
        alter = MidiNumberManager.GetAlterFromMidiNumber(initialPitch.MidiNumber);
        Assert.That(alter, Is.EqualTo(initialPitch.Alter));
    }
}
