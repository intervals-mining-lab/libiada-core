﻿using System.Collections.Generic;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace SequenceGenerator
{
    public class SequenceGenerator
    {
        public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
        {
            var result = new List<BaseChain>();
            var iterator = new SequenceIterator(length, alphabetCardinality);
            foreach (var sequence1 in iterator)
            {
                int[] sequence = (int[])sequence1;
                var elements = new List<IBaseObject>(sequence.Length);
                for (int i = 0; i < sequence.Length; i++)
                {
                    elements.Add(new ValueInt(sequence[i]));
                }
                result.Add(new BaseChain(elements));
            }
            return result;
        }

        public List<BaseChain> GenerateSequences(int length)
        {
            var result = new List<BaseChain>();
            for (int i = 1; i <= length; i++)
            {
                result.AddRange(GenerateSequences(length, i));
            }
            return result;
        }
    }
}
