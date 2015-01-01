namespace Segmenter.Base.Iterators
{
    using System;
    using System.Collections.Generic;

    using Segmenter.Base.Sequences;
    using Segmenter.Interfaces;

    /// <summary>
    /// Describes a behavior and a structure of  a simple iterator
    /// </summary>
    public abstract class BaseIterator : IIterator
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
        protected List<string> currentCut = new List<string>();

        /// <summary>
        /// Initializes a main options of an iterator.
        /// </summary>
        /// <param name="chain">An iterate sequence</param>
        /// <param name="length">Length of a word (window of cutting)</param>
        /// <param name="step">The number of elements through which the pointer will jump at the next iteration</param>
        public BaseIterator(ComplexChain chain, int length, int step)
        {
            Initialize(chain, length, step);
        }

        /// <summary>
        /// Gets maximum number of iterations on this chain
        /// </summary>
        /// <returns>Maximum number of iterations on this chain</returns>
        public int MaxShifts
        {
            get
            {
                return maxShifts;
            }
        }

        /// <summary>
        /// Gets current cursor cursorPosition
        /// </summary>
        /// <returns>Current cursor cursorPosition</returns>
        public int CursorPosition
        {
            get
            {
                return cursorPosition;
            }
        }

        /// <summary>
        /// Gets number of shifts at this moment
        /// </summary>
        /// <returns>number of shifts</returns>
        public int Shifts
        {
            get
            {
                return (CursorPosition / step) + 1;
            }
        }

        /// <summary>
        /// Moves a pointer to specified cursorPosition
        /// </summary>
        /// <param name="position">a cursorPosition in a chain subject to a cutting window</param>
        /// <returns>true if moving is available, false - otherwise</returns>
        public abstract bool Move(int position);

        /// <summary>
        /// The has next.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool HasNext();

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public abstract List<string> Next();

        /// <summary>
        /// The reset.
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// The position.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public abstract int Position();

        /// <summary>
        /// The current.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public abstract List<string> Current();

        /// <summary>
        /// Calculates count of shifts
        /// </summary>
        private void CalculateMaxShifts()
        {
            maxShifts = ((chain.GetLength() - windowLength) / step) + 1;
        }

        /// <summary>
        /// The initialize method.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="windowLength">
        /// The window length.
        /// </param>
        /// <param name="step">
        /// The step.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        private void Initialize(ComplexChain chain, int windowLength, int step)
        {
            try
            {
                int chainLength = chain.GetLength();

                if ((chainLength < windowLength) || (windowLength == 0) || ((step < 1) || (step > chainLength)))
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
            }

            this.chain = chain.Clone();
            this.windowLength = windowLength;
            this.step = step;
            cursorPosition = -step;
            CalculateMaxShifts();
        }
    }
}
