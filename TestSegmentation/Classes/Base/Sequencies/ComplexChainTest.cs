using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using NUnit.Framework;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;

namespace TestSegmentation.Classes.Base.Sequencies
{
    [TestFixture]
    public class ComplexComplexChainTest
    {
        private ComplexChain chain;
        private ComplexChain differentComplexChain;

        [SetUp]
        public void SetUp()
        {
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
            differentComplexChain = new ComplexChain("AACAGGTGCTTATTT");
        }

        [Test]
        public void TestClone()
        {

            ComplexChain foreignComplexChain = chain.Clone();

            Assert.AreNotSame(chain, foreignComplexChain);
            Assert.True(chain.Equals(foreignComplexChain));
        }

        [Test]
        public void TestEquals()
        {
            ComplexChain foreignComplexChain = chain.Clone();

            Assert.True(foreignComplexChain.Equals(chain));
            foreignComplexChain.ClearAt(0);
            foreignComplexChain.ClearAt(0);
            Assert.True(!foreignComplexChain.Equals(chain));
        }

        [Test]
        public void TestElementAt()
        {
            String str1 = "A";
            String str2 = "G";
            String str3 = "C";

            Assert.True(str1.Equals(chain[0].ToString()));
            Assert.True(str2.Equals(chain[4].ToString()));
            Assert.True(str3.Equals(chain[2].ToString()));
        }

        [Test]
        public void TestSubstring()
        {
            int start = 0, end = 2;
            ComplexChain thirdComplexChain = new ComplexChain("AA");
            ComplexChain foreignComplexChain = new ComplexChain(chain.Substring(start, end));

            Assert.True(thirdComplexChain.Equals(foreignComplexChain));
        }

        [Test]
        public void TestClearAt()
        {
            ComplexChain secondComplexChain = new ComplexChain("AGTC");
            ComplexChain firstComplexChain = new ComplexChain("ATC");
            secondComplexChain.ClearAt(1);
            Assert.True(firstComplexChain.Equals(secondComplexChain));
        }

        [Test]
        public void TestConcat1()
        {
            int start = 0;
            int end = chain.Length;

            ComplexChain firstComplexChain = new ComplexChain(chain.Substring(start, end/2));
            ComplexChain secondComplexChain = new ComplexChain(chain.Substring(end/2, end));
            ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain);
            Assert.True(concatChain.Equals(chain));
        }

        [Test]
        public void TestConcat2()
        {
            int start = 0, end;
            end = chain.Length;

            ComplexChain firstComplexChain = new ComplexChain(chain.Substring(start, end - 1));
            ComplexChain secondComplexChain = new ComplexChain(chain.Substring(end - 1, end));
            ComplexChain concatChain = firstComplexChain.Concat(secondComplexChain.ToString());
            Assert.True(concatChain.Equals(chain));
        }

        [Test]
        public void TestLength()
        {
            ComplexChain foreignComplexChain = chain.Clone();

            Assert.True(chain.Length != differentComplexChain.Length);
            Assert.True(chain.Length == foreignComplexChain.Length);
            foreignComplexChain.ClearAt(0);
            Assert.True(chain.Length != foreignComplexChain.Length);
        }

        [Test]
        public void TestIsEmpty()
        {
            String str = "s";
            ComplexChain chain = new ComplexChain("");
            Assert.True(chain.IsEmpty());
            chain.Concat(str);
            Assert.True(!chain.IsEmpty());
            chain.ClearAt(0);
            Assert.True(chain.IsEmpty());
        }

        [Test]
        public void TestupdateUniforms()
        {
            FrequencyDictionary alphabet;
            ComplexChain clonedComplexChain;
            clonedComplexChain = chain.Clone();

            alphabet = new FrequencyDictionary(chain);
            chain.ClearAt(0);
            clonedComplexChain.ClearAt(0);
            Assert.True(chain.Equals(clonedComplexChain));
        }

        [Test]
        public void Testintervals()
        {

        }

        [Test]
        public void TestJoin()
        {
            ComplexChain clon = chain.Clone();
            List<String> list1 = new List<String>{"AAC","A","G","G","T","G","C","C","C","C","T","T","A","T","T","T"};
            List<String> list2 = new List<String>{"AAC","A","G","G","TGC","C","C","C","T","T","A","T","T","T"};
            List<String> list3 = new List<String>{"AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T"};
            List<String> list4 = new List<String>{"AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT"};
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
        public void TestjoinAll()
        {
            List<String> list1 = new List<String>
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
            List<String> list2 = new List<String> {"A", "A"};
            clon.JoinAll(list2);
        }
    }
}