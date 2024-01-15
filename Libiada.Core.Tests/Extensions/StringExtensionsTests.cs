namespace Libiada.Core.Tests.Extensions;

using Libiada.Core.Extensions;

using NUnit.Framework;

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
        var source = "Chaoyang virus strain Deming polyprotein gene, complete cds.";
        var expected = "Chaoyang virus strain Deming polyprotein gene";

        string actual = source.TrimEnd(", complete cds.");
        Assert.AreEqual(expected, actual);

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
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Tests for trim end method when string or substring has trash at the end.
    /// </summary>
    [Test]
    public void TrimEndWithTrashTest()
    {
        var source = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome.";
        var expected = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome.";

        string actual = source.TrimEnd(", complete cds");
        Assert.AreEqual(expected, actual);

        actual = source.TrimEnd(", complete genome")
                       .TrimEnd(", complete sequence")
                       .TrimEnd(", complete CDS")
                       .TrimEnd(", complete cds")
                       .TrimEnd(", genome");
        Assert.AreEqual(expected, actual);

        source = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome";
        expected = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome";

        actual = source.TrimEnd(", complete cds.");
        Assert.AreEqual(expected, actual);

        actual = source.TrimEnd(", complete genome.")
                       .TrimEnd(", complete sequence.")
                       .TrimEnd(", complete CDS.")
                       .TrimEnd(", complete cds.")
                       .TrimEnd(", genome.");
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Test for get largest repeating substring method.
    /// </summary>
    [Test]
    public void GetLargestRepeatingSubstringTest()
    {
        string source = " abc abc abc abc ";
        string expected = "abc";
        string actual = source.GetLargestRepeatingSubstring();
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Test for get largest repeating substring method
    /// with no substring to be found.
    /// </summary>
    [Test]
    public void GetLargestRepeatingSubstringNoSubstringTest()
    {
        string source = " abc abc abc abf ";
        string expected = " abc abc abc abf ";
        string actual = source.GetLargestRepeatingSubstring();
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Test for is subset method.
    /// </summary>
    [Test]
    public void IsSubsetOfTest()
    {
        var firstSource = "Salmonella enterica subsp. enterica serovar Paratyphi C str. RKS4594";
        var secondSource = "enterica subsp. enterica serovar Paratyphi C str. Salmonella enterica subsp. enterica serovar Paratyphi C str.";
        Assert.IsTrue(secondSource.IsSubsetOf(firstSource));
        Assert.IsFalse(firstSource.IsSubsetOf(secondSource));

        secondSource = secondSource.GetLargestRepeatingSubstring();
        Assert.IsTrue(secondSource.IsSubsetOf(firstSource));
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
        Assert.IsTrue(source.IsSubsetOf(source));

        source = source.GetLargestRepeatingSubstring();
        Assert.IsTrue(source.IsSubsetOf(source));
    }
}
