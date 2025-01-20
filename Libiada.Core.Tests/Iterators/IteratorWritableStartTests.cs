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
    /// The sequence to iterate.
    /// </summary>
    private ComposedSequence sequenceToIterate;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        sequenceToIterate = new ComposedSequence("121331212231");
    }

    /// <summary>
    /// The write test.
    /// </summary>
    [Test]
    public void WriteTest()
    {
        List<ValueString> messages =
                           ['1', '2', '1', '3', '3', '1', '2', '1', '2', '2', '3', '1'];

        ComposedSequence toWrite = new(12);
        IteratorWritableStart iteratorWrite = new(toWrite);
        int i = 0;
        while (iteratorWrite.Next())
        {
            iteratorWrite.WriteValue(messages[i++]);
        }

        Assert.That(toWrite, Is.EqualTo(sequenceToIterate));
    }
}
