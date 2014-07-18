using System.Collections.Generic;
using LibiadaMusic.MusicXml;
using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.MusicXml
{
    [TestClass]
    public class MusicXmlParserTests
    {
        [TestMethod]
        public void XmlParserTest()
        {
            var xmlreader = new MusicXmlReader("../../LibiadaMusicexample7Liga.xml");
            var Parser = new MusicXmlParser();

            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);


            // Создание атрибутов для такта
            var attributes1 = new Attributes(new Size(7, 8, 1024), new Key(0,"major"));
            // Создание списков нот для каждого из 4 тактов
            var notes1 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 2, false, 2048), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, 'F', 0), new Duration(1, 8, false, 512), false, Tie.Start)
            };
            var notes2 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'F', 0), new Duration(1, 8, false, 512), false, Tie.Stop),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, 'G', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, 'G', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None)
            };
            var notes3 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'G', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'B', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'D', 0), new Duration(1, 8, true, 768), false, Tie.None),
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 8, true, 768), false, Tie.None),
                new ValueNote((Pitch) null, new Duration(1, 8, false, 512), false, Tie.None)
            };
            var notes4 = new List<ValueNote>
            {
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(2, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'D', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(2, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'G', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None)
            };
            //создание списка тактов для монофонического трека p0
            var measures1 = new List<Measure>
            {
                new Measure(notes1, (Attributes) attributes1.Clone()),
                new Measure(notes2, (Attributes) attributes1.Clone()),
                new Measure(notes3, (Attributes) attributes1.Clone()),
                new Measure(notes4, (Attributes) attributes1.Clone())
            };
            //создание списка монофонических треков для полного музыкального трека
            var utracks = new List<UniformScoreTrack> {new UniformScoreTrack("p0", measures1)};
            //создание полной модели музыкального трека/текста, с присвоением имени файла
            var Scoremodel = new ScoreTrack("LibiadaMusicexample7Liga",utracks);

            Assert.AreEqual(xmlreader.FileName , Parser.ScoreModel.Name);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].MeasureList[0].Attributes, Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].Attributes);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].MeasureList[0].NoteList[0], Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].NoteList[0]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].MeasureList[0], Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].MeasureList[1], Parser.ScoreModel.UniformScoreTracks[0].MeasureList[1]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].MeasureList[2], Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].MeasureList[3], Parser.ScoreModel.UniformScoreTracks[0].MeasureList[3]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0], Parser.ScoreModel.UniformScoreTracks[0]);
            Assert.AreEqual(Scoremodel, Parser.ScoreModel);
        }

        [TestMethod]
        public void PolyXmlParserTest()
        {
            var xmlreader = new MusicXmlReader("../../polytest.xml");
            var Parser = new MusicXmlParser();

            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

            Assert.AreEqual(xmlreader.FileName, Parser.ScoreModel.Name);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks.Count, 1);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList.Count, 3);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].NoteList.Count, 5);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[1].NoteList.Count, 6);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2].NoteList.Count, 4);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].NoteList[0].Pitch.Count, 2);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2].NoteList[0].Pitch.Count, 3);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].NoteList[0].Duration.Denominator, 4);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].NoteList[0].Pitch[0].Step.ToString(), "A");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[0].NoteList[0].Pitch[1].Step.ToString(), "C");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2].NoteList[0].Duration.Denominator, 8);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2].NoteList[0].Pitch[0].Step.ToString(), "G");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2].NoteList[0].Pitch[1].Step.ToString(), "G");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].MeasureList[2].NoteList[0].Pitch[2].Step.ToString(), "C");
        }

        [TestMethod]
        public void XmlParserFileNameTest()
        {
        }

        [TestMethod]
        public void XmlParserScoretrackTest()
        {
        }

        [TestMethod]
        public void XmlParserUniformScoretrackTest()
        {
        }

        [TestMethod]
        public void XmlParserMeasureTest()
        {
        }

        [TestMethod]
        public void XmlParserNoteTest()
        {
        }

        [TestMethod]
        public void XmlParserAttributesTest()
        {
        }

        [TestMethod]
        public void XmlParserPitchTest()
        {
        }

        [TestMethod]
        public void XmlParserDurationTest()
        {
        }

        [TestMethod]
        public void XmlParserTieTest()
        {
        }

        [TestMethod]
        public void XmlParserTripletTest()
        {
        }

    }
}
