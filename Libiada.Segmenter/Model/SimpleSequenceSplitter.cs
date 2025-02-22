namespace Libiada.Segmenter.Model;

using Libiada.Core.Core.SimpleTypes;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Extended;
using Segmenter.Model.Seekers;

/// <summary>
/// This class cuts and convoluts all occurrences of the found word.
/// </summary>
public sealed class SimpleSequenceSplitter : SequenceSplitter
{
    /// <summary>
    /// The extractor.
    /// </summary>
    private WordExtractor extractor;

    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleSequenceSplitter"/> class.
    /// </summary>
    /// <param name="extractor">
    /// The extractor.
    /// </param>
    public SimpleSequenceSplitter(WordExtractor extractor)
    {
        this.extractor = extractor;
    }

    /// <summary>
    /// The cut.
    /// </summary>
    /// <param name="parameters">
    /// The current parameters for segmentation.
    /// </param>
    /// <returns>
    /// The convoluted sequence <see cref="ComplexSequence"/>.
    /// </returns>
    public override ComplexSequence Cut(Dictionary<string, object> parameters)
    {
        int maxWindowLen = (int)parameters["Window"];
        int windowDec = (int)parameters["WindowDecrement"];

        convoluted = (ComplexSequence)parameters["Sequence"];
        alphabet = new FrequencyDictionary();

        for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
        {
            bool flag = true;
            while (flag)
            {
                UpdateParams(parameters, winLen);
                //TODO: refactor this to use tuples
                KeyValuePair<List<string>, List<int>>? pair = WordExtractorFactory.GetSeeker(extractor).Find(parameters);
                flag = pair != null;
                if (flag)
                {
                    pair.Value.Value.Reverse();
                    foreach (int position in pair.Value.Value)
                    {
                        convoluted.Join(position, winLen);
                    }

                    alphabet.Add(Helper.ToString(pair.Value.Key), pair.Value.Value);
                }
            }
        }

        FindLastWords();

        return convoluted;
    }

    /// <summary>
    /// The update parameters.
    /// </summary>
    /// <param name="par">
    /// The par.
    /// </param>
    /// <param name="winLen">
    /// The win len.
    /// </param>
    private void UpdateParams(Dictionary<string, object> par, int winLen)
    {
        par.Add("Sequence", convoluted.ToString());
        par.Add("Alphabet", alphabet.ToString());
        par.Add("Window", winLen);
    }

    /// <summary>
    /// The find last words.
    /// </summary>
    private void FindLastWords()
    {
        for (int index = 0; index < convoluted.Length; index++)
        {
            ValueString letter;
            if ((letter = (ValueString)convoluted[index]).Value.Length == 1)
            {
                if (!alphabet.Contains(letter))
                {
                    alphabet.Add(letter, []);
                }

                alphabet.Put(letter, index);
            }
        }
    }
}
