using System;
using System.Collections.Generic;
using Segmentator.Classes.Base.Sequencies;

namespace Segmentator.Classes.Base.Iterators
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


        public override bool HasNext()
        {
            if (WindowLength + CursorPosition + Step > Chain.Length) return false;
            return true;
        }

        public override List<String> Next()
        {
            try
            {
                cursorPosition = CursorPosition + Step;
                CurrentCut = Chain.Substring(CursorPosition, CursorPosition + WindowLength);
            }
            catch (Exception)
            {
            }

            return CurrentCut;
        }

        public override void Reset()
        {
            cursorPosition = -Step;
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