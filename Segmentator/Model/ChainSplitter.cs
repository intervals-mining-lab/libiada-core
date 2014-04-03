namespace Segmentator.Model
{
    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;

    /// <summary>
    /// Used as a base for all kinds of word splitters for a chain
    /// </summary>
    public abstract class ChainSplitter
    {
        protected FrequencyDictionary Alphabet;
        protected ComplexChain Convoluted;

        public abstract ComplexChain Cut(ContentValues par);


        public FrequencyDictionary FrequencyDictionary
        {
            get { return this.Alphabet; }
        }
    }
}