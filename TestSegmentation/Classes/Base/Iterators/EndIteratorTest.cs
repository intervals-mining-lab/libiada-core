using System;
using System.Collections.Generic;
using NUnit.Framework;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Extended;

namespace TestSegmentation.Classes.Base.Iterators
{
    [TestFixture]
    public class EndIteratorTest
    {
        private ComplexChain chain;

        [SetUp]
        public void SetUp()
        {
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void TestHasNext()
        {
            int lengthCut = 3;
            int step = 1;
            int countSteps = 0;
            EndIterator iterator = null;
            List<String> cut = null;

            iterator = new EndIterator(chain, lengthCut, step);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }
            Assert.AreEqual(countSteps, iterator.MaxShifts);

            //        System.out.println("Count steps " + countSteps);
            countSteps = 0;
            iterator = new EndIterator(chain, lengthCut, step + 1);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }
            Assert.True(countSteps == iterator.MaxShifts);
            //        System.out.println("Count steps " + countSteps);
        }

        [Test]
        public void TestNext()
        {
            EndIterator iterator = null;
            List<String> cut = null;
            String[] triplesForStepOne =
                {
                    "AAC", "ACA", "CAG", "AGG",
                    "GGT", "GTG", "TGC", "GCC",
                    "CCC", "CCC", "CCT", "CTT",
                    "TTA", "TAT", "ATT", "TTT"
                };
            String[] triplesForStepTwo = {"AAC", "CAG", "GGT", "TGC", "CCC", "CCT", "TTA", "ATT"};
            int lengthCut = 3;
            int step = 1;

            iterator = new EndIterator(chain, lengthCut, step);

            for (int i = iterator.MaxShifts - 1; i >= 0; i--)
            {
                cut = iterator.Next();
                //            System.out.println(triplesForStepOne[i] + " vs " + cut);
                Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
            }

            iterator = new EndIterator(chain, lengthCut, step + 1);

            for (int i = iterator.MaxShifts - 1; i >= 0; i--)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepTwo[i]));
            }

        }

        [Test]
        public void TestReset()
        {
            EndIterator iterator = null;
            ComplexChain chain = null;
            List<String> list = null;
            int lengthCut = 2;
            int step = 1;
            int index = 0;
            int position = 6;
            List<String> list1 = new List<string>
                {
                    "ABABAB",
                    "ABATAT",
                    "TABABAB",
                    "ABTABAB",
                    "ABABAB",
                    "ABABAB",
                    "ABABAB"
                };
            chain = new ComplexChain(list1);
            iterator = new EndIterator(chain, lengthCut, step);
            while (iterator.HasNext())
            {
                iterator.Next();
                index = index + 1;
            }
            iterator.Reset();

            Assert.True(iterator.Position() == position);

        }

        [Test]
        public void TestGetMaxShifts()
        {
            EndIterator iterator = null;
            int lengthCut = 3;
            int step = 1;
            int maxShifts = 16;
            iterator = new EndIterator(chain, lengthCut, step);
            Assert.True(iterator.MaxShifts == maxShifts);
        }

        [Test]
        public void TestMove()
        {
            EndIterator iterator = null;
            ComplexChain chain = null;
            List<String> list = null;
            int len = 2;
            int step = 1;
            int index = 0;
            int from = 1, to = 3;
            List<String> list1 = new List<string>
                {
                    "ABABAB",
                    "ABATAT",
                    "TABABAB",
                    "ABTABAB",
                    "ABABAB",
                    "ABABAB",
                    "ABABAB"
                };
            list = list1.GetRange(from, to - from);
            chain = new ComplexChain(list1);
            iterator = new EndIterator(chain, len, step);
            iterator.Move(2);
            List<String> result = iterator.Next();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.True(list[i].Equals(result[i]));
            }
            
        }
    }
}