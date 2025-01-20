namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The fmotif sequence tests.
/// </summary>
[TestFixture]
public class FmotifSequenceTests
{
    /// <summary>
    /// The fmotif sequence test.
    /// </summary>
    [Test]
    public void FmotifSequenceTest()
    {
        FmotifSequence sequence = new();
        sequence.FmotifsList.Add(new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0));
        sequence.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));
        sequence.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.B, 0), new Duration(1, 2, false), false, Tie.None));
        Assert.That(sequence.FmotifsList[0].Id, Is.EqualTo(0));
        Assert.That(sequence.FmotifsList[0].NoteList[0].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
        Assert.That(sequence.FmotifsList[0].NoteList[1].Pitches[0].Step, Is.EqualTo(NoteSymbol.B));
    }

    /// <summary>
    /// The fmotif sequence equals test.
    /// </summary>
    [Test]
    public void FmotifSequenceEqualsTest()
    {
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        FmotifSequence firstSequence = new();
        firstSequence.FmotifsList.Add(fmotif1);
        firstSequence.FmotifsList.Add(fmotif2);

        FmotifSequence secondSequence = new();
        secondSequence.FmotifsList.Add(fmotif1);
        secondSequence.FmotifsList.Add(fmotif2);
        Assert.That(firstSequence, Is.EqualTo(secondSequence));

        secondSequence = new FmotifSequence();
        secondSequence.FmotifsList.Add(fmotif2);
        secondSequence.FmotifsList.Add(fmotif1);
        Assert.That(firstSequence, Is.Not.EqualTo(secondSequence));

        secondSequence = new FmotifSequence();
        secondSequence.FmotifsList.Add(fmotif2);
        secondSequence.FmotifsList.Add(fmotif2);
        Assert.That(firstSequence, Is.Not.EqualTo(secondSequence));

        firstSequence = new FmotifSequence();
        firstSequence.FmotifsList.Add(fmotif1);
        firstSequence.FmotifsList.Add(fmotif1);
        firstSequence.FmotifsList.Add(fmotif2);
        firstSequence.FmotifsList.Add(fmotif1);

        secondSequence = new FmotifSequence();
        secondSequence.FmotifsList.Add(fmotif1);
        secondSequence.FmotifsList.Add(fmotif1);
        secondSequence.FmotifsList.Add(fmotif2);
        secondSequence.FmotifsList.Add(fmotif1);
        Assert.That(firstSequence, Is.EqualTo(secondSequence));
    }
}
