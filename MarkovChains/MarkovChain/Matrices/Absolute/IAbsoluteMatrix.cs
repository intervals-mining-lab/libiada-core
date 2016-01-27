namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// The AbsoluteMatrix interface.
    /// </summary>
    public interface IAbsoluteMatrix
    {
        /// <summary>
        /// Gets matrix elements sum.
        /// </summary>
        double Count { get; }

        /// <summary>
        /// Adds element to the frequency dictionary.
        /// </summary>
        /// <param name="arrayToTeach">
        /// The array to teach.
        /// </param>
        /// <returns>
        /// Number stored at given key.
        /// </returns>
        double Add(int[] arrayToTeach);

        /// <summary>
        /// Increments value of this matrix.
        /// </summary>
        void IncrementValue();

        /// <summary>
        /// Calculates sum of elements at given key.
        /// </summary>
        /// <param name="arrayOfIndexes">
        /// Key of the elements.
        /// </param>
        /// <returns>
        /// Sum of matrix elements at given address.
        /// </returns>
        double Sum(int[] arrayOfIndexes);

        /// <summary>
        /// The probability matrix.
        /// </summary>
        /// <returns>
        /// The <see cref="IProbabilityMatrix"/>.
        /// </returns>
        IProbabilityMatrix ProbabilityMatrix();
    }
}
