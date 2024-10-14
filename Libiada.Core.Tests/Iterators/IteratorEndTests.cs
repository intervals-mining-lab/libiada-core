namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// The iterator end test.
/// </summary>
[TestFixture]
public class IteratorEndTests
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
    /// The read window mode test.
    /// </summary>
    [Test]
    public void ReadWindowModeTest()
    {
        const int length = 3;
        const int step = 1;
        IteratorEnd iterator = new(chainToIterate, length, step);

        // 12 - 3 + 1
        List<Chain> message2 =
            [
                // 121331212|231|
                new("231"),

                // 12133121|223|1
                new("223"),

                // 1213312|122|31
                new("122"),

                // 121331|212|231
                new("212"),

                // 12133|121|2231
                new("121"),

                // 1213|312|12231
                new("312"),

                // 121|331|212231
                new("331"),

                // 12|133|1212231
                new("133"),

                // 1|213|31212231
                new("213"),

                // |121|331212231
                new("121")
            ];

        int i = 0;
        while (iterator.Next())
        {
            AbstractChain message1 = iterator.Current();
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
        IteratorEnd iterator = new(chainToIterate, length, step);

        List<Chain> message2 =
                        [
                            // 121331212|231|
                            new("231"),

                            // 121331|212|231
                            new("212"),

                            // 121|331|212231
                            new("331"),

                             // |121|331212231
                             new("121")
                         ];

        int i = 0;
        while (iterator.Next())
        {
            AbstractChain message1 = iterator.Current();
            Assert.That(message2[i++], Is.EqualTo(message1));
        }

        Assert.That(--i, Is.EqualTo(3));
    }
}
