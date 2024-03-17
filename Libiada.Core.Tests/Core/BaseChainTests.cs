namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The base chain test.
/// </summary>
[TestFixture]
public class BaseChainTests
{
    /// <summary>
    /// The constructor with given length test.
    /// </summary>
    [Test]
    public void ConstructorWithLengthTest()
    {
        var chain = new BaseChain(100);
        Assert.That(chain.Length, Is.EqualTo(100));
        var expectedOrder = new int[100];
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        var expectedAlphabet = new Alphabet();
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));
    }

    /// <summary>
    /// The constructor with less than zero length test.
    /// </summary>
    [Test]
    public void ConstructorLessZeroLengthTest()
    {
        Assert.Throws<ArgumentException>(() => new BaseChain(-10));
    }

    /// <summary>
    /// Constructor with string tests.
    /// </summary>
    [Test]
    public void ConstructorWithStringTest()
    {
        var chain = new BaseChain("A");
        Assert.That(chain.Length, Is.EqualTo(1));
        var expectedOrder = new[] { 1 };
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        var expectedAlphabet = new Alphabet() { (ValueString)"A"};
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));

        chain = new BaseChain("ABC");
        Assert.That(chain.Length, Is.EqualTo(3));
        expectedOrder = [1, 2, 3];
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"A", (ValueString)"B", (ValueString)"C"];
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));

        chain = new BaseChain("AAABBBCCC");
        Assert.That(chain.Length, Is.EqualTo(9));
        expectedOrder = [1, 1, 1, 2, 2, 2, 3, 3, 3];
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"A", (ValueString)"B", (ValueString)"C"];
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));

        chain = new BaseChain("AAABBBCCC");
        Assert.That(chain.Length, Is.EqualTo(9));
        expectedOrder = [1, 1, 1, 2, 2, 2, 3, 3, 3];
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"A", (ValueString)"B", (ValueString)"C"];
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));

        chain = new BaseChain("BBBCCCAAA");
        Assert.That(chain.Length, Is.EqualTo(9));
        expectedOrder = [1, 1, 1, 2, 2, 2, 3, 3, 3];
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"B", (ValueString)"C", (ValueString)"A"];
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));

        chain = new BaseChain("BBB---");
        Assert.That(chain.Length, Is.EqualTo(6));
        expectedOrder = [1, 1, 1, 2, 2, 2];
        Assert.That(chain.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"B", (ValueString)"-"];
        Assert.That(chain.Alphabet, Is.EqualTo(expectedAlphabet));
    }

    /// <summary>
    /// The get by this test.
    /// </summary>
    [Test]
    public void GetByThisTest()
    {
        var chain = new BaseChain(10);
        chain.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)chain[0]).Equals("1"), Is.True);
    }

    /// <summary>
    /// The set by this test.
    /// </summary>
    [Test]
    public void SetByThisTest()
    {
        var chain = new BaseChain(10);
        chain[0] = new ValueString('1');
        Assert.That(((ValueString)chain.Get(0)).Equals("1"), Is.True);
    }

    /// <summary>
    /// The get test.
    /// </summary>
    [Test]
    public void GetTest()
    {
        var chain = new BaseChain(10);
        chain.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)chain.Get(0)).Equals("1"), Is.True);
    }

    /// <summary>
    /// The set test.
    /// </summary>
    [Test]
    public void SetTest()
    {
        var chain = new BaseChain(10);
        chain.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)chain.Get(0)).Equals("1"), Is.True);
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        var chain = new BaseChain(10);
        chain.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)chain[0]).Equals("1"), Is.True);

        chain.RemoveAt(0);
        Assert.That(chain[0], Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The delete test.
    /// </summary>
    [Test]
    public void DeleteTest()
    {
        var chain = new BaseChain(10);
        chain.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)chain[0]).Equals("1"), Is.True);

        chain.DeleteAt(0);
        Assert.That(chain[0], Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The get length test.
    /// </summary>
    [Test]
    public void GetLengthTest()
    {
        var chain = new BaseChain(10);
        Assert.That(chain.Length, Is.EqualTo(10));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        var chain = new BaseChain("123456789A");

        var clone = (BaseChain)chain.Clone();
        Assert.That(clone, Is.EqualTo(chain));
        Assert.That(clone, Is.Not.SameAs(chain));
    }

    [TestCase(9, 0, "C", 10)]
    [TestCase(9, 2, "A", 11)]
    [TestCase(9, 2, "B", 12)]
    [TestCase(9, 5, "B", 13)]
    [TestCase(9, 7, "A", 14)]
    [TestCase(9, 7, "C", 15)]
    [TestCase(9, 8, "B", 16)]
    [TestCase(9, 0, "A", 17)]
    [TestCase(9, 1, "B", 17)]
    [TestCase(9, 2, "C", 17)]
    [TestCase(9, 3, "A", 17)]
    [TestCase(9, 4, "B", 17)]
    [TestCase(9, 5, "C", 17)]
    [TestCase(9, 6, "A", 17)]
    [TestCase(9, 7, "B", 17)]
    [TestCase(9, 8, "C", 17)]
    public void SetInFullSequenceTests(int sourceIndex, int index, string element, int expectedIndex)
    {
        Chain source = ChainsStorage.Chains[sourceIndex];
        char[] charArraySource = source.ToString().ToCharArray();
        Chain expected = ChainsStorage.Chains[expectedIndex];

        source.Set(new ValueString(element), index);
        Assert.That(source, Is.EqualTo(expected));

        charArraySource[index] = element[0];
        expected = new Chain(new string(charArraySource));
        Assert.That(source, Is.EqualTo(expected));
    }

    [TestCase(18, 0, "A", 19)]
    [TestCase(18, 1, "A", 20)]
    [TestCase(19, 1, "A", 21)]
    [TestCase(19, 1, "B", 22)]
    [TestCase(19, 0, "B", 23)]
    [TestCase(19, 3, "A", 24)]
    [TestCase(19, 5, "B", 25)]
    [TestCase(25, 3, "B", 26)]
    [TestCase(29, 0, "A", 27)]
    public void SetInSparseSequenceTests(int sourceIndex, int index, string element, int expectedIndex)
    {
        Chain source = ChainsStorage.Chains[sourceIndex];
        Chain expected = ChainsStorage.Chains[expectedIndex];

        source.Set(new ValueString(element), index);
        Assert.That(source, Is.EqualTo(expected));
    }
}
