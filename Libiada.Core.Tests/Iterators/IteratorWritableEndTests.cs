namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Iterators;

/// <summary>
/// The iterator writable end test.
/// </summary>
[TestFixture]
public class IteratorWritableEndTests
{
    /// <summary>
    /// The chain to iterate.
    /// </summary>
    private Chain chainToIterate;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        chainToIterate = new Chain("121331212231");
    }

    /// <summary>
    /// The write test.
    /// </summary>
    [Test]
    public void WriteTest()
    {
        List<ValueString> messages = ['1', '3', '2', '2', '1', '2', '1', '3', '3', '1', '2', '1'];

        var toWrite = new Chain(12);
        var iteratorWrite = new IteratorWritableEnd(toWrite);
        int i = 0;
        while (iteratorWrite.Next())
        {
            iteratorWrite.WriteValue(messages[i++]);
        }

        Assert.That(toWrite, Is.EqualTo(chainToIterate));
    }
}
