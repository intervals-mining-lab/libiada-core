using System;
using System.Collections.Generic;
using NUnit.Framework;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Extended;

namespace TestSegmentation.Classes.Base.Iterators
{
    [TestFixture]
    public class StartIteratorTest
    {
        private ComplexChain chain;

        [SetUp]
        public void SetUp()
        {
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void testHasNext()
        {
            int lengthCut = 3;
            int step = 1;
            int countSteps = 0;
            StartIterator iterator = null;
            List<String> cut = null;

            iterator = new StartIterator(chain, lengthCut, step);
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

        [Test]
        public void testNext()
        {
            StartIterator iterator = null;
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

            iterator = new StartIterator(chain, lengthCut, step);

            for (int i = 0; i < iterator.MaxShifts; i++)
            {
                cut = iterator.Next();
                //            System.out.println(triplesForStepOne[i] + " vs " + cut);
                Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
            }

            iterator = new StartIterator(chain, lengthCut, step + 1);

            for (int i = 0; i < iterator.MaxShifts; i++)
            {
                cut = iterator.Next();
                Assert.True(Helper.ToString(cut).Equals(triplesForStepTwo[i]));
            }
        }

        [Test]
        public void testReset()
        {
            StartIterator iterator = null;
            int length = 2;
            int step = 1;
            iterator = new StartIterator(chain, length, step);
            if (iterator.Move(3))
            {
                iterator.Reset();
            }
            Assert.True(iterator.CursorPosition == -step);
        }

        [Test]
        public void testMove()
        {
            StartIterator iterator = null;
            int length = 2;
            int step = 1;
            int position = 3;
            iterator = new StartIterator(chain, length, step);
            iterator.Move(position);
            Assert.True(iterator.CursorPosition == position);


            position = 100;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition != position);

            position = chain.Length/2;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition == position);

            position = -1;
            iterator.Move(position);
            Assert.True(iterator.CursorPosition != position);

            length = 3;
            step = 2;
            position = 3;
            String triple = "GTG";
            iterator = new StartIterator(chain, length, step);
            iterator.Move(position);
            iterator.Next();
            Assert.AreEqual(triple, Helper.ToString(iterator.Current()));
            //            System.out.println(triple + " vs " + Helper.ToString(iterator.current()));
        }

        [Test]
        public void testGetMaxShifts()
        {
            StartIterator iterator = null;
            int lengthCut = 3;
            int step = 1;
            int maxShifts = 16;
            iterator = new StartIterator(chain, lengthCut, step);
            Assert.True(iterator.MaxShifts == maxShifts);
        }

        [Test]
        public void testGetPosition()
        {
            StartIterator iterator = null;
            int lengthCut = 2;
            int step = 1;
            iterator = new StartIterator(chain, lengthCut, step);
            iterator.Next();
            Assert.True(iterator.CursorPosition == 0);
            iterator.Next();
            Assert.True(iterator.CursorPosition == 1);
            for (int index = 2; index < iterator.MaxShifts; index++)
                iterator.Next();
            Assert.True(iterator.CursorPosition == 16);

        }
    }
}