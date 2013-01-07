using System;
using System.Collections.Generic;

namespace Segmentation.Classes.Interfaces
{
    public interface IIterator
    {
        /// <summary>
        /// Returns true if the iteration has more elements.
        /// </summary>
        /// <returns>true if the iterator has more elements.</returns>
        bool hasNext();

        /// <summary>
        /// Returns the next element in the iteration.
        /// </summary>
        /// <returns>the next element in the iteration.</returns>
        List<String> next();

        /// <summary>
        /// Moves a cursor before the beginning of sequence.
        /// </summary>
        void reset();

        /// <summary>
        /// Returns current cursorPosition
        /// </summary>
        /// <returns>current cursorPosition</returns>
        int position();

        /// <summary>
        /// Returns current element
        /// </summary>
        /// <returns>current element</returns>
        List<String> current();
    }
}