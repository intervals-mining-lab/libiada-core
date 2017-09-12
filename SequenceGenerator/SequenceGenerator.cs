﻿using System;
using System.Collections.Generic;
using System.Text;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace SequenceGenerator
{
    class SequenceGenerator
    {
        public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
        {
            var result = new List<BaseChain>();
            var iterator = new SequenceIterator(length, alphabetCardinality);
            foreach (int[] sequence in iterator)
            {
                var elements = new List<IBaseObject>(sequence.Length);
                for (int i = 0; i < sequence.Length; i++)
                {
                    elements[i] = new ValueInt(sequence[i]);
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
