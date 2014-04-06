namespace Segmenter.Tests.Base.Seekers.Converters
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Seekers.Converters;
    using Segmenter.Base.Sequencies;

    [TestFixture]
    public class FilterSequenceTest
    {
        [Test]
        public void FilteroutTest()
        {
            List<string> list1 = new List<string>
                {
                    "ABABAB",
                    "ABATAT",
                    "TABABAB",
                    "ABTABAB",
                    "ABABAB",
                    "ABABAB",
                    "ABABAB"
                };
            List<string> listSequence1 = new List<string> { "ABATAT", "TABABAB" };
            List<string> listSequence2 = new List<string> { "ABABAB", "ABABAB" };
            List<string> listSequence3 = new List<string> { "ABABAB" };
            List<string> result1 = new List<string> { "ABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB" };
            List<string> result2 = new List<string> { "ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB" };
            List<string> result3 = new List<string> { "ABATAT", "TABABAB", "ABTABAB" };

            SequenceCleaner a1Cleaner = new SequenceCleaner(new ComplexChain(list1));
            SequenceCleaner a2Cleaner = new SequenceCleaner(new ComplexChain(list1));
            SequenceCleaner a3Cleaner = new SequenceCleaner(new ComplexChain(list1));

            a1Cleaner.FilterOut(listSequence1);
            a2Cleaner.FilterOut(listSequence2);
            a3Cleaner.FilterOut(listSequence3);

            Assert.True((new ComplexChain(result1)).Equals(a1Cleaner.GetChain()));
            Assert.True((new ComplexChain(result2)).Equals(a2Cleaner.GetChain()));
            Assert.True((new ComplexChain(result3)).Equals(a3Cleaner.GetChain()));
        }
    }
}