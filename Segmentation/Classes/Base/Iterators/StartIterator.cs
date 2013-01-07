using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Sequencies;

namespace Segmentation.Classes.Base.Iterators
{
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


        public override bool hasNext()
        {
            if (windowLength + cursorPosition + step > chain.Length) return false;
            return true;
        }

        public override List<String> next()
        {
            try
            {
                cursorPosition = cursorPosition + step;
                currentCut = chain.substring(cursorPosition, cursorPosition + windowLength);
            }
            catch (Exception e)
            {
            }

            return currentCut;
        }

        public override void reset()
        {
            cursorPosition = -step;
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