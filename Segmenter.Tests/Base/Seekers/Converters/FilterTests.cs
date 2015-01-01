﻿namespace Segmenter.Tests.Base.Seekers.Converters
{
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    using Segmenter.Base.Seekers.Converters;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// The filter test.
    /// </summary>
    [TestFixture]
    public class FilterTests
    {
        /// <summary>
        /// The str 1.
        /// </summary>
        private string str1;

        /// <summary>
        /// The str 2.
        /// </summary>
        private string str2;

        /// <summary>
        /// The list.
        /// </summary>
        private List<string> list;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            str1 = "A";
            str2 = "TA";
            list = new List<string> { "ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB" };
        }

        /// <summary>
        /// The filterout test.
        /// </summary>
        [Test]
        public void FilteroutTest()
        {
            var chain = new ComplexChain(list);
            var filter = new Filter(chain);
            int hits = filter.FilterOut(str1);

            var sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.Append(s);
            }

            string result = filter.GetChain().ToString();
            string buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);

            filter = new Filter(chain);
            hits = filter.FilterOut(str2);

            filter.GetChain().ToString();
            chain.ToString();
            Assert.True(3 == hits);
        }

        /// <summary>
        /// The replace test.
        /// </summary>
        [Test]
        public void ReplaceTest()
        {
            var chain = new ComplexChain(list);
            var filter = new Filter(chain);
            int hits = filter.Replace(str2, "-");

            var sb = new StringBuilder();
            foreach (string s in list)
            {
                sb.Append(s);
            }
            
            string result = filter.GetChain().ToString();
            string buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);
        }
    }
}
