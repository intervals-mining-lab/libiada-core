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
        var starts = new List<List<int>> { new List<int> { 0 }, new List<int> { 3 }, new List<int> { 5, 9 } };
        var lengthes = new List<List<int>> { new List<int> { 2 }, new List<int> { 3 }, new List<int> { 2, 1 } };

        var source = new Chain("abcdefghij");

        List<Chain> expected = new List<Chain> { new Chain("ab"), new Chain("def"), new Chain("fgj") };

        var iterator = new CustomIterator(source, starts, lengthes);

        for (int i = 0; iterator.Next(); i++)
        {
            Chain result = (Chain)iterator.Current();

            Assert.AreEqual(expected[i], result);
        }
    }
}
