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
            cursorPosition = chain.Length - windowLength + 1;
        }


        public override bool hasNext()
        {
            if ((cursorPosition - step) >= 0) return true;
            return false;
        }

        public override List<String> next()
        {
            cursorPosition = cursorPosition - step;
            try
            {
                currentCut = chain.substring(cursorPosition, cursorPosition + windowLength);
            }
            catch (Exception e)
            {
            }
            return currentCut;
        }

        public override void reset()
        {
            cursorPosition = maxShifts;
        }

        public override int position()
        {
            return cursorPosition;
        }

        public override List<String> current()
        {
            return currentCut;
        }

        public override bool move(int position)
        {
            if ((position >= 0) && (chain.Length >= windowLength + position))
            {
                cursorPosition = position;
                return true;
            }
            return false;
        } 
    }
}