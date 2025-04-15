namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The sequence test.
/// </summary>
[TestFixture]
public class SequenceTests
{
    /// <summary>
    /// The constructor with given length test.
    /// </summary>
    [Test]
    public void ConstructorWithLengthTest()
    {
        Sequence sequence = new(100);
        Assert.That(sequence.Length, Is.EqualTo(100));
        int[] expectedOrder = new int[100];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        Alphabet expectedAlphabet = [];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));
    }


    // Create sequence with elements 
    [Test]
    public void ConstrutorWithElementsTest()
    {
        var elements = new IBaseObject[] { new ValueInt(1), new ValueInt(2), new ValueInt(1) };
        Sequence sequence = new(elements);

        Assert.That(sequence.Length, Is.EqualTo(3));
        Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(2));
        Assert.That(sequence.Order, Is.EqualTo(new int[] { 1, 2, 1 }));

        Assert.That(sequence.Length, Is.Not.EqualTo(4));
        Assert.That(sequence.Alphabet.Cardinality, Is.Not.EqualTo(3));
        Assert.That(sequence.Order, Is.Not.EqualTo(new int[] { 1, 2, 2 }));
    }

    // Create a sequence using the provided order and alphabet directly
    [Test]
    public void ConstructorWithOrderAndAlphabetTest()
    {
        int[] order = { 0, 1, 0 };
        Alphabet alphabet = new() { new ValueInt(5), new ValueInt(7) };

        Sequence sequence = new(order, alphabet);

        Assert.That(sequence.Length, Is.EqualTo(3));
        Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(1));
        Assert.That(sequence.Order, Is.EqualTo(new int[] {0,1,0}));
    }

    // Create a sequence with numeric alphabet (1 to max order value)
    [Test]
    public void ConstructorWithOrderTest()
    {
        Sequence sequence = new(new int[] { 1, 2, 1 });

        Assert.That(sequence.Length, Is.EqualTo(3));
        Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(2));
        Assert.That(sequence.Order, Is.EqualTo(new int[] { 1, 2, 1 }));

        Assert.That(sequence.Length, Is.Not.EqualTo(4));
        Assert.That(sequence.Alphabet.Cardinality, Is.Not.EqualTo(3));
        Assert.That(sequence.Order, Is.Not.EqualTo(new int[] { 1, 2, 2 }));
    }

    // Create a sequence using provided order and alphabet and store the given ID
    [Test]
    public void ConstructorWithOrderAlphabetAndIdTest()
    {
        int[] order = { 0, 1, 0 };
        Alphabet alphabet = new() { new ValueInt(4), new ValueInt(5) };
        long id = 11;

        Sequence sequence = new(order, alphabet, id);

        Assert.That(sequence.Length, Is.EqualTo(3));
        Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(1));
        Assert.That(sequence.Order, Is.EqualTo(new int[] { 0, 1, 0 }));
        Assert.That(sequence.Id, Is.EqualTo(11));

        Assert.That(sequence.Length, Is.Not.EqualTo(4));
        Assert.That(sequence.Alphabet.Cardinality, Is.Not.EqualTo(3));
        Assert.That(sequence.Order, Is.Not.EqualTo(new int[] { 1, 2, 2 }));
        Assert.That(sequence.Id, Is.Not.EqualTo(21));

    }

    /// <summary>
    /// The constructor with less than zero length test.
    /// </summary>
    [Test]
    public void ConstructorLessZeroLengthTest()
    {
        Assert.Throws<ArgumentException>(() => new Sequence(-10));
    }

    /// <summary>
    /// Constructor with string tests.
    /// </summary>
    [Test]
    public void ConstructorWithStringTest()
    {
        Sequence sequence = new("A");
        Assert.That(sequence.Length, Is.EqualTo(1));
        int[] expectedOrder = [1];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        Alphabet expectedAlphabet = [(ValueString)"A"];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));

        sequence = new Sequence("ABC");
        Assert.That(sequence.Length, Is.EqualTo(3));
        expectedOrder = [1, 2, 3];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"A", (ValueString)"B", (ValueString)"C"];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));

        sequence = new Sequence("AAABBBCCC");
        Assert.That(sequence.Length, Is.EqualTo(9));
        expectedOrder = [1, 1, 1, 2, 2, 2, 3, 3, 3];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"A", (ValueString)"B", (ValueString)"C"];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));

        sequence = new Sequence("AAABBBCCC");
        Assert.That(sequence.Length, Is.EqualTo(9));
        expectedOrder = [1, 1, 1, 2, 2, 2, 3, 3, 3];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"A", (ValueString)"B", (ValueString)"C"];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));

        sequence = new Sequence("BBBCCCAAA");
        Assert.That(sequence.Length, Is.EqualTo(9));
        expectedOrder = [1, 1, 1, 2, 2, 2, 3, 3, 3];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"B", (ValueString)"C", (ValueString)"A"];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));

        sequence = new Sequence("BBB---");
        Assert.That(sequence.Length, Is.EqualTo(6));
        expectedOrder = [1, 1, 1, 2, 2, 2];
        Assert.That(sequence.Order, Is.EqualTo(expectedOrder));
        expectedAlphabet = [(ValueString)"B", (ValueString)"-"];
        Assert.That(sequence.Alphabet, Is.EqualTo(expectedAlphabet));
    }

    /// <summary>
    /// The get by this test.
    /// </summary>
    [Test]
    public void GetByThisTest()
    {
        Sequence sequence = new(10);
        sequence.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)sequence[0]).Equals("1"), Is.True);
    }

    /// <summary>
    /// The set by this test.
    /// </summary>
    [Test]
    public void SetByThisTest()
    {
        Sequence sequence = new(10);
        sequence[0] = new ValueString('1');
        Assert.That(((ValueString)sequence.Get(0)).Equals("1"), Is.True);
    }

    /// <summary>
    /// The get test.
    /// </summary>
    [Test]
    public void GetTest()
    {
        Sequence sequence = new(10);
        sequence.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)sequence.Get(0)).Equals("1"), Is.True);
    }

    /// <summary>
    /// The set test.
    /// </summary>
    [Test]
    public void SetTest()
    {
        Sequence sequence = new(10);
        sequence.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)sequence.Get(0)).Equals("1"), Is.True);
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        Sequence sequence = new(10);
        sequence.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)sequence[0]).Equals("1"), Is.True);

        sequence.RemoveAt(0);
        Assert.That(sequence[0], Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The delete test.
    /// </summary>
    [Test]
    public void DeleteTest()
    {
        Sequence sequence = new(10);
        sequence.Set(new ValueString('1'), 0);
        Assert.That(((ValueString)sequence[0]).Equals("1"), Is.True);

        sequence.DeleteAt(0);
        Assert.That(sequence[0], Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The get length test.
    /// </summary>
    [Test]
    public void GetLengthTest()
    {
        Sequence sequence = new(10);
        Assert.That(sequence.Length, Is.EqualTo(10));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        Sequence sequence = new("123456789A");

        Sequence clone = (Sequence)sequence.Clone();
        Assert.That(clone, Is.EqualTo(sequence));
        Assert.That(clone, Is.Not.SameAs(sequence));
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
        ComposedSequence source = SequencesStorage.CompusedSequences[sourceIndex];
        char[] charArraySource = source.ToString().ToCharArray();
        ComposedSequence expected = SequencesStorage.CompusedSequences[expectedIndex];

        source.Set(new ValueString(element), index);
        Assert.That(source, Is.EqualTo(expected));

        charArraySource[index] = element[0];
        expected = new ComposedSequence(new string(charArraySource));
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
        ComposedSequence source = SequencesStorage.CompusedSequences[sourceIndex];
        ComposedSequence expected = SequencesStorage.CompusedSequences[expectedIndex];

        source.Set(new ValueString(element), index);
        Assert.That(source, Is.EqualTo(expected));
    }
}
