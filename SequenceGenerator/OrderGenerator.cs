using System.Collections.Generic;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace SequenceGenerator
{
    public class OrderGenerator
    {
        public List<BaseChain> GenerateOrders(int length, int alphabetCardinality)
        {
            var result = new List<BaseChain>();
            var iterator = new OrderIterator(length, alphabetCardinality);
            foreach (int[] order in iterator)
            {
                var elements = new List<IBaseObject>(order.Length);
                for (int i = 0; i < order.Length; i++)
                {
                    elements.Add(new ValueInt(order[i]));
                }
                result.Add(new BaseChain(elements));
            }
            return result;
        }

        public List<BaseChain> StrictGenerateOrders(int length, int alphabetCardinality)
        {
            var result = GenerateOrders(length, alphabetCardinality);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i].Alphabet.Cardinality < alphabetCardinality)
                {
                    result.RemoveAt(i);
                }
            }
            return result;
        }

        public List<BaseChain> GenerateOrders(int length)
        {
            return GenerateOrders(length, length);
        }
    }
}
