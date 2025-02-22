namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Extensions;

/// <summary>
/// BindingMode enum tests.
/// </summary>
[TestFixture(TestOf = typeof(BindingMode))]
public class BindingModeTests
{
    /// <summary>
    /// Binding modes count.
    /// </summary>
    private const int BindingModesCount = 5;

    /// <summary>
    /// Array of all binding modes.
    /// </summary>
    private readonly BindingMode[] bindingModes = EnumExtensions.ToArray<BindingMode>();

    /// <summary>
    /// Tests count of binding modes.
    /// </summary>
    [Test]
    public void BindingModeCountTest() => Assert.That(bindingModes, Has.Length.EqualTo(BindingModesCount));

    /// <summary>
    /// Tests values of binding modes.
    /// </summary>
    [Test]
    public void BindingModeValuesTest()
    {
        for (int i = 0; i < BindingModesCount; i++)
        {
            Assert.That(bindingModes, Contains.Item((BindingMode)i));
        }
    }

    /// <summary>
    /// Tests names of binding modes.
    /// </summary>
    /// <param name="bindingMode">
    /// The binding mode.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((BindingMode)0, "NotApplicable")]
    [TestCase((BindingMode)1, "Normal")]
    [TestCase((BindingMode)2, "Cyclic")]
    [TestCase((BindingMode)3, "Lossy")]
    [TestCase((BindingMode)4, "Redundant")]
    public void BindingModeNamesTest(BindingMode bindingMode, string name) => Assert.That(bindingMode.GetName(), Is.EqualTo(name));

    /// <summary>
    /// Tests that all binding modes have display value.
    /// </summary>
    /// <param name="bindingMode">
    /// The binding mode.
    /// </param>
    [Test]
    public void BindingModeHasDisplayValueTest([Values] BindingMode bindingMode) => Assert.That(bindingMode.GetDisplayValue(), Is.Not.Empty);

    /// <summary>
    /// Tests that all binding modes have description.
    /// </summary>
    /// <param name="bindingMode">
    /// The binding mode.
    /// </param>
    [Test]
    public void BindingModeHasDescriptionTest([Values] BindingMode bindingMode) => Assert.That(bindingMode.GetDescription(), Is.Not.Empty);

    /// <summary>
    /// Tests that all binding modes values are unique.
    /// </summary>
    [Test]
    public void BindingModeValuesUniqueTest() => Assert.That(bindingModes.Cast<byte>(), Is.Unique);
}
