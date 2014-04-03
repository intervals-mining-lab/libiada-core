using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SegmentatorTest.Classes.Base.Seekers.Converters
{
    using Segmentator.Base.Seekers.Converters;
    using Segmentator.Base.Sequencies;

    [TestFixture]
    public class FilterTest
    {
        private String str1;
        private String str2;
        private List<String> list;
        
        [SetUp]
        public void SetUp()
        {
            str1 = "A";
            str2 = "TA";
            list = new List<string> { "ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB" };
        }

        [Test]
        public void FilteroutTest()
        {
            ComplexChain chain = new ComplexChain(list);
            Filter filter = new Filter(chain);
            int hits = filter.FilterOut(str1);

            StringBuilder sb = new StringBuilder();
            foreach (String s in list) sb.Append(s);
            string result = filter.GetChain().ToString();
            string buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);

            filter = new Filter(chain);
            hits = filter.FilterOut(str2);

            filter.GetChain().ToString();
            chain.ToString();
            Assert.True(3 == hits);
        }

        [Test]
        public void ReplaceTest()
        {
            ComplexChain chain = new ComplexChain(list);
            Filter filter = new Filter(chain);
            int hits = filter.Replace(str2, "-");

            StringBuilder sb = new StringBuilder();
            foreach (String s in list)
            sb.Append(s);
            string result = filter.GetChain().ToString();
            string buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);
        }
    }
}