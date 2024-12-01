namespace Libiada.Segmenter.Tests.Base.Sequences;

using Segmenter.Base.Sequences;

/// <summary>
/// The complex complex chain test.
/// </summary>
[TestFixture]
public class ComplexChainTests
{
    /// <summary>
    /// The chain.
    /// </summary>
    private ComplexChain chain;

    /// <summary>
    /// The different complex chain.
    /// </summary>
    private ComplexChain differentComplexChain;

    /// <summary>
    /// The set up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        differentComplexChain = new ComplexChain("AACAGGTGCTTATTT");
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        ComplexChain foreignComplexChain = chain.Clone();

        Assert.That(foreignComplexChain, Is.Not.SameAs(chain));
        Assert.That(foreignComplexChain, Is.EqualTo(chain));
    }

    /// <summary>
    /// The equals test.
    /// </summary>
    [Test]
    public void EqualsTest()
    {
        ComplexChain foreignComplexChain = chain.Clone();

        Assert.That(foreignComplexChain, Is.EqualTo(chain));
        foreignComplexChain.DeleteAt(0);
        foreignComplexChain.DeleteAt(0);
        Assert.That(foreignComplexChain, Is.Not.EqualTo(chain));
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
            Assert.That(chain[0].ToString(), Is.EqualTo(str1));
            Assert.That(chain[4].ToString(), Is.EqualTo(str2));
            Assert.That(chain[2].ToString(), Is.EqualTo(str3));
        });
    }

    /// <summary>
    /// The substring test.
    /// </summary>
    [Test]
    public void SubstringTest()
    {
        const int start = 0, end = 2;
        ComplexChain thirdComplexChain = new("AA");
        ComplexChain foreignComplexChain = new(chain.Substring(start, end));

        Assert.That(foreignComplexChain, Is.EqualTo(thirdComplexChain));
    }

    /// <summary>
    /// The clear at test.
    /// </summary>
    [Test]
    public void DeleteAtTest()
    {
        ComplexChain actual = new("AGTC");
        ComplexChain expected = new("ATC");
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
        int end = chain.Length;

        ComplexChain firstComplexChain = new(chain.Substring(start, end / 2));
        ComplexChain secondComplexChain = new(chain.Substring(end / 2, end));
        ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain);
        Assert.That(concatChain, Is.EqualTo(chain));
    }

    /// <summary>
    /// The concat two test.
    /// </summary>
    [Test]
    public void ConcatTwoTest()
    {
        const int start = 0;
        int end = chain.Length;

        ComplexChain firstComplexChain = new(chain.Substring(start, end - 1));
        ComplexChain secondComplexChain = new(chain.Substring(end - 1, end));
        ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain.ToString());
        Assert.That(concatChain, Is.EqualTo(chain));
    }

    /// <summary>
    /// The length test.
    /// </summary>
    [Test]
    public void LengthTest()
    {
        ComplexChain foreignComplexChain = chain.Clone();

        Assert.That(chain.Length, Is.Not.EqualTo(differentComplexChain.Length));
        Assert.That(foreignComplexChain.Length, Is.EqualTo(chain.Length));
        foreignComplexChain.DeleteAt(0);
        Assert.That(foreignComplexChain.Length, Is.Not.EqualTo(chain.Length));
    }

    /// <summary>
    /// The is empty test.
    /// </summary>
    [Test]
    public void IsEmptyTest()
    {
        const string str = "s";
        ComplexChain emptyChain = new(string.Empty);
        Assert.That(emptyChain.IsEmpty());
        emptyChain.Concat(str);
        Assert.That(!emptyChain.IsEmpty());
        emptyChain.DeleteAt(0);
        Assert.That(emptyChain.IsEmpty());
    }

    /// <summary>
    /// The update congenerics test.
    /// </summary>
    [Test]
    public void UpdateCongenericsTest()
    {
        ComplexChain clonedComplexChain = chain.Clone();

        chain.DeleteAt(0);
        clonedComplexChain.DeleteAt(0);
        Assert.That(chain, Is.EqualTo(clonedComplexChain));
    }

    /// <summary>
    /// The join test.
    /// </summary>
    [Test]
    public void JoinTest()
    {
        ComplexChain clone = chain.Clone();
        List<string> expected1 = ["AAC", "A", "G", "G", "T", "G", "C", "C", "C", "C", "T", "T", "A", "T", "T", "T"];
        List<string> expected2 = ["AAC", "A", "G", "G", "TGC", "C", "C", "C", "T", "T", "A", "T", "T", "T"];
        List<string> expected3 = ["AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T"];
        List<string> expected4 = ["AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT"];

        clone.Join(0, 3);
        Assert.That(new ComplexChain(expected1), Is.EqualTo(clone));

        clone.Join(4, 3);
        Assert.That(new ComplexChain(expected2), Is.EqualTo(clone));

        clone.Join(0, 5);
        Assert.That(new ComplexChain(expected3).Equals(clone));

        clone.Join(8, 2);
        Assert.That(new ComplexChain(expected4).Equals(clone));
    }

    /// <summary>
    /// The join all test.
    /// </summary>
    [Test]
    public void JoinAllTest()
    {
        List<string> list1 = ["A", "A", "G", "G", "T", "G", "C", "A", "A", "A", "A", "T", "A", "T", "A", "A", "A"];
        ComplexChain clone = new(list1);
        List<string> list2 = ["A", "A"];
        clone.JoinAll(list2);

        //TODO: add asserts
    }
}
