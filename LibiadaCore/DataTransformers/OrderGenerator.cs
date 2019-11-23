using System;
using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.DataTransformers
{
    /// <summary>
    /// Generates all possible permutations of given number of elements.
    /// </summary>
    public class OrderGenerator
    {
        /// <summary>
        /// Calculate factorial of given number.
        /// </summary>
        /// <param name="number">
        /// Number to calculate factorial.
        /// </param>
        /// <returns>
        /// Factorial of given number.
        /// </returns>
        static int Factorial(int number)
        {
            int count = 1;
            for (int i = 2; i <= number; i++)
            {
                count *= i;
            }
            return count;
        }

        /// <summary>
        /// Yields one of permutation.
        /// </summary>
        /// <param name="characterSet">
        /// Set of elements to permute.
        /// </param>
        /// <param name="componentCount">
        /// Length of permutation.
        /// </param>
        /// <returns>
        /// Set of given elements in a certain order.
        /// </returns>
        static IEnumerable<string> Combinations(HashSet<char> characterSet, int componentCount)
        {
            if (componentCount == 0)
            {
                yield return "";
            }

            foreach (var character in characterSet.ToList())
            {
                characterSet.Remove(character);
                foreach (var symbol in Combinations(characterSet, componentCount - 1))
                {
                    yield return character + symbol;
                }
                characterSet.Add(character);
            }
        }

        /// <summary>
        /// Generates all possible permutations of given count of elements.
        /// </summary>
        /// <param name="componentCount">
        /// Number of elements to permute.
        /// </param>
        /// <returns>
        /// All possible orders of given number of elements.
        /// </returns>
        public static int[][] GetOrders(int componentCount)
        {
            HashSet<char> characterSet = new HashSet<char>();
            for (int j = 0; j < componentCount; j++)
            {
                characterSet.Add((char) j);
            }

            int orderCount = Factorial(componentCount);
            int[][] ordersArray = new int[orderCount][];
            for (int j = 0; j < orderCount; j++)
            {
                ordersArray[j] = new int[componentCount];
            }

            int i = 0;
            foreach (var variant in Combinations(characterSet, componentCount))
            {
                for (int j = 0; j < variant.Length; j++)
                {
                    ordersArray[i][j] = Convert.ToInt32(variant[j]);
                }

                i++;
            }

            return ordersArray;
        }

    }
}
