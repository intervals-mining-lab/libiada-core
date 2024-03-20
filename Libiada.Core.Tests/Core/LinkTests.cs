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
        int actualCount = EnumExtensions.ToArray<Link>().Length;
        Assert.That(EnumExtensions.ToArray<Link>(), Has.Length.EqualTo(LinksCount));
    }

    /// <summary>
    /// Tests values of links.
    /// </summary>
    [Test]
    public void LinkValuesTest()
    {
        Link[] links = EnumExtensions.ToArray<Link>();
        for (int i = 0; i < LinksCount; i++)
        {
            Assert.That(links, Does.Contain((Link)i));
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
        Assert.That(link.GetName(), Is.EqualTo(name));
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
        Assert.That(link.GetDisplayValue(), Is.Not.Empty);
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
        Assert.That(link.GetDescription(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all links values are unique.
    /// </summary>
    [Test]
    public void LinkValuesUniqueTest()
    {
        Link[] links = EnumExtensions.ToArray<Link>();
        IEnumerable<byte> linkValues = links.Cast<byte>();
        Assert.That(linkValues, Is.Unique);
    }
}
