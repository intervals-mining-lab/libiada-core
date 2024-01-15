namespace Libiada.Core.Tests.Music;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The priority discover tests.
/// </summary>
[TestFixture]
public class PriorityDiscoverTests
{
    /// <summary>
    /// The note.
    /// </summary>
    private readonly ValueNote note = new ValueNote(new Pitch(1, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None);

    /// <summary>
    /// The a note.
    /// </summary>
    private readonly ValueNote aNote = new ValueNote(new Pitch(1, NoteSymbol.B, 0), new Duration(1, 2, false), false, 0);

    /// <summary>
    /// The b note.
    /// </summary>
    private readonly ValueNote bNote = new ValueNote((Pitch)null, new Duration(1, 4, false), false, 0);

    /// <summary>
    /// The с note.
    /// </summary>
    private readonly ValueNote сNote = new ValueNote(new Pitch(1, NoteSymbol.A, 0), new Duration(1, 4, 2, 3, false), true, 0);

    /// <summary>
    /// The cc note.
    /// </summary>
    private readonly ValueNote ccNote = new ValueNote(new Pitch(1, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false), true, 0);

    /// <summary>
    /// The сcc note.
    /// </summary>
    private readonly ValueNote сccNote = new ValueNote(new Pitch(1, NoteSymbol.A, 0), new Duration(1, 8, 4, 7, false), true, 0);

    /// <summary>
    /// The d note.
    /// </summary>
    private readonly ValueNote dNote = new ValueNote(new Pitch(1, NoteSymbol.B, 0), new Duration(1, 16, false), false, 0);

    /// <summary>
    /// The attributes.
    /// </summary>
    private readonly MeasureAttributes attributes = new MeasureAttributes(new Size(4, 4), new Key(0, "minor"));

    /// <summary>
    /// The attributes 1.
    /// </summary>
    private readonly MeasureAttributes attributes1 = new MeasureAttributes(new Size(3, 4), new Key(0, "minor"));

    /// <summary>
    /// The attributes 2.
    /// </summary>
    private readonly MeasureAttributes attributes2 = new MeasureAttributes(new Size(12, 8), new Key(0, "minor"));

    /// <summary>
    /// The attributes 3.
    /// </summary>
    private readonly MeasureAttributes attributes3 = new MeasureAttributes(new Size(13, 16), new Key(0, "minor"));

    /// <summary>
    /// The priority get set test.
    /// </summary>
    [Test]
    public void PriorityGetSetTest()
    {
        note.Priority = 0;
        aNote.Priority = -1;
        bNote.Priority = 3;

        Assert.AreEqual(0, note.Priority);
        Assert.AreEqual(3, bNote.Priority);
        Assert.AreEqual(-1, aNote.Priority);
    }

    /// <summary>
    /// The priority min duration test.
    /// </summary>
    [Test]
    public void PriorityMinDurationTest()
    {
        var pd = new PriorityDiscover();

        var notes = new List<ValueNote> { note, bNote, dNote, aNote };
        var measure = new Measure(notes, attributes);

        // minimal note duration in measure is 1/16 = 0.0625 (dNote)
        Assert.IsTrue(Math.Abs(pd.MinDuration(measure) - 0.0625) < 0.00001);

        measure.NoteList.Clear();
        Assert.Throws<ArgumentException>(() => pd.MinDuration(measure));
    }

    /// <summary>
    /// The priority mask calculation first test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationFirstTest()
    {
        var pd = new PriorityDiscover();

        var notes = new List<ValueNote> { note, bNote, dNote, aNote };
        var measure = new Measure(notes, attributes);
        var priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/32
        Assert.AreEqual(0, priorityMask.NoteList[0].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[1].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[2].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[3].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[4].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[5].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[6].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[7].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[8].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[9].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[10].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[11].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[12].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[13].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[14].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[15].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[16].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[17].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[18].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[19].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[20].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[21].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[22].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[23].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[24].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[25].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[26].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[27].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[28].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[29].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[30].Priority);
        Assert.AreEqual(5, priorityMask.NoteList[31].Priority);

        // проверка длительностей
        foreach (var lnote in priorityMask.NoteList)
        {
            Assert.AreEqual(1, lnote.Duration.Numerator);
            Assert.AreEqual(32, lnote.Duration.Denominator);
        }
    }

    /// <summary>
    /// The priority mask calculation second test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationSecondTest()
    {
        var pd = new PriorityDiscover();

        var notes = new List<ValueNote> { note, bNote, dNote, aNote };
        var measure = new Measure(notes, attributes2);
        var priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/32
        // размер 12/8, поэтому будет считаться приоритет для 48/32 нот
        Assert.AreEqual(0, priorityMask.NoteList[0].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[1].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[2].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[3].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[4].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[5].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[6].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[7].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[8].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[9].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[10].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[11].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[12].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[13].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[14].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[15].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[16].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[17].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[18].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[19].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[20].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[21].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[22].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[23].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[24].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[25].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[26].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[27].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[28].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[29].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[30].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[31].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[32].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[33].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[34].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[35].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[36].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[37].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[38].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[39].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[40].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[41].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[42].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[43].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[44].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[45].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[46].Priority);
        Assert.AreEqual(4, priorityMask.NoteList[47].Priority);

        // проверка длительностей
        foreach (var lnote in priorityMask.NoteList)
        {
            Assert.AreEqual(1, lnote.Duration.Numerator);
            Assert.AreEqual(32, lnote.Duration.Denominator);
        }
    }

    /// <summary>
    /// The priority mask calculation third test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationThirdTest()
    {
        var pd = new PriorityDiscover();

        var notes = new List<ValueNote> { note, bNote, dNote, aNote };
        var measure = new Measure(notes, attributes3);
        var priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/32
        // размер 13/16, поэтому будет считаться приоритет для 26/32 нот
        Assert.AreEqual(0, priorityMask.NoteList[0].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[1].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[2].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[3].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[4].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[5].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[6].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[7].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[8].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[9].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[10].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[11].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[12].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[13].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[14].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[15].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[16].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[17].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[18].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[19].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[20].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[21].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[22].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[23].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[24].Priority);
        Assert.AreEqual(3, priorityMask.NoteList[25].Priority);

        // проверка длительностей
        foreach (var lnote in priorityMask.NoteList)
        {
            Assert.AreEqual(1, lnote.Duration.Numerator);
            Assert.AreEqual(32, lnote.Duration.Denominator);
        }
    }

    /// <summary>
    /// The priority mask calculation fourth test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationFourthTest()
    {
        var pd = new PriorityDiscover();

        var notes = new List<ValueNote> { note, aNote };
        var measure = new Measure(notes, attributes1);
        var priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/4 то маска приоритетов должна разложиться (посчитаться) до 1/4
        // размер 3/4, поэтому будет считаться приоритет для 3/4 нот
        Assert.AreEqual(0, priorityMask.NoteList[0].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[1].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[2].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[3].Priority);
        Assert.AreEqual(1, priorityMask.NoteList[4].Priority);
        Assert.AreEqual(2, priorityMask.NoteList[5].Priority);

        // проверка длительностей
        foreach (var lnote in priorityMask.NoteList)
        {
            Assert.AreEqual(1, lnote.Duration.Numerator);
            Assert.AreEqual(8, lnote.Duration.Denominator);
        }
    }

    /// <summary>
    /// The priority discover test.
    /// </summary>
    [Test]
    public void PriorityDiscoverTest()
    {
        var notes = new List<ValueNote> { note, bNote, aNote };
        var notes1 = new List<ValueNote> { note, note, note };
        var notes2 = new List<ValueNote> { aNote, note, bNote, note, bNote };
        var notes3 = new List<ValueNote> { note, dNote, note, note };
        var notes4 = new List<ValueNote> { сNote, сNote, сNote, ccNote, ccNote, ccNote };
        var notes5 = new List<ValueNote> { сccNote, сccNote, сccNote, сccNote, сccNote, сccNote, сccNote, note, note };

        var measure = new Measure(notes, attributes);
        var measure1 = new Measure(notes1, attributes1);
        var measure2 = new Measure(notes2, attributes2);
        var measure3 = new Measure(notes3, attributes3);
        var measure4 = new Measure(notes4, attributes1);
        var measure5 = new Measure(notes5, attributes);

        var prioritydiscover = new PriorityDiscover();

        Assert.AreEqual(-1, measure.NoteList[0].Priority);
        Assert.AreEqual(-1, measure.NoteList[1].Priority);
        Assert.AreEqual(-1, measure.NoteList[2].Priority);

        prioritydiscover.Calculate(measure);
        prioritydiscover.Calculate(measure1);
        prioritydiscover.Calculate(measure2);
        prioritydiscover.Calculate(measure3);
        prioritydiscover.Calculate(measure4);
        prioritydiscover.Calculate(measure5);

        Assert.AreEqual(0, measure.NoteList[0].Priority);
        Assert.AreEqual(2, measure.NoteList[1].Priority);
        Assert.AreEqual(1, measure.NoteList[2].Priority);

        Assert.AreEqual(0, measure1.NoteList[0].Priority);
        Assert.AreEqual(1, measure1.NoteList[1].Priority);
        Assert.AreEqual(1, measure1.NoteList[2].Priority);

        Assert.AreEqual(0, measure2.NoteList[0].Priority);
        Assert.AreEqual(1, measure2.NoteList[1].Priority);
        Assert.AreEqual(1, measure2.NoteList[2].Priority);
        Assert.AreEqual(1, measure2.NoteList[3].Priority);
        Assert.AreEqual(1, measure2.NoteList[4].Priority);

        Assert.AreEqual(0, measure3.NoteList[0].Priority);
        Assert.AreEqual(1, measure3.NoteList[1].Priority);
        Assert.AreEqual(2, measure3.NoteList[2].Priority);
        Assert.AreEqual(2, measure3.NoteList[3].Priority);

        Assert.AreEqual(0, measure4.NoteList[0].Priority);
        Assert.AreEqual(1, measure4.NoteList[1].Priority);
        Assert.AreEqual(1, measure4.NoteList[2].Priority);
        Assert.AreEqual(1, measure4.NoteList[3].Priority);
        Assert.AreEqual(2, measure4.NoteList[4].Priority);
        Assert.AreEqual(2, measure4.NoteList[5].Priority);

        Assert.AreEqual(0, measure5.NoteList[0].Priority);
        Assert.AreEqual(3, measure5.NoteList[1].Priority);
        Assert.AreEqual(2, measure5.NoteList[2].Priority);
        Assert.AreEqual(3, measure5.NoteList[3].Priority);
        Assert.AreEqual(3, measure5.NoteList[4].Priority);
        Assert.AreEqual(3, measure5.NoteList[5].Priority);
        Assert.AreEqual(3, measure5.NoteList[6].Priority);
        Assert.AreEqual(1, measure5.NoteList[7].Priority);
        Assert.AreEqual(2, measure5.NoteList[8].Priority);

        Assert.AreEqual(-1, note.Priority);
        Assert.AreEqual(-1, bNote.Priority);
        Assert.AreEqual(-1, aNote.Priority);
    }
}
