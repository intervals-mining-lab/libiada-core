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
        Assert.That(congenericSequence.Length, Is.EqualTo(10));
        Assert.That(congenericSequence.Element, Is.EqualTo(message));
    }

    // Create a sequence with specified length and element
    [Test]
    public void ConstructorWithElementAndLengthTest()
    {
        IBaseObject element = new ValueInt(5);
        int length = 10;

        CongenericSequence sequence = new(element, length);

        Assert.That(sequence.Length, Is.EqualTo(10));
        Assert.That(sequence.Element, Is.EqualTo(element));

        Assert.That(sequence.Length, Is.Not.EqualTo(15));
        Assert.That(sequence.Element, Is.Not.EqualTo(new ValueInt(10)));

    }


    // Create a sequence with specified element
    [Test]
    public void ConstructorWithElementTests()
    {
        IBaseObject element = new ValueInt(10);

        CongenericSequence sequence = new(element);

        Assert.That(sequence.Element, Is.EqualTo(element));
        Assert.That(sequence.Element, Is.Not.EqualTo(new ValueInt(100)));
    }

    [Test]
    public void ConstructorWithPositionsElementAndLengthTests()
    {
        List<int> positions = new() { 1, 3, 5 };
        IBaseObject element = new ValueInt(15);
        int length = 6;

        CongenericSequence sequence = new(positions, element, length);

        Assert.That(sequence.Length, Is.EqualTo(6));
        Assert.That(sequence.Element, Is.EqualTo(element));
        Assert.That(sequence.Positions, Is.EqualTo(new int[] { 1, 3, 5 }));
        Assert.That(sequence.OccurrencesCount, Is.EqualTo(3));
    }

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
