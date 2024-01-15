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
        Assert.AreEqual(10, congenericChain.Length);
        Assert.AreEqual(message, congenericChain.Element);
    }

    /// <summary>
    /// The independence message test.
    /// </summary>
    [Test]
    public void IndependenceMessageTest()
    {
        congenericChain = new CongenericChain(message, 10);

        var newMessage = (ValueString)congenericChain.Element;

        Assert.AreNotSame(congenericChain.Element, newMessage);
    }

    /// <summary>
    /// The add test.
    /// </summary>
    [Test]
    public void AddTest()
    {
        congenericChain.Set(message, 3);
        Assert.AreEqual(message, congenericChain.Get(3));
    }

    /// <summary>
    /// The wrong message test.
    /// </summary>
    [Test]
    public void WrongMessageTest()
    {
        congenericChain.Set(wrongMessage, 4);
        Assert.AreNotEqual(wrongMessage, congenericChain.Get(4));
        Assert.AreEqual(NullValue.Instance(), congenericChain.Get(4));
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        congenericChain.Set(message, 3);
        congenericChain.RemoveAt(3);
        Assert.AreNotEqual(message, congenericChain.Get(3));
        Assert.AreEqual(NullValue.Instance(), congenericChain.Get(3));
    }

    /// <summary>
    /// The delete test.
    /// </summary>
    [Test]
    public void DeleteTest()
    {
        congenericChain.Set(message, 3);
        congenericChain.DeleteAt(3);
        Assert.AreNotEqual(message, congenericChain.Get(3));
        Assert.AreEqual(NullValue.Instance(), congenericChain.Get(3));
    }

    /// <summary>
    /// The clear and set new length test.
    /// </summary>
    [Test]
    public void ClearAndSetNewLengthTest()
    {
        const int newLength = 5;
        congenericChain.ClearAndSetNewLength(newLength);
        Assert.AreEqual(newLength, congenericChain.Length);
        Assert.IsEmpty(congenericChain.Positions);
    }

    /// <summary>
    /// The CongenericChain test.
    /// </summary>
   [Test]
    public void CongenericChainTest()
    {
        var element = new ValueString("A");
        var result = new CongenericChain(element);
        Assert.AreEqual(element, result.Element);
        Assert.That(result.Length, Is.Zero);
        Assert.IsEmpty(result.Positions);
        Assert.That(result.OccurrencesCount, Is.Zero);
    }

    /// <summary>
    /// The Set test.
    /// </summary>
    [Test]
    public void SetTest()
    {
        List<int> position = new List<int>();
        position.Add(4);
        const int index = 5;
        congenericChain.Set(index);
        Assert.AreNotEqual(position, congenericChain.Positions);
    }

    ///<sumary>
    /// GetFirstAfter empty seuqence test.
    ///</sumary
    [Test]
    public void GetFirstAfterEmptyTest()
    {
        const int index = 3;
        const int expectedIndex = -1;
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));
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
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));

        congenericChain.Set(9);
        expectedIndex = 9;
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));

        index = 5;
        expectedIndex = 9;
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));

        congenericChain.Set(5);
        index = 0;
        expectedIndex = 5;
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));
        
        index = 4;
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));

        index = 5;
        expectedIndex = 9;
        Assert.AreEqual(expectedIndex, congenericChain.GetFirstAfter(index));
    }
}
