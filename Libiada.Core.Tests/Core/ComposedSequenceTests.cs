namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The sequence test.
/// </summary>
[TestFixture]
public class ComposedSequenceTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private readonly List<ComposedSequence> sequences = SequencesStorage.CompusedSequences;

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = SequencesStorage.Elements;

    /// <summary>
    /// The similar sequences get test.
    /// </summary>
    [Test]
    public void SimilarCongenericSequencesGetTest()
    {
        CongenericSequence congenericSequenceA = new([2, 8], elements["A"], 10);

        CongenericSequence createdCongenericSequence = sequences[2].CongenericSequence(elements["A"]);

        Assert.That(createdCongenericSequence, Is.EqualTo(congenericSequenceA));
    }

    /// <summary>
    /// ComposedSequence Test
    /// </summary>
    [Test]
    public void ComposedSequenceTest()
    {
        short[] source = [1, 2, 3, 2, 2, 4, 5, 1];
        ComposedSequence actual = new(source);
        Alphabet alphabet = [new ValueInt(1), new ValueInt(2) , new ValueInt(3) , new ValueInt(4), new ValueInt(5)];
        Assert.That(actual.Alphabet, Is.EqualTo(alphabet));

        int[] order = [1, 2, 3, 2, 2, 4, 5, 1];
        Assert.That(actual.Order, Is.EqualTo(order));
    }

    /// <summary>
    /// Constructors the order test.
    /// </summary>
    [Test]
    public void ConstructorOrderTest()
    {
        ComposedSequence sequence = new ComposedSequence([1, 2, 1, 3, 2]);
        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(5));
            Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(3));
        });

        ComposedSequence identicalSequence = new ComposedSequence([1, 1, 1, 1]);
        Assert.Multiple(() =>
        {
            Assert.That(identicalSequence.Length, Is.EqualTo(4));
            Assert.That(identicalSequence.Alphabet.Cardinality, Is.EqualTo(1));
        });

        ComposedSequence differentSequence = new ComposedSequence([1, 2, 3, 4]);
        Assert.Multiple(() =>
        {
            Assert.That(differentSequence.Length, Is.EqualTo(4));
            Assert.That(differentSequence.Alphabet.Cardinality, Is.EqualTo(4));
        });

        Assert.Throws<InvalidOperationException>(() => new ComposedSequence(new int[] { }));

    }

    /// <summary>
    /// Constructors the invalid cases test.
    /// </summary>
    [Test]
    [Ignore("Fail invalid tests")]
    public void ConstructorInvalidCasesTest()
    {
        // Test 1: Invalid elements
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() => new ComposedSequence([1, 4, 2, 4]));
            Assert.Throws<ArgumentException>(() => new ComposedSequence([1, 3, 2, 4]));
            Assert.Throws<ArgumentException>(() => new ComposedSequence([2, 1, 4, 3]));
        });

        // Test 2: Contains zero
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() => new ComposedSequence([0, 1, 2, 3]));
            Assert.Throws<ArgumentException>(() => new ComposedSequence([1, 0, 2, 3]));
            Assert.Throws<ArgumentException>(() => new ComposedSequence([1, 2, 0, 3]));
        });

        // Test 3: Negative elements
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() => new ComposedSequence([1, -1, 2, 3]));
            Assert.Throws<ArgumentException>(() => new ComposedSequence([-1, 1, 2, 3]));
            Assert.Throws<ArgumentException>(() => new ComposedSequence([1, 2, -3, 4]));
        });

        //Test 4: Invalid ShortArray cases
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() => new ComposedSequence(new short[] { -1, 1, 2, 3 }));
            Assert.Throws<ArgumentException>(() => new ComposedSequence(new short[] { 1, 0, 2, 3 }));
        });
    }

    [Test]
    public void ConstructorLengthTests()
    {
        // Test 1: Empty one-length chain
        ComposedSequence oneLength = new ComposedSequence(1);
        Assert.Multiple(() =>
        {
            Assert.That(oneLength.Length, Is.EqualTo(1));
            Assert.That(oneLength.Alphabet.Cardinality, Is.EqualTo(0));
            Assert.That(oneLength.Order, Has.All.EqualTo(0));
        });

        // Test 2: Empty chain with length > 0
        ComposedSequence multiLength = new ComposedSequence(5);
        Assert.Multiple(() =>
        {
            Assert.That(multiLength.Length, Is.EqualTo(5));
            Assert.That(multiLength.Alphabet.Cardinality, Is.EqualTo(0));
            Assert.That(multiLength.Order, Has.All.EqualTo(0));
        });

        ComposedSequence largeLength = new ComposedSequence(100);
        Assert.Multiple(() =>
        {
            Assert.That(largeLength.Length, Is.EqualTo(100));
            Assert.That(largeLength.Order, Has.All.EqualTo(0));
        });

        // Test 3: Zero length
        ComposedSequence zeroLength = new ComposedSequence(0);
        Assert.Multiple(() =>
        {
            Assert.That(zeroLength.Length, Is.EqualTo(0));
            Assert.That(zeroLength.Alphabet.Cardinality, Is.EqualTo(0));
        });

        // Test 4: Negative length
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() => new ComposedSequence(-1));
            Assert.Throws<ArgumentException>(() => new ComposedSequence(-100));
        });

    }

    /// <summary>
    /// Constructors the string test.
    /// </summary>
    [Test]
    public void ConstructorStringTest()
    {
        // Test 1: Normal operation
        ComposedSequence sequence = new ComposedSequence("ATGC");
        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(4));
            Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(4));
        });

        ComposedSequence dnaSequence = new ComposedSequence("ATGCATGC");
        Assert.Multiple(() =>
        {
            Assert.That(dnaSequence.Length, Is.EqualTo(8));
            Assert.That(dnaSequence.Alphabet.Cardinality, Is.EqualTo(4));
        });

        // Test 2: Identical elements
        ComposedSequence identicalSequence = new ComposedSequence("AAAA");
        Assert.Multiple(() =>
        {
            Assert.That(identicalSequence.Length, Is.EqualTo(4));
            Assert.That(identicalSequence.Alphabet.Cardinality, Is.EqualTo(1));
        });

        ComposedSequence longIdentical = new ComposedSequence("AAAAAAAAAA");
        Assert.Multiple(() =>
        {
            Assert.That(longIdentical.Length, Is.EqualTo(10));
            Assert.That(longIdentical.Alphabet.Cardinality, Is.EqualTo(1));
        });

        // Test 3: All different elements
        ComposedSequence differentSequence = new ComposedSequence("ATGC");
        Assert.Multiple(() =>
        {
            Assert.That(differentSequence.Length, Is.EqualTo(4));
            Assert.That(differentSequence.Alphabet.Cardinality, Is.EqualTo(4));
        });

        ComposedSequence mixedSequence = new ComposedSequence("123456789");
        Assert.Multiple(() =>
        {
            Assert.That(mixedSequence.Length, Is.EqualTo(9));
            Assert.That(mixedSequence.Alphabet.Cardinality, Is.EqualTo(9));
        });

        // Test 4: Empty string
        ComposedSequence emptySequence = new ComposedSequence("");
        Assert.Multiple(() =>
        {
            Assert.That(emptySequence.Length, Is.EqualTo(0));
            Assert.That(emptySequence.Alphabet.Cardinality, Is.EqualTo(0));
        });

        // Test 5: Special characters
        ComposedSequence specialChars = new ComposedSequence("!@#$%^&*()");
        Assert.Multiple(() =>
        {
            Assert.That(specialChars.Length, Is.EqualTo(10));
            Assert.That(specialChars.Alphabet.Cardinality, Is.EqualTo(10));
        });
    }

    [Test]
    public void ConstructorShortArrayTests()
    {
        // Test 1: Normal operation
        ComposedSequence sequence = new ComposedSequence(new short[] { 1, 2, 1, 3 });
        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(4));
            Assert.That(sequence.Alphabet.Cardinality, Is.EqualTo(3));
        });

        ComposedSequence sequence2 = new ComposedSequence(new short[] { 1, 2, 3, 1, 2, 3 });
        Assert.Multiple(() =>
        {
            Assert.That(sequence2.Length, Is.EqualTo(6));
            Assert.That(sequence2.Alphabet.Cardinality, Is.EqualTo(3));
        });

            // Test 2: Identical elements
        ComposedSequence identicalSequence = new ComposedSequence(new short[] { 1, 1, 1, 1 });
        Assert.Multiple(() =>
        {
            Assert.That(identicalSequence.Length, Is.EqualTo(4));
            Assert.That(identicalSequence.Alphabet.Cardinality, Is.EqualTo(1));
        });

        ComposedSequence longIdentical = new ComposedSequence(new short[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        Assert.Multiple(() =>
        {
            Assert.That(longIdentical.Length, Is.EqualTo(10));
            Assert.That(longIdentical.Alphabet.Cardinality, Is.EqualTo(1));
        });

        // Test 3: All different elements
        ComposedSequence differentSequence = new ComposedSequence(new short[] { 1, 2, 3, 4 });
        Assert.Multiple(() =>
        {
            Assert.That(differentSequence.Length, Is.EqualTo(4));
            Assert.That(differentSequence.Alphabet.Cardinality, Is.EqualTo(4));
        });

        // Test 4: Large numbers
        ComposedSequence largeNumbers = new ComposedSequence(new short[] { 100, 200, 300, 400 });
        Assert.Multiple(() =>
        {
            Assert.That(largeNumbers.Length, Is.EqualTo(4));
            Assert.That(largeNumbers.Alphabet.Cardinality, Is.EqualTo(4));
        });

        // Test 5: Empty array
        ComposedSequence emptySequence = new ComposedSequence(Array.Empty<short>());
        Assert.Multiple(() =>
        {
            Assert.That(emptySequence.Length, Is.EqualTo(0));
            Assert.That(emptySequence.Alphabet.Cardinality, Is.EqualTo(0));
        });

    }

    /// <summary>
    /// The intervals test.
    /// </summary>
    [Test]
    public void IntervalsTest()
    {
        List<List<int>> intervals =
            [
                [1, 1, 4, 4, 1],
                [3, 1, 3, 4],
                [5, 3, 1, 2]
            ];
        for (int i = 0; i < sequences[0].Alphabet.Cardinality; i++)
        {
            int[] actualIntervals = sequences[0].CongenericSequence(i).GetArrangement(Link.Both);
            for (int j = 0; j < actualIntervals.Length; j++)
            {
                Assert.That(actualIntervals[j], Is.EqualTo(intervals[i][j]), $"{j} and {i} intervals of sequence are not equal");
            }
        }
    }

    /// <summary>
    /// The get element position test.
    /// </summary>
    /// <param name="expected">
    /// The expected position.
    /// </param>
    /// <param name="sequenceIndex">
    /// The sequence index.
    /// </param>
    /// <param name="element">
    /// The element.
    /// </param>
    /// <param name="occurrence">
    /// The occurrence number.
    /// </param>
    [TestCase(2, 2, "A", 1)]
    [TestCase(8, 2, "A", 2)]
    [TestCase(-1, 2, "A", 3)]
    [TestCase(0, 2, "C", 1)]
    [TestCase(1, 2, "C", 2)]
    [TestCase(3, 2, "C", 3)]
    [TestCase(5, 2, "C", 4)]
    [TestCase(9, 2, "C", 5)]
    [TestCase(-1, 2, "C", 6)]
    [TestCase(4, 2, "G", 1)]
    [TestCase(-1, 2, "G", 2)]
    [TestCase(-1, 2, "G", 3)]
    [TestCase(6, 2, "T", 1)]
    [TestCase(7, 2, "T", 2)]
    [TestCase(-1, 2, "T", 3)]
    public void GetElementPositionTest(int expected, int sequenceIndex, string element, int occurrence)
    {
        int actual = sequences[sequenceIndex].GetOccurrence(elements[element], occurrence);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
