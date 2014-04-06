namespace Segmenter.Tests.Base.Seekers.Converters
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Seekers.Converters;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// The filter sequence test.
    /// </summary>
    [TestFixture]
    public class FilterSequenceTest
    {
        /// <summary>
        /// The filterout test.
        /// </summary>
        [Test]
        public void FilteroutTest()
        {
            var list1 = new List<string>
                {
                    "ABABAB", 
                    "ABATAT", 
                    "TABABAB", 
                    "ABTABAB", 
                    "ABABAB", 
                    "ABABAB", 
                    "ABABAB"
                };
            var listSequence1 = new List<string> { "ABATAT", "TABABAB" };
            var listSequence2 = new List<string> { "ABABAB", "ABABAB" };
            var listSequence3 = new List<string> { "ABABAB" };
            var result1 = new List<string> { "ABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB" };
            var result2 = new List<string> { "ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB" };
            var result3 = new List<string> { "ABATAT", "TABABAB", "ABTABAB" };

            var a1Cleaner = new SequenceCleaner(new ComplexChain(list1));
            var a2Cleaner = new SequenceCleaner(new ComplexChain(list1));
            var a3Cleaner = new SequenceCleaner(new ComplexChain(list1));

            a1Cleaner.FilterOut(listSequence1);
            a2Cleaner.FilterOut(listSequence2);
            a3Cleaner.FilterOut(listSequence3);

            Assert.True((new ComplexChain(result1)).Equals(a1Cleaner.GetChain()));
            Assert.True((new ComplexChain(result2)).Equals(a2Cleaner.GetChain()));
            Assert.True((new ComplexChain(result3)).Equals(a3Cleaner.GetChain()));
        }
    }
}