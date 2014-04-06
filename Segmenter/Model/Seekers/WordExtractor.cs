namespace Segmenter.Model.Seekers
{
    using System.Collections.Generic;

    using LibiadaCore.Core.SimpleTypes;

    using Segmenter.Base.Collectors;
    using Segmenter.Extended;

    /// <summary>
    /// Used as a base for all kinds of word seekers for a chain
    /// </summary>
    public abstract class WordExtractor
    {
        protected Dictionary<double, KeyValuePair<List<string>, List<int>>> wordPriority =
            new Dictionary<double, KeyValuePair<List<string>, List<int>>>();

        protected DataCollector fullEntry = new DataCollector();

        /// <summary>
        /// Finds a word based on current parameters
        /// </summary>
        /// <param name="par">current segmentation parameters</param>
        /// <returns></returns>
        public abstract KeyValuePair<List<string>, List<int>>? Find(ContentValues par);

        /// <summary>
        /// Discards all words which enter in the alphabet and contains compound words
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="level">filtrate level</param>
        /// <returns></returns>
        protected KeyValuePair<List<string>, List<int>>? DiscardCompositeWords(FrequencyDictionary alphabet, double level)
        {
            List<double> stds = new List<double>(this.wordPriority.Keys);
            List<KeyValuePair<List<string>, List<int>>> entries =
                new List<KeyValuePair<List<string>, List<int>>>(this.wordPriority.Values);
            for (int index = entries.Count; --index >= 0;)
            {
                List<string> entry = entries[index].Key;
                string entryS;
                if (!alphabet.Contains(new ValueString(entryS = Helper.ToString(entry))) && (entry.Count == entryS.Length))
                {
                    double bestStd = stds[index];
                    if (bestStd > level)
                    {
                        return new KeyValuePair<List<string>, List<int>>(this.wordPriority[bestStd].Key, this.wordPriority[bestStd].Value);
                    }
                }
            }

            return null;
        }
    }
}