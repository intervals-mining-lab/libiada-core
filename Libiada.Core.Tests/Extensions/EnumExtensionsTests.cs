namespace Libiada.Core.Tests.Extensions;

using Libiada.Core.Attributes;
using Libiada.Core.Core;
using Libiada.Core.Extensions;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// The enum extensions tests.
/// </summary>
[TestFixture]
public class EnumExtensionsTests
{
    /// <summary>
    /// Sample enum for testing.
    /// </summary>
    private enum TestEnum : byte
    {
        [Link(Link.Start)]
        [Display(Name = "First Value")]
        First = 1,

        [Link(Link.End)]
        Second = 2,

        Third = 3
    }

    /// <summary>
    /// Test for ToArray method.
    /// </summary>
    [Test]
    public void ToArrayTest()
    {
        TestEnum[] actual = Enum.GetValues<TestEnum>();
        TestEnum[] expected = [TestEnum.First, TestEnum.Second, TestEnum.Third];

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetLinkTest()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(TestEnum.First.GetLink(), Is.EqualTo(Link.Start));
            Assert.That(TestEnum.Second.GetLink(), Is.EqualTo(Link.End));
        }
    }

    [Test]
    public void GetLinkThrowsForValueWithoutAttribute()
    {
        Assert.Throws<NullReferenceException>(() => TestEnum.Third.GetLink());
    }


    [Test]
    public void GetAttributeTest()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(TestEnum.First.GetAttribute<TestEnum, DisplayAttribute>()?.Name, Is.EqualTo("First Value"));
            Assert.That(TestEnum.Second.GetAttribute<TestEnum, DisplayAttribute>(), Is.Null);
        }
    }

    [Test]
    public void SelectAllWithAttributeTest()
    {
        var valuesWithLink = EnumExtensions.SelectAllWithAttribute<TestEnum, LinkAttribute>();
        var valuesWithDisplay = EnumExtensions.SelectAllWithAttribute<TestEnum, DisplayAttribute>();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(valuesWithLink, Is.EquivalentTo([TestEnum.First, TestEnum.Second]));
            Assert.That(valuesWithDisplay, Is.EquivalentTo([TestEnum.First]));
        }
    }
}
