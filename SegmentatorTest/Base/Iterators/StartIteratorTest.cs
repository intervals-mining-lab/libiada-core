namespace SegmentatorTest.Base.Iterators
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmentator.Base.Iterators;
    using Segmentator.Base.Sequencies;
    using Segmentator.Extended;

    [TestFixture]
    public class StartIteratorTest
    {
        private ComplexChain chain;

        [SetUp]
        public void SetUp()
        {
            this.chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void HasNextTest()
        {
            int lengthCut = 3;
            int step = 1;
            int countSteps = 0;

            StartIterator iterator = new StartIterator(this.chain, lengthCut, step);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }

            Assert.True(countSteps == iterator.MaxShifts);

            countSteps = 0;
            iterator = new StartIterator(this.chain, lengthCut, step + 1);
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
                    "AAC", "ACA", "CAG", "AGG", "GGT", "GTG", "TGC", "GCC", "CCC", "CCC", "CCT",
                    "CTT", "TTA", "TAT", "ATT", "TTT"
                };
            string[] triplesForStepTwo = { "AAC", "CAG", "GGT", "TGC", "CCC", "CCT", "TTA", "ATT" };
            int lengthCut = 3;
            int step = 1;

            StartIterator iterator = new StartIterator(this.chain, lengthCut, step);

            for (int i = 0; i < iterator.MaxShifts; i++)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
            }

            iterator = new StartIterator(this.chain, lengthCut, step + 1);

            for (int i = 0; i < iterator.MaxShifts; i++)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepTwo[i]));
            }
        }

        [Test]
        public void ResetTest()
        {
            int length = 2;
            int step = 1;
            StartIterator iterator = new StartIterator(this.chain, length, step);
            if (iterator.Move(3))
            {
                iterator.Reset();
            }

            Assert.True(iterator.CursorPosition == -step);
        }

        [Test]
        public void MoveTest()
        {
            int length = 2;
            int step = 1;
            int position = 3;
            StartIterator iterator = new StartIterator(this.chain, length, step);
            iterator.Move(position);
            Assert.True(iterator.CursorPosition == position);

            position = 100;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition != position);

            position = this.chain.Length / 2;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition == position);

            position = -1;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition != position);

            length = 3;
            step = 2;
            position = 3;
            string triple = "GTG";
            iterator = new StartIterator(this.chain, length, step);
            iterator.Move(position);
            iterator.Next();
            Assert.AreEqual(triple, Helper.ToString(iterator.Current()));
        }

        [Test]
        public void GetMaxShiftsTest()
        {
            int lengthCut = 3;
            int step = 1;
            int maxShifts = 16;
            StartIterator iterator = new StartIterator(this.chain, lengthCut, step);
            Assert.True(iterator.MaxShifts == maxShifts);
        }

        [Test]
        public void GetPositionTest()
        {
            int lengthCut = 2;
            int step = 1;
            StartIterator iterator = new StartIterator(this.chain, lengthCut, step);
            iterator.Next();
            Assert.True(iterator.CursorPosition == 0);
            iterator.Next();
            Assert.True(iterator.CursorPosition == 1);
            for (int index = 2; index < iterator.MaxShifts; index++)
            {
                iterator.Next();
            }

            Assert.True(iterator.CursorPosition == 16);
        }
    }
}