namespace SequenceGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrderGenerator
    {
        public List<int[]> GenerateOrders(int length, int alphabetCardinality)
        {
            var result = new List<int[]>();
            var iterator = new OrderIterator(length, alphabetCardinality);
            foreach (int[] order in iterator)
            {
                result.Add(order);
            }

            return result;
        }

        public List<int[]> StrictGenerateOrders(int length, int alphabetCardinality)
        {
            var result = GenerateOrders(length, alphabetCardinality);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i].Distinct().ToArray().Length < alphabetCardinality)
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        public List<int[]> GenerateOrders(int length)
        {
            return GenerateOrders(length, length);
        }
    }
}
