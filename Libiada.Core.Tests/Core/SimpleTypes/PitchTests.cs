namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Pitch tests.
/// </summary>
[TestFixture]
public class PitchTests
{
    /// <summary>
    /// The pitch constructor test.
    /// </summary>
    [Test]
    public void PitchConstructorTest()
    {
        Pitch initialPitch = new(1, NoteSymbol.A, Accidental.Bekar);
        Pitch midiNumberPitch = new(initialPitch.MidiNumber);
        Assert.That(midiNumberPitch.MidiNumber, Is.EqualTo(initialPitch.MidiNumber));
        initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
        midiNumberPitch = new Pitch(initialPitch.MidiNumber);
        Assert.That(midiNumberPitch.MidiNumber, Is.EqualTo(initialPitch.MidiNumber));
    }
}
