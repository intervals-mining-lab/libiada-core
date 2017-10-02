namespace SequenceGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core;

    public class StrictSequenceGenerator
    {
        public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
        {
            var sequenceGenerator = new SequenceGenerator();
            var result = sequenceGenerator.GenerateSequences(length, alphabetCardinality);
            for(int i = result.Count - 1; i >= 0; i--)
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
            var result = new List<BaseChain>();
            for (int i = 1; i <= length; i++)
            {
                result.AddRange(GenerateSequences(length, i));
            }

            return result.Distinct().ToList();
        }
    }
}
