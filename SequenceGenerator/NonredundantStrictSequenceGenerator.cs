using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace SequenceGenerator
{
    public class NonredundantStrictSequenceGenerator : ISequenceGenerator
    {
        private StrictSequenceGenerator redundantSequenceGenerator = new StrictSequenceGenerator();

        public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
        {
            var redundantResult = redundantSequenceGenerator.GenerateSequences(length, alphabetCardinality);
            var nonredundantResult = new List<BaseChain>();
            foreach (var chain in redundantResult)
            {
                var chainAlphabetCardinality = chain.Alphabet.Cardinality;
                bool nonredundant = chain.Alphabet.All(el => (ValueInt)el <= chainAlphabetCardinality);
                if (nonredundant)
                {
                    nonredundantResult.Add(chain);
                }
            }
            return nonredundantResult;
        }

        public List<BaseChain> GenerateSequences(int length)
        {
            var result = new List<BaseChain>();
            for (int i = 1; i <= length; i++)
            {
                result.AddRange(GenerateSequences(length, i));
            }

            return result.Distinct().ToList();
        }
    }
}
