namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The congeneric sequence test.
/// </summary>
[TestFixture]
public class CongenericSequenceTests
{
    /// <summary>
    /// The message.
    /// </summary>
    private ValueString message;

    /// <summary>
    /// The wrong message.
    /// </summary>
    private ValueString wrongMessage;

    /// <summary>
    /// The congeneric sequence.
    /// </summary>
    private CongenericSequence congenericSequence;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        message = new ValueString('1');
        congenericSequence = new CongenericSequence(message, 10);
        wrongMessage = new ValueString('2');
    }

    /// <summary>
    /// The constructor test.
    /// </summary>
    [Test]
    public void ConstructorTest()
    {
        CongenericSequence sequence = new(new ValueInt(1), 5);
        sequence.Set(1);
        sequence.Set(3);
        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(5));
            Assert.That(sequence.Element, Is.EqualTo(new ValueInt(1)));
            Assert.That(sequence.Positions, Is.EqualTo(new[] { 1, 3 }));
            Assert.That(sequence.OccurrencesCount, Is.EqualTo(2));
        });
    }

    /// <summary>
    /// Constructors the full sequence test.
    /// </summary>
    [Test]
    public void ConstructorFullSequenceTest()
    {
        CongenericSequence sequence = new(new ValueInt(1), 3);
        sequence.Set(0);
        sequence.Set(1);
        sequence.Set(2);
        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(3));
            Assert.That(sequence.OccurrencesCount, Is.EqualTo(3));
            Assert.That(sequence.Positions, Is.EqualTo(new[] { 0, 1, 2 }));
            Assert.That(sequence.Order, Is.EqualTo(new[] { 1, 1, 1 }));
        });
    }

    /// <summary>
    /// Constructors the empty sequence test.
    /// </summary>
    [Test]
    public void ConstructorEmptySequenceTest()
    {
        // Test 1: Empty length 1 sequence
        CongenericSequence sequence1 = new(new ValueInt(1), 1);
        Assert.Multiple(() =>
        {
            Assert.That(sequence1.Length, Is.EqualTo(1));
            Assert.That(sequence1.OccurrencesCount, Is.Zero);
            Assert.That(sequence1.Positions, Is.Empty);
        });

        // Test 2: Empty sequence length > 0
        CongenericSequence sequence2 = new(new ValueInt(1), 5);
        Assert.Multiple(() =>
        {
            Assert.That(sequence2.Length, Is.EqualTo(5));
            Assert.That(sequence2.OccurrencesCount, Is.Zero);
            Assert.That(sequence2.Positions, Is.Empty);
        });

        // Test 3: Zero length sequence
        CongenericSequence sequence3 = new(new ValueInt(1), 0);
        Assert.Multiple(() =>
        {
            Assert.That(sequence3.Length, Is.Zero);
            Assert.That(sequence3.OccurrencesCount, Is.Zero);
            Assert.That(sequence3.Positions, Is.Empty);
        });
    }


    /// <summary>
    /// Constructors the with element and length test.
    /// </summary>
    [Test]
    public void ConstructorWithElementAndLengthTest()
    {
        IBaseObject element = new ValueInt(5);
        int length = 10;

        CongenericSequence sequence = new(element, length);

        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(10));
            Assert.That(sequence.Element, Is.EqualTo(element));
        });


    }


    /// <summary>
    /// Constructors the with element tests.
    /// </summary>
    [Test]
    public void ConstructorWithElementTests()
    {
        IBaseObject element = new ValueInt(10);

        CongenericSequence sequence = new(element);

        Assert.Multiple(() =>
        {
            Assert.That(sequence.Element, Is.EqualTo(element));
            Assert.That(sequence.Element, Is.Not.EqualTo(new ValueInt(100)));
        });
    }

    /// <summary>
    /// Constructors the with positions element and length tests.
    /// </summary>
    [Test]
    public void ConstructorWithPositionsElementAndLengthTests()
    {
        List<int> positions = new() { 1, 3, 5 };
        IBaseObject element = new ValueInt(15);
        int length = 6;

        CongenericSequence sequence = new(positions, element, length);

        Assert.Multiple(() =>
        {
            Assert.That(sequence.Length, Is.EqualTo(6));
            Assert.That(sequence.Element, Is.EqualTo(element));
            Assert.That(sequence.Positions, Is.EqualTo(new int[] { 1, 3, 5 }));
            Assert.That(sequence.OccurrencesCount, Is.EqualTo(3));
        });
    }

    /// <summary>
    /// Constructors the map with mixed values tests.
    /// </summary>
    [Test]
    public void ConstructorMapWithMixedValuesTests()
    {
        bool[] map1 = { false, true, false, true, false };
        IBaseObject element1 = new ValueInt(5);
        CongenericSequence sequence1 = new(map1, element1);

        Assert.Multiple(() =>
        {
            Assert.That(sequence1.Length, Is.EqualTo(5));
            Assert.That(sequence1.Element, Is.EqualTo(element1));
            Assert.That(sequence1.OccurrencesCount, Is.EqualTo(2));
            Assert.That(sequence1.Positions, Is.EqualTo(new int[] { 1, 3 }));
        });
    }

    /// <summary>
    /// Contructors the map with all false tests.
    /// </summary>
    [Test]
    public void ContructorMapWithAllFalseTests()
    {
        bool[] map2 = { false, false, false };
        IBaseObject element2 = new ValueInt(7);
        CongenericSequence sequence2 = new(map2, element2);

        Assert.Multiple(() =>
        {
            Assert.That(sequence2.Length, Is.EqualTo(3));
            Assert.That(sequence2.OccurrencesCount, Is.Zero);
            Assert.That(sequence2.Positions, Is.Empty);
        });
    }

    /// <summary>
    /// Constructors the map wint all true tests.
    /// </summary>
    [Test]
    public void ConstructorMapWintAllTrueTests()
    {
        bool[] map3 = { true, true, true, true };
        IBaseObject element3 = new ValueInt(3);
        CongenericSequence sequence3 = new(map3, element3);

        Assert.Multiple(() =>
        {
            Assert.That(sequence3.Length, Is.EqualTo(4));
            Assert.That(sequence3.OccurrencesCount, Is.EqualTo(4));
            Assert.That(sequence3.Positions, Is.EqualTo(new int[] { 0, 1, 2, 3 }));
        });
    }

    [Test]
    [Ignore("Fail")]
    public void ConstructorInvalidInputTest()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentException>(() =>
                new CongenericSequence(new List<int> { 1, 4, 2, 4 }, new ValueInt(1), 5));

            Assert.Throws<ArgumentException>(() =>
                new CongenericSequence(new List<int> { 0, 1, 2 }, new ValueInt(1), 3));

            Assert.Throws<ArgumentException>(() =>
                new CongenericSequence(new List<int> { 1, 0, 3 }, new ValueInt(1), 4));

            Assert.Throws<ArgumentException>(() =>
                new CongenericSequence(new List<int> { -1, 2, 3 }, new ValueInt(1), 4));

            Assert.Throws<ArgumentException>(() =>
                new CongenericSequence(new List<int> { 1, 2, 5 }, new ValueInt(1), 4));

            Assert.Throws<ArgumentNullException>(() => new CongenericSequence(null, 5));

            Assert.Throws<ArgumentException>(() => new CongenericSequence(new ValueInt(1), -5));

            Assert.Throws<ArgumentException>(() =>
                new CongenericSequence(new List<int> { 1, 2 }, new ValueInt(1), 2));
        });
    }


    /// <summary>
    /// Verifies that manager is created correctly for both empty and non-empty sequences.
    /// </summary>
    [Test]
    [Ignore("SeriesIvtervals link start")]
    public void CreateSeriesIntervalsManagerLinkStartTest()
    {
        CongenericSequence emptySequence = new(new ValueInt(1), 5);
        CongenericSequence sequence = new(new ValueInt(1), 5);
        sequence.Set(1);
        sequence.Set(3);

        emptySequence.CreateSeriesIntervalsManager();
        sequence.CreateSeriesIntervalsManager();

        Assert.That(emptySequence.GetSeriesAndIntervals(Link.Start), Is.Empty);
        Assert.That(sequence.GetSeriesAndIntervals(Link.Start), Is.Not.Empty);
    }

    /// <summary>
    /// Creates the series intervals manager link end test.
    /// </summary>
    [Test]
    [Ignore("SeriesIvtervals link end")]
    public void CreateSeriesIntervalsManagerLinkEndTest()
    {
        CongenericSequence emptySequence = new(new ValueInt(1), 5);
        CongenericSequence sequence = new(new ValueInt(1), 5);
        sequence.Set(1);
        sequence.Set(3);

        emptySequence.CreateSeriesIntervalsManager();
        sequence.CreateSeriesIntervalsManager();

        Assert.That(emptySequence.GetSeriesAndIntervals(Link.End), Is.Empty);
        Assert.That(sequence.GetSeriesAndIntervals(Link.End), Is.Not.Empty);
    }

    /// <summary>
    /// Fills the interval manager test.
    /// </summary>
    [Test]
    public void FillIntervalManagerTest()
    {
        CongenericSequence sequence = new(new ValueInt(1), 5);
        sequence.Set(1);
        sequence.Set(3);

        sequence.FillIntervalManager();

        Assert.That(sequence.GetIntervals(Link.Start), Is.Not.Empty);
    }



    /// <summary>
    /// Gets the hash code test.
    /// </summary>
    [Test]
    public void GetHashCodeTest()
    {
        CongenericSequence sequence1 = new(new ValueInt(1), 3);
        sequence1.Set(0);
        sequence1.Set(2);

        CongenericSequence sequence2 = new(new ValueInt(1), 3);
        sequence2.Set(0);
        sequence2.Set(2);

        CongenericSequence differentSequence = new(new ValueInt(1), 3);
        differentSequence.Set(0);
        differentSequence.Set(1);

        Assert.That(sequence1.GetHashCode(), Is.EqualTo(sequence2.GetHashCode()));
        Assert.That(sequence1.GetHashCode(), Is.Not.EqualTo(differentSequence.GetHashCode()));
    }

    /// <summary>
    /// Orders the empty sequence test.
    /// </summary>
    [Test]
    public void OrderEmptySequenceTest()
    {
        CongenericSequence sequence = new(new ValueInt(1), 4);

        int[] order = sequence.Order;

        Assert.That(order, Is.EqualTo(new[] { 0, 0, 0, 0 }));
    }


    /// <summary>
    /// Orders the full sequence test.
    /// </summary>
    [Test]
    public void OrderFullSequenceTest()
    {
        CongenericSequence sequence = new(new ValueInt(1), 3);
        sequence.Set(0);
        sequence.Set(1);
        sequence.Set(2);

        int[] order = sequence.Order;

        Assert.That(order, Is.EqualTo(new[] { 1, 1, 1 }));
    }

    /// <summary>
    /// Orders the single element test.
    /// </summary>
    [Test]
    public void OrderSingleElementTest()
    {
        CongenericSequence sequence = new(new ValueInt(1), 5);
        sequence.Set(2);

        int[] order = sequence.Order;

        Assert.That(order, Is.EqualTo(new[] { 0, 0, 1, 0, 0 }));
    }

    /// <summary>
    /// The independence message test.
    /// </summary>
    [Test]
    public void IndependenceMessageTest()
    {
        congenericSequence = new CongenericSequence(message, 10);

        ValueString newMessage = (ValueString)congenericSequence.Element;

        Assert.That(newMessage, Is.Not.SameAs(congenericSequence.Element));
    }

    /// <summary>
    /// The add test.
    /// </summary>
    [Test]
    public void AddTest()
    {
        congenericSequence.Set(message, 3);
        Assert.That(congenericSequence.Get(3), Is.EqualTo(message));
    }

    /// <summary>
    /// The wrong message test.
    /// </summary>
    [Test]
    public void WrongMessageTest()
    {
        congenericSequence.Set(wrongMessage, 4);
        Assert.That(congenericSequence.Get(4), Is.Not.EqualTo(wrongMessage));
        Assert.That(congenericSequence.Get(4), Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        congenericSequence.Set(message, 3);
        congenericSequence.RemoveAt(3);
        Assert.That(congenericSequence.Get(3), Is.Not.EqualTo(message));
        Assert.That(congenericSequence.Get(3), Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The delete test.
    /// </summary>
    [Test]
    public void DeleteTest()
    {
        congenericSequence.Set(message, 3);
        congenericSequence.DeleteAt(3);
        Assert.That(congenericSequence.Get(3), Is.Not.EqualTo(message));
        Assert.That(congenericSequence.Get(3), Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The clear and set new length test.
    /// </summary>
    [Test]
    public void ClearAndSetNewLengthTest()
    {
        const int newLength = 5;
        congenericSequence.ClearAndSetNewLength(newLength);
        Assert.That(congenericSequence.Length, Is.EqualTo(newLength));
        Assert.That(congenericSequence.Positions, Is.Empty);
    }

    /// <summary>
    /// The congeneric sequence test.
    /// </summary>
   [Test]
    public void CongenericSequenceTest()
    {
        ValueString element = new("A");
        CongenericSequence result = new(element);
        Assert.That(result.Element, Is.EqualTo(element));
        Assert.That(result.Length, Is.Zero);
        Assert.That(result.Positions, Is.Empty);
        Assert.That(result.OccurrencesCount, Is.Zero);
    }

    /// <summary>
    /// The Set test.
    /// </summary>
    [Test]
    public void SetTest()
    {
        List<int> position = [4];
        const int index = 5;
        congenericSequence.Set(index);
        Assert.That(congenericSequence.Positions, Is.Not.EqualTo(position));
    }

    ///<sumary>
    /// GetFirstAfter empty seuqence test.
    ///</sumary
    [Test]
    public void GetFirstAfterEmptyTest()
    {
        const int index = 3;
        const int expectedIndex = -1;
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));
    }

    /// <summary>
    /// GetFirstAfter test.
    /// </summary>
    [Test]
    public void GetFirstAfterTest()
    {
        int index = 0;
        int expectedIndex = -1;

        congenericSequence.Set(0);
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        congenericSequence.Set(9);
        expectedIndex = 9;
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        index = 5;
        expectedIndex = 9;
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        congenericSequence.Set(5);
        index = 0;
        expectedIndex = 5;
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));
        
        index = 4;
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        index = 5;
        expectedIndex = 9;
        Assert.That(congenericSequence.GetFirstAfter(index), Is.EqualTo(expectedIndex));
    }
}
