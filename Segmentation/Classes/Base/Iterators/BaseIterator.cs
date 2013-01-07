using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Iterators
{
    /// <summary>
    /// Describes a behavior and a structure of  a simple iterator
    /// </summary>
    public abstract class BaseIterator: IIterator
    {
        /// <summary>
        /// Current cursor cursorPosition
        /// </summary>
        protected int cursorPosition = -1;

        /// <summary>
        /// The number of elements through which the pointer will jump at the next iteration
        /// </summary>
        protected int step;

        /// <summary>
        /// Length of a word (window of cutting)
        /// </summary>
        protected int windowLength;

        /// <summary>
        /// Amount of offsets for current sequence
        /// </summary>
        protected int maxShifts;

        /// <summary>
        /// An iterate sequence
        /// </summary>
        protected ComplexChain chain;

        /// <summary>
        /// The currentCut composed sequence was extracted from a chain
        /// </summary>
        protected List<String> currentCut = new List<String>();

        /// <summary>
        /// Initializes a main options of an iterator.
        /// </summary>
        /// <param name="chain">An iterate sequence</param>
        /// <param name="length">Length of a word (window of cutting)</param>
        /// <param name="step">The number of elements through which the pointer will jump at the next iteration</param>
        public BaseIterator(ComplexChain chain, int length, int step)
        {
            init(chain, length, step);
        }

        private void init(ComplexChain chain, int windowLength, int step)
        {
            try
            {
                int chainLength = chain.Length;

                if ((chainLength < windowLength) || (windowLength == 0)
                    || ((step < 1) || (step > chainLength)))
                    throw new Exception();
            }
            catch (Exception e)
            {
            }


            this.chain = (ComplexChain)chain.Clone();
            this.windowLength = windowLength;
            this.step = step;
            this.cursorPosition = -step;
            CalculteMaxShifts();
        }

        /// <summary>
        /// Returns maximum number of iterations on this chain
        /// </summary>
        /// <returns>Maximum number of iterations on this chain</returns>
        public int getMaxShifts()
        {
            return maxShifts;
        }

        /// <summary>
        /// Returns current cursor cursorPosition
        /// </summary>
        /// <returns>Current cursor cursorPosition</returns>
        public int getCursorPosition()
        {
            return cursorPosition;
        }

        /// <summary>
        /// Returns number of shifts at this moment
        /// </summary>
        /// <returns>number of shifts</returns>
        public int shifts()
        {
            return (cursorPosition/step) + 1;
        }

        /// <summary>
        /// Calculates count of shifts
        /// </summary>
        private void CalculteMaxShifts()
        {
            maxShifts = (chain.Length - windowLength)/step + 1;
        }

        /// <summary>
        /// Moves a pointer to specified cursorPosition
        /// </summary>
        /// <param name="position">a cursorPosition in a chain subject to a cutting window</param>
        /// <returns>true if moving is available, false - otherwise</returns>
        public abstract bool move(int position);

        public abstract bool hasNext();

        public abstract List<string> next();

        public abstract void reset();

        public abstract int position();

        public abstract List<string> current();
    }
}