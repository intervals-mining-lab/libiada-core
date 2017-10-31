namespace SequenceGenerator
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    public class SequenceGenerator
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
                    elements.Add(new ValueInt(sequence[i]));
                }

                result.Add(new BaseChain(elements));
            }

            return result;
        }

        public List<BaseChain> StrictGenerateSequences(int length, int alphabetCardinality)
        {
            var result = GenerateSequences(length, alphabetCardinality);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i].Alphabet.Cardinality < alphabetCardinality)
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        public List<BaseChain> GenerateSequences(int length)
        {
            return GenerateSequences(length, length);
        }
    }
}
