namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The fmotif tests.
/// </summary>
[TestFixture]
public class FmotifTests
{
    /// <summary>
    /// The note.
    /// </summary>
    private readonly ValueNote note = new(new Pitch(1, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None);

    /// <summary>
    /// The a note.
    /// </summary>
    private readonly ValueNote aNote = new(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 2, false), false, 0);

    /// <summary>
    /// The fmotif test.
    /// </summary>
    [Test]
    public void FmotifTest()
    {
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        List<ValueNote> notelist = [(ValueNote)note.Clone(), (ValueNote)aNote.Clone(), (ValueNote)note.Clone()];

        fmotif.NoteList.Add((ValueNote)note.Clone());
        fmotif.NoteList.Add((ValueNote)aNote.Clone());
        fmotif.NoteList.Add((ValueNote)note.Clone());

        Assert.That(fmotif.NoteList[0], Is.EqualTo(notelist[0]));
        Assert.That(fmotif.NoteList[1], Is.EqualTo(notelist[1]));
        Assert.That(fmotif.NoteList[2], Is.EqualTo(notelist[2]));
        Assert.That(fmotif.Type, Is.EqualTo(FmotifType.CompleteMinimalMeasure));
        fmotif.Type = FmotifType.CompleteMinimalMetrorhythmicGroup;
        Assert.That(fmotif.Type, Is.EqualTo(FmotifType.CompleteMinimalMetrorhythmicGroup));
        Assert.That(fmotif.Id, Is.EqualTo(0));
        fmotif.Id = 1;
        Assert.That(fmotif.Id, Is.EqualTo(1));

        // проверка на идентичность нот проверяется только высота звучания и реальная длительность, не сравнивая приоритеты, лиги, триоли
    }

    /// <summary>
    /// The fmotif without pauses first test.
    /// </summary>
    [Test]
    public void FmotifWithoutPausesFirstTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), только без пауз.
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        Assert.Multiple(() =>
        {
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[0].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[1].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[2].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList, Has.Count.EqualTo(3));
        });
    }

    /// <summary>
    /// The fmotif without pauses second test.
    /// </summary>
    [Test]
    public void FmotifWithoutPausesSecondTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), только без пауз.
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        Assert.Multiple(() =>
        {
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[0].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[1].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[2].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
            Assert.That(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList, Has.Count.EqualTo(3));
        });
    }

    /// <summary>
    /// The fmotif tie gathered first test.
    /// </summary>
    [Test]
    public void FmotifTieGatheredFirstTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        
        Assert.Multiple(() =>
        {
            Assert.That(fmotif.TieGathered().NoteList, Has.Count.EqualTo(4));
            Assert.That(fmotif.TieGathered().NoteList[1].Duration.Numerator, Is.EqualTo(1));
            Assert.That(fmotif.TieGathered().NoteList[1].Duration.Denominator, Is.EqualTo(2));
            Assert.That(fmotif.TieGathered().NoteList[1].Priority, Is.EqualTo(2));
        });
    }

    /// <summary>
    /// The fmotif tie gathered second test.
    /// </summary>
    [Test]
    public void FmotifTieGatheredSecondTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));
        Assert.Multiple(() =>
        {
            Assert.That(fmotif.TieGathered().NoteList, Has.Count.EqualTo(4));
            Assert.That(fmotif.TieGathered().NoteList[1].Duration.Numerator, Is.EqualTo(3));
            Assert.That(fmotif.TieGathered().NoteList[1].Duration.Denominator, Is.EqualTo(8));
            Assert.That(fmotif.TieGathered().NoteList[1].Priority, Is.EqualTo(2));
        });
    }

    /// <summary>
    /// The fmotif tie gathered third test.
    /// </summary>
    [Test]
    public void FmotifTieGatheredThirdTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        // старт лиги, потом опять старт лиги
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Start, 2));
        try
        {
            fmotif.TieGathered();
            Assert.Fail();
        }
        catch (Exception e)
        {
            if (e.Message != "LibiadaMusic: Tie note start after existing start note!")
            {
                Assert.Fail();
            }
        }

        // после старта идет обычная нота без лиги
        fmotif.NoteList.Clear();
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.Start, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 0));
        try
        {
            fmotif.TieGathered();
            Assert.Fail();
        }
        catch (Exception e)
        {
            if (e.Message != "LibiadaMusic: Tie started but (stop)/(startstop) note NOT following!")
            {
                Assert.Fail();
            }
        }

        // лига без старта
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 4));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 3));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        try
        {
            fmotif1.TieGathered();
            Assert.Fail();
        }
        catch (Exception e)
        {
            if (e.Message != "LibiadaMusic: Tie note (stopes and starts)/(stops), without previous note start!")
            {
                Assert.Fail();
            }
        }

        // в знаке лиги не {-1,0,1,2}
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, (Tie)9, 1));
        try
        {
            fmotif2.TieGathered();
            Assert.Fail();
        }
        catch (Exception e)
        {
            if (e.Message != "LibiadaMusic: Tie is not valid!")
            {
                Assert.Fail();
            }
        }

        // в знаке лиги не {-1,0,1,2}
        Fmotif fmotif3 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Start, 1));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        try
        {
            fmotif3.TieGathered();
            Assert.Fail();
        }
        catch (Exception e)
        {
            if (e.Message != "LibiadaMusic: Pitches of tie notes not equal!")
            {
                Assert.Fail();
            }
        }
    }

    /// <summary>
    /// The fmotif equals first test.
    /// </summary>
    [Test]
    public void FmotifEqualsFirstTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif3 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);

        fmotif1.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Start, 2));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 4));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 3));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif1.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        fmotif2.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 0));
        fmotif2.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 0));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 1));
        fmotif2.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        fmotif3.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 0));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 1));
        fmotif3.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 2, false), false, Tie.None, 4));

        Assert.That(fmotif1, Is.EqualTo(fmotif2));
        Assert.That(fmotif1, Is.EqualTo(fmotif3));
        Assert.That(fmotif2, Is.EqualTo(fmotif3));
        Assert.That(fmotif3, Is.EqualTo(fmotif2));
        Assert.That(fmotif3, Is.EqualTo(fmotif1));
        Assert.That(fmotif2, Is.EqualTo(fmotif1));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));
        Assert.That(fmotif1, Is.Not.EqualTo(fmotif2));
    }

    /// <summary>
    /// The fmotif equals second test.
    /// </summary>
    [Test]
    public void FmotifEqualsSecondTest()
    {
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        Assert.That(fmotif, Is.EqualTo(fmotif));
    }

    /// <summary>
    /// The fmotif equals third test.
    /// </summary>
    [Test]
    public void FmotifEqualsThirdTest()
    {
        Fmotif fmotif = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 0));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 1));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 2));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, Accidental.DoubleFlat), new Duration(1, 2, false), false, Tie.None, 5));

        Assert.That(fmotif.FmEquals(fmotif1, PauseTreatment.Ignore, true), Is.True);
    }
}
