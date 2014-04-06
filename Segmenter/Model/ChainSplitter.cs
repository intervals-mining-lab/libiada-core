namespace Segmenter.Model
{
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// Used as a base for all kinds of word splitters for a chain
    /// </summary>
    public abstract class ChainSplitter
    {
        /// <summary>
        /// The alphabet.
        /// </summary>
        protected FrequencyDictionary alphabet;

        /// <summary>
        /// The convoluted.
        /// </summary>
        protected ComplexChain convoluted;

        /// <summary>
        /// Gets the frequency dictionary.
        /// </summary>
        public FrequencyDictionary FrequencyDictionary
        {
            get { return this.alphabet; }
        }

        /// <summary>
        /// The cut.
        /// </summary>
        /// <param name="par">
        /// The par.
        /// </param>
        /// <returns>
        /// The <see cref="ComplexChain"/>.
        /// </returns>
        public abstract ComplexChain Cut(ContentValues par);
    }
}