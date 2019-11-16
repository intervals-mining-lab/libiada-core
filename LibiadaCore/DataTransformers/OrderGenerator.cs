using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibiadaCore.DataTransformers
{
    public class OrderGenerator
    {
        static int Factorial(int num)
        {
            int count = 1;
            for (int i = 2; i <= num; i++)
                count *= i;
            return count;
        }

        static IEnumerable<string> Combinations(HashSet<char> characterSet, int componentCount)
        {
            if (componentCount == 0) yield return "";
            foreach (var character in characterSet.ToList())
            {
                characterSet.Remove(character);
                foreach (var smbl in Combinations(characterSet, componentCount - 1))
                    yield return character + smbl;
                characterSet.Add(character);
            }
        }

        public static int[][] GetOrders(int componentCount)
        {
            HashSet<char> characterSet = new HashSet<char>();
            for (int j = 0; j < componentCount; j++)
                characterSet.Add((char)j);
            int orderCount = Factorial(componentCount);
            int[][] ordersArray = new int[orderCount][];
            for (int j = 0; j < orderCount; j++)
                ordersArray[j] = new int[componentCount];
            int i = 0;
            foreach (var variant in Combinations(characterSet, componentCount))
            {
                variant.ToCharArray();
                for (int j = 0; j < variant.Length; j++)
                    ordersArray[i][j] = Convert.ToInt32(variant[j]);
                i++;
            }
            return ordersArray;
        }

    }
}
