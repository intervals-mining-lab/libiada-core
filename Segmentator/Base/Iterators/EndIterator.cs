namespace Segmentator.Base.Iterators
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Base.Sequencies;

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
            this.cursorPosition = chain.Length - this.WindowLength + 1;
        }


        public override bool HasNext()
        {
            if ((this.CursorPosition - this.Step) >= 0) return true;
            return false;
        }

        public override List<String> Next()
        {
            this.cursorPosition = this.CursorPosition - this.Step;
            try
            {
                this.CurrentCut = this.Chain.Substring(this.CursorPosition, this.CursorPosition + this.WindowLength);
            }
            catch (Exception)
            {
            }
            return this.CurrentCut;
        }

        public override void Reset()
        {
            this.cursorPosition = this.MaxShifts;
        }

        public override int Position()
        {
            return this.CursorPosition;
        }

        public override List<String> Current()
        {
            return this.CurrentCut;
        }

        public override bool Move(int position)
        {
            if ((position >= 0) && (this.Chain.Length >= this.WindowLength + position))
            {
                this.cursorPosition = position;
                return true;
            }
            return false;
        } 
    }
}