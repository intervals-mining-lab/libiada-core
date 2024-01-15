namespace Segmenter.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Iterator interface.
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// Returns true if the iteration has more elements.
        /// </summary>
        /// <returns>true if the iterator has more elements.</returns>
        bool HasNext();

        /// <summary>
        /// Returns the next element in the iteration.
        /// </summary>
        /// <returns>the next element in the iteration.</returns>
        List<string> Next();

        /// <summary>
        /// Moves a cursor before the beginning of sequence.
        /// </summary>
        void Reset();

        /// <summary>
        /// Returns current cursorPosition
        /// </summary>
        /// <returns>current cursorPosition</returns>
        int Position();

        /// <summary>
        /// Returns current element
        /// </summary>
        /// <returns>current element</returns>
        List<string> Current();
    }
}
