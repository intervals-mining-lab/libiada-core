namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The null value test.
/// </summary>
[TestFixture]
public class NullValueTests
{
    /// <summary>
    /// The instance not null test.
    /// </summary>
    [Test]
    public void InstanceNotNullTest()
    {
        Assert.That(NullValue.Instance(), Is.Not.Null);
    }

    /// <summary>
    /// The instance single tone test.
    /// </summary>
    [Test]
    public void InstanceSingleToneTest()
    {
        Assert.That(NullValue.Instance(), Is.SameAs(NullValue.Instance()));
    }
}
