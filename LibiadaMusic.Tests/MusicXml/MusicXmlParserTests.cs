namespace LibiadaMusic.Tests.MusicXml
{
    using System.Collections.Generic;

    using LibiadaMusic.MusicXml;
    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// The music xml parser tests.
    /// </summary>
    [TestFixture]
    public class MusicXmlParserTests
    {
        /// <summary>
        /// The xml parser test.
        /// </summary>
        [Test]
        public void XmlParserTest()
        {
            var xmlReader = new MusicXmlReader("../../LibiadaMusicexample7Liga.xml");
            var parser = new MusicXmlParser();

            parser.Execute(xmlReader.MusicXmlDocument, xmlReader.FileName);

            // Создание атрибутов для такта
            var attributes1 = new Attributes(new Size(7, 8, 1024), new Key(0, "major"));

            // Создание списков нот для каждого из 4 тактов
            var notes1 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 2, false, 2048), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.F, 0), new Duration(1, 8, false, 512), false, Tie.Start)
            };
            var notes2 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.F, 0), new Duration(1, 8, false, 512), false, Tie.End),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false, 512), false, Tie.None),
                new ValueNote(new Pitch(2, NoteSymbol.A, 0), new Duration(1, 8, false, 512), false, Tie.None)
            };
            var notes3 = new List<ValueNote>
            {
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.E, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.D, 0), new Duration(1, 8, true, 768), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 8, true, 768), false, Tie.None),
                new ValueNote((Pitch)null, new Duration(1, 8, false, 512), false, Tie.None)
            };
            var notes4 = new List<ValueNote>
            {
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(2, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.D, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(2, NoteSymbol.E, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false, 256), false, Tie.None),
                new ValueNote(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false, 256), false, Tie.None)
            };

            // создание списка тактов для монофонического трека p0
            var measures1 = new List<Measure>
            {
                new Measure(notes1, (Attributes)attributes1.Clone()),
                new Measure(notes2, (Attributes)attributes1.Clone()),
                new Measure(notes3, (Attributes)attributes1.Clone()),
                new Measure(notes4, (Attributes)attributes1.Clone())
            };

            // создание списка монофонических треков для полного музыкального трека
            var utracks = new List<CongenericScoreTrack> { new CongenericScoreTrack("p0", measures1) };

            // создание полной модели музыкального трека/текста, с присвоением имени файла
            var scoreModel = new ScoreTrack("LibiadaMusicexample7Liga", utracks);

            Assert.AreEqual(xmlReader.FileName, parser.ScoreModel.Name);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0].MeasureList[0].Attributes, parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].Attributes);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0]);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0].MeasureList[0], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0]);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0].MeasureList[1], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[1]);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0].MeasureList[2], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2]);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0].MeasureList[3], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[3]);
            Assert.AreEqual(scoreModel.CongenericScoreTracks[0], parser.ScoreModel.CongenericScoreTracks[0]);
            Assert.AreEqual(scoreModel, parser.ScoreModel);
        }

        /// <summary>
        /// The poly xml parser test.
        /// </summary>
        [Test]
        public void PolyXmlParserTest()
        {
            var xmlReader = new MusicXmlReader("../../polytest.xml");
            var parser = new MusicXmlParser();

            parser.Execute(xmlReader.MusicXmlDocument, xmlReader.FileName);

            Assert.AreEqual(xmlReader.FileName, parser.ScoreModel.Name);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks.Count, 1);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList.Count, 3);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList.Count, 5);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[1].NoteList.Count, 6);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2].NoteList.Count, 4);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0].Pitch.Count, 2);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2].NoteList[0].Pitch.Count, 3);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0].Duration.Denominator, 4);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0].Pitch[0].Step.ToString(), "A");
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0].Pitch[1].Step.ToString(), "C");
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2].NoteList[0].Duration.Denominator, 8);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2].NoteList[0].Pitch[0].Step.ToString(), "G");
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2].NoteList[0].Pitch[1].Step.ToString(), "G");
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2].NoteList[0].Pitch[2].Step.ToString(), "C");
        }

        /// <summary>
        /// The xml parser file name test.
        /// </summary>
        [Test]
        public void XmlParserFileNameTest()
        {
        }

        /// <summary>
        /// The xml parser scoretrack test.
        /// </summary>
        [Test]
        public void XmlParserScoretrackTest()
        {
        }

        /// <summary>
        /// The xml parser congeneric scoretrack test.
        /// </summary>
        [Test]
        public void XmlParserCongenericScoretrackTest()
        {
        }

        /// <summary>
        /// The xml parser measure test.
        /// </summary>
        [Test]
        public void XmlParserMeasureTest()
        {
        }

        /// <summary>
        /// The xml parser note test.
        /// </summary>
        [Test]
        public void XmlParserNoteTest()
        {
        }

        /// <summary>
        /// The xml parser attributes test.
        /// </summary>
        [Test]
        public void XmlParserAttributesTest()
        {
        }

        /// <summary>
        /// The xml parser pitch test.
        /// </summary>
        [Test]
        public void XmlParserPitchTest()
        {
        }

        /// <summary>
        /// The xml parser duration test.
        /// </summary>
        [Test]
        public void XmlParserDurationTest()
        {
        }

        /// <summary>
        /// The xml parser tie test.
        /// </summary>
        [Test]
        public void XmlParserTieTest()
        {
        }

        /// <summary>
        /// The xml parser triplet test.
        /// </summary>
        [Test]
        public void XmlParserTripletTest()
        {
        }
    }
}
