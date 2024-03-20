namespace Libiada.Core.Tests.Music;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The fmotif identification tests.
/// </summary>
[TestFixture]
public class FmotifIdentifierTests
{
    /// <summary>
    /// The fmotif identification first test.
    /// </summary>
    [Test]
    public void FmotifIdentificationFirstTest()
    {
        // создание ф-мотивов
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
        Fmotif fmotif3 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 2);
        Fmotif fmotif4 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 3);
        Fmotif fmotif5 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 4);
        Fmotif fmotif6 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 5);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);
        fmchain1.FmotifsList.Add(fmotif3);
        fmchain1.FmotifsList.Add(fmotif4);
        fmchain1.FmotifsList.Add(fmotif5);
        fmchain1.FmotifsList.Add(fmotif6);

        FmotifIdentifier fmid = new();
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[0].Id, Is.EqualTo(0));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[1].Id, Is.EqualTo(1));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[2].Id, Is.EqualTo(1));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[3].Id, Is.EqualTo(1));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[4].Id, Is.EqualTo(0));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[5].Id, Is.EqualTo(0));
    }

    /// <summary>
    /// The fmotif identification second test.
    /// </summary>
    [Test]
    public void FmotifIdentificationSecondTest()
    {
        // создание ф-мотивов
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
        Fmotif fmotif3 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 2);
        Fmotif fmotif4 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 3);
        Fmotif fmotif5 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 4);
        Fmotif fmotif6 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 5);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif4.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif5.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.C, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif6.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.D, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);
        fmchain1.FmotifsList.Add(fmotif3);
        fmchain1.FmotifsList.Add(fmotif4);
        fmchain1.FmotifsList.Add(fmotif5);
        fmchain1.FmotifsList.Add(fmotif6);

        FmotifIdentifier fmid = new();

        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[0].Id, Is.EqualTo(0));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[1].Id, Is.EqualTo(0));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[2].Id, Is.EqualTo(0));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[3].Id, Is.EqualTo(1));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[4].Id, Is.EqualTo(2));
        Assert.That(fmid.GetIdentification(fmchain1, true).FmotifsList[5].Id, Is.EqualTo(3));
    }
}
