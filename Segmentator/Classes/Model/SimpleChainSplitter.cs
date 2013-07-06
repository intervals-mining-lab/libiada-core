using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;
using Segmentator.Classes.Base;
using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Sequencies;
using Segmentator.Classes.Extended;
using Segmentator.Classes.Model.Seekers;

namespace Segmentator.Classes.Model
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
        /// <param name="par">current parameters for segmentation</param>
        /// <returns>a convoluted chain</returns>
        public override ComplexChain Cut(ContentValues par)
        {
            int maxWindowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            int windowDec = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.WindowDecrement));

            Convoluted = ((ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence)));
            Alphabet = new FrequencyDictionary();

            for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
            {
                bool flag = true;
                while (flag)
                {
                    UpdateParams(par,winLen);
                    KeyValuePair<List<string>, List<int>>? pair = WordExtractorFactory.GetSeeker(extractor).Find(par);
                    flag = pair != null;
                    if (flag)
                    {
                        pair.Value.Value.Reverse();
                        foreach (int position in pair.Value.Value) Convoluted.Join(position, winLen);
                        //convoluted.updateUniforms();
                        Alphabet.Add(Helper.ToString(pair.Value.Key), pair.Value.Value);
                    }
                }
            }
            FindLastWords();

            return Convoluted;
        }

        private void UpdateParams(ContentValues par, int winLen)
        {
            par.Put(Formalism.Sequence.ToString(), Convoluted.ToString());
            par.Put(Formalism.Alphabet.ToString(), Alphabet.ToString());
            par.Put(Parameter.Window, winLen);
        }

        private void FindLastWords()
        {
            for (int index = 0; index < Convoluted.Length; index++)
            {
                ValueString letter;
                if ((letter = (ValueString)Convoluted[index]).Value.Length == 1)
                {
                    if (!Alphabet.Contains(letter)) Alphabet.Add(letter, new List<int>());
                    Alphabet.Put(letter, index);
                }
            }
        }
    }
}