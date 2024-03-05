namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Extensions;

/// <summary>
/// Link enum tests.
/// </summary>
[TestFixture(TestOf = typeof(Link))]
public class LinkTests
{
    /// <summary>
    /// The links count.
    /// </summary>
    private const int LinksCount = 8;

    /// <summary>
    /// Tests count of links.
    /// </summary>
    [Test]
    public void LinkCountTest()
    {
        var actualCount = EnumExtensions.ToArray<Link>().Length;
        Assert.AreEqual(LinksCount, actualCount);
    }

    /// <summary>
    /// Tests values of links.
    /// </summary>
    [Test]
    public void LinkValuesTest()
    {
        var links = EnumExtensions.ToArray<Link>();
        for (int i = 0; i < LinksCount; i++)
        {
            Assert.IsTrue(links.Contains((Link)i));
        }
    }

    /// <summary>
    /// Tests names of links.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((Link)0, "NotApplied")]
    [TestCase((Link)1, "None")]
    [TestCase((Link)2, "Start")]
    [TestCase((Link)3, "End")]
    [TestCase((Link)4, "Both")]
    [TestCase((Link)5, "Cycle")]
    [TestCase((Link)6, "CycleStart")]
    [TestCase((Link)7, "CycleEnd")]
    public void LinkNamesTest(Link link, string name)
    {
        Assert.AreEqual(name, link.GetName());
    }

    /// <summary>
    /// Tests that all links have display value.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    [Test]
    public void LinkHasDisplayValueTest([Values]Link link)
    {
        Assert.IsFalse(string.IsNullOrEmpty(link.GetDisplayValue()));
    }

    /// <summary>
    /// Tests that all links have description.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    [Test]
    public void LinkHasDescriptionTest([Values]Link link)
    {
        Assert.IsFalse(string.IsNullOrEmpty(link.GetDescription()));
    }

    /// <summary>
    /// Tests that all links values are unique.
    /// </summary>
    [Test]
    public void LinkValuesUniqueTest()
    {
        var links = EnumExtensions.ToArray<Link>();
        var linkValues = links.Cast<byte>();
        Assert.That(linkValues, Is.Unique);
    }
}
