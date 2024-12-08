namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Extensions;

/// <summary>
/// Binding enum tests.
/// </summary>
[TestFixture(TestOf = typeof(Binding))]
public class BindingTests
{
    /// <summary>
    /// Bindings count.
    /// </summary>
    private const int BindingsCount = 3;

    /// <summary>
    /// Array of all bindings.
    /// </summary>
    private readonly Binding[] bindings = EnumExtensions.ToArray<Binding>();

    /// <summary>
    /// Tests count of bindings.
    /// </summary>
    [Test]
    public void BindingCountTest() => Assert.That(bindings, Has.Length.EqualTo(BindingsCount));

    /// <summary>
    /// Tests values of bindings.
    /// </summary>
    [Test]
    public void BindingValuesTest()
    {
        for (int i = 0; i < BindingsCount; i++)
        {
            Assert.That(bindings, Contains.Item((Binding)i));
        }
    }

    /// <summary>
    /// Tests names of bindings.
    /// </summary>
    /// <param name="binding">
    /// The binding.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((Binding)0, "NotApplicable")]
    [TestCase((Binding)1, "Beginning")]
    [TestCase((Binding)2, "End")]
    public void BindingNamesTest(Binding binding, string name) => Assert.That(binding.GetName(), Is.EqualTo(name));

    /// <summary>
    /// Tests that all bindings have display value.
    /// </summary>
    /// <param name="binding">
    /// The binding.
    /// </param>
    [Test]
    public void BindingHasDisplayValueTest([Values] Binding binding) => Assert.That(binding.GetDisplayValue(), Is.Not.Empty);

    /// <summary>
    /// Tests that all bindings have description.
    /// </summary>
    /// <param name="binding">
    /// The binding.
    /// </param>
    [Test]
    public void BindingHasDescriptionTest([Values] Binding binding) => Assert.That(binding.GetDescription(), Is.Not.Empty);

    /// <summary>
    /// Tests that all bindings values are unique.
    /// </summary>
    [Test]
    public void BindingValuesUniqueTest() => Assert.That(bindings.Cast<byte>(), Is.Unique);
}
