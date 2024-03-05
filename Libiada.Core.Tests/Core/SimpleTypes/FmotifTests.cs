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
    private readonly ValueNote note = new ValueNote(new Pitch(1, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None);

    /// <summary>
    /// The a note.
    /// </summary>
    private readonly ValueNote aNote = new ValueNote(new Pitch(1, NoteSymbol.B, Accidental.Bekar), new Duration(1, 2, false), false, 0);

    /// <summary>
    /// The fmotif test.
    /// </summary>
    [Test]
    public void FmotifTest()
    {
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var notelist = new List<ValueNote> { (ValueNote)note.Clone(), (ValueNote)aNote.Clone(), (ValueNote)note.Clone() };

        fmotif.NoteList.Add((ValueNote)note.Clone());
        fmotif.NoteList.Add((ValueNote)aNote.Clone());
        fmotif.NoteList.Add((ValueNote)note.Clone());

        Assert.AreEqual(notelist[0], fmotif.NoteList[0]);
        Assert.AreEqual(notelist[1], fmotif.NoteList[1]);
        Assert.AreEqual(notelist[2], fmotif.NoteList[2]);
        Assert.AreEqual(FmotifType.CompleteMinimalMeasure, fmotif.Type);
        fmotif.Type = FmotifType.CompleteMinimalMetrorhythmicGroup;
        Assert.AreEqual(FmotifType.CompleteMinimalMetrorhythmicGroup, fmotif.Type);
        Assert.AreEqual(0, fmotif.Id);
        fmotif.Id = 1;
        Assert.AreEqual(1, fmotif.Id);

        // проверка на идентичность нот проверяется только высота звучания и реальная длительность, не сравнивая приоритеты, лиги, триоли
    }

    /// <summary>
    /// The fmotif without pauses first test.
    /// </summary>
    [Test]
    public void FmotifWithoutPausesFirstTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), только без пауз.
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[0].Pitches[0].Step, NoteSymbol.A);
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[1].Pitches[0].Step, NoteSymbol.A);
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[2].Pitches[0].Step, NoteSymbol.A);
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList.Count, 3);
    }

    /// <summary>
    /// The fmotif without pauses second test.
    /// </summary>
    [Test]
    public void FmotifWithoutPausesSecondTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), только без пауз.
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None));
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[0].Pitches[0].Step, NoteSymbol.A);
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[1].Pitches[0].Step, NoteSymbol.A);
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList[2].Pitches[0].Step, NoteSymbol.A);
        Assert.AreEqual(fmotif.PauseTreatmentProcedure(PauseTreatment.Ignore).NoteList.Count, 3);
    }

    /// <summary>
    /// The fmotif tie gathered first test.
    /// </summary>
    [Test]
    public void FmotifTieGatheredFirstTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        Assert.AreEqual(4, fmotif.TieGathered().NoteList.Count);
        Assert.AreEqual(1, fmotif.TieGathered().NoteList[1].Duration.Numerator);
        Assert.AreEqual(2, fmotif.TieGathered().NoteList[1].Duration.Denominator);
        Assert.AreEqual(2, fmotif.TieGathered().NoteList[1].Priority);
    }

    /// <summary>
    /// The fmotif tie gathered second test.
    /// </summary>
    [Test]
    public void FmotifTieGatheredSecondTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        Assert.AreEqual(4, fmotif.TieGathered().NoteList.Count);
        Assert.AreEqual(3, fmotif.TieGathered().NoteList[1].Duration.Numerator);
        Assert.AreEqual(8, fmotif.TieGathered().NoteList[1].Duration.Denominator);
        Assert.AreEqual(2, fmotif.TieGathered().NoteList[1].Priority);
    }

    /// <summary>
    /// The fmotif tie gathered third test.
    /// </summary>
    [Test]
    public void FmotifTieGatheredThirdTest()
    {
        // проверка работы метода, который возвращает копию объекта (Fmotif), c собранными залигованными нотами.
        // старт лиги, потом опять старт лиги
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
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
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
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
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
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
        var fmotif3 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
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
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif3 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);

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

        Assert.IsTrue(fmotif1.Equals(fmotif2));
        Assert.IsTrue(fmotif1.Equals(fmotif3));
        Assert.IsTrue(fmotif2.Equals(fmotif3));
        Assert.IsTrue(fmotif3.Equals(fmotif2));
        Assert.IsTrue(fmotif3.Equals(fmotif1));
        Assert.IsTrue(fmotif2.Equals(fmotif1));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));
        Assert.IsTrue(!fmotif1.Equals(fmotif2));
    }

    /// <summary>
    /// The fmotif equals second test.
    /// </summary>
    [Test]
    public void FmotifEqualsSecondTest()
    {
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(1, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        Assert.IsTrue(fmotif.Equals(fmotif));
    }

    /// <summary>
    /// The fmotif equals third test.
    /// </summary>
    [Test]
    public void FmotifEqualsThirdTest()
    {
        var fmotif = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 2, false), false, Tie.None, 0));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 2));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 4));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 1));
        fmotif.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None, 3));
        fmotif.NoteList.Add(new ValueNote(new Pitch(2, NoteSymbol.A, Accidental.Bekar), new Duration(1, 2, false), false, Tie.None, 4));

        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Start, 0));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 1));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, 2, 3, false), false, Tie.Continue, 3));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Bekar), new Duration(1, 8, false), false, Tie.End, 2));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, Accidental.DoubleFlat), new Duration(1, 2, false), false, Tie.None, 5));

        Assert.IsTrue(fmotif.FmEquals(fmotif1, PauseTreatment.Ignore, true));
    }
}
