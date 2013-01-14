using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Sequencies;

namespace Segmentation.Classes.Base.Iterators
{
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
            cursorPosition = chain.Length - WindowLength + 1;
        }


        public override bool HasNext()
        {
            if ((CursorPosition - Step) >= 0) return true;
            return false;
        }

        public override List<String> Next()
        {
            cursorPosition = CursorPosition - Step;
            try
            {
                CurrentCut = Chain.Substring(CursorPosition, CursorPosition + WindowLength);
            }
            catch (Exception e)
            {
            }
            return CurrentCut;
        }

        public override void Reset()
        {
            cursorPosition = MaxShifts;
        }

        public override int Position()
        {
            return CursorPosition;
        }

        public override List<String> Current()
        {
            return CurrentCut;
        }

        public override bool Move(int position)
        {
            if ((position >= 0) && (Chain.Length >= WindowLength + position))
            {
                cursorPosition = position;
                return true;
            }
            return false;
        } 
    }
}