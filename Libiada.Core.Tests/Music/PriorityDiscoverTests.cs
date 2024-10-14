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
    private readonly ValueNote note = new(new Pitch(1, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None);

    /// <summary>
    /// The a note.
    /// </summary>
    private readonly ValueNote aNote = new(new Pitch(1, NoteSymbol.B, 0), new Duration(1, 2, false), false, 0);

    /// <summary>
    /// The b note.
    /// </summary>
    private readonly ValueNote bNote = new(new Duration(1, 4, false), false, 0);

    /// <summary>
    /// The с note.
    /// </summary>
    private readonly ValueNote сNote = new(new Pitch(1, NoteSymbol.A, 0), new Duration(1, 4, 2, 3, false), true, 0);

    /// <summary>
    /// The cc note.
    /// </summary>
    private readonly ValueNote ccNote = new(new Pitch(1, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false), true, 0);

    /// <summary>
    /// The сcc note.
    /// </summary>
    private readonly ValueNote сccNote = new(new Pitch(1, NoteSymbol.A, 0), new Duration(1, 8, 4, 7, false), true, 0);

    /// <summary>
    /// The d note.
    /// </summary>
    private readonly ValueNote dNote = new(new Pitch(1, NoteSymbol.B, 0), new Duration(1, 16, false), false, 0);

    /// <summary>
    /// The attributes.
    /// </summary>
    private readonly MeasureAttributes attributes = new(new Size(4, 4), new Key(0, "minor"));

    /// <summary>
    /// The attributes 1.
    /// </summary>
    private readonly MeasureAttributes attributes1 = new(new Size(3, 4), new Key(0, "minor"));

    /// <summary>
    /// The attributes 2.
    /// </summary>
    private readonly MeasureAttributes attributes2 = new(new Size(12, 8), new Key(0, "minor"));

    /// <summary>
    /// The attributes 3.
    /// </summary>
    private readonly MeasureAttributes attributes3 = new(new Size(13, 16), new Key(0, "minor"));

    /// <summary>
    /// The priority get set test.
    /// </summary>
    [Test]
    public void PriorityGetSetTest()
    {
        note.Priority = 0;
        aNote.Priority = -1;
        bNote.Priority = 3;

        Assert.That(note.Priority, Is.EqualTo(0));
        Assert.That(bNote.Priority, Is.EqualTo(3));
        Assert.That(aNote.Priority, Is.EqualTo(-1));
    }

    /// <summary>
    /// The priority min duration test.
    /// </summary>
    [Test]
    public void PriorityMinDurationTest()
    {
        PriorityDiscover pd = new();

        List<ValueNote> notes = [note, bNote, dNote, aNote];
        Measure measure = new(notes, attributes);

        // minimal note duration in measure is 1/16 = 0.0625 (dNote)
        Assert.That(pd.MinDuration(measure), Is.EqualTo(0.0625).Within(0.00001d));

        measure.NoteList.Clear();
        Assert.Throws<ArgumentException>(() => pd.MinDuration(measure));
    }

    /// <summary>
    /// The priority mask calculation first test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationFirstTest()
    {
        PriorityDiscover pd = new();

        List<ValueNote> notes = [note, bNote, dNote, aNote];
        Measure measure = new(notes, attributes);
        Measure priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/32
        Assert.That(priorityMask.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(priorityMask.NoteList[1].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[2].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[3].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[4].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[5].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[6].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[7].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[8].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[9].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[10].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[11].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[12].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[13].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[14].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[15].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[16].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[17].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[18].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[19].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[20].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[21].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[22].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[23].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[24].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[25].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[26].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[27].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[28].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[29].Priority, Is.EqualTo(5));
        Assert.That(priorityMask.NoteList[30].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[31].Priority, Is.EqualTo(5));

        // проверка длительностей
        foreach (ValueNote lnote in priorityMask.NoteList)
        {
            Assert.That(lnote.Duration.Numerator, Is.EqualTo(1));
            Assert.That(lnote.Duration.Denominator, Is.EqualTo(32));
        }
    }

    /// <summary>
    /// The priority mask calculation second test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationSecondTest()
    {
        PriorityDiscover pd = new();

        List<ValueNote> notes = [note, bNote, dNote, aNote];
        Measure measure = new(notes, attributes2);
        Measure priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/32
        // размер 12/8, поэтому будет считаться приоритет для 48/32 нот
        Assert.That(priorityMask.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(priorityMask.NoteList[1].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[2].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[3].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[4].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[5].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[6].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[7].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[8].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[9].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[10].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[11].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[12].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[13].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[14].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[15].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[16].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[17].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[18].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[19].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[20].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[21].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[22].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[23].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[24].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[25].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[26].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[27].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[28].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[29].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[30].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[31].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[32].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[33].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[34].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[35].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[36].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[37].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[38].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[39].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[40].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[41].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[42].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[43].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[44].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[45].Priority, Is.EqualTo(4));
        Assert.That(priorityMask.NoteList[46].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[47].Priority, Is.EqualTo(4));

        // проверка длительностей
        foreach (ValueNote lnote in priorityMask.NoteList)
        {
            Assert.That(lnote.Duration.Numerator, Is.EqualTo(1));
            Assert.That(lnote.Duration.Denominator, Is.EqualTo(32));
        }
    }

    /// <summary>
    /// The priority mask calculation third test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationThirdTest()
    {
        PriorityDiscover pd = new();

        List<ValueNote> notes = [note, bNote, dNote, aNote];
        Measure measure = new(notes, attributes3);
        Measure priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/16 то маска приоритетов должна разложиться (посчитаться) до 1/32
        // размер 13/16, поэтому будет считаться приоритет для 26/32 нот
        Assert.That(priorityMask.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(priorityMask.NoteList[1].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[2].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[3].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[4].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[5].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[6].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[7].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[8].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[9].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[10].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[11].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[12].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[13].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[14].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[15].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[16].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[17].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[18].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[19].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[20].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[21].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[22].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[23].Priority, Is.EqualTo(3));
        Assert.That(priorityMask.NoteList[24].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[25].Priority, Is.EqualTo(3));

        // проверка длительностей
        foreach (ValueNote lnote in priorityMask.NoteList)
        {
            Assert.That(lnote.Duration.Numerator, Is.EqualTo(1));
            Assert.That(lnote.Duration.Denominator, Is.EqualTo(32));
        }
    }

    /// <summary>
    /// The priority mask calculation fourth test.
    /// </summary>
    [Test]
    public void PriorityMaskCalculationFourthTest()
    {
        PriorityDiscover pd = new();

        List<ValueNote> notes = [note, aNote];
        Measure measure = new(notes, attributes1);
        Measure priorityMask = pd.CalculatePriorityMask(measure);

        // так как минимальная длительность ноты в такте 1/4 то маска приоритетов должна разложиться (посчитаться) до 1/4
        // размер 3/4, поэтому будет считаться приоритет для 3/4 нот
        Assert.That(priorityMask.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(priorityMask.NoteList[1].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[2].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[3].Priority, Is.EqualTo(2));
        Assert.That(priorityMask.NoteList[4].Priority, Is.EqualTo(1));
        Assert.That(priorityMask.NoteList[5].Priority, Is.EqualTo(2));

        // проверка длительностей
        foreach (ValueNote lnote in priorityMask.NoteList)
        {
            Assert.That(lnote.Duration.Numerator, Is.EqualTo(1));
            Assert.That(lnote.Duration.Denominator, Is.EqualTo(8));
        }
    }

    /// <summary>
    /// The priority discover test.
    /// </summary>
    [Test]
    public void PriorityDiscoverTest()
    {
        List<ValueNote> notes = [note, bNote, aNote];
        List<ValueNote> notes1 = [note, note, note];
        List<ValueNote> notes2 = [aNote, note, bNote, note, bNote];
        List<ValueNote> notes3 = [note, dNote, note, note];
        List<ValueNote> notes4 = [сNote, сNote, сNote, ccNote, ccNote, ccNote];
        List<ValueNote> notes5 = [сccNote, сccNote, сccNote, сccNote, сccNote, сccNote, сccNote, note, note];

        Measure measure = new(notes, attributes);
        Measure measure1 = new(notes1, attributes1);
        Measure measure2 = new(notes2, attributes2);
        Measure measure3 = new(notes3, attributes3);
        Measure measure4 = new(notes4, attributes1);
        Measure measure5 = new(notes5, attributes);

        PriorityDiscover prioritydiscover = new();

        Assert.That(measure.NoteList[0].Priority, Is.EqualTo(-1));
        Assert.That(measure.NoteList[1].Priority, Is.EqualTo(-1));
        Assert.That(measure.NoteList[2].Priority, Is.EqualTo(-1));

        prioritydiscover.Calculate(measure);
        prioritydiscover.Calculate(measure1);
        prioritydiscover.Calculate(measure2);
        prioritydiscover.Calculate(measure3);
        prioritydiscover.Calculate(measure4);
        prioritydiscover.Calculate(measure5);

        Assert.That(measure.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(measure.NoteList[1].Priority, Is.EqualTo(2));
        Assert.That(measure.NoteList[2].Priority, Is.EqualTo(1));

        Assert.That(measure1.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(measure1.NoteList[1].Priority, Is.EqualTo(1));
        Assert.That(measure1.NoteList[2].Priority, Is.EqualTo(1));

        Assert.That(measure2.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(measure2.NoteList[1].Priority, Is.EqualTo(1));
        Assert.That(measure2.NoteList[2].Priority, Is.EqualTo(1));
        Assert.That(measure2.NoteList[3].Priority, Is.EqualTo(1));
        Assert.That(measure2.NoteList[4].Priority, Is.EqualTo(1));

        Assert.That(measure3.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(measure3.NoteList[1].Priority, Is.EqualTo(1));
        Assert.That(measure3.NoteList[2].Priority, Is.EqualTo(2));
        Assert.That(measure3.NoteList[3].Priority, Is.EqualTo(2));

        Assert.That(measure4.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(measure4.NoteList[1].Priority, Is.EqualTo(1));
        Assert.That(measure4.NoteList[2].Priority, Is.EqualTo(1));
        Assert.That(measure4.NoteList[3].Priority, Is.EqualTo(1));
        Assert.That(measure4.NoteList[4].Priority, Is.EqualTo(2));
        Assert.That(measure4.NoteList[5].Priority, Is.EqualTo(2));

        Assert.That(measure5.NoteList[0].Priority, Is.EqualTo(0));
        Assert.That(measure5.NoteList[1].Priority, Is.EqualTo(3));
        Assert.That(measure5.NoteList[2].Priority, Is.EqualTo(2));
        Assert.That(measure5.NoteList[3].Priority, Is.EqualTo(3));
        Assert.That(measure5.NoteList[4].Priority, Is.EqualTo(3));
        Assert.That(measure5.NoteList[5].Priority, Is.EqualTo(3));
        Assert.That(measure5.NoteList[6].Priority, Is.EqualTo(3));
        Assert.That(measure5.NoteList[7].Priority, Is.EqualTo(1));
        Assert.That(measure5.NoteList[8].Priority, Is.EqualTo(2));

        Assert.That(note.Priority, Is.EqualTo(-1));
        Assert.That(bNote.Priority, Is.EqualTo(-1));
        Assert.That(aNote.Priority, Is.EqualTo(-1));
    }
}
