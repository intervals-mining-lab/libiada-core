namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The congeneric chain test.
/// </summary>
[TestFixture]
public class CongenericChainTests
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
    /// The congeneric chain.
    /// </summary>
    private CongenericChain congenericChain;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        message = new ValueString('1');
        congenericChain = new CongenericChain(message, 10);
        wrongMessage = new ValueString('2');
    }

    /// <summary>
    /// The constructor test.
    /// </summary>
    [Test]
    public void ConstructorTest()
    {
        Assert.That(congenericChain.Length, Is.EqualTo(10));
        Assert.That(congenericChain.Element, Is.EqualTo(message));
    }

    /// <summary>
    /// The independence message test.
    /// </summary>
    [Test]
    public void IndependenceMessageTest()
    {
        congenericChain = new CongenericChain(message, 10);

        ValueString newMessage = (ValueString)congenericChain.Element;

        Assert.That(newMessage, Is.Not.SameAs(congenericChain.Element));
    }

    /// <summary>
    /// The add test.
    /// </summary>
    [Test]
    public void AddTest()
    {
        congenericChain.Set(message, 3);
        Assert.That(congenericChain.Get(3), Is.EqualTo(message));
    }

    /// <summary>
    /// The wrong message test.
    /// </summary>
    [Test]
    public void WrongMessageTest()
    {
        congenericChain.Set(wrongMessage, 4);
        Assert.That(congenericChain.Get(4), Is.Not.EqualTo(wrongMessage));
        Assert.That(congenericChain.Get(4), Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        congenericChain.Set(message, 3);
        congenericChain.RemoveAt(3);
        Assert.That(congenericChain.Get(3), Is.Not.EqualTo(message));
        Assert.That(congenericChain.Get(3), Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The delete test.
    /// </summary>
    [Test]
    public void DeleteTest()
    {
        congenericChain.Set(message, 3);
        congenericChain.DeleteAt(3);
        Assert.That(congenericChain.Get(3), Is.Not.EqualTo(message));
        Assert.That(congenericChain.Get(3), Is.EqualTo(NullValue.Instance()));
    }

    /// <summary>
    /// The clear and set new length test.
    /// </summary>
    [Test]
    public void ClearAndSetNewLengthTest()
    {
        const int newLength = 5;
        congenericChain.ClearAndSetNewLength(newLength);
        Assert.That(congenericChain.Length, Is.EqualTo(newLength));
        Assert.That(congenericChain.Positions, Is.Empty);
    }

    /// <summary>
    /// The CongenericChain test.
    /// </summary>
   [Test]
    public void CongenericChainTest()
    {
        ValueString element = new("A");
        CongenericChain result = new(element);
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
        congenericChain.Set(index);
        Assert.That(congenericChain.Positions, Is.Not.EqualTo(position));
    }

    ///<sumary>
    /// GetFirstAfter empty seuqence test.
    ///</sumary
    [Test]
    public void GetFirstAfterEmptyTest()
    {
        const int index = 3;
        const int expectedIndex = -1;
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));
    }

    /// <summary>
    /// GetFirstAfter test.
    /// </summary>
    [Test]
    public void GetFirstAfterTest()
    {
        int index = 0;
        int expectedIndex = -1;

        congenericChain.Set(0);
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        congenericChain.Set(9);
        expectedIndex = 9;
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        index = 5;
        expectedIndex = 9;
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        congenericChain.Set(5);
        index = 0;
        expectedIndex = 5;
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));
        
        index = 4;
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));

        index = 5;
        expectedIndex = 9;
        Assert.That(congenericChain.GetFirstAfter(index), Is.EqualTo(expectedIndex));
    }
}
