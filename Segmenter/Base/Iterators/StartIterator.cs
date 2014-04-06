namespace Segmenter.Base.Iterators
{
    using System;
    using System.Collections.Generic;

    using Segmenter.Base.Sequencies;

    /// <summary>
    /// An iterator shifts its pointer through a chain left to right
    /// until it reach the end of the chain.
    /// </summary>
    public class StartIterator : BaseIterator
    {
        /// <summary>
        /// Initializes a main options of an iterator.
        /// </summary>
        /// <param name="chain">An iterable sequence</param>
        /// <param name="windowLength">Length of a word (window of cutting)</param>
        /// <param name="step">The number of elements through which the pointer will jump at the next iteration</param>
        public StartIterator(ComplexChain chain, int windowLength, int step)
            : base(chain, windowLength, step)
        {
        }

        public override bool HasNext()
        {
            return this.windowLength + this.CursorPosition + this.step <= this.chain.Length;
        }

        public override List<string> Next()
        {
            try
            {
                this.cursorPosition = this.CursorPosition + this.step;
                this.currentCut = this.chain.Substring(this.CursorPosition, this.CursorPosition + this.windowLength);
            }
            catch (Exception)
            {
            }

            return this.currentCut;
        }

        public override void Reset()
        {
            this.cursorPosition = -this.step;
        }

        public override int Position()
        {
            return this.CursorPosition;
        }

        public override List<string> Current()
        {
            return this.currentCut;
        }

        public override bool Move(int position)
        {
            if ((position >= 0) && (this.chain.Length >= this.windowLength + position))
            {
                this.cursorPosition = position;
                return true;
            }

            return false;
        }
    }
}