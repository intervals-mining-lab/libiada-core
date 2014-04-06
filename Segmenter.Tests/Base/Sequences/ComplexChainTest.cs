namespace Segmenter.Tests.Base.Sequences
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Sequences;

    /// <summary>
    /// The complex complex chain test.
    /// </summary>
    [TestFixture]
    public class ComplexComplexChainTest
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private ComplexChain chain;

        /// <summary>
        /// The different complex chain.
        /// </summary>
        private ComplexChain differentComplexChain;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.chain = new ComplexChain("AACAGGTGCCCCTTATTT");
            this.differentComplexChain = new ComplexChain("AACAGGTGCTTATTT");
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            ComplexChain foreignComplexChain = this.chain.Clone();

            Assert.AreNotSame(this.chain, foreignComplexChain);
            Assert.True(this.chain.Equals(foreignComplexChain));
        }

        /// <summary>
        /// The equals test.
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            ComplexChain foreignComplexChain = this.chain.Clone();

            Assert.True(foreignComplexChain.Equals(this.chain));
            foreignComplexChain.ClearAt(0);
            foreignComplexChain.ClearAt(0);
            Assert.True(!foreignComplexChain.Equals(this.chain));
        }

        /// <summary>
        /// The element at test.
        /// </summary>
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

        /// <summary>
        /// The substring test.
        /// </summary>
        [Test]
        public void SubstringTest()
        {
            int start = 0, end = 2;
            var thirdComplexChain = new ComplexChain("AA");
            var foreignComplexChain = new ComplexChain(this.chain.Substring(start, end));

            Assert.True(thirdComplexChain.Equals(foreignComplexChain));
        }

        /// <summary>
        /// The clear at test.
        /// </summary>
        [Test]
        public void ClearAtTest()
        {
            var secondComplexChain = new ComplexChain("AGTC");
            var firstComplexChain = new ComplexChain("ATC");
            secondComplexChain.ClearAt(1);
            Assert.True(firstComplexChain.Equals(secondComplexChain));
        }

        /// <summary>
        /// The concat one test.
        /// </summary>
        [Test]
        public void ConcatOneTest()
        {
            int start = 0;
            int end = this.chain.Length;

            var firstComplexChain = new ComplexChain(this.chain.Substring(start, end / 2));
            var secondComplexChain = new ComplexChain(this.chain.Substring(end / 2, end));
            ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain);
            Assert.True(concatChain.Equals(this.chain));
        }

        /// <summary>
        /// The concat two test.
        /// </summary>
        [Test]
        public void ConcatTwoTest()
        {
            int start = 0;
            int end = this.chain.Length;

            var firstComplexChain = new ComplexChain(this.chain.Substring(start, end - 1));
            var secondComplexChain = new ComplexChain(this.chain.Substring(end - 1, end));
            ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain.ToString());
            Assert.True(concatChain.Equals(this.chain));
        }

        /// <summary>
        /// The length test.
        /// </summary>
        [Test]
        public void LengthTest()
        {
            ComplexChain foreignComplexChain = this.chain.Clone();

            Assert.True(this.chain.Length != this.differentComplexChain.Length);
            Assert.True(this.chain.Length == foreignComplexChain.Length);
            foreignComplexChain.ClearAt(0);
            Assert.True(this.chain.Length != foreignComplexChain.Length);
        }

        /// <summary>
        /// The is empty test.
        /// </summary>
        [Test]
        public void IsEmptyTest()
        {
            string str = "s";
            var chain = new ComplexChain(string.Empty);
            Assert.True(chain.IsEmpty());
            chain.Concat(str);
            Assert.True(!chain.IsEmpty());
            chain.ClearAt(0);
            Assert.True(chain.IsEmpty());
        }

        /// <summary>
        /// The update uniforms test.
        /// </summary>
        [Test]
        public void UpdateUniformsTest()
        {
            ComplexChain clonedComplexChain = this.chain.Clone();

            this.chain.ClearAt(0);
            clonedComplexChain.ClearAt(0);
            Assert.True(this.chain.Equals(clonedComplexChain));
        }

        /// <summary>
        /// The join test.
        /// </summary>
        [Test]
        public void JoinTest()
        {
            ComplexChain clon = this.chain.Clone();
            var list1 = new List<string>
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
            var list2 = new List<string>
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
            var list3 = new List<string> { "AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T" };
            var list4 = new List<string> { "AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT" };
            clon.Join(0, 3);
            Assert.True((new ComplexChain(list1)).Equals(clon));

            clon.Join(4, 3);
            Assert.True((new ComplexChain(list2)).Equals(clon));
            clon.Join(0, 5);
            Assert.True((new ComplexChain(list3)).Equals(clon));

            clon.Join(8, 2);
            Assert.True((new ComplexChain(list4)).Equals(clon));
        }

        /// <summary>
        /// The join all test.
        /// </summary>
        [Test]
        public void JoinAllTest()
        {
            var list1 = new List<string>
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
            var clon = new ComplexChain(list1);
            var list2 = new List<string> { "A", "A" };
            clon.JoinAll(list2);
        }
    }
}