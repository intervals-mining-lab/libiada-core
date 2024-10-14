namespace Libiada.Core.Tests.Music;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The fmotif divider tests.
/// </summary>
[TestFixture]
public class FmotifDividerTests
{
    // ТЕСТЫ ПМТ

    /// <summary>
    /// The fmotif divider first test.
    /// </summary>
    [Test]
    public void FmotifDividerFirstTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None, 1)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain chain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain secondChain = new();
        secondChain.FmotifsList.Add(fmotif1);
        secondChain.FmotifsList.Add(fmotif2);

        Assert.That(secondChain, Is.EqualTo(chain));
    }

    /// <summary>
    /// The fmotif divider second test.
    /// </summary>
    [Test]
    public void FmotifDividerSecondTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 2)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The test fmotif third divider.
    /// </summary>
    [Test]
    public void TestFmotifThirdDivider()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None, 2)
        ];

        List<ValueNote> notes1 =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 1)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures =
        [
            new(notes, (MeasureAttributes)attributes.Clone()),
            new(notes1, (MeasureAttributes)attributes.Clone())
        ];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.PartialMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMetrorhythmicGroup, PauseTreatment.Ignore, 1);
        Fmotif fmotif3 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 3);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);
        fmchain1.FmotifsList.Add(fmotif3);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The fmotif divider fourth test.
    /// </summary>
    [Test]
    public void FmotifDividerFourthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.Start, 0),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.End, 2),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None, 1)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.Start));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.End));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The fmotif divider fifth test.
    /// </summary>
    [Test]
    public void FmotifDividerFifthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 1)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The fmotif divider sixth test.
    /// </summary>
    [Test]
    public void FmotifDividerSixthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.PartialMinimalMeasure, PauseTreatment.Ignore, 0);
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
        Fmotif fmotif3 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 2);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None));

        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);
        fmchain1.FmotifsList.Add(fmotif3);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The fmotif divider seventh test.
    /// </summary>
    [Test]
    public void FmotifDividerSeventhTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Duration(1, 4, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The fmotif divider eighth test.
    /// </summary>
    [Test]
    public void FmotifDividerEighthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2),
            new(new Duration(1, 8, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);

        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }

    /// <summary>
    /// The fmotif divider pause silence test.
    /// </summary>
    [Test]
    public void FmotifDividerPauseSilenceTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        List<ValueNote> notes =
        [
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new(new Duration(1, 8, false), false, Tie.None, 2),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2)
        ];

        // создание атрибутов для такта(ов)
        MeasureAttributes attributes = new(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        List<Measure> measures = [new(notes, (MeasureAttributes)attributes.Clone())];

        // создание моно трека
        CongenericScoreTrack unitrack = new(measures);

        // создание объекта для деления монотрека на фмотивы
        FmotifDivider fmdivider = new();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.SilenceNote);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        Fmotif fmotif1 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Duration(1, 8, false), false, Tie.None));
        Fmotif fmotif2 = new(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        FmotifChain fmchain1 = new();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);

        Assert.That(fmotif1.FmEquals(fmotif1, PauseTreatment.SilenceNote, true));
        Assert.That(fmotif2.FmEquals(fmotif2, PauseTreatment.SilenceNote, true));
        Assert.That(fmchain.FmotifsList[0].FmEquals(fmotif1, PauseTreatment.SilenceNote, true));
        Assert.That(fmchain.FmotifsList[1].FmEquals(fmotif2, PauseTreatment.SilenceNote, true));
        Assert.That(fmchain1, Is.EqualTo(fmchain));
    }
}
