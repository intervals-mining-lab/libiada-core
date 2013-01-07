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
            while (iterator.hasNext())
            {
                iterator.next();
                countSteps = countSteps + 1;
            }
            Assert.True(countSteps == iterator.getMaxShifts());

            countSteps = 0;
            iterator = new StartIterator(chain, lengthCut, step + 1);
            while (iterator.hasNext())
            {
                iterator.next();
                countSteps = countSteps + 1;
            }
            Assert.True(countSteps == iterator.getMaxShifts());
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

            for (int i = 0; i < iterator.getMaxShifts(); i++)
            {
                cut = iterator.next();
                //            System.out.println(triplesForStepOne[i] + " vs " + cut);
                Assert.True(Helper.ToString(cut).Equals(triplesForStepOne[i]));
            }

            iterator = new StartIterator(chain, lengthCut, step + 1);

            for (int i = 0; i < iterator.getMaxShifts(); i++)
            {
                cut = iterator.next();
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
            if (iterator.move(3))
            {
                iterator.reset();
            }
            Assert.True(iterator.getCursorPosition() == -step);
        }

        [Test]
        public void testMove()
        {
            StartIterator iterator = null;
            int length = 2;
            int step = 1;
            int position = 3;
            iterator = new StartIterator(chain, length, step);
            iterator.move(position);
            Assert.True(iterator.getCursorPosition() == position);


            position = 100;
            iterator.move(position);
            Assert.True(iterator.getCursorPosition() != position);

            position = chain.Length/2;
            iterator.move(position);
            Assert.True(iterator.getCursorPosition() == position);

            position = -1;
            iterator.move(position);
            Assert.True(iterator.getCursorPosition() != position);

            length = 3;
            step = 2;
            position = 3;
            String triple = "GTG";
            iterator = new StartIterator(chain, length, step);
            iterator.move(position);
            iterator.next();
            Assert.AreEqual(triple, Helper.ToString(iterator.current()));
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
            Assert.True(iterator.getMaxShifts() == maxShifts);
        }

        [Test]
        public void testGetPosition()
        {
            StartIterator iterator = null;
            int lengthCut = 2;
            int step = 1;
            iterator = new StartIterator(chain, lengthCut, step);
            iterator.next();
            Assert.True(iterator.getCursorPosition() == 0);
            iterator.next();
            Assert.True(iterator.getCursorPosition() == 1);
            for (int index = 2; index < iterator.getMaxShifts(); index++)
                iterator.next();
            Assert.True(iterator.getCursorPosition() == 16);

        }
    }
}