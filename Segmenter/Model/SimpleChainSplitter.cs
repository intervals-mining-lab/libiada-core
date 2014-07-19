namespace Segmenter.Model
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.SimpleTypes;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Extended;
    using Segmenter.Model.Seekers;

    /// <summary>
    /// This class cuts and convoluts all occurrences of the found word
    /// </summary>
    public sealed class SimpleChainSplitter : ChainSplitter
    {
        /// <summary>
        /// The extractor.
        /// </summary>
        private WordExtractor extractor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleChainSplitter"/> class.
        /// </summary>
        /// <param name="extractor">
        /// The extractor.
        /// </param>
        public SimpleChainSplitter(WordExtractor extractor)
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
        /// The convoluted chain <see cref="ComplexChain"/>.
        /// </returns>
        public override ComplexChain Cut(ContentValues parameters)
        {
            int maxWindowLen = (int)parameters.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            int windowDec = (int)parameters.Get(Enum.GetName(typeof(Parameter), Parameter.WindowDecrement));

            this.convoluted = (ComplexChain)parameters.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence));
            this.alphabet = new FrequencyDictionary();

            for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
            {
                bool flag = true;
                while (flag)
                {
                    this.UpdateParams(parameters, winLen);
                    KeyValuePair<List<string>, List<int>>? pair = WordExtractorFactory.GetSeeker(this.extractor).Find(parameters);
                    flag = pair != null;
                    if (flag)
                    {
                        pair.Value.Value.Reverse();
                        foreach (int position in pair.Value.Value)
                        {
                            this.convoluted.Join(position, winLen);
                        }

                        // convoluted.updateCongenerics();
                        this.alphabet.Add(Helper.ToString(pair.Value.Key), pair.Value.Value);
                    }
                }
            }

            this.FindLastWords();

            return this.convoluted;
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
        private void UpdateParams(ContentValues par, int winLen)
        {
            par.Put(Formalism.Sequence.ToString(), this.convoluted.ToString());
            par.Put(Formalism.Alphabet.ToString(), this.alphabet.ToString());
            par.Put(Parameter.Window, winLen);
        }

        /// <summary>
        /// The find last words.
        /// </summary>
        private void FindLastWords()
        {
            for (int index = 0; index < this.convoluted.GetLength(); index++)
            {
                ValueString letter;
                if ((letter = (ValueString)this.convoluted[index]).Value.Length == 1)
                {
                    if (!this.alphabet.Contains(letter))
                    {
                        this.alphabet.Add(letter, new List<int>());
                    }

                    this.alphabet.Put(letter, index);
                }
            }
        }
    }
}