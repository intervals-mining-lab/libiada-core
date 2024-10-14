namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Iterators;

/// <summary>
/// The iterator writable start test.
/// </summary>
[TestFixture]
public class IteratorWritableStartTests
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
        List<ValueString> messages =
                           ['1', '2', '1', '3', '3', '1', '2', '1', '2', '2', '3', '1'];

        Chain toWrite = new(12);
        IteratorWritableStart iteratorWrite = new(toWrite);
        int i = 0;
        while (iteratorWrite.Next())
        {
            iteratorWrite.WriteValue(messages[i++]);
        }

        Assert.That(toWrite, Is.EqualTo(chainToIterate));
    }
}
