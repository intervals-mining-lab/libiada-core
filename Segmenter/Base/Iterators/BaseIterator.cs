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
        /// The number of elements through which the pointer will jump at the next iteration
        /// </summary>
        protected int step;

        /// <summary>
        /// Length of a word (window of cutting)
        /// </summary>
        protected int windowLength;

        /// <summary>
        /// An iterate sequence
        /// </summary>
        protected ComplexChain chain;

        /// <summary>
        /// The currentCut composed sequence was extracted from a chain
        /// </summary>
        protected List<string> currentCut = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIterator"/> class.
        /// </summary>
        /// <param name="chain">
        /// An iterated sequence.
        /// </param>
        /// <param name="length">
        /// Length of a word (window of cutting).
        /// </param>
        /// <param name="step">
        /// The number of elements through which the pointer will jump at the next iteration.
        /// </param>
        public BaseIterator(ComplexChain chain, int length, int step)
        {
            CursorPosition = -1;
            Initialize(chain, length, step);
        }

        /// <summary>
        /// Gets or sets maximum number of iterations on this chain.
        /// Amount of offsets for current sequence.
        /// </summary>
        /// <returns>Maximum number of iterations on this chain</returns>
        public int MaxShifts { get; protected set; }

        /// <summary>
        /// Gets or sets current cursor position.
        /// </summary>
        /// <returns>Current cursor cursorPosition</returns>
        public int CursorPosition { get; protected set; }

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
        /// <param name="position">
        /// a cursorPosition in a chain subject to a cutting window
        /// </param>
        /// <returns>
        /// true if moving is available, false - otherwise
        /// </returns>
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
        /// The <see cref="List{String}"/>.
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
        /// The <see cref="List{String}"/>.
        /// </returns>
        public abstract List<string> Current();

        /// <summary>
        /// Calculates count of shifts
        /// </summary>
        private void CalculateMaxShifts()
        {
            MaxShifts = ((chain.GetLength() - windowLength) / step) + 1;
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
            CursorPosition = -step;
            CalculateMaxShifts();
        }
    }
}
