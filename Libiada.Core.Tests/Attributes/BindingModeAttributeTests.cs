namespace Libiada.Core.Tests.Attributes;

using Libiada.Core.Attributes;
using Libiada.Core.Extensions;
using Libiada.Core.Core;

/// <summary>
/// The binding mode attribute tests.
/// </summary>
[TestFixture(TestOf = typeof(BindingModeAttribute))]
public class BindingModeAttributeTests
{
    /// <summary>
    /// Invalid binding mode value test.
    /// </summary>
    [Test]
    public void InvalidBindingModeValueTest()
    {
        Assert.Throws<ArgumentException>(() => new BindingModeAttribute((BindingMode)5));
    }

    /// <summary>
    /// Binding mode attribute value test.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    [Test]
    public void BindingModeAttributeValueTest([Values] BindingMode value)
    {
        BindingModeAttribute attribute = new(value);
        Assert.Multiple(() =>
        {
            Assert.That(attribute.Value, Is.EqualTo(value));
            Assert.That(attribute.Value.GetDisplayValue(), Is.EqualTo(value.GetDisplayValue()));
        });
    }
}
