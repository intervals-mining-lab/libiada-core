﻿namespace Segmenter.Base.Iterators
{
    using System;
    using System.Collections.Generic;

    using Segmenter.Base.Sequences;

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

        /// <summary>
        /// The has next.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool HasNext()
        {
            return windowLength + CursorPosition + step <= chain.GetLength();
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public override List<string> Next()
        {
            try
            {
                cursorPosition = CursorPosition + step;
                currentCut = chain.Substring(CursorPosition, CursorPosition + windowLength);
            }
            catch (Exception)
            {
            }

            return currentCut;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public override void Reset()
        {
            cursorPosition = -step;
        }

        /// <summary>
        /// The position.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int Position()
        {
            return CursorPosition;
        }

        /// <summary>
        /// The current.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public override List<string> Current()
        {
            return currentCut;
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
            if ((position >= 0) && (chain.GetLength() >= windowLength + position))
            {
                cursorPosition = position;
                return true;
            }

            return false;
        }
    }
}