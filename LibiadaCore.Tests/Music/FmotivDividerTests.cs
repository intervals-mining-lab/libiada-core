namespace LibiadaCore.Tests.Music
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The fmotiv divider tests.
    /// </summary>
    [TestFixture]
    public class FmotivDividerTests
    {
        // ТЕСТЫ ПМТ

        /// <summary>
        /// The fmotiv divider first test.
        /// </summary>
        [Test]
        public void FmotivDividerFirstTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var chain = fmdivider.GetDivision(unitrack, ParamPauseTreatment.Ignore);
            chain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var secondChain = new FmotivChain { Id = 0, Name = "track1" };
            secondChain.FmotivList.Add(fmotiv1);
            secondChain.FmotivList.Add(fmotiv2);

            Assert.IsTrue(secondChain.Equals(chain));
        }

        /// <summary>
        /// The fmotiv divider second test.
        /// </summary>
        [Test]
        public void FmotivDividerSecondTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None, 2),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 512), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The test fmotiv third divider.
        /// </summary>
        [Test]
        public void TestFmotivThirdDivider()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            var notes1 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure>
            {
                new Measure(notes, (MeasureAttributes)attributes.Clone()),
                new Measure(notes1, (MeasureAttributes)attributes.Clone())
            };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.PartialMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMetrorhythmicGroup, 1);
            var fmotiv3 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 3);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The fmotiv divider fourth test.
        /// </summary>
        [Test]
        public void FmotivDividerFourthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 256), false, Tie.Start, 0),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 256), false, Tie.End, 2),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 256), false, Tie.Start));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 256), false, Tie.End));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The fmotiv divider fifth test.
        /// </summary>
        [Test]
        public void FmotivDividerFifthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 360), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 360), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1440), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 360), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 360), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The fmotiv divider sixth test.
        /// </summary>
        [Test]
        public void FmotivDividerSixthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false, 128), false, Tie.None, 3)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.PartialMinimalMeasure, 0);
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);
            var fmotiv3 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 2);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, Accidental.Bekar), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.C, Accidental.Sharp), new Duration(1, 16, false, 128), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.Flat), new Duration(1, 16, false, 128), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.D, Accidental.Bekar), new Duration(1, 16, false, 128), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, Accidental.DoubleSharp), new Duration(1, 16, false, 128), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The fmotiv divider seventh test.
        /// </summary>
        [Test]
        public void FmotivDividerSeventhTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote((Pitch)null, new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The fmotiv divider eighth test.
        /// </summary>
        [Test]
        public void FmotivDividerEighthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None, 0),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None, 2),
                new ValueNote((Pitch)null, new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, (int)ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        /// <summary>
        /// The fmotiv divider pause silence test.
        /// </summary>
        [Test]
        public void FmotivDividerPauseSilenceTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None, 0),
                new ValueNote((Pitch)null, new Duration(1, 8, false, 256), false, Tie.None, 2),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new MeasureAttributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> { new Measure(notes, (MeasureAttributes)attributes.Clone()) };

            // создание моно трека
            var unitrack = new CongenericScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();

            // создание результирующей цепочки фмотивов
            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, ParamPauseTreatment.SilenceNote);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 0);
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote((Pitch)null, new Duration(1, 8, false, 256), false, Tie.None));
            var fmotiv2 = new Fmotiv(FmotivType.CompleteMinimalMeasure, 1);
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain { Id = 0, Name = "track1" };
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmotiv1.FmEquals(fmotiv1, ParamPauseTreatment.SilenceNote, ParamEqualFM.Sequent));
            Assert.IsTrue(fmotiv2.FmEquals(fmotiv2, ParamPauseTreatment.SilenceNote, ParamEqualFM.Sequent));
            Assert.IsTrue(fmchain.FmotivList[0].FmEquals(fmotiv1, ParamPauseTreatment.SilenceNote, ParamEqualFM.Sequent));
            Assert.IsTrue(fmchain.FmotivList[1].FmEquals(fmotiv2, ParamPauseTreatment.SilenceNote, ParamEqualFM.Sequent));
            Assert.IsTrue(fmchain1.Equals(fmchain));
        }
    }
}
