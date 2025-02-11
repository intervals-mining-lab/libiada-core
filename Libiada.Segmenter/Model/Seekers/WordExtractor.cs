﻿namespace Libiada.Segmenter.Model.Seekers;

using Libiada.Core.Core.SimpleTypes;

using Segmenter.Base.Collectors;
using Segmenter.Extended;

/// <summary>
/// Used as a base for all kinds of word seekers for a sequence.
/// </summary>
public abstract class WordExtractor
{
    /// <summary>
    /// The word priority.
    /// </summary>
    protected Dictionary<double, KeyValuePair<List<string>, List<int>>> wordPriority = [];

    /// <summary>
    /// The full entry.
    /// </summary>
    protected DataCollector fullEntry = new();

    // TODO: refactor it to rerturn tuple
    /// <summary>
    /// Finds a word based on current parameters.
    /// </summary>
    /// <param name="parameters">
    /// The current segmentation parameters.
    /// </param>
    /// <returns>
    /// The <see cref="KeyValuePair{List{string},List{int}}?"/>.
    /// </returns>
    public abstract KeyValuePair<List<string>, List<int>>? Find(Dictionary<string, object> parameters);

    /// <summary>
    /// Discards all words which enter in the alphabet and contains compound words
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <param name="level">
    /// The filter level.
    /// </param>
    /// <returns>
    /// The <see cref="KeyValuePair{List{string},List{int}}?"/>.
    /// </returns>
    protected KeyValuePair<List<string>, List<int>>? DiscardCompositeWords(FrequencyDictionary alphabet, double level)
    {
        // TODO: refactor it to rerturn tuple
        List<double> stds = new(wordPriority.Keys);
        List<KeyValuePair<List<string>, List<int>>> entries = new(wordPriority.Values);
        for (int index = entries.Count; --index >= 0;)
        {
            List<string> entry = entries[index].Key;
            string entryS;
            if (!alphabet.Contains(new ValueString(entryS = Helper.ToString(entry))) && (entry.Count == entryS.Length))
            {
                double bestStd = stds[index];
                if (bestStd > level)
                {
                    return new KeyValuePair<List<string>, List<int>>(wordPriority[bestStd].Key, wordPriority[bestStd].Value);
                }
            }
        }

        return null;
    }
}
