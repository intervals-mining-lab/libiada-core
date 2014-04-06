namespace SegmentatorTest.Base.Iterators
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmentator.Base.Iterators;
    using Segmentator.Base.Sequencies;
    using Segmentator.Extended;

    [TestFixture]
    public class EndIteratorTest
    {
        private ComplexChain complexChain;

        [SetUp]
        public void SetUp()
        {
            this.complexChain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void HasNextTest()
        {
            int lengthCut = 3;
            int step = 1;
            int countSteps = 0;

            EndIterator iterator = new EndIterator(this.complexChain, lengthCut, step);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }

            Assert.AreEqual(countSteps, iterator.MaxShifts);

            countSteps = 0;
            iterator = new EndIterator(this.complexChain, lengthCut, step + 1);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }

            Assert.True(countSteps == iterator.MaxShifts);
        }

        [Test]
        public void NextTest()
        {
            List<string> cut;
            string[] triplesForStepOne =
                {
                    "AAC", "ACA", "CAG", "AGG",
                    "GGT", "GTG", "TGC", "GCC",
                    "CCC", "CCC", "CCT", "CTT",
                    "TTA", "TAT", "ATT", "TTT"
                };
            string[] triplesForStepTwo = { "AAC", "CAG", "GGT", "TGC", "CCC", "CCT", "TTA", "ATT" };
            int lengthCut = 3;
            int step = 1;

            EndIterator iterator = new EndIterator(this.complexChain, lengthCut, step);

            for (int i = iterator.MaxShifts - 1; i >= 0; i--)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
            }

            iterator = new EndIterator(this.complexChain, lengthCut, step + 1);

            for (int i = iterator.MaxShifts - 1; i >= 0; i--)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepTwo[i]));
            }
        }

        [Test]
        public void ResetTest()
        {
            int lengthCut = 2;
            int step = 1;
            int index = 0;
            int position = 6;
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
            ComplexChain chain = new ComplexChain(list1);
            EndIterator iterator = new EndIterator(chain, lengthCut, step);
            while (iterator.HasNext())
            {
                iterator.Next();
                index = index + 1;
            }

            iterator.Reset();

            Assert.True(iterator.Position() == position);
        }

        [Test]
        public void GetMaxShiftsTest()
        {
            int lengthCut = 3;
            int step = 1;
            int maxShifts = 16;
            EndIterator iterator = new EndIterator(this.complexChain, lengthCut, step);
            Assert.True(iterator.MaxShifts == maxShifts);
        }

        [Test]
        public void MoveTest()
        {
            int len = 2;
            int step = 1;
            int from = 1, to = 3;
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
            List<string> list = list1.GetRange(@from, to - @from);
            ComplexChain chain = new ComplexChain(list1);
            EndIterator iterator = new EndIterator(chain, len, step);
            iterator.Move(2);
            List<string> result = iterator.Next();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.True(list[i].Equals(result[i]));
            }
        }
    }
}