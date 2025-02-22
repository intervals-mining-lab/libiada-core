namespace Libiada.Core.Tests.Attributes;

using Libiada.Core.Attributes;
using Libiada.Core.Extensions;
using Libiada.Core.Core;

/// <summary>
/// The link attribute tests.
/// </summary>
[TestFixture(TestOf = typeof(LinkAttribute))]
public class LinkAttributeTests
{
    /// <summary>
    /// Invalid link value test.
    /// </summary>
    [Test]
    public void InvalidLinkValueTest()
    {
        Assert.Throws<ArgumentException>(() => new LinkAttribute((Link)8));
    }

    /// <summary>
    /// Link attribute value test.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    [Test]
    public void LinkAttributeValueTest([Values] Link value)
    {
        LinkAttribute attribute = new(value);
        Assert.Multiple(() =>
        {
            Assert.That(attribute.Value, Is.EqualTo(value));
            Assert.That(attribute.Value.GetDisplayValue(), Is.EqualTo(value.GetDisplayValue()));
        });
    }
}
