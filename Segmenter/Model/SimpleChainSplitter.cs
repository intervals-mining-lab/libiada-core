namespace Segmenter.Model
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.SimpleTypes;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequencies;
    using Segmenter.Extended;
    using Segmenter.Model.Seekers;

    /// <summary>
    /// This class cuts and convoluts all occurrences of the found word
    /// </summary>
    public sealed class SimpleChainSplitter : ChainSplitter
    {
        private WordExtractor extractor;

        public SimpleChainSplitter(WordExtractor extractor)
        {
            this.extractor = extractor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="par">current parameters for segmentation</param>
        /// <returns>a convoluted chain</returns>
        public override ComplexChain Cut(ContentValues par)
        {
            int maxWindowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            int windowDec = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.WindowDecrement));

            this.convoluted = (ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence));
            this.alphabet = new FrequencyDictionary();

            for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
            {
                bool flag = true;
                while (flag)
                {
                    this.UpdateParams(par, winLen);
                    KeyValuePair<List<string>, List<int>>? pair = WordExtractorFactory.GetSeeker(this.extractor).Find(par);
                    flag = pair != null;
                    if (flag)
                    {
                        pair.Value.Value.Reverse();
                        foreach (int position in pair.Value.Value)
                        {
                            this.convoluted.Join(position, winLen);
                        }

                        // convoluted.updateUniforms();
                        this.alphabet.Add(Helper.ToString(pair.Value.Key), pair.Value.Value);
                    }
                }
            }

            this.FindLastWords();

            return this.convoluted;
        }

        private void UpdateParams(ContentValues par, int winLen)
        {
            par.Put(Formalism.Sequence.ToString(), this.convoluted.ToString());
            par.Put(Formalism.Alphabet.ToString(), this.alphabet.ToString());
            par.Put(Parameter.Window, winLen);
        }

        private void FindLastWords()
        {
            for (int index = 0; index < this.convoluted.Length; index++)
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