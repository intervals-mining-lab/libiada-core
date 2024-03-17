namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The alphabet test.
/// </summary>
[TestFixture]
public class AlphabetTests
{
    /// <summary>
    /// The first alphabet.
    /// </summary>
    private Alphabet firstAlphabet;

    /// <summary>
    /// The second alphabet.
    /// </summary>
    private Alphabet secondAlphabet;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        firstAlphabet = [];
        secondAlphabet = [];
    }

    /// <summary>
    /// The constructor test.
    /// </summary>
    [Test]
    public void ConstructorTest()
    {
        Assert.That(firstAlphabet, Is.Not.Null);
        Assert.That(firstAlphabet.Cardinality, Is.Zero);
    }

    /// <summary>
    /// The add same test.
    /// </summary>
    [Test]
    public void AddSameTest()
    {
        firstAlphabet.Add(new ValueInt(2));
        Assert.Throws<ArgumentException>(() => firstAlphabet.Add(new ValueInt(2)));
    }

    /// <summary>
    /// Tests that all elements in alphabet are unique.
    /// </summary>
    [Test]
    public void UniqueElementsTest()
    {
        firstAlphabet.Add(new ValueInt(2));
        firstAlphabet.Add(new ValueInt(3));
        firstAlphabet.Add(new ValueInt(4));
        firstAlphabet.Add(new ValueInt(5));
        firstAlphabet.Add(new ValueString("2"));
        firstAlphabet.Add(new ValueString("3"));
        firstAlphabet.Add(new ValueString("5"));
        firstAlphabet.Add(new ValueString("1"));
        firstAlphabet[0] = new ValueString("3");
        Assert.Throws<ArgumentException>(() => firstAlphabet.Add(new ValueInt(5)));
        Assert.That(firstAlphabet, Is.Unique);
    }

    /// <summary>
    /// The get test.
    /// </summary>
    [Test]
    public void GetTest()
    {
        firstAlphabet.Add(new ValueInt(2));
        firstAlphabet.Add(new ValueInt(3));
        firstAlphabet.Add(new ValueInt(4));
        firstAlphabet.Add(new ValueInt(5));
        Assert.That(firstAlphabet[0], Is.EqualTo(new ValueInt(2)));
        Assert.That(firstAlphabet[1], Is.EqualTo(new ValueInt(3)));
        Assert.That(firstAlphabet[2], Is.EqualTo(new ValueInt(4)));
        Assert.That(firstAlphabet[3], Is.EqualTo(new ValueInt(5)));
    }

    /// <summary>
    /// The independent number test.
    /// </summary>
    [Test]
    public void IndependentNumberTest()
    {
        firstAlphabet.Add(new ValueInt(2));
        firstAlphabet.Add(new ValueInt(1));
        firstAlphabet.Add(new ValueInt(3));
        firstAlphabet.Add(new ValueInt(4));
        firstAlphabet[0] = new ValueInt(3);
        Assert.That(firstAlphabet[0], Is.EqualTo(new ValueInt(2)));
        Assert.That(firstAlphabet[1], Is.EqualTo(new ValueInt(1)));
        Assert.That(firstAlphabet[2], Is.EqualTo(new ValueInt(3)));
        Assert.That(firstAlphabet[3], Is.EqualTo(new ValueInt(4)));
    }

    /// <summary>
    /// The independent string test.
    /// </summary>
    [Test]
    public void IndependentStringTest()
    {
        firstAlphabet.Add(new ValueString("2"));
        firstAlphabet.Add(new ValueString("3"));
        firstAlphabet.Add(new ValueString("5"));
        firstAlphabet.Add(new ValueString("1"));
        firstAlphabet[0] = new ValueString("3");
        Assert.That(firstAlphabet[0], Is.EqualTo(new ValueString("2")));
        Assert.That(firstAlphabet[1], Is.EqualTo(new ValueString("3")));
        Assert.That(firstAlphabet[2], Is.EqualTo(new ValueString("5")));
        Assert.That(firstAlphabet[3], Is.EqualTo(new ValueString("1")));
    }

    /// <summary>
    /// The null test.
    /// </summary>
    [Test]
    public void NullTest()
    {
        Assert.Throws<ArgumentNullException>(() => firstAlphabet.Add(null));
    }

    /// <summary>
    /// The cardinality test.
    /// </summary>
    [Test]
    public void CardinalityTest()
    {
        firstAlphabet.Add(new ValueInt(100));
        firstAlphabet.Add(new ValueInt(200));
        firstAlphabet.Add(new ValueInt(300));
        Assert.That(firstAlphabet.Cardinality, Is.EqualTo(3));
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        firstAlphabet.Add(new ValueInt(100));
        firstAlphabet.Add(new ValueInt(200));
        firstAlphabet.Add(new ValueInt(300));
        firstAlphabet.Add(new ValueInt(400));
        firstAlphabet.Remove(2);
        Assert.That(firstAlphabet.Cardinality, Is.EqualTo(3));
        Assert.That(firstAlphabet[2], Is.EqualTo(new ValueInt(400)));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        var clone = firstAlphabet.Clone();

        Assert.That(firstAlphabet, Is.Not.SameAs(clone));

        Assert.That(firstAlphabet, Is.EqualTo(clone));
    }

    /// <summary>
    /// The equals tests.
    /// </summary>
    /// <param name="firstElementsList">
    /// First alphabet elements list.
    /// </param>
    /// <param name="secondElementsList">
    /// Second alphabet elements list.
    /// </param>
    /// <param name="equals">
    /// Equals flag.
    /// </param>
    [TestCase(new[] { "a", "b", "c" }, new[] { "a", "b", "c" }, true)]
    [TestCase(new[] { "a", "b", "c", "d" }, new[] { "a", "b", "c" }, false)]
    [TestCase(new[] { "a", "c", "b" }, new[] { "a", "b", "c" }, false)]
    [TestCase(new[] { "c", "b", "a" }, new[] { "a", "b", "c", "d" }, false)]
    [TestCase(new[] { "aa", "bb", "cc" }, new[] { "a", "b", "c" }, false)]
    [TestCase(new[] { "aa", "bb", "cc" }, new string[0], false)]
    [TestCase(new string[0], new string[0], true)]
    public void EqualsTests(string[] firstElementsList, string[] secondElementsList, bool equals)
    {
        foreach (string element in firstElementsList)
        {
            firstAlphabet.Add(new ValueString(element));
        }

        foreach (string element in secondElementsList)
        {
            secondAlphabet.Add(new ValueString(element));
        }

        Assert.That(firstAlphabet.Equals(secondAlphabet), Is.EqualTo(equals));
        Assert.That(secondAlphabet.Equals(firstAlphabet), Is.EqualTo(equals));
    }

    /// <summary>
    /// Tests for alphabets comparison as sets.
    /// </summary>
    /// <param name="firstElementsList">
    /// First alphabet elements list.
    /// </param>
    /// <param name="secondElementsList">
    /// Second alphabet elements list.
    /// </param>
    /// <param name="equals">
    /// Equals flag.
    /// </param>
    [TestCase(new[] { "a", "b", "c" }, new[] { "a", "b", "c" }, true)]
    [TestCase(new[] { "a", "b", "c", "d" }, new[] { "a", "b", "c" }, false)]
    [TestCase(new[] { "a", "c", "b" }, new[] { "a", "b", "c" }, true)]
    [TestCase(new[] { "c", "b", "a" }, new[] { "a", "b", "c", "d" }, false)]
    [TestCase(new[] { "aa", "bb", "cc" }, new[] { "a", "b", "c" }, false)]
    [TestCase(new[] { "aa", "bb", "cc" }, new string[0], false)]
    [TestCase(new string[0], new string[0], true)]
    public void SetEqualsTests(string[] firstElementsList, string[] secondElementsList, bool equals)
    {
        foreach (string element in firstElementsList)
        {
            firstAlphabet.Add(new ValueString(element));
        }

        foreach (string element in secondElementsList)
        {
            secondAlphabet.Add(new ValueString(element));
        }

        Assert.That(firstAlphabet.SetEquals(secondAlphabet), Is.EqualTo(equals));
        Assert.That(secondAlphabet.SetEquals(firstAlphabet), Is.EqualTo(equals));
    }

    /// <summary>
    /// Tests for alphabets comparison as sets.
    /// With alphabets containing NullValue.
    /// </summary>
    [Test]
    public void SetEqualsWithNullValueTest()
    {
        firstAlphabet.Add(NullValue.Instance());
        firstAlphabet.Add((ValueInt)1);
        firstAlphabet.Add((ValueString)"a");
        firstAlphabet.Add((ValueInt)2);
        secondAlphabet.Add(NullValue.Instance());
        secondAlphabet.Add((ValueInt)1);
        secondAlphabet.Add((ValueString)"a");
        secondAlphabet.Add((ValueInt)2);
        Assert.That(firstAlphabet.SetEquals(secondAlphabet), Is.True);

        firstAlphabet = [NullValue.Instance(), (ValueInt)1, (ValueString)"a", (ValueInt)2];
        secondAlphabet = [NullValue.Instance(), (ValueInt)2, (ValueInt)1, (ValueString)"a"];
        Assert.That(firstAlphabet.SetEquals(secondAlphabet), Is.True);

        firstAlphabet = [NullValue.Instance(), (ValueInt)1, (ValueString)"a", (ValueInt)2];
        secondAlphabet = [(ValueInt)2, (ValueInt)1, (ValueString)"a"];
        Assert.That(firstAlphabet.SetEquals(secondAlphabet), Is.False);
        Assert.That(secondAlphabet.SetEquals(firstAlphabet), Is.False);
    }

    /// <summary>
    /// The contains test.
    /// </summary>
    [Test]
    public void ContainsTest()
    {
        firstAlphabet.Add(new ValueString('a'));
        firstAlphabet.Add(new ValueString('b'));
        firstAlphabet.Add(new ValueString('c'));
        Assert.That(firstAlphabet.Contains(new ValueString('a')), Is.True);
        Assert.That(firstAlphabet.Contains(new ValueString('b')), Is.True);
        Assert.That(firstAlphabet.Contains(new ValueString('c')), Is.True);
        Assert.That(firstAlphabet.Contains(new ValueString('d')), Is.False);
    }

    /// <summary>
    /// The index of test.
    /// </summary>
    [Test]
    public void IndexOfTest()
    {
        firstAlphabet.Add(new ValueString('a'));
        firstAlphabet.Add(new ValueString('b'));
        firstAlphabet.Add(new ValueString('c'));
        Assert.That(firstAlphabet.IndexOf(new ValueString('d')), Is.EqualTo(-1));
        Assert.That(firstAlphabet.IndexOf(new ValueString('a')), Is.Zero);
        Assert.That(firstAlphabet.IndexOf(new ValueString('c')), Is.EqualTo(2));
    }

    /// <summary>
    /// Testing that alphabet creates internal copy of the element
    /// so it cannot be changed from outside.
    /// </summary>
    [Test]
    public void ToArrayTest()
    {
        var a = new ValueString('a');
        var c = new ValueString('c');
        var e = new ValueString('e');

        firstAlphabet.Add(a);
        firstAlphabet.Add(new ValueString('b'));
        firstAlphabet.Add(c);
        firstAlphabet.Add(new ValueString('d'));
        firstAlphabet.Add(e);

        Assert.Multiple(() =>
        {
            Assert.That(firstAlphabet[4], Is.Not.SameAs(e));
            Assert.That(firstAlphabet[2], Is.Not.SameAs(c));
            Assert.That(firstAlphabet[0], Is.Not.SameAs(a));
        });
    }

    /// <summary>
    /// Testing alphabet to string conversion.
    /// </summary>
    [Test]
    public void ToStringTest()
    {
        firstAlphabet.Add(NullValue.Instance());
        firstAlphabet.Add((ValueInt)1);
        firstAlphabet.Add((ValueString)"a");
        firstAlphabet.Add((ValueInt)2);

        var result = firstAlphabet.ToString();
        Assert.That(result, Is.EqualTo("< -, 1, a, 2 >"));
    }
}
