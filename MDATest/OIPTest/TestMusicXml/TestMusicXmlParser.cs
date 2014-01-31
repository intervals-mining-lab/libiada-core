using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;
using MDA.OIP.MusicXml;
using System.Xml;

namespace TestMusicXml.MDATest.OIPTest
{
    [TestClass]
    public class TestMusicXmlParser
    {
        [TestMethod]
        public void TestXmlParser()
        {
            XmlDocument xmldocument = new XmlDocument();
            MusicXmlReader xmlreader = new MusicXmlReader("..\\..\\OIPTest\\MDAexample7Liga.xml");
            MusicXmlParser Parser = new MusicXmlParser();

            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

            #region Creating EqualScoreModel
            // Создание атрибутов для такта
            Attributes attributes1 = new Attributes(new Size(7, 8, 1024), new Key(0,"major"));
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
            notes3.Add(new Note((Pitch)null, new Duration(1, 8, false, 512), false, Tie.None)); // паузы, поэтому null вместо Pitch
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
            List <UniformScoreTrack> utracks = new List<UniformScoreTrack>();
            utracks.Add(new UniformScoreTrack("p0", measures1));
            //создание полной модели музыкального трека/текста, с присвоением имени файла
            ScoreTrack Scoremodel = new ScoreTrack("MDAexample7Liga",utracks);

            #endregion

            Assert.AreEqual(xmlreader.FileName , Parser.ScoreModel.Name);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[0].Attributes, Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].Attributes);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[0].NoteList[0], Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList[0]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[0], Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[1], Parser.ScoreModel.UniformScoreTracks[0].Measurelist[1]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[2], Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0].Measurelist[3], Parser.ScoreModel.UniformScoreTracks[0].Measurelist[3]);
            Assert.AreEqual(Scoremodel.UniformScoreTracks[0], Parser.ScoreModel.UniformScoreTracks[0]);
            Assert.AreEqual(Scoremodel, Parser.ScoreModel);
        }

        [TestMethod]
        public void TestPolyXmlParser()
        {
            XmlDocument xmldocument = new XmlDocument();
            MusicXmlReader xmlreader = new MusicXmlReader("..\\..\\OIPTest\\polytest.xml");
            MusicXmlParser Parser = new MusicXmlParser();

            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

            Assert.AreEqual(xmlreader.FileName, Parser.ScoreModel.Name);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks.Count, 1);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist.Count, 3);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList.Count, 5);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[1].NoteList.Count, 6);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2].NoteList.Count, 4);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList[0].Pitch.Count, 2);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2].NoteList[0].Pitch.Count, 3);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList[0].Duration.Denominator, 4);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList[0].Pitch[0].Step.ToString(), "A");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[0].NoteList[0].Pitch[1].Step.ToString(), "C");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2].NoteList[0].Duration.Denominator, 8);
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2].NoteList[0].Pitch[0].Step.ToString(), "G");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2].NoteList[0].Pitch[1].Step.ToString(), "G");
            Assert.AreEqual(Parser.ScoreModel.UniformScoreTracks[0].Measurelist[2].NoteList[0].Pitch[2].Step.ToString(), "C");
        }

        [TestMethod]
        public void TestXmlParserFileName()
        {
        }
        public void TestXmlParserScoretrack()
        {
        }
        public void TestXmlParserUniformScoretrack()
        {
        }
        public void TestXmlParserMeasure()
        {
        }
        public void TestXmlParserNote()
        {
        }
        public void TestXmlParserAttributes()
        {
        }
        public void TestXmlParserPitch()
        {
        }
        public void TestXmlParserDuration()
        {
        }
        public void TestXmlParserTie()
        {
        }
        public void TestXmlParserTriplet()
        {
        }

    }
}
