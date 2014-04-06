namespace Segmenter.Base.Iterators
{
    using System;
    using System.Collections.Generic;

    using Segmenter.Base.Sequences;

    /// <summary>
    /// An iterator shifts its pointer through a chain right to left
    /// until it reach the beginning of the chain.
    /// </summary>
    public sealed class EndIterator : BaseIterator
    {
        /// <summary>
        /// Initializes a main options of an iterator.
        /// </summary>
        /// <param name="chain">An iterable sequence</param>
        /// <param name="length">Length of a word (window of cutting)</param>
        /// <param name="step">The number of elements through which the pointer will jump at the next iteration</param>
        public EndIterator(ComplexChain chain, int length, int step)
            : base(chain, length, step)
        {
            this.cursorPosition = chain.Length - this.windowLength + 1;
        }

        /// <summary>
        /// The has next.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool HasNext()
        {
            return (this.CursorPosition - this.step) >= 0;
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public override List<string> Next()
        {
            this.cursorPosition = this.CursorPosition - this.step;
            try
            {
                this.currentCut = this.chain.Substring(this.CursorPosition, this.CursorPosition + this.windowLength);
            }
            catch (Exception)
            {
            }

            return this.currentCut;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public override void Reset()
        {
            this.cursorPosition = this.MaxShifts;
        }

        /// <summary>
        /// The position.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int Position()
        {
            return this.CursorPosition;
        }

        /// <summary>
        /// The current.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public override List<string> Current()
        {
            return this.currentCut;
        }

        /// <summary>
        /// The move.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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