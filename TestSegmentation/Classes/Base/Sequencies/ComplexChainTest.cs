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
        public void testClone()
        {

            ComplexChain foreignComplexChain = chain.Clone();

            Assert.AreNotSame(chain, foreignComplexChain);
            Assert.True(chain.Equals(foreignComplexChain));
        }

        [Test]
        public void testEquals()
        {
            ComplexChain foreignComplexChain = chain.Clone();

            Assert.True(foreignComplexChain.Equals(chain));
            foreignComplexChain.clearAt(0);
            foreignComplexChain.clearAt(0);
            Assert.True(!foreignComplexChain.Equals(chain));
        }

        [Test]
        public void testElementAt()
        {
            String str1 = "A";
            String str2 = "G";
            String str3 = "C";

            Assert.True(str1.Equals(chain.elementAt(0)));
            Assert.True(str2.Equals(chain.elementAt(4)));
            Assert.True(str3.Equals(chain.elementAt(2)));
        }

        [Test]
        public void testSubstring()
        {
            int start = 0, end = 2;
            ComplexChain thirdComplexChain = new ComplexChain("AA");
            ComplexChain foreignComplexChain = new ComplexChain(chain.substring(start, end));

            Assert.True(thirdComplexChain.Equals(foreignComplexChain));
        }

        [Test]
        public void testClearAt()
        {
            ComplexChain secondComplexChain = new ComplexChain("AGTC");
            ComplexChain firstComplexChain = new ComplexChain("ATC");
            secondComplexChain.clearAt(1);
            Assert.True(firstComplexChain.Equals(secondComplexChain));
        }

        [Test]
        public void testToUpperCase()
        {
            ComplexChain secondComplexChain = new ComplexChain("aacaggtgccccttattt");
            Assert.True(chain.Equals(secondComplexChain.toUpperCase()));
        }

        [Test]
        public void testConcat1()
        {
            int start = 0, end;
            end = chain.Length;

            ComplexChain firstComplexChain = new ComplexChain(chain.substring(start, end/2));
            ComplexChain secondComplexChain = new ComplexChain(chain.substring(end/2, end));
            Assert.True((firstComplexChain.concat(secondComplexChain)).Equals(chain));
        }

        [Test]
        public void testConcat2()
        {
            int start = 0, end;
            end = chain.Length;

            ComplexChain firstComplexChain = new ComplexChain(chain.substring(start, end - 1));
            ComplexChain secondComplexChain = new ComplexChain(chain.substring(end - 1, end));

            Assert.True((firstComplexChain.concat(secondComplexChain.ToString())).Equals(chain));
        }

        [Test]
        public void testLength()
        {
            ComplexChain foreignComplexChain = chain.Clone();

            Assert.True(chain.Length != differentComplexChain.Length);
            Assert.True(chain.Length == foreignComplexChain.Length);
            foreignComplexChain.clearAt(0);
            Assert.True(chain.Length != foreignComplexChain.Length);
        }

        [Test]
        public void testIsEmpty()
        {
            String str = "s";
            ComplexChain chain = new ComplexChain("");
            Assert.True(chain.IsEmpty());
            chain.concat(str);
            Assert.True(!chain.IsEmpty());
            chain.clearAt(0);
            Assert.True(chain.IsEmpty());
        }

        [Test]
        public void testupdateUniforms()
        {
            FrequencyDictionary alphabet;
            ComplexChain clonedComplexChain;
            clonedComplexChain = chain.Clone();

            alphabet = new FrequencyDictionary(chain);
            chain.clearAt(0);
            clonedComplexChain.clearAt(0);
            Assert.True(chain.Equals(clonedComplexChain));
        }

        [Test]
        public void testintervals()
        {

        }

        [Test]
        public void testjoin()
        {
            ComplexChain clon = chain.Clone();
            List<String> list1 = new List<String>{"AAC","A","G","G","T","G","C","C","C","C","T","T","A","T","T","T"};
            List<String> list2 = new List<String>{"AAC","A","G","G","TGC","C","C","C","T","T","A","T","T","T"};
            List<String> list3 = new List<String>{"AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "T", "T"};
            List<String> list4 = new List<String>{"AACAGGTGC", "C", "C", "C", "T", "T", "A", "T", "TT"};
            clon.join(0, 3);
            Assert.True((new ComplexChain(list1)).Equals(clon));

            clon.join(4, 3);
            Assert.True((new ComplexChain(list2)).Equals(clon));
            clon.join(0, 5);
            Assert.True((new ComplexChain(list3)).Equals(clon));

            clon.join(8, 2);
            Assert.True((new ComplexChain(list4)).Equals(clon));
        }

        [Test]
        public void testjoinAll()
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
            clon.joinAll(list2);
        }
    }
}