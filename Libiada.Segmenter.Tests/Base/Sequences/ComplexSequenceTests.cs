namespace Libiada.Segmenter.Tests.Base.Sequences;

using Segmenter.Base.Sequences;

/// <summary>
/// The complex complex sequence test.
/// </summary>
[TestFixture]
public class ComplexSequenceTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private ComplexSequence sequence;

    /// <summary>
    /// The different complex sequence.
    /// </summary>
    private ComplexSequence differentComplexSequence;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        sequence = new ComplexSequence("AACAGGTGCCCCTTATTT");
        differentComplexSequence = new ComplexSequence("AACAGGTGCTTATTT");
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        ComplexSequence foreignComplexSequence = sequence.Clone();

        Assert.That(foreignComplexSequence, Is.Not.SameAs(sequence));
        Assert.That(foreignComplexSequence, Is.EqualTo(sequence));
    }

    /// <summary>
    /// The equals test.
    /// </summary>
    [Test]
    public void EqualsTest()
    {
        ComplexSequence foreignComplexSequence = sequence.Clone();

        Assert.That(foreignComplexSequence, Is.EqualTo(sequence));
        foreignComplexSequence.DeleteAt(0);
        foreignComplexSequence.DeleteAt(0);
        Assert.That(foreignComplexSequence, Is.Not.EqualTo(sequence));
    }

    /// <summary>
    /// The element at test.
    /// </summary>
    [Test]
    public void ElementAtTest()
    {
        const string str1 = "A";
        const string str2 = "G";
        const string str3 = "C";

        Assert.Multiple(() =>
        {
            Assert.That(sequence[0].ToString(), Is.EqualTo(str1));
            Assert.That(sequence[4].ToString(), Is.EqualTo(str2));
            Assert.That(sequence[2].ToString(), Is.EqualTo(str3));
        });
    }

    /// <summary>
    /// The substring test.
    /// </summary>
    [Test]
    public void SubstringTest()
    {
        const int start = 0, end = 2;
        ComplexSequence thirdComplexSequence = new("AA");
        ComplexSequence foreignComplexSequence = new(sequence.Substring(start, end));

        Assert.That(foreignComplexSequence, Is.EqualTo(thirdComplexSequence));
    }

    /// <summary>
    /// The clear at test.
    /// </summary>
    [Test]
    public void DeleteAtTest()
    {
        ComplexSequence actual = new("AGTC");
        ComplexSequence expected = new("ATC");
        actual.DeleteAt(1);
        Assert.That(actual.Equals(expected));
    }

    /// <summary>
    /// The concat one test.
    /// </summary>
    [Test]
    public void ConcatOneTest()
    {
        const int start = 0;
        int end = sequence.Length;

        ComplexSequence firstComplexSequence = new(sequence.Substring(start, end / 2));
        ComplexSequence secondComplexSequence = new(sequence.Substring(end / 2, end));
        ComplexSequence concatSequence = firstComplexSequence.Concat(secondComplexSequence);
        Assert.That(concatSequence, Is.EqualTo(sequence));
    }

    /// <summary>
    /// The concat two test.
    /// </summary>
    [Test]
    public void ConcatTwoTest()
    {
        const int start = 0;
        int end = sequence.Length;

        ComplexSequence firstComplexSequence = new(sequence.Substring(start, end - 1));
        ComplexSequence secondComplexSequence = new(sequence.Substring(end - 1, end));
        ComplexSequence concatSequence = firstComplexSequence.Concat(secondComplexSequence.ToString());
        Assert.That(concatSequence, Is.EqualTo(sequence));
    }

    /// <summary>
    /// The length test.
    /// </summary>
    [Test]
    public void LengthTest()
    {
        ComplexSequence foreignComplexSequence = sequence.Clone();

        Assert.That(sequence.Length, Is.Not.EqualTo(differentComplexSequence.Length));
        Assert.That(foreignComplexSequence.Length, Is.EqualTo(sequence.Length));
        foreignComplexSequence.DeleteAt(0);
        Assert.That(foreignComplexSequence.Length, Is.Not.EqualTo(sequence.Length));
    }

    /// <summary>
    /// The is empty test.
    /// </summary>
    [Test]
    public void IsEmptyTest()
    {
        const string str = "s";
        ComplexSequence emptySequence = new(string.Empty);
        Assert.That(emptySequence.IsEmpty());
        emptySequence.Concat(str);
        Assert.That(!emptySequence.IsEmpty());
        emptySequence.DeleteAt(0);
        Assert.That(emptySequence.IsEmpty());
    }

    /// <summary>
    /// The update congenerics test.
    /// </summary>
    [Test]
    public void UpdateCongenericsTest()
    {
        ComplexSequence clonedComplexSequence = sequence.Clone();

        sequence.DeleteAt(0);
        clonedComplexSequence.DeleteAt(0);
        Assert.That(sequence, Is.EqualTo(clonedComplexSequence));
    }

    /// <summary>
    /// The join test.
    /// </summary>
    [Test]
    public void JoinTest()
    {
        ComplexSequence clone = sequence.Clone();
        List<string> expected1 = ["AAC", "A", "G", "G", "T", "G", "C", "C", "C", "C", "T", "T", "A", "T", "T", "T"];
        List<string> expected2 = ["AAC", "A", "G", "G", "TGC", "C", "C", "C", "T", "T", "A", "T", "T", "T"];
        List<string> expected3 = ["AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T"];
        List<string> expected4 = ["AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT"];

        clone.Join(0, 3);
        Assert.That(new ComplexSequence(expected1), Is.EqualTo(clone));

        clone.Join(4, 3);
        Assert.That(new ComplexSequence(expected2), Is.EqualTo(clone));

        clone.Join(0, 5);
        Assert.That(new ComplexSequence(expected3).Equals(clone));

        clone.Join(8, 2);
        Assert.That(new ComplexSequence(expected4).Equals(clone));
    }

    /// <summary>
    /// The join all test.
    /// </summary>
    [Test]
    public void JoinAllTest()
    {
        List<string> list1 = ["A", "A", "G", "G", "T", "G", "C", "A", "A", "A", "A", "T", "A", "T", "A", "A", "A"];
        ComplexSequence clone = new(list1);
        List<string> list2 = ["A", "A"];
        clone.JoinAll(list2);

        //TODO: add asserts
    }
}
