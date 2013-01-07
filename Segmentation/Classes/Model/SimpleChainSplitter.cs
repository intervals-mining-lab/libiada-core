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
        public override sealed ComplexChain cut(ContentValues par)
        {
            int maxWindowLen = (int)par.get(Enum.GetName(typeof(Parameter), Parameter.WINDOW));
            int windowDec = (int)par.get(Enum.GetName(typeof(Parameter), Parameter.WINDOW_DECREMENT));
            bool flag = true;
            KeyValuePair<List<string>, List<int>>? pair = null;

            convoluted = ((ComplexChain)par.get(Formalism.GetName(typeof(Formalism), Formalism.SEQUENCE)));
            alphabet = new FrequencyDictionary();

            for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
            {
                flag = true;
                while (flag)
                {
                    updateParams(par,winLen);
                    pair = WordExtractorFactory.getSeeker(extractor).find(par);
                    flag = pair != null;
                    if (flag)
                    {
                        pair.Value.Value.Reverse();
                        foreach (int position in pair.Value.Value) convoluted.join(position, winLen);
                        //convoluted.updateUniforms();
                        alphabet.add(Helper.ToString(pair.Value.Key), pair.Value.Value);
                    }
                }
            }
            findLastWords();

            return convoluted;
        }

        private void updateParams(ContentValues par, int winLen)
        {
            par.put(Formalism.SEQUENCE.ToString(), convoluted.ToString());
            par.put(Formalism.ALPHABET.ToString(), alphabet.ToString());
            par.put(Parameter.WINDOW, winLen);
        }

        private void findLastWords()
        {
            ValueString letter;
            for (int index = 0; index < convoluted.Length; index++)
            {
                if ((letter = (ValueString)convoluted[index]).value.Length == 1)
                {
                    if (!alphabet.contains(letter)) alphabet.add(letter, new List<int>());
                    this.alphabet.get(letter).Add(index);
                }
            }
        }
    }
}