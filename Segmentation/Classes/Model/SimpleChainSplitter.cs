using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Extended;
using Segmentation.Classes.Model.Seekers;

namespace Segmentation.Classes.Model
{
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
        /// <param name="?">current parameters for segmentation</param>
        /// <returns>a convoluted chain</returns>
        public override sealed ComplexChain Cut(ContentValues par)
        {
            int maxWindowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.WINDOW));
            int windowDec = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.WINDOW_DECREMENT));
            bool flag = true;
            KeyValuePair<List<string>, List<int>>? pair = null;

            convoluted = ((ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.SEQUENCE)));
            alphabet = new FrequencyDictionary();

            for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
            {
                flag = true;
                while (flag)
                {
                    updateParams(par,winLen);
                    pair = WordExtractorFactory.GetSeeker(extractor).Find(par);
                    flag = pair != null;
                    if (flag)
                    {
                        pair.Value.Value.Reverse();
                        foreach (int position in pair.Value.Value) convoluted.Join(position, winLen);
                        //convoluted.updateUniforms();
                        alphabet.Add(Helper.ToString(pair.Value.Key), pair.Value.Value);
                    }
                }
            }
            findLastWords();

            return convoluted;
        }

        private void updateParams(ContentValues par, int winLen)
        {
            par.Put(Formalism.SEQUENCE.ToString(), convoluted.ToString());
            par.Put(Formalism.ALPHABET.ToString(), alphabet.ToString());
            par.Put(Parameter.WINDOW, winLen);
        }

        private void findLastWords()
        {
            ValueString letter;
            for (int index = 0; index < convoluted.Length; index++)
            {
                if ((letter = (ValueString)convoluted[index]).value.Length == 1)
                {
                    if (!alphabet.Contains(letter)) alphabet.Add(letter, new List<int>());
                    this.alphabet.Put(letter, index);
                }
            }
        }
    }
}