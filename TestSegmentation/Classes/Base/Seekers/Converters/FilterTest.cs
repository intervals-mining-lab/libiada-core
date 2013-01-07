using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Segmentation.Classes.Base.Seekers.Converters;
using Segmentation.Classes.Base.Sequencies;

namespace TestSegmentation.Classes.Base.Seekers.Converters
{
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
        public void testFilterout()
        {
            Filter filter = null;
            ComplexChain chain = null;
            String result, buf;
            int hits;
            chain = new ComplexChain(list);
            filter = new Filter(chain);
            hits = filter.filterout(str1);

            StringBuilder sb = new StringBuilder();
            foreach (String s in list) sb.Append(s);
            result = filter.getChain().ToString();
            buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);

            filter = new Filter(chain);
            hits = filter.filterout(str2);

            result = filter.getChain().ToString();
            buf = chain.ToString();
            Assert.True(3 == hits);
        }

        [Test]
        public void testReplace()
        {
            Filter filter = null;
            ComplexChain chain = null;
            String result, buf;
            int hits;
            chain = new ComplexChain(list);
            filter = new Filter(chain);
            hits = filter.replace(str2, "-");

            StringBuilder sb = new StringBuilder();
            foreach (String s in list)
            sb.Append(s);
            result = filter.getChain().ToString();
            buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);
        }
    }
}