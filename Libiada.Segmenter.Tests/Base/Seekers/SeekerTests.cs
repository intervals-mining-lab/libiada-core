namespace Libiada.Segmenter.Tests.Base.Seekers;

using Segmenter.Base.Iterators;
using Segmenter.Base.Seekers;
using Segmenter.Base.Sequences;

/// <summary>
/// The seeker test.
/// </summary>
[TestFixture]
public class SeekerTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private ComplexSequence sequence;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        sequence = new ComplexSequence("AACAGGTGCCCCTTATTT");
    }

    /// <summary>
    /// The seek test.
    /// </summary>
    [Test]
    public void SeekTest()
    {
        const int length = 1;
        const int step = 1;
        const string required1 = "A";
        const string required2 = "C";
        const string required3 = "T";
        const string required4 = "G";

        Seeker seek = new(new StartIterator(sequence, length, step));
        seek.Seek([required1]);
        Assert.That(seek.Arrangement, Has.Count.EqualTo(4));

        seek.Seek([required2]);
        Assert.That(seek.Arrangement, Has.Count.EqualTo(5));

        seek.Seek([required3]);
        Assert.That(seek.Arrangement, Has.Count.EqualTo(6));

        seek.Seek([required4]);
        Assert.That(seek.Arrangement, Has.Count.EqualTo(3));
    }

    /// <summary>
    /// The seek two test.
    /// </summary>
    [Test]
    public void SeekTwoTest()
    {
        const int length = 1;
        const int step = 1;
        const string required1 = "AA";
        const string required2 = "C";
        const string required3 = "TTA";
        List<string> list = ["AA", "AAAT", "AJJTTA"];

        Seeker seek = new(new StartIterator(new ComplexSequence(list), length, step));
        seek.Seek([required1]);
        Assert.That(seek.Arrangement, Has.Count.EqualTo(1));

        seek.Seek([required2]);
        Assert.That(seek.Arrangement, Is.Empty);

        seek.Seek([required3]);
        Assert.That(seek.Arrangement, Is.Empty);
    }

    /// <summary>
    /// The get match test.
    /// </summary>
    [Test]
    public void GetMatchTest()
    {
        const int length = 1;
        const int step = 1;
        const string required1 = "A";
        Seeker seek = new(new StartIterator(sequence, length, step));
        seek.Seek([required1]);
        Assert.That(seek.Arrangement, Has.Count.EqualTo(4));
    }
}
