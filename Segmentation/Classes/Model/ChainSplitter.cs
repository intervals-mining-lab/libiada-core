using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;

namespace Segmentation.Classes.Model
{
    /// <summary>
    /// Used as a base for all kinds of word splitters for a chain
    /// </summary>
    public abstract class ChainSplitter
    {
        protected FrequencyDictionary alphabet;
        protected ComplexChain convoluted;

        public abstract ComplexChain Cut(ContentValues par);


        public FrequencyDictionary FrequencyDictionary
        {
            get { return alphabet; }
        }
    }
}