using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Extended;

namespace Segmentation.Classes.Model.Seekers
{
    /// <summary>
    /// Used as a base for all kinds of word seekers for a chain
    /// </summary>
    public abstract class WordExtractor
    {
        protected Dictionary<Double, KeyValuePair<List<String>, List<int>>> wordPriority =
            new Dictionary<Double, KeyValuePair<List<String>, List<int>>>();

        protected DataCollector fullEntry = new DataCollector();

        /// <summary>
        /// Finds a word based on current parameters
        /// </summary>
        /// <param name="?">current segmentation parameters</param>
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
            double bestStd;
            List<Double> stds = new List<Double>(wordPriority.Keys);
            List<KeyValuePair<List<String>, List<int>>> entries =
                new List<KeyValuePair<List<String>, List<int>>>(wordPriority.Values);
            for (int index = entries.Count; --index >= 0;)
            {
                List<String> entry = entries[index].Key;
                String entryS;
                if (!alphabet.Contains(new ValueString(entryS = Helper.ToString(entry))) && (entry.Count == entryS.Length))
                {
                    bestStd = stds[index];
                    if (bestStd > level)
                    {
                        return new KeyValuePair<List<string>, List<int>>(wordPriority[bestStd].Key, wordPriority[bestStd].Value);
                    }
                }
            }
            return null;
        }
    }
}