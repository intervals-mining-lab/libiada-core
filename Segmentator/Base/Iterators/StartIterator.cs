namespace Segmentator.Base.Iterators
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Base.Sequencies;

    /// <summary>
    /// An iterator shifts its pointer through a chain left to right
    /// until it reach the end of the chain.
    /// </summary>
    public class StartIterator :BaseIterator
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
            if (this.WindowLength + this.CursorPosition + this.Step > this.Chain.Length) return false;
            return true;
        }

        public override List<String> Next()
        {
            try
            {
                this.cursorPosition = this.CursorPosition + this.Step;
                this.CurrentCut = this.Chain.Substring(this.CursorPosition, this.CursorPosition + this.WindowLength);
            }
            catch (Exception)
            {
            }

            return this.CurrentCut;
        }

        public override void Reset()
        {
            this.cursorPosition = -this.Step;
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