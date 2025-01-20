namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// The iterator start test.
/// </summary>
[TestFixture]
public class IteratorStartTests
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
    /// The read window mode test.
    /// </summary>
    [Test]
    public void ReadWindowModeTest()
    {
        const int length = 3;
        const int step = 1;
        IteratorStart iterator = new(sequenceToIterate, length, step);
        List<ComposedSequence> message2 =
                           [
                               new("121"),
                               new("213"),
                               new("133"),
                               new("331"),
                               new("312"),
                               new("121"),
                               new("212"),
                               new("122"),
                               new("223"),
                               new("231")
                           ];

        int i = 0;
        while (iterator.Next())
        {
            AbstractSequence message1 = iterator.Current();
            Assert.That(message2[i++], Is.EqualTo(message1));
        }

        Assert.That(--i, Is.EqualTo(9));
    }

    /// <summary>
    /// The read block mode test.
    /// </summary>
    [Test]
    public void ReadBlockModeTest()
    {
        const int length = 3;
        const int step = 3;
        IteratorStart iterator = new(sequenceToIterate, length, step);
        List<ComposedSequence> message2 = [new("121"), new("331"), new("212"), new("231")];

        int i = 0;
        while (iterator.Next())
        {
            AbstractSequence message1 = iterator.Current();
            Assert.That(message2[i++], Is.EqualTo(message1));
        }

        Assert.That(--i, Is.EqualTo(3));
    }
}
