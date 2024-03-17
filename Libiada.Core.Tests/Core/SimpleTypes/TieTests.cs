namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Extensions;

/// <summary>
/// Tie enum tests.
/// </summary>
[TestFixture(TestOf = typeof(Tie))]
public class TieTests
{
    /// <summary>
    /// The ties count.
    /// </summary>
    private const int TiesCount = 4;

    /// <summary>
    /// Tests count of ties.
    /// </summary>
    [Test]
    public void TieCountTest()
    {
        var actualCount = EnumExtensions.ToArray<Tie>().Length;
        Assert.That(actualCount, Is.EqualTo(TiesCount));
    }

    /// <summary>
    /// Tests values of ties.
    /// </summary>
    [Test]
    public void TieValuesTest()
    {
        var ties = EnumExtensions.ToArray<Tie>();
        for (int i = 0; i < TiesCount; i++)
        {
            Assert.That(ties, Does.Contain((Tie)i));
        }
    }

    /// <summary>
    /// Tests names of ties.
    /// </summary>
    /// <param name="tie">
    /// The tie.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((Tie)0, "None")]
    [TestCase((Tie)1, "Start")]
    [TestCase((Tie)2, "End")]
    [TestCase((Tie)3, "Continue")]
    public void TieNamesTest(Tie tie, string name)
    {
        Assert.That(tie.GetName(), Is.EqualTo(name));
    }

    /// <summary>
    /// Tests that all ties have display value.
    /// </summary>
    /// <param name="tie">
    /// The tie.
    /// </param>
    [Test]
    public void TieHasDisplayValueTest([Values]Tie tie)
    {
        Assert.That(tie.GetDisplayValue(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all ties have description.
    /// </summary>
    /// <param name="tie">
    /// The tie.
    /// </param>
    [Test]
    public void TieHasDescriptionTest([Values]Tie tie)
    {
        Assert.That(tie.GetDescription(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all ties values are unique.
    /// </summary>
    [Test]
    public void TieValuesUniqueTest()
    {
        var ties = EnumExtensions.ToArray<Tie>();
        var tieValues = ties.Cast<byte>();
        Assert.That(tieValues, Is.Unique);
    }
}
