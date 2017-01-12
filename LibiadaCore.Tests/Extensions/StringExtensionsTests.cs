namespace LibiadaCore.Tests.Extensions
{
    using LibiadaCore.Extensions;

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
            string source = "Chaoyang virus strain Deming polyprotein gene, complete cds.";
            string expected = "Chaoyang virus strain Deming polyprotein gene";

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
            string source = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome.";
            string expected = "Bagaza virus isolate BAGV/Spain/RLP-Hcc2/2010, complete genome.";

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
    }
}
