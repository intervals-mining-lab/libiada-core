using System.Collections.Generic;
using LibiadaMusic.BorodaDivider;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTests.BorodaDivider
{
    [TestClass]
    public class FmotivDividerTests
    {
        //ТЕСТЫ ПМТ
        [TestMethod]
        public void FmotivDividerFirstTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var chain = fmdivider.GetDivision(unitrack, ParamPauseTreatment.Ignore);
            chain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var secondChain = new FmotivChain {Id = 0, Name = "track1"};
            secondChain.FmotivList.Add(fmotiv1);
            secondChain.FmotivList.Add(fmotiv2);

            Assert.IsTrue(secondChain.Equals(chain));

        }

        [TestMethod]
        public void FmotivDividerSecondTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivThirdDivider()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            var notes1 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure>
            {
                new Measure(notes, (Attributes) attributes.Clone()),
                new Measure(notes1, (Attributes) attributes.Clone())
            };

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ЧМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТВП", 1);
            var fmotiv3 = new Fmotiv("ПМТ", 3);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void FmotivDividerFourthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Start, 0),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Stop, 2),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Start));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Stop));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void FmotivDividerFivthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 360), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 360), false, Tie.None, 1)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1440), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes) attributes.Clone()));

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 360), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 360), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void FmotivDividerSixthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None, 3),
                new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None, 3)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            var fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ЧМТ", 0);
            var fmotiv2 = new Fmotiv("ПМТ", 1);
            var fmotiv3 = new Fmotiv("ПМТ", 2);

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);
            fmchain1.FmotivList.Add(fmotiv3);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void FmotivDividerSeventhTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote((Pitch) null, new Duration(1, 4, false, 512), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            fmotiv1.NoteList.Add(new ValueNote((Pitch) null, new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);

            Assert.IsTrue(fmchain1.Equals(fmchain));

        }

        [TestMethod]
        public void FmotivDividerEighthTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None, 0),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 2),
                new ValueNote((Pitch) null, new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, (int) ParamPauseTreatment.Ignore);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote((Pitch) null, new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void FmotivDividerPauseSilenceTest()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            var notes = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None, 0),
                new ValueNote((Pitch) null, new Duration(1, 8, false, 256), false, Tie.None, 2),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 1),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 2)
            };

            // создание атрибутов для такта(ов)
            var attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            var measures = new List<Measure> {new Measure(notes, (Attributes) attributes.Clone())};

            // создание моно трека
            var unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            var fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            FmotivChain fmchain = fmdivider.GetDivision(unitrack, ParamPauseTreatment.SilenceNote);
            fmchain.Id = 0;

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            var fmotiv1 = new Fmotiv("ПМТ", 0);
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote((Pitch) null, new Duration(1, 8, false, 256), false, Tie.None));
            var fmotiv2 = new Fmotiv("ПМТ", 1);
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            var fmchain1 = new FmotivChain {Id = 0, Name = "track1"};
            fmchain1.FmotivList.Add(fmotiv1);
            fmchain1.FmotivList.Add(fmotiv2);

            Assert.IsTrue(fmotiv1.FmEquals(fmotiv1, ParamPauseTreatment.SilenceNote, (int) ParamEqualFM.Sequent));
            Assert.IsTrue(fmotiv2.FmEquals(fmotiv2, ParamPauseTreatment.SilenceNote, (int) ParamEqualFM.Sequent));
            Assert.IsTrue(fmchain.FmotivList[0].FmEquals(fmotiv1, ParamPauseTreatment.SilenceNote,
                (int) ParamEqualFM.Sequent));
            Assert.IsTrue(fmchain.FmotivList[1].FmEquals(fmotiv2, ParamPauseTreatment.SilenceNote,
                (int) ParamEqualFM.Sequent));
            Assert.IsTrue(fmchain1.Equals(fmchain));
        }
    }
}