namespace Libiada.Segmenter.Tests.Base.Seekers;

using Segmenter.Base.Iterators;
using Segmenter.Base.Seekers;
using Segmenter.Base.Sequences;

/// <summary>
/// The seeker sequence test.
/// </summary>
[TestFixture]
public class SeekerSequenceTests
{
    /// <summary>
    /// The seek test.
    /// </summary>
    [Test]
    public void SeekTest()
    {
        const int length = 2;
        const int step = 1;

        List<string> list1 = ["ABAC", "A", "A", "A", "ABAC", "A", "ABC", "AC", "ABC", "AG", "ABC", "A", "AB", "A", "ABC", "ABAC", "A"];
        List<string> list2 = ["ABAC", "A"];
        SeekerSequence seek = new(new StartIterator(new ComplexChain(list1), length, step));
        Assert.That(seek.Seek(list2), Is.EqualTo(3));
    }
}
