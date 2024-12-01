namespace Libiada.Core.Tests.Iterators;

using Libiada.Core.Core;
using Libiada.Core.Iterators;

/// <summary>
/// The custom iterator tests.
/// </summary>
[TestFixture]
public class CustomIteratorTests
{
    /// <summary>
    /// The custom iterator test.
    /// </summary>
    [Test]
    public void CustomIteratorTest()
    {
        List<List<int>> starts = [[0], [3], [5, 9]];
        List<List<int>> lengthes = [[2], [3], [2, 1]];

        Chain source = new("abcdefghij");

        List<Chain> expected = [new Chain("ab"), new Chain("def"), new Chain("fgj")];

        CustomIterator iterator = new(source, starts, lengthes);

        for (int i = 0; iterator.Next(); i++)
        {
            Chain result = (Chain)iterator.Current();

            Assert.That(result, Is.EqualTo(expected[i]));
        }
    }
}
