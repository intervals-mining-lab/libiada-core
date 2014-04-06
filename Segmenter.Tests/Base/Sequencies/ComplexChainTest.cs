namespace Segmenter.Tests.Base.Sequencies
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Sequencies;

    [TestFixture]
    public class ComplexComplexChainTest
    {
        private ComplexChain chain;

        private ComplexChain differentComplexChain;

        [SetUp]
        public void SetUp()
        {
            this.chain = new ComplexChain("AACAGGTGCCCCTTATTT");
            this.differentComplexChain = new ComplexChain("AACAGGTGCTTATTT");
        }

        [Test]
        public void CloneTest()
        {
            ComplexChain foreignComplexChain = this.chain.Clone();

            Assert.AreNotSame(this.chain, foreignComplexChain);
            Assert.True(this.chain.Equals(foreignComplexChain));
        }

        [Test]
        public void EqualsTest()
        {
            ComplexChain foreignComplexChain = this.chain.Clone();

            Assert.True(foreignComplexChain.Equals(this.chain));
            foreignComplexChain.ClearAt(0);
            foreignComplexChain.ClearAt(0);
            Assert.True(!foreignComplexChain.Equals(this.chain));
        }

        [Test]
        public void ElementAtTest()
        {
            string str1 = "A";
            string str2 = "G";
            string str3 = "C";

            Assert.True(str1.Equals(this.chain[0].ToString()));
            Assert.True(str2.Equals(this.chain[4].ToString()));
            Assert.True(str3.Equals(this.chain[2].ToString()));
        }

        [Test]
        public void SubstringTest()
        {
            int start = 0, end = 2;
            ComplexChain thirdComplexChain = new ComplexChain("AA");
            ComplexChain foreignComplexChain = new ComplexChain(this.chain.Substring(start, end));

            Assert.True(thirdComplexChain.Equals(foreignComplexChain));
        }

        [Test]
        public void ClearAtTest()
        {
            ComplexChain secondComplexChain = new ComplexChain("AGTC");
            ComplexChain firstComplexChain = new ComplexChain("ATC");
            secondComplexChain.ClearAt(1);
            Assert.True(firstComplexChain.Equals(secondComplexChain));
        }

        [Test]
        public void ConcatOneTest()
        {
            int start = 0;
            int end = this.chain.Length;

            ComplexChain firstComplexChain = new ComplexChain(this.chain.Substring(start, end / 2));
            ComplexChain secondComplexChain = new ComplexChain(this.chain.Substring(end / 2, end));
            ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain);
            Assert.True(concatChain.Equals(this.chain));
        }

        [Test]
        public void ConcatTwoTest()
        {
            int start = 0;
            int end = this.chain.Length;

            ComplexChain firstComplexChain = new ComplexChain(this.chain.Substring(start, end - 1));
            ComplexChain secondComplexChain = new ComplexChain(this.chain.Substring(end - 1, end));
            ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain.ToString());
            Assert.True(concatChain.Equals(this.chain));
        }

        [Test]
        public void LengthTest()
        {
            ComplexChain foreignComplexChain = this.chain.Clone();

            Assert.True(this.chain.Length != this.differentComplexChain.Length);
            Assert.True(this.chain.Length == foreignComplexChain.Length);
            foreignComplexChain.ClearAt(0);
            Assert.True(this.chain.Length != foreignComplexChain.Length);
        }

        [Test]
        public void IsEmptyTest()
        {
            string str = "s";
            ComplexChain chain = new ComplexChain(string.Empty);
            Assert.True(chain.IsEmpty());
            chain.Concat(str);
            Assert.True(!chain.IsEmpty());
            chain.ClearAt(0);
            Assert.True(chain.IsEmpty());
        }

        [Test]
        public void UpdateUniformsTest()
        {
            ComplexChain clonedComplexChain = this.chain.Clone();

            // new FrequencyDictionary(chain);
            this.chain.ClearAt(0);
            clonedComplexChain.ClearAt(0);
            Assert.True(this.chain.Equals(clonedComplexChain));
        }

        [Test]
        public void JoinTest()
        {
            ComplexChain clon = this.chain.Clone();
            List<string> list1 = new List<string>
                                     {
                                         "AAC",
                                         "A",
                                         "G",
                                         "G",
                                         "T",
                                         "G",
                                         "C",
                                         "C",
                                         "C",
                                         "C",
                                         "T",
                                         "T",
                                         "A",
                                         "T",
                                         "T",
                                         "T"
                                     };
            List<string> list2 = new List<string>
                                     {
                                         "AAC",
                                         "A",
                                         "G",
                                         "G",
                                         "TGC",
                                         "C",
                                         "C",
                                         "C",
                                         "T",
                                         "T",
                                         "A",
                                         "T",
                                         "T",
                                         "T"
                                     };
            List<string> list3 = new List<string> { "AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T" };
            List<string> list4 = new List<string> { "AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT" };
            clon.Join(0, 3);
            Assert.True((new ComplexChain(list1)).Equals(clon));

            clon.Join(4, 3);
            Assert.True((new ComplexChain(list2)).Equals(clon));
            clon.Join(0, 5);
            Assert.True((new ComplexChain(list3)).Equals(clon));

            clon.Join(8, 2);
            Assert.True((new ComplexChain(list4)).Equals(clon));
        }

        [Test]
        public void JoinAllTest()
        {
            List<string> list1 = new List<string>
                                     {
                                         "A",
                                         "A",
                                         "G",
                                         "G",
                                         "T",
                                         "G",
                                         "C",
                                         "A",
                                         "A",
                                         "A",
                                         "A",
                                         "T",
                                         "A",
                                         "T",
                                         "A",
                                         "A",
                                         "A"
                                     };
            ComplexChain clon = new ComplexChain(list1);
            List<string> list2 = new List<string> { "A", "A" };
            clon.JoinAll(list2);
        }
    }
}