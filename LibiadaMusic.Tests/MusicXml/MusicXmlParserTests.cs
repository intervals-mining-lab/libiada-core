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
        /// The score track.
        /// </summary>
        private ScoreTrack scoreTrack;

        /// <summary>
        /// The music xml parser set up.
        /// </summary>
        [OneTimeSetUp]
        public void MusicXmlParserSetUp()
        {
            // Measures attributes
            var attributes = new Attributes(new Size(7, 8, 1024), new Key(0, "major"));

            // notes lists for each measure
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

            // measures list for congeneric score track
            var measures1 = new List<Measure>
            {
                new Measure(notes1, (Attributes)attributes.Clone()),
                new Measure(notes2, (Attributes)attributes.Clone()),
                new Measure(notes3, (Attributes)attributes.Clone()),
                new Measure(notes4, (Attributes)attributes.Clone())
            };

            // single uniform score track
            var uniformTracks = new List<CongenericScoreTrack> { new CongenericScoreTrack("p0", measures1) };

            // whole music sequence
            scoreTrack = new ScoreTrack(uniformTracks);
        }


        /// <summary>
        /// The xml parser test.
        /// </summary>
        [Test]
        public void XmlParserTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[0].Attributes, parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].Attributes);
            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[0].NoteList[0], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList[0]);
            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[0], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0]);
            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[1], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[1]);
            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[2], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[2]);
            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[3], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[3]);
            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0], parser.ScoreModel.CongenericScoreTracks[0]);
            Assert.AreEqual(scoreTrack, parser.ScoreModel);
        }

        /// <summary>
        /// The poly xml parser test.
        /// </summary>
        [Test]
        public void PolyXmlParserTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}polytest.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

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
        /// Test for measure repeat parse in MusicXml.
        /// </summary>
        [Test]
        public void RepeaterTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}repeatertest.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks.Count, 1);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList.Count, 8);
            Assert.AreEqual(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].NoteList.Count, 1);
            Assert.IsTrue(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[0].Equals(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[4]));
            Assert.IsTrue(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[1].Equals(parser.ScoreModel.CongenericScoreTracks[0].MeasureList[5]));
        }

        /// <summary>
        /// The xml parser score track test.
        /// </summary>
        [Test]
        public void XmlParserScoreTrackTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            Assert.AreEqual(scoreTrack,  parser.ScoreModel);
        }

        /// <summary>
        /// The xml parser congeneric score track test.
        /// </summary>
        [Test]
        public void XmlParserCongenericScoreTrackTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            Assert.AreEqual(scoreTrack.CongenericScoreTracks[0], parser.ScoreModel.CongenericScoreTracks[0]);
        }

        /// <summary>
        /// The xml parser measure test.
        /// </summary>
        [Test]
        public void XmlParserMeasureTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                Assert.AreEqual(scoreTrack.CongenericScoreTracks[0].MeasureList[i], parser.ScoreModel.CongenericScoreTracks[0].MeasureList[i]);
            }
        }

        /// <summary>
        /// The xml parser note test.
        /// </summary>
        [Test]
        public void XmlParserNoteTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
                List<ValueNote> actualNotes = actualMeasures[i].NoteList;
                Assert.AreEqual(expectedNotes.Count, actualNotes.Count);
                for (int j = 0; j < expectedNotes.Count; j++)
                {
                    Assert.AreEqual(expectedNotes[j], actualNotes[j]);
                }
            }
        }

        /// <summary>
        /// The xml parser attributes test.
        /// </summary>
        [Test]
        public void XmlParserAttributesTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                Attributes expectedAttributes = scoreTrack.CongenericScoreTracks[0].MeasureList[i].Attributes;
                Attributes actualAttributes = parser.ScoreModel.CongenericScoreTracks[0].MeasureList[i].Attributes;
                Assert.AreEqual(expectedAttributes, actualAttributes);
                Assert.AreEqual(expectedAttributes.Key, actualAttributes.Key);
                Assert.AreEqual(expectedAttributes.Size, actualAttributes.Size);
            }
        }

        /// <summary>
        /// The xml parser pitch test.
        /// </summary>
        [Test]
        public void XmlParserPitchTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
                List<ValueNote> actualNotes = actualMeasures[i].NoteList;
                Assert.AreEqual(expectedNotes.Count, actualNotes.Count);
                for (int j = 0; j < expectedNotes.Count; j++)
                {
                    Assert.AreEqual(expectedNotes[j].Pitch.Count, actualNotes[j].Pitch.Count);
                    for (int k = 0; k < expectedNotes[j].Pitch.Count; k++)
                    {
                        Assert.AreEqual(expectedNotes[j].Pitch[k], actualNotes[j].Pitch[k]);
                    }
                }
            }
        }

        /// <summary>
        /// The xml parser duration test.
        /// </summary>
        [Test]
        public void XmlParserDurationTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
                List<ValueNote> actualNotes = actualMeasures[i].NoteList;
                Assert.AreEqual(expectedNotes.Count, actualNotes.Count);
                for (int j = 0; j < expectedNotes.Count; j++)
                {
                    Assert.AreEqual(expectedNotes[j].Duration, actualNotes[j].Duration);
                }
            }
        }

        /// <summary>
        /// The xml parser tie test.
        /// </summary>
        [Test]
        public void XmlParserTieTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
                List<ValueNote> actualNotes = actualMeasures[i].NoteList;
                Assert.AreEqual(expectedNotes.Count, actualNotes.Count);
                for (int j = 0; j < expectedNotes.Count; j++)
                {
                    Assert.AreEqual(expectedNotes[j].Tie, actualNotes[j].Tie);
                }
            }
        }

        /// <summary>
        /// The xml parser triplet test.
        /// </summary>
        [Test]
        public void XmlParserTripletTest()
        {
            var xmlReader = new MusicXmlReader($"{SystemData.ProjectFolderPath}LibiadaMusicExample7Liga.xml");
            var parser = new MusicXmlParser();
            parser.Execute(xmlReader.MusicXmlDocument);

            List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
            List<Measure> actualMeasures = parser.ScoreModel.CongenericScoreTracks[0].MeasureList;
            Assert.AreEqual(expectedMeasures.Count, actualMeasures.Count);
            for (int i = 0; i < expectedMeasures.Count; i++)
            {
                List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
                List<ValueNote> actualNotes = actualMeasures[i].NoteList;
                Assert.AreEqual(expectedNotes.Count, actualNotes.Count);
                for (int j = 0; j < expectedNotes.Count; j++)
                {
                    Assert.AreEqual(expectedNotes[j].Triplet, actualNotes[j].Triplet);
                }
            }
        }
    }
}
