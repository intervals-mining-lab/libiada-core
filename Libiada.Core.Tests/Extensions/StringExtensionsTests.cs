namespace Libiada.Core.Tests.Extensions;

using Libiada.Core.Extensions;

/// <summary>
/// Tests for string extensions methods.
/// </summary>
[TestFixture(TestOf = typeof(StringExtensions))]
public class StringExtensionsTests
{
    /// <summary>
    /// Tests for trim end method.
    /// </summary>
    [Test]
    public void TrimEndTest()
    {
        const string source = "Chaoyang virus strain Deming polyprotein gene, complete cds.";
        const string expected = "Chaoyang virus strain Deming polyprotein gene";

        string actual = source.TrimEnd(", complete cds.");
        Assert.That(actual, Is.EqualTo(expected));

        actual = source.TrimEnd(", complete genome.")
                       .TrimEnd(", complete sequence.")
                       .TrimEnd(", complete CDS.")
                       .TrimEnd(", complete cds.")
                       .TrimEnd(", genome.")
                       .TrimEnd(" complete genome.")
                       .TrimEnd(" complete sequence.")
                       .TrimEnd(" complete CDS.")
                       .TrimEnd(" complete cds.")
                       .TrimEnd(" genome.");
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Tests for trim end method when string or substring has trash at the end.
    /// </summary>
    [Test]
    public void TrimEndWithTrashTest()
    {
        string source = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome.";
        string expected = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome.";

        string actual = source.TrimEnd(", complete cds");
        Assert.That(actual, Is.EqualTo(expected));

        actual = source.TrimEnd(", complete genome")
                       .TrimEnd(", complete sequence")
                       .TrimEnd(", complete CDS")
                       .TrimEnd(", complete cds")
                       .TrimEnd(", genome");
        Assert.That(actual, Is.EqualTo(expected));

        source = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome";
        expected = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome";

        actual = source.TrimEnd(", complete cds.");
        Assert.That(actual, Is.EqualTo(expected));

        actual = source.TrimEnd(", complete genome.")
                       .TrimEnd(", complete sequence.")
                       .TrimEnd(", complete CDS.")
                       .TrimEnd(", complete cds.")
                       .TrimEnd(", genome.");
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test for get largest repeating substring method.
    /// </summary>
    [Test]
    public void GetLargestRepeatingSubstringTest()
    {
        const string source = " abc abc abc abc ";
        const string expected = "abc";
        string actual = source.GetLargestRepeatingSubstring();
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test for get largest repeating substring method
    /// with no substring to be found.
    /// </summary>
    [Test]
    public void GetLargestRepeatingSubstringNoSubstringTest()
    {
        const string source = " abc abc abc abf ";
        const string expected = " abc abc abc abf ";
        string actual = source.GetLargestRepeatingSubstring();
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test for is subset method.
    /// </summary>
    [Test]
    public void IsSubsetOfTest()
    {
        const string firstSource = "Salmonella enterica subsp. enterica serovar Paratyphi C str. RKS4594";
        string secondSource = "enterica subsp. enterica serovar Paratyphi C str. Salmonella enterica subsp. enterica serovar Paratyphi C str.";

        Assert.Multiple(() =>
        {
            Assert.That(secondSource.IsSubsetOf(firstSource));
            Assert.That(firstSource.IsSubsetOf(secondSource), Is.False);
        });

        secondSource = secondSource.GetLargestRepeatingSubstring();
        Assert.That(secondSource.IsSubsetOf(firstSource));
    }

    /// <summary>
    /// Test that string is subset of itself.
    /// </summary>
    /// <param name="source">
    /// The source.
    /// </param>
    [TestCase("Salmonella enterica subsp. enterica serovar Paratyphi C str. RKS4594")]
    [TestCase("enterica subsp. enterica serovar Paratyphi C str. Salmonella enterica subsp. enterica serovar Paratyphi C str.")]
    [TestCase("Salmonella enterica subsp. enterica serovar Paratyphi C strain RKS4594")]
    public void IsSubsetOfItselfTest(string source)
    {
        Assert.That(source.IsSubsetOf(source));

        source = source.GetLargestRepeatingSubstring();
        Assert.That(source.IsSubsetOf(source));
    }

    private enum TestEnum
    {
        Value1,
        Value2,
        Value3
    }

    /// <summary>
    /// Converts to enumvalidvaluetest.
    /// </summary>
    [Test]
    public void ToEnumValidValueTest()
    {
        string value = "Value1";

        TestEnum result = value.ToEnum<TestEnum>();

        Assert.That(result, Is.EqualTo(TestEnum.Value1));
    }

    /// <summary>
    /// Converts to enumcaseinsensitivetest.
    /// </summary>
    [Test]
    public void ToEnumCaseInsensitiveTest()
    {
        string value = "value2";

        TestEnum result = value.ToEnum<TestEnum>();

        Assert.That(result, Is.EqualTo(TestEnum.Value2));
    }

    /// <summary>
    /// Converts to enumemptystringtest.
    /// </summary>
    [Test]
    public void ToEnumEmptyStringTest()
    {
        string value = string.Empty;

        Assert.Throws<ArgumentException>(() => value.ToEnum<TestEnum>());
    }

    /// <summary>
    /// Converts to enuminvalidvaluetest.
    /// </summary>
    [Test]
    public void ToEnumInvalidValueTest()
    {
        string value = "InvalidValue";

        Assert.Throws<ArgumentException>(() => value.ToEnum<TestEnum>());
    }
}
