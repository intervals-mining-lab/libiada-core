namespace Libiada.Core.Tests.Attributes;

using Libiada.Core.Attributes;
using Libiada.Core.Extensions;
using Libiada.Core.Core;

/// <summary>
/// The binding attribute tests.
/// </summary>
[TestFixture(TestOf = typeof(BindingAttribute))]
public class BindingAttributeTests
{
    /// <summary>
    /// Invalid binding value test.
    /// </summary>
    [Test]
    public void InvalidBindingValueTest()
    {
        Assert.Throws<ArgumentException>(() => new BindingAttribute((Binding)3));
    }

    /// <summary>
    /// Binding attribute value test.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    [Test]
    public void BindingAttributeValueTest([Values] Binding value)
    {
        BindingAttribute attribute = new(value);
        Assert.Multiple(() =>
        {
            Assert.That(attribute.Value, Is.EqualTo(value));
            Assert.That(attribute.Value.GetDisplayValue(), Is.EqualTo(value.GetDisplayValue()));
        });
    }
}
