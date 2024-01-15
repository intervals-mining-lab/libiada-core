namespace Libiada.Segmenter.Tests.Base.Sequences;

using System.Collections.Generic;

using NUnit.Framework;

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

        Assert.AreNotSame(chain, foreignComplexChain);
        Assert.True(chain.Equals(foreignComplexChain));
    }

    /// <summary>
    /// The equals test.
    /// </summary>
    [Test]
    public void EqualsTest()
    {
        ComplexChain foreignComplexChain = chain.Clone();

        Assert.True(foreignComplexChain.Equals(chain));
        foreignComplexChain.ClearAt(0);
        foreignComplexChain.ClearAt(0);
        Assert.True(!foreignComplexChain.Equals(chain));
    }

    /// <summary>
    /// The element at test.
    /// </summary>
    [Test]
    public void ElementAtTest()
    {
        string str1 = "A";
        string str2 = "G";
        string str3 = "C";

        Assert.True(str1.Equals(chain[0].ToString()));
        Assert.True(str2.Equals(chain[4].ToString()));
        Assert.True(str3.Equals(chain[2].ToString()));
    }

    /// <summary>
    /// The substring test.
    /// </summary>
    [Test]
    public void SubstringTest()
    {
        int start = 0, end = 2;
        var thirdComplexChain = new ComplexChain("AA");
        var foreignComplexChain = new ComplexChain(chain.Substring(start, end));

        Assert.True(thirdComplexChain.Equals(foreignComplexChain));
    }

    /// <summary>
    /// The clear at test.
    /// </summary>
    [Test]
    public void ClearAtTest()
    {
        var secondComplexChain = new ComplexChain("AGTC");
        var firstComplexChain = new ComplexChain("ATC");
        secondComplexChain.ClearAt(1);
        Assert.True(firstComplexChain.Equals(secondComplexChain));
    }

    /// <summary>
    /// The concat one test.
    /// </summary>
    [Test]
    public void ConcatOneTest()
    {
        int start = 0;
        int end = chain.Length;

        var firstComplexChain = new ComplexChain(chain.Substring(start, end / 2));
        var secondComplexChain = new ComplexChain(chain.Substring(end / 2, end));
        ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain);
        Assert.True(concatChain.Equals(chain));
    }

    /// <summary>
    /// The concat two test.
    /// </summary>
    [Test]
    public void ConcatTwoTest()
    {
        int start = 0;
        int end = chain.Length;

        var firstComplexChain = new ComplexChain(chain.Substring(start, end - 1));
        var secondComplexChain = new ComplexChain(chain.Substring(end - 1, end));
        ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain.ToString());
        Assert.True(concatChain.Equals(chain));
    }

    /// <summary>
    /// The length test.
    /// </summary>
    [Test]
    public void LengthTest()
    {
        ComplexChain foreignComplexChain = chain.Clone();

        Assert.True(chain.Length != differentComplexChain.Length);
        Assert.True(chain.Length == foreignComplexChain.Length);
        foreignComplexChain.ClearAt(0);
        Assert.True(chain.Length != foreignComplexChain.Length);
    }

    /// <summary>
    /// The is empty test.
    /// </summary>
    [Test]
    public void IsEmptyTest()
    {
        string str = "s";
        var emptyChain = new ComplexChain(string.Empty);
        Assert.True(emptyChain.IsEmpty());
        emptyChain.Concat(str);
        Assert.True(!emptyChain.IsEmpty());
        emptyChain.ClearAt(0);
        Assert.True(emptyChain.IsEmpty());
    }

    /// <summary>
    /// The update congenerics test.
    /// </summary>
    [Test]
    public void UpdateCongenericsTest()
    {
        ComplexChain clonedComplexChain = chain.Clone();

        chain.ClearAt(0);
        clonedComplexChain.ClearAt(0);
        Assert.True(chain.Equals(clonedComplexChain));
    }

    /// <summary>
    /// The join test.
    /// </summary>
    [Test]
    public void JoinTest()
    {
        ComplexChain clon = chain.Clone();
        var expected1 = new List<string> { "AAC", "A", "G", "G", "T", "G", "C", "C", "C", "C", "T", "T", "A", "T", "T", "T" };
        var expected2 = new List<string> { "AAC", "A", "G", "G", "TGC", "C", "C", "C", "T", "T", "A", "T", "T", "T" };
        var expected3 = new List<string> { "AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T" };
        var expected4 = new List<string> { "AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT" };

        clon.Join(0, 3);
        Assert.True((new ComplexChain(expected1)).Equals(clon));

        clon.Join(4, 3);
        Assert.True((new ComplexChain(expected2)).Equals(clon));

        clon.Join(0, 5);
        Assert.True((new ComplexChain(expected3)).Equals(clon));

        clon.Join(8, 2);
        Assert.True((new ComplexChain(expected4)).Equals(clon));
    }

    /// <summary>
    /// The join all test.
    /// </summary>
    [Test]
    public void JoinAllTest()
    {
        var list1 = new List<string> { "A", "A", "G", "G", "T", "G", "C", "A", "A", "A", "A", "T", "A", "T", "A", "A", "A" };
        var clon = new ComplexChain(list1);
        var list2 = new List<string> { "A", "A" };
        clon.JoinAll(list2);
    }
}
