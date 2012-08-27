using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;
using MDA.OIP.MusicXml;
using System.Xml;

namespace MDATest.OIPTest.TestMusicXml
{
    [TestClass]
    public class TestMusicXmlParser
    {
        [TestMethod]
        public void TestXmlParser()
        {
            XmlDocument xmldocument = new XmlDocument();
            // WTF????!!!!!!1111
            MusicXmlReader xmlreader =
                new MusicXmlReader("K:\\_Учеба\\MDA 2.0.3\\MDA\\MDATest\\OIPTest\\MDAexample7Liga.xml");
            MusicXmlParser Parser = new MusicXmlParser();

            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

            #region Creating EqualScoreModel

            // Создание атрибутов для такта
            Attributes attributes1 = new Attributes(new Size(7, 8, 1024), new Key(0, "major"));
            // Создание списков нот для каждого из 4 тактов
            List<Note> notes1 = new List<Note>();
            notes1.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 2, false, 2048), false, Tie.None));
            notes1.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes1.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes1.Add(new Note(new Pitch(3, 'F', 0), new Duration(1, 8, false, 512), false, Tie.Start));
            List<Note> notes2 = new List<Note>();
            notes2.Add(new Note(new Pitch(3, 'F', 0), new Duration(1, 8, false, 512), false, Tie.Stop));
            notes2.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 8, false, 512), false, Tie.None));
            notes2.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 8, false, 512), false, Tie.None));
            List<Note> notes3 = new List<Note>();
            notes3.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(4, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'B', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes3.Add(new Note(new Pitch(4, 'D', 0), new Duration(1, 8, true, 768), false, Tie.None));
            notes3.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 8, true, 768), false, Tie.None));
            notes3.Add(new Note(null, new Duration(1, 8, false, 512), false, Tie.None));
            // паузы, поэтому null вместо Pitch
            List<Note> notes4 = new List<Note>();
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(2, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'D', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(2, 'E', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'G', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(3, 'A', 0), new Duration(1, 16, false, 256), false, Tie.None));
            notes4.Add(new Note(new Pitch(4, 'C', 0), new Duration(1, 16, false, 256), false, Tie.None));
            //создание списка тактов для монофонического трека p0
            List<Measure> measures1 = new List<Measure>();
            measures1.Add(new Measure(notes1, (Attributes) attributes1.Clone()));
            measures1.Add(new Measure(notes2, (Attributes) attributes1.Clone()));
            measures1.Add(new Measure(notes3, (Attributes) attributes1.Clone()));
            measures1.Add(new Measure(notes4, (Attributes) attributes1.Clone()));
            //создание списка монофонических треков для полного музыкального трека
            List<UniformScoreTrack> utracks = new List<UniformScoreTrack>();
            utracks.Add(new UniformScoreTrack("p0", measures1));
            //создание полной модели музыкального трека/текста, с присвоением имени файла
            ScoreTrack Scoremodel = new ScoreTrack("MDAexample7Liga", utracks);

            #endregion

            Assert.AreEqual(xmlreader.FileName, Parser.ScoreModel.Name);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[0].Attributes,
                            Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].Attributes);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[0].NoteList[0],
                            Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList[0]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[0],
                            Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[1],
                            Parser.ScoreModel.UniformScoreTracks[0].Measurelist[1]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[2],
                            Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[3],
                            Parser.ScoreModel.UniformScoreTracks[0].Measurelist[3]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0], Parser.ScoreModel.UniformScoreTracks[0]);
            Assert.AreEqual(Scoremodel, Parser.ScoreModel);
        }

        [TestMethod]
        public void TestXmlParserFileName()
        {
        }

        [TestMethod]
        public void TestXmlParserScoretrack()
        {
        }

        [TestMethod]
        public void TestXmlParserUniformScoretrack()
        {
        }

        [TestMethod]
        public void TestXmlParserMeasure()
        {
        }

        [TestMethod]
        public void TestXmlParserNote()
        {
        }

        [TestMethod]
        public void TestXmlParserAttributes()
        {
        }

        [TestMethod]
        public void TestXmlParserPitch()
        {
        }

        [TestMethod]
        public void TestXmlParserDuration()
        {
        }

        [TestMethod]
        public void TestXmlParserTie()
        {
        }

        public void TestXmlParserTriplet()
        {
        }
    }
}
