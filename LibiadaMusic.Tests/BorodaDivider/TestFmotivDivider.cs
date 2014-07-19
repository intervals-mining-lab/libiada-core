using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;
using System.Xml;
using MDA.OIP.MusicXml;

namespace MDATest.OIP.BorodaDivider
{
    [TestClass]
    public class TestFmotivDivider
    {
        // Создание атрибутов для такта
        private Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

        //-----------------ТЕСТЫ ПМТ---------------------------------------------------------------------
        [TestMethod]
        public void TestFmotivDivider1() 
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None,1));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack , PauseTreatment.Ignore);
            
            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);

            Assert.IsTrue(fmchain1.Equals(fmchain));

        }

        [TestMethod]
        public void TestFmotivDivider2()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None,2));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None,2));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivDivider3()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.None,2));

            List<ValueNote> notes1 = new List<ValueNote>();
            notes1.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None,0));
            notes1.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None,1));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));
            measures.Add(new Measure(notes1, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack , PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ЧМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТВП");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));            

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(3);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            fmchain1.Add(fmotiv3, 2);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivDivider4()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Start,0));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Stop,2));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None,1));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Start));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 256), false, Tie.Stop));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 4, false, 512), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(1);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivDivider5()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None,1));

            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 360), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 360), false, Tie.None,1));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1440), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, 2, 3, false, 240), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 360), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 360), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivDivider6()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None,3));
            notes.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None,2));
            notes.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None,3));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ЧМТ");
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            Fmotiv fmotiv3 = new Fmotiv("ПМТ");

            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 4, false, 512), false, Tie.None));

            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'C', 1), new Duration(1, 16, false, 128), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'A', -1), new Duration(1, 16, false, 128), false, Tie.None));

            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'D', 0), new Duration(1, 16, false, 128), false, Tie.None));
            fmotiv3.NoteList.Add(new ValueNote(new Pitch(3, 'A', 2), new Duration(1, 16, false, 128), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(3);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);
            fmchain1.Add(fmotiv3, 2);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivDivider7()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            notes.Add(new ValueNote(null, new Duration(1, 4, false, 512), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None,2));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 4, false, 512), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(1);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);

            Assert.IsTrue(fmchain1.Equals(fmchain));

        }

        [TestMethod]
        public void TestFmotivDivider8()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();
            
            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None,0));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None,2));
            notes.Add(new ValueNote(null, new Duration(1, 8, false, 256), false, Tie.None,1));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None,2));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.Ignore);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(1);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);

            Assert.IsTrue(fmchain1.Equals(fmchain));
        }
        [TestMethod]
        public void TestFmotivDivider9PauseSilence()
        {
            // создание и заполнения списка(ов) нот для такта(ов) монотрека
            List<ValueNote> notes = new List<ValueNote>();

            notes.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None, 0));
            notes.Add(new ValueNote(null, new Duration(1, 8, false, 256), false, Tie.None, 2));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 1));
            notes.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None, 2));

            // создание атрибутов для такта(ов)
            Attributes attributes = new Attributes(new Size(2, 4, 1024), new Key(0, "major"));

            // создание и заполнение такта(ов) списками нот и атрибутами
            List<Measure> measures = new List<Measure>();
            measures.Add(new Measure(notes, (Attributes)attributes.Clone()));

            // создание моно трека
            UniformScoreTrack unitrack = new UniformScoreTrack("track1", measures);

            // создание объекта для деления монотрека на фмотивы
            FmotivDivider fmdivider = new FmotivDivider();
            // создание результирующей цепочки фмотивов
            FmotivChain fmchain;

            // вычисление, опрделение, разбиение на  ф-мотивы данного монотрека
            fmchain = fmdivider.GetDivision(unitrack, PauseTreatment.SilenceNote);

            // создание аналогов ф-мотивов, которые должны получиться, после разбиения
            // процедура определения одинаковых на данном этапе не производится
            Fmotiv fmotiv1 = new Fmotiv("ПМТ");
            fmotiv1.NoteList.Add(new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv1.NoteList.Add(new ValueNote(null, new Duration(1, 8, false, 256), false, Tie.None));
            Fmotiv fmotiv2 = new Fmotiv("ПМТ");
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));
            fmotiv2.NoteList.Add(new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 256), false, Tie.None));

            // записываем ф-мотивы в цепь ф-мотивов, которая будет сравниваться с получившейся
            FmotivChain fmchain1 = new FmotivChain(2);
            fmchain1.Name = "track1";
            fmchain1.Add(fmotiv1, 0);
            fmchain1.Add(fmotiv2, 1);

            Assert.IsTrue(fmotiv1.Equals(fmotiv1,PauseTreatment.SilenceNote,FMSequentEquality.Sequent));
            Assert.IsTrue(fmotiv2.Equals(fmotiv2, PauseTreatment.SilenceNote, FMSequentEquality.Sequent));
            Assert.IsTrue(((Fmotiv)fmchain[0]).Equals(fmotiv1, PauseTreatment.SilenceNote, FMSequentEquality.Sequent));
            Assert.IsTrue(((Fmotiv)fmchain[1]).Equals(fmotiv2, PauseTreatment.SilenceNote, FMSequentEquality.Sequent));
            Assert.IsTrue(fmchain1.Equals(fmchain));
        }

        [TestMethod]
        public void TestFmotivDivider10Consistence()
        {
            XmlDocument xmldocument = new XmlDocument();
            MusicXmlReader xmlreader = new MusicXmlReader("../../../MDATest/etalon_test/1_no_rep_the_last_summer_rose_GP.xml");
            MusicXmlParser Parser = new MusicXmlParser();
            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

            MDA.OIP.BorodaDivider.BorodaDivider bd = new MDA.OIP.BorodaDivider.BorodaDivider();

            List<FmotivChain> Listfmotivchains = bd.Divide(Parser.ScoreModel, PauseTreatment.NoteTrace,
                                                           FMSequentEquality.Sequent);

            List<string> linescur = new List<string>(0);

            foreach (FmotivChain fmchain in Listfmotivchains)
            {
                linescur.Add("Fmotiv Chain № 0 Name = " + fmchain.Name);
                linescur.Add("");
                linescur.Add("------------------------");

                for (int j = 0; j < fmchain.Length; j++)
                {
                    linescur.Add("Fmotiv № " + (fmchain.Building[j]-1).ToString() + " | type " + ((Fmotiv)fmchain[j]).Type);
                    linescur.Add("");
                    foreach (ValueNote note in ((Fmotiv)fmchain[j]).NoteList)
                    {
                        // TODO : добавить вывод триоли и лиги
                        if (note.Pitch != null)
                        {
                            // если есть лига, то определяем ее тип по номеру
                            string tietype = "";
                            switch (note.Tie)
                            {
                                case 0:
                                    tietype = " TieStarts";
                                    break;
                                case 1:
                                    tietype = " TieStops";
                                    break;
                                case 2:
                                    tietype = " TieContinues";
                                    break;
                                default:
                                    break;
                            }
                            linescur.Add("Note: duration = " + note.Duration.Numerator.ToString() + "/" +
                                         note.Duration.Denominator.ToString() +
                                         " step = " + note.Pitch.Step.ToString() + " priority = " +
                                         note.Priority.ToString() + tietype);
                        }
                        else
                        {
                            linescur.Add("Pause: duration = " + note.Duration.Numerator.ToString() + "/" +
                                         note.Duration.Denominator.ToString() +
                                         " priority = " + note.Priority.ToString());
                        }

                    }
                    linescur.Add("------------------------");
                }
            }

            string[] lines;
            lines =
                System.IO.File.ReadAllLines(
                    "../../../MDATest/etalon_test/1_no_rep_the_last_summer_rose_GP.xml_Consistence.txt");
            List<string> linesorig = new List<string>(lines);
            int min = (linesorig.Count > linescur.Count ? linescur.Count : linesorig.Count);
            for (int i = 0; i < min; i++ )
                Assert.AreEqual(linesorig[i], linescur[i]);

        }
    }
}
