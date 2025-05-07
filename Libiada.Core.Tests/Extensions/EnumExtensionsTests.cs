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
    /// The test enum.
    /// </summary>
    private enum TestEnum : byte
    {
        /// <summary>
        /// The first.
        /// </summary>
        First = 1,

        /// <summary>
        /// The second.
        /// </summary>
        Second = 2,

        /// <summary>
        /// The third.
        /// </summary>
        Third = 3
    }

    /// <summary>
    /// Test for ToArray method.
    /// </summary>
    [Test]
    public void ToArrayTest()
    {
        TestEnum[] actual = EnumExtensions.ToArray<TestEnum>();
        TestEnum[] expected = [TestEnum.First, TestEnum.Second, TestEnum.Third];

        Assert.That(actual, Is.EqualTo(expected));
    }

    private enum TestEnumValues
    {
        [Link(Link.Start)]
        Value1,

        [Link(Link.End)]
        Value2,

        Value3
    }
    private enum TestEnumWithCustomAttribute
    {
        [Display(Name = "First Value")]
        Value1,
        Value2
    }

    [Test]
    public void GetLinkTest()
    {
        Assert.That(TestEnumValues.Value1.GetLink(), Is.EqualTo(Link.Start));
        Assert.That(TestEnumValues.Value2.GetLink(), Is.EqualTo(Link.End));
    }

    [Test]
    public void GetLinkThrowsForValueWithoutAttribute()
    {
        Assert.Throws<NullReferenceException>(() => TestEnumValues.Value3.GetLink());
    }

    [Test]
    public void GetAttributeTest()
    {
        Assert.That(TestEnumWithCustomAttribute.Value1.GetAttribute<TestEnumWithCustomAttribute, DisplayAttribute>().Name, Is.EqualTo("First Value"));
        Assert.That(TestEnumWithCustomAttribute.Value2.GetAttribute<TestEnumWithCustomAttribute, DisplayAttribute>(), Is.Null);
    }

    [Test]
    public void SelectAllWithAttributeTest()
    {
        var valuesWithLink = EnumExtensions.SelectAllWithAttribute<TestEnumValues>(typeof(LinkAttribute));
        var valuesWithDisplay = EnumExtensions.SelectAllWithAttribute<TestEnumWithCustomAttribute>(typeof(DisplayAttribute));

        Assert.That(valuesWithLink, Is.EquivalentTo(new[] { TestEnumValues.Value1, TestEnumValues.Value2 }));
        Assert.That(valuesWithDisplay, Is.EquivalentTo(new[] { TestEnumWithCustomAttribute.Value1 }));
    }

    [Test]
    public void SelectAllWithAttributeThrowsForNonAttributeType()
    {
        Assert.Throws<ArgumentException>(() => EnumExtensions.SelectAllWithAttribute<TestEnumValues>(typeof(string)));
    }

}
