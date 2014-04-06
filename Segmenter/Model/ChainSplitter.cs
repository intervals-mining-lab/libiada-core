namespace Segmenter.Model
{
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequencies;

    /// <summary>
    /// Used as a base for all kinds of word splitters for a chain
    /// </summary>
    public abstract class ChainSplitter
    {
        protected FrequencyDictionary alphabet;
        protected ComplexChain convoluted;

        public FrequencyDictionary FrequencyDictionary
        {
            get { return this.alphabet; }
        }

        public abstract ComplexChain Cut(ContentValues par);
    }
}