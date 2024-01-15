namespace Libiada.Core.Tests.Music;

using System.Collections.Generic;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

using NUnit.Framework;

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
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None, 1)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        var chain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var secondChain = new FmotifChain();
        secondChain.FmotifsList.Add(fmotif1);
        secondChain.FmotifsList.Add(fmotif2);

        Assert.IsTrue(secondChain.Equals(chain));
    }

    /// <summary>
    /// The fmotif divider second test.
    /// </summary>
    [Test]
    public void FmotifDividerSecondTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 2),
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 2)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The test fmotif third divider.
    /// </summary>
    [Test]
    public void TestFmotifThirdDivider()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None, 2)
        };

        var notes1 = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None, 1)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure>
        {
            new Measure(notes, (MeasureAttributes)attributes.Clone()),
            new Measure(notes1, (MeasureAttributes)attributes.Clone())
        };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        var fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.PartialMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMetrorhythmicGroup, PauseTreatment.Ignore, 1);
        var fmotif3 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 3);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);
        fmchain1.FmotifsList.Add(fmotif3);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The fmotif divider fourth test.
    /// </summary>
    [Test]
    public void FmotifDividerFourthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.Start, 0),
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.End, 2),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None, 1)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        var fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.Start));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.End));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The fmotif divider fifth test.
    /// </summary>
    [Test]
    public void FmotifDividerFifthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 1)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        var fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The fmotif divider sixth test.
    /// </summary>
    [Test]
    public void FmotifDividerSixthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None, 3),
            new ValueNote(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None, 2),
            new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None, 3)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        var fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.PartialMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
        var fmotif3 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 2);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false), false, Tie.None));

        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false), false, Tie.None));
        fmotif3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);
        fmchain1.FmotifsList.Add(fmotif3);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The fmotif divider seventh test.
    /// </summary>
    [Test]
    public void FmotifDividerSeventhTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote((Pitch)null, new Duration(1, 4, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The fmotif divider eighth test.
    /// </summary>
    [Test]
    public void FmotifDividerEighthTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2),
            new ValueNote((Pitch)null, new Duration(1, 8, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);

        Assert.IsTrue(fmchain1.Equals(fmchain));
    }

    /// <summary>
    /// The fmotif divider pause silence test.
    /// </summary>
    [Test]
    public void FmotifDividerPauseSilenceTest()
    {
        // создание и заполнения списка(ов) нот для такта(ов) монотрека
        var notes = new List<ValueNote>
        {
            new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None, 0),
            new ValueNote((Pitch)null, new Duration(1, 8, false), false, Tie.None, 2),
            new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 1),
            new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None, 2)
        };

        // создание атрибутов для такта(ов)
        var attributes = new MeasureAttributes(new Size(2, 4), new Key(0, "major"));

        // создание и заполнение такта(ов) списками нот и атрибутами
        var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

        // создание моно трека
        var unitrack = new CongenericScoreTrack(measures);

        // создание объекта для деления монотрека на фмотивы
        var fmdivider = new FmotifDivider();

        // создание результирующей цепочки фмотивов
        // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
        FmotifChain fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.SilenceNote);

        // создание аналогов ф-мотивов, которые должны получиться, после разбиения
        // процедура определения одинаковых на данном этапе не производится
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 8, false), false, Tie.None));
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None));

        // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
        var fmchain1 = new FmotifChain();
        fmchain1.FmotifsList.Add(fmotif1);
        fmchain1.FmotifsList.Add(fmotif2);

        Assert.IsTrue(fmotif1.FmEquals(fmotif1, PauseTreatment.SilenceNote, true));
        Assert.IsTrue(fmotif2.FmEquals(fmotif2, PauseTreatment.SilenceNote, true));
        Assert.IsTrue(fmchain.FmotifsList[0].FmEquals(fmotif1, PauseTreatment.SilenceNote, true));
        Assert.IsTrue(fmchain.FmotifsList[1].FmEquals(fmotif2, PauseTreatment.SilenceNote, true));
        Assert.IsTrue(fmchain1.Equals(fmchain));
    }
}
