using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;
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
            int maxWindowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            int windowDec = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.WindowDecrement));
            bool flag = true;
            KeyValuePair<List<string>, List<int>>? pair = null;

            Convoluted = ((ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence)));
            Alphabet = new FrequencyDictionary();

            for (int winLen = maxWindowLen; (winLen >= windowDec) && (winLen > 1); winLen -= windowDec)
            {
                flag = true;
                while (flag)
                {
                    UpdateParams(par,winLen);
                    pair = WordExtractorFactory.GetSeeker(extractor).Find(par);
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
            ValueString letter;
            for (int index = 0; index < Convoluted.Length; index++)
            {
                if ((letter = (ValueString)Convoluted[index]).value.Length == 1)
                {
                    if (!Alphabet.Contains(letter)) Alphabet.Add(letter, new List<int>());
                    this.Alphabet.Put(letter, index);
                }
            }
        }
    }
}