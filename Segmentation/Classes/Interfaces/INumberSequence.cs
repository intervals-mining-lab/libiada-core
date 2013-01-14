namespace Segmentation.Classes.Interfaces
{
    /// <summary>
    /// An interface that implements all the standard methods
    /// of management given numerical sequence.
    /// </summary>
    public interface INumberSequence
    {
        /// <summary>
        /// Returns true if, and only if, length() is 0.
        /// </summary>
        /// <returns>true if, and only if, length() is 0.</returns>
        bool IsEmpty();

        /// <summary>
        /// Returns the length of this sequence. The length is equal to the number of elements in the array.
        /// </summary>
        /// <returns>the length of the sequence of numbers represented by this object.</returns>
        int Length();

        /// <summary>
        /// Returns the Integer value at the specified index. An index ranges from 0 to length() - 1.
        /// The first number value of the sequence is at index 0, the next at index 1, and so on, as for array indexing.
        /// </summary>
        /// <param name="index">the index of the integer value</param>
        /// <returns>the Integer value at the specified index of this sequence. The first sequence value is at index 0.</returns>
        int ElementAt(int index);

        /// <summary>
        /// Concatenates the specified INumberSequence sequence to the end of this sequence.
        /// </summary>
        /// <param name="value">the INumberSequence that is concatenated to the end of this numerical sequence</param>
        /// <returns>
        /// an INumberSequence that represents the concatenation of this object's figures followed
        /// by the sequence argument's figures.
        /// </returns>
        INumberSequence Concat(INumberSequence value);

        /// <summary>
        /// Adds the specified value to the end of this sequence.
        /// </summary>
        /// <param name="value">the figure that is concatenated to the end of this numerical sequence</param>
        /// <returns>
        /// an INumberSequence that represents the concatenation of this object's figures followed
        /// by the argument's figure.
        /// </returns>
        INumberSequence Add(int value);

        /// <summary>
        /// Returns a new sequence that is a substring of this sequence. The substring begins at the specified beginIndex
        /// and extends to the figures at index endIndex - 1. Thus the length of the substring is endIndex-beginIndex.
        /// </summary>
        /// <param name="beginIndex">the beginning index, inclusive.</param>
        /// <param name="endIndex">the ending index, exclusive.</param>
        /// <returns>the specified numerical substring.</returns>
        INumberSequence Substring(int beginIndex, int endIndex);

        /// <summary>
        /// Clear a specified cursorPosition of this sequence and reduces the length of one element.
        /// </summary>
        /// <param name="index">element's cursorPosition</param>
        /// <returns>the reduced sequence</returns>
        INumberSequence ClearAt(int index);

        void Push(int value); 
    }
}