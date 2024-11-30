namespace Libiada.Core.Tests.Music.MusicXml;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music.MusicXml;

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
        MeasureAttributes attributes = new(new Size(7, 8), new Key(0, "major"));

        // notes lists for each measure
        List<ValueNote> notes1 =
        [
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 2, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.F, 0), new Duration(1, 8, false), false, Tie.Start)
        ];
        List<ValueNote> notes2 =
        [
            new(new Pitch(3, NoteSymbol.F, 0), new Duration(1, 8, false), false, Tie.End),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 8, false), false, Tie.None),
            new(new Pitch(2, NoteSymbol.A, 0), new Duration(1, 8, false), false, Tie.None)
        ];
        List<ValueNote> notes3 =
        [
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.E, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.D, 0), new Duration(1, 8, true), false, Tie.None),
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 8, true), false, Tie.None),
            new(new Duration(1, 8, false), false, Tie.None)
        ];
        List<ValueNote> notes4 =
        [
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(2, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.D, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(2, NoteSymbol.E, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.G, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 16, false), false, Tie.None),
            new(new Pitch(4, NoteSymbol.C, 0), new Duration(1, 16, false), false, Tie.None)
        ];

        // measures list for congeneric score track
        List<Measure> measures1 =
        [
            new(notes1, (MeasureAttributes)attributes.Clone()),
            new(notes2, (MeasureAttributes)attributes.Clone()),
            new(notes3, (MeasureAttributes)attributes.Clone()),
            new(notes4, (MeasureAttributes)attributes.Clone())
        ];

        // single uniform score track
        List<CongenericScoreTrack> uniformTracks = [new(measures1)];

        // whole music sequence
        scoreTrack = new ScoreTrack(uniformTracks);
    }

    /// <summary>
    /// The xml parser test.
    /// </summary>
    [Test]
    public void XmlParserTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);

        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        CongenericScoreTrack expected = scoreTrack.CongenericScoreTracks[0];

        Assert.Multiple(() =>
        {
            Assert.That(actual.MeasureList[0].Attributes, Is.EqualTo(expected.MeasureList[0].Attributes));
            Assert.That(actual.MeasureList[0].NoteList[0], Is.EqualTo(expected.MeasureList[0].NoteList[0]));
            Assert.That(actual.MeasureList[0], Is.EqualTo(expected.MeasureList[0]));
            Assert.That(actual.MeasureList[1], Is.EqualTo(expected.MeasureList[1]));
            Assert.That(actual.MeasureList[2], Is.EqualTo(expected.MeasureList[2]));
            Assert.That(actual.MeasureList[3], Is.EqualTo(expected.MeasureList[3]));
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(parser.ScoreModel, Is.EqualTo(scoreTrack));
        });
    }

    /// <summary>
    /// The poly xml parser test.
    /// </summary>
    [Test]
    public void PolyXmlParserTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "PolyTest.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);

        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];

        Assert.Multiple(() =>
        {
            Assert.That(parser.ScoreModel.CongenericScoreTracks, Has.Count.EqualTo(1));
            Assert.That(actual.MeasureList, Has.Count.EqualTo(3));
        });
        Assert.Multiple(() =>
        {
            Assert.That(actual.MeasureList[0].NoteList, Has.Count.EqualTo(5));
            Assert.That(actual.MeasureList[1].NoteList, Has.Count.EqualTo(6));
            Assert.That(actual.MeasureList[2].NoteList, Has.Count.EqualTo(4));
            Assert.That(actual.MeasureList[0].NoteList[0].Pitches, Has.Count.EqualTo(2));
            Assert.That(actual.MeasureList[2].NoteList[0].Pitches, Has.Count.EqualTo(3));
            Assert.That(actual.MeasureList[0].NoteList[0].Duration.Denominator, Is.EqualTo(4));
            Assert.That(actual.MeasureList[0].NoteList[0].Pitches[0].Step.ToString(), Is.EqualTo("A"));
            Assert.That(actual.MeasureList[0].NoteList[0].Pitches[1].Step.ToString(), Is.EqualTo("C"));
            Assert.That(actual.MeasureList[2].NoteList[0].Duration.Denominator, Is.EqualTo(8));
            Assert.That(actual.MeasureList[2].NoteList[0].Pitches[0].Step.ToString(), Is.EqualTo("G"));
            Assert.That(actual.MeasureList[2].NoteList[0].Pitches[1].Step.ToString(), Is.EqualTo("G"));
            Assert.That(actual.MeasureList[2].NoteList[0].Pitches[2].Step.ToString(), Is.EqualTo("C"));
        });
    }

    /// <summary>
    /// Test for measure repeat parse in MusicXml.
    /// </summary>
    [Test]
    public void RepeaterTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "RepeaterTest.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);

        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];

        Assert.That(parser.ScoreModel.CongenericScoreTracks, Has.Count.EqualTo(1));
        Assert.That(actual.MeasureList, Has.Count.EqualTo(8));
        Assert.That(actual.MeasureList[0].NoteList, Has.Count.EqualTo(1));
        Assert.That(actual.MeasureList[0], Is.EqualTo(actual.MeasureList[4]));
        Assert.That(actual.MeasureList[1], Is.EqualTo(actual.MeasureList[5]));
    }

    /// <summary>
    /// The xml parser score track test.
    /// </summary>
    [Test]
    public void XmlParserScoreTrackTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);

        Assert.That(parser.ScoreModel, Is.EqualTo(scoreTrack));
    }

    /// <summary>
    /// The xml parser congeneric score track test.
    /// </summary>
    [Test]
    public void XmlParserCongenericScoreTrackTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        Assert.That(actual, Is.EqualTo(scoreTrack.CongenericScoreTracks[0]));
    }

    /// <summary>
    /// The xml parser measure test.
    /// </summary>
    [Test]
    public void XmlParserMeasureTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            Assert.That(actual.MeasureList[i], Is.EqualTo(scoreTrack.CongenericScoreTracks[0].MeasureList[i]));
        }
    }

    /// <summary>
    /// The xml parser note test.
    /// </summary>
    [Test]
    public void XmlParserNoteTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
            List<ValueNote> actualNotes = actualMeasures[i].NoteList;
            Assert.That(actualNotes, Has.Count.EqualTo(expectedNotes.Count));
            for (int j = 0; j < expectedNotes.Count; j++)
            {
                Assert.That(actualNotes[j], Is.EqualTo(expectedNotes[j]));
            }
        }
    }

    /// <summary>
    /// The xml parser attributes test.
    /// </summary>
    [Test]
    public void XmlParserAttributesTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            MeasureAttributes expectedAttributes = scoreTrack.CongenericScoreTracks[0].MeasureList[i].Attributes;
            MeasureAttributes actualAttributes = actual.MeasureList[i].Attributes;
            Assert.That(actualAttributes, Is.EqualTo(expectedAttributes));
            Assert.That(actualAttributes.Key, Is.EqualTo(expectedAttributes.Key));
            Assert.That(actualAttributes.Size, Is.EqualTo(expectedAttributes.Size));
        }
    }

    /// <summary>
    /// The xml parser pitch test.
    /// </summary>
    [Test]
    public void XmlParserPitchTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
            List<ValueNote> actualNotes = actualMeasures[i].NoteList;
            Assert.That(actualNotes, Has.Count.EqualTo(expectedNotes.Count));
            for (int j = 0; j < expectedNotes.Count; j++)
            {
                Assert.That(actualNotes[j].Pitches, Has.Count.EqualTo(expectedNotes[j].Pitches.Count));
                for (int k = 0; k < expectedNotes[j].Pitches.Count; k++)
                {
                    Assert.That(actualNotes[j].Pitches[k], Is.EqualTo(expectedNotes[j].Pitches[k]));
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
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
            List<ValueNote> actualNotes = actualMeasures[i].NoteList;
            Assert.That(actualNotes, Has.Count.EqualTo(expectedNotes.Count));
            for (int j = 0; j < expectedNotes.Count; j++)
            {
                Assert.That(actualNotes[j].Duration, Is.EqualTo(expectedNotes[j].Duration));
            }
        }
    }

    /// <summary>
    /// The xml parser tie test.
    /// </summary>
    [Test]
    public void XmlParserTieTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
            List<ValueNote> actualNotes = actualMeasures[i].NoteList;
            Assert.That(actualNotes, Has.Count.EqualTo(expectedNotes.Count));
            for (int j = 0; j < expectedNotes.Count; j++)
            {
                Assert.That(actualNotes[j].Tie, Is.EqualTo(expectedNotes[j].Tie));
            }
        }
    }

    /// <summary>
    /// The xml parser triplet test.
    /// </summary>
    [Test]
    public void XmlParserTripletTest()
    {
        string xmlFilePath = Path.Join(TestContext.CurrentContext.TestDirectory, "Music", "XmlTestFiles", "LibiadaMusicExample7Liga.xml");
        MusicXmlReader xmlReader = new(xmlFilePath);
        MusicXmlParser parser = new();
        parser.Execute(xmlReader.MusicXmlDocument);
        CongenericScoreTrack actual = parser.ScoreModel.CongenericScoreTracks[0];
        List<Measure> expectedMeasures = scoreTrack.CongenericScoreTracks[0].MeasureList;
        List<Measure> actualMeasures = actual.MeasureList;
        Assert.That(actualMeasures, Has.Count.EqualTo(expectedMeasures.Count));
        for (int i = 0; i < expectedMeasures.Count; i++)
        {
            List<ValueNote> expectedNotes = expectedMeasures[i].NoteList;
            List<ValueNote> actualNotes = actualMeasures[i].NoteList;
            Assert.That(actualNotes, Has.Count.EqualTo(expectedNotes.Count));
            for (int j = 0; j < expectedNotes.Count; j++)
            {
                Assert.That(actualNotes[j].Triplet, Is.EqualTo(expectedNotes[j].Triplet));
            }
        }
    }
}
