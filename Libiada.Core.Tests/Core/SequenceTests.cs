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

        // Random sequence
        Sequence randomSequence = new(5);
        randomSequence[0] = new ValueInt(3);
        randomSequence[2] = new ValueString("test");
        randomSequence[4] = new ValueInt(7);
        Assert.That(randomSequence.Length, Is.EqualTo(5));
        Assert.That(randomSequence[1], Is.EqualTo(NullValue.Instance()));
        Assert.That(randomSequence[3], Is.EqualTo(NullValue.Instance()));

        // Length 1 sequence
        Sequence singleElementSeq = new(1);
        singleElementSeq[0] = new ValueInt(42);
        Assert.That(singleElementSeq.Length, Is.EqualTo(1));

        // Empty sequence
        Sequence emptySeq = new(0);
        Assert.That(emptySeq.Length, Is.EqualTo(0));
    }


    // Create sequence with elements 
    [Test]
    public void ConstrutorWithElementsTest()
    {
        var elements = new IBaseObject[] { new ValueInt(1), new ValueInt(2), new ValueInt(1) };
        var uniqueElements = new IBaseObject[] { new ValueInt(1), new ValueInt(2), new ValueInt(3) };
        var repeatedElement = new IBaseObject[] { new ValueInt(1), new ValueInt(1), new ValueInt(1) };
        var singleElement = new IBaseObject[] { new ValueInt(1) };
        var emptyElements = new IBaseObject[] { };

        Sequence sequence = new(elements);
        Sequence uniqueSequence = new(uniqueElements);
        Sequence repeatedSequence = new(repeatedElement);
        Sequence singleElementSequence = new(singleElement);
        Sequence emptySequence = new(emptyElements);

        Assert.That(sequence.Length, Is.EqualTo(3));
        Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(2));
        Assert.That(sequence.Order, Is.EqualTo(new int[] { 1, 2, 1 }));

        Assert.That(uniqueSequence.Length, Is.EqualTo(3));
        Assert.That(uniqueSequence.Alphabet.Cardinality, Is.EqualTo(3));
        Assert.That(uniqueSequence.Order, Is.EqualTo(new int[] { 1, 2, 3 }));

        Assert.That(repeatedSequence.Length, Is.EqualTo(3));
        Assert.That(repeatedSequence.Alphabet.Cardinality, Is.EqualTo(1));
        Assert.That(repeatedSequence.Order, Is.EqualTo(new int[] { 1, 1, 1 }));

        Assert.That(singleElementSequence.Length, Is.EqualTo(1));
        Assert.That(singleElementSequence.Alphabet.Cardinality, Is.EqualTo(1));
        Assert.That(singleElementSequence.Order, Is.EqualTo(new int[] { 1 }));

        Assert.That(emptySequence.Length, Is.EqualTo(0));
        Assert.That(emptySequence.Alphabet.Cardinality, Is.EqualTo(0));
        Assert.That(emptySequence.Order, Is.Empty);

    }

    // Create a sequence using the provided order and alphabet directly
    [Test]
    public void ConstructorWithOrderAndAlphabetTest()
    {
        // Test case 1: Basic sequence with repeating elements
        int[] order1 = { 0, 1, 0 };
        Alphabet alphabet1 = new() { new ValueInt(5), new ValueInt(7) };
        Sequence sequence1 = new(order1, alphabet1);

        Assert.Multiple(() =>
        {
            Assert.That(sequence1.Length, Is.EqualTo(3));
            Assert.That(sequence1.Alphabet.Cardinality, Is.EqualTo(1));
            Assert.That(sequence1.Order, Is.EqualTo(new int[] { 0, 1, 0 }));
        });

        // Test case 2: Larger alphabet and order
        int[] order2 = { 0, 1, 2, 3, 1, 0 };
        Alphabet alphabet2 = new()
        {
            new ValueInt(10),
            new ValueInt(20),
            new ValueInt(30),
            new ValueInt(40)
        };
        Sequence sequence2 = new(order2, alphabet2);

        Assert.Multiple(() =>
        {
            Assert.That(sequence2.Length, Is.EqualTo(6));
            Assert.That(sequence2.Alphabet.Cardinality, Is.EqualTo(3));
            Assert.That(sequence2.Order, Is.EqualTo(new int[] { 0, 1, 2, 3, 1, 0 }));
        });

        // Test case 3: Single element alphabet
        int[] order3 = { 0, 0, 0 };
        Alphabet alphabet3 = new() { new ValueInt(1) };
        Sequence sequence3 = new(order3, alphabet3);

        Assert.Multiple(() =>
        {
            Assert.That(sequence3.Length, Is.EqualTo(3));
            Assert.That(sequence3.Alphabet.Cardinality, Is.EqualTo(0));
            Assert.That(sequence3.Order, Is.EqualTo(new int[] { 0, 0, 0 }));
        });

        // Test case 4: Mixed value types in alphabet
        int[] order5 = { 0, 1, 2, 1 };
        Alphabet alphabet5 = new()
        {
            new ValueInt(1),
            new ValueString("test"),
            new ValueInt(3)
        };
        Sequence sequence5 = new(order5, alphabet5);

        Assert.Multiple(() =>
        {
            Assert.That(sequence5.Length, Is.EqualTo(4));
            Assert.That(sequence5.Alphabet.Cardinality, Is.EqualTo(2));
            Assert.That(sequence5.Order, Is.EqualTo(new int[] { 0, 1, 2, 1 }));
        });

        // Test case 5: Alphabet smaller than order requires
        int[] order = { 1, 2, 3, 4 };
        Alphabet smallAlphabet = new() { new ValueInt(1), new ValueInt(2) };
        Assert.Throws<ArgumentException>(() => new Sequence(order, smallAlphabet));

        // Test case 6: Alphabet larger than order uses
        int[] smallOrder = { 1, 2, 1 };
        Alphabet largeAlphabet = new()
        {
            new ValueInt(1),
            new ValueInt(2),
            new ValueInt(3),
            new ValueInt(4)
        };
        Assert.Throws<ArgumentException>(() => new Sequence(smallOrder, largeAlphabet));

    }

    [Test]
    [Ignore("Must Fall")]
    public void AlphabetWithoutNullValueTest()
    {
        Alphabet noNullAlphabet = new() { new ValueInt(1) };
        Assert.Throws<ArgumentException>(() => new Sequence(new int[] { 0 }, noNullAlphabet));
    }

    // Create a sequence with numeric alphabet (1 to max order value)
    [Test]
    public void ConstructorWithOrderTest()
    {
        // Test case 1: Basic sequence with repeating elements
        Sequence sequence1 = new(new int[] { 1, 2, 1 });
        Assert.Multiple(() =>
        {
            Assert.That(sequence1.Length, Is.EqualTo(3));
            Assert.That(sequence1.Alphabet.Cardinality, Is.EqualTo(2));
            Assert.That(sequence1.Order, Is.EqualTo(new int[] { 1, 2, 1 }));
        });

        // Test case 2: Sequence with consecutive numbers
        Sequence sequence2 = new(new int[] { 1, 2, 3, 4 });
        Assert.Multiple(() =>
        {
            Assert.That(sequence2.Length, Is.EqualTo(4));
            Assert.That(sequence2.Alphabet.Cardinality, Is.EqualTo(4));
            Assert.That(sequence2.Order, Is.EqualTo(new int[] { 1, 2, 3, 4 }));
        });

        // Test case 3: Single element sequence
        Sequence sequence3 = new(new int[] { 1 });
        Assert.Multiple(() =>
        {
            Assert.That(sequence3.Length, Is.EqualTo(1));
            Assert.That(sequence3.Alphabet.Cardinality, Is.EqualTo(1));
            Assert.That(sequence3.Order, Is.EqualTo(new int[] { 1 }));
        });

        // Test case 4: Non-sequential numbers
        Sequence sequence5 = new(new int[] { 5, 3, 5, 1 });
        Assert.Multiple(() =>
        {
            Assert.That(sequence5.Length, Is.EqualTo(4));
            Assert.That(sequence5.Alphabet.Cardinality, Is.EqualTo(5));
            Assert.That(sequence5.Order, Is.EqualTo(new int[] { 5, 3, 5, 1 }));
        });

        // Test case 5: Array not starting with 1
        Sequence nonSequentialSequence = new(new int[] { 3, 5, 4, 3 });
        Assert.That(nonSequentialSequence.Order, Is.EqualTo(new int[] { 3, 5, 4, 3 }));
        Assert.That(nonSequentialSequence.Alphabet.Cardinality, Is.EqualTo(5));

        // Test case 6: Element 2 appears before 3
        Sequence outOfOrderSequence = new(new int[] { 1, 2, 4, 3, 2 });
        Assert.That(outOfOrderSequence.Order, Is.EqualTo(new int[] { 1, 2, 4, 3, 2 }));
        Assert.That(outOfOrderSequence.Alphabet.Cardinality, Is.EqualTo(4));
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

    // Checking for equals
    [Test]
    public void EqualWithDifferentValuesTest()
    {
        Sequence sequence1 = new Sequence("ABC");
        Sequence sequence2 = new Sequence("ABC");
        Sequence sequence3 = new Sequence("ABD");
        Sequence sequence4 = sequence1;
        Assert.That(sequence1.Equals(sequence2), Is.True);
        Assert.That(sequence1.Equals(sequence3), Is.False);
        Assert.That(sequence1.Equals(sequence4), Is.True);
        Assert.That(sequence1.Equals(null), Is.False);
        Assert.That(sequence1.Equals("not a sequence"), Is.False);

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
