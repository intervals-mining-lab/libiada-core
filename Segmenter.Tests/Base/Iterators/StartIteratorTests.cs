namespace Segmenter.Tests.Base.Iterators
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Segmenter.Base.Iterators;
    using Segmenter.Base.Sequences;
    using Segmenter.Extended;

    /// <summary>
    /// The start iterator test.
    /// </summary>
    [TestFixture]
    public class StartIteratorTests
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private ComplexChain chain;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        /// <summary>
        /// The has next test.
        /// </summary>
        [Test]
        public void HasNextTest()
        {
            int lengthCut = 3;
            int step = 1;
            int countSteps = 0;

            var iterator = new StartIterator(chain, lengthCut, step);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }

            Assert.True(countSteps == iterator.MaxShifts);

            countSteps = 0;
            iterator = new StartIterator(chain, lengthCut, step + 1);
            while (iterator.HasNext())
            {
                iterator.Next();
                countSteps = countSteps + 1;
            }

            Assert.True(countSteps == iterator.MaxShifts);
        }

        /// <summary>
        /// The next test.
        /// </summary>
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

            var iterator = new StartIterator(chain, lengthCut, step);

            for (int i = 0; i < iterator.MaxShifts; i++)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
            }

            iterator = new StartIterator(chain, lengthCut, step + 1);

            for (int i = 0; i < iterator.MaxShifts; i++)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepTwo[i]));
            }
        }

        /// <summary>
        /// The reset test.
        /// </summary>
        [Test]
        public void ResetTest()
        {
            int length = 2;
            int step = 1;
            var iterator = new StartIterator(chain, length, step);
            if (iterator.Move(3))
            {
                iterator.Reset();
            }

            Assert.True(iterator.CursorPosition == -step);
        }

        /// <summary>
        /// The move test.
        /// </summary>
        [Test]
        public void MoveTest()
        {
            int length = 2;
            int step = 1;
            int position = 3;
            var iterator = new StartIterator(chain, length, step);
            iterator.Move(position);
            Assert.True(iterator.CursorPosition == position);

            position = 100;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition != position);

            position = chain.GetLength() / 2;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition == position);

            position = -1;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition != position);

            length = 3;
            step = 2;
            position = 3;
            string triple = "GTG";
            iterator = new StartIterator(chain, length, step);
            iterator.Move(position);
            iterator.Next();
            Assert.AreEqual(triple, Helper.ToString(iterator.Current()));
        }

        /// <summary>
        /// The get max shifts test.
        /// </summary>
        [Test]
        public void GetMaxShiftsTest()
        {
            int lengthCut = 3;
            int step = 1;
            int maxShifts = 16;
            var iterator = new StartIterator(chain, lengthCut, step);
            Assert.True(iterator.MaxShifts == maxShifts);
        }

        /// <summary>
        /// The get position test.
        /// </summary>
        [Test]
        public void GetPositionTest()
        {
            int lengthCut = 2;
            int step = 1;
            var iterator = new StartIterator(chain, lengthCut, step);
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
