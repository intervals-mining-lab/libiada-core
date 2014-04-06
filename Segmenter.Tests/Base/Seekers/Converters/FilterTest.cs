namespace Segmenter.Tests.Base.Seekers.Converters
{
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    using Segmenter.Base.Seekers.Converters;
    using Segmenter.Base.Sequencies;

    [TestFixture]
    public class FilterTest
    {
        private string str1;
        private string str2;
        private List<string> list;
        
        [SetUp]
        public void SetUp()
        {
            this.str1 = "A";
            this.str2 = "TA";
            this.list = new List<string> { "ABABAB", "ABATAT", "TABABAB", "ABTABAB", "ABABAB", "ABABAB", "ABABAB" };
        }

        [Test]
        public void FilteroutTest()
        {
            ComplexChain chain = new ComplexChain(this.list);
            Filter filter = new Filter(chain);
            int hits = filter.FilterOut(this.str1);

            StringBuilder sb = new StringBuilder();
            foreach (string s in this.list)
            {
                sb.Append(s);
            }

            string result = filter.GetChain().ToString();
            string buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);

            filter = new Filter(chain);
            hits = filter.FilterOut(this.str2);

            filter.GetChain().ToString();
            chain.ToString();
            Assert.True(3 == hits);
        }

        [Test]
        public void ReplaceTest()
        {
            ComplexChain chain = new ComplexChain(this.list);
            Filter filter = new Filter(chain);
            int hits = filter.Replace(this.str2, "-");

            StringBuilder sb = new StringBuilder();
            foreach (string s in this.list)
            {
                sb.Append(s);
            }
            
            string result = filter.GetChain().ToString();
            string buf = chain.ToString();
            Assert.True(buf.Length - result.Length == hits);
        }
    }
}