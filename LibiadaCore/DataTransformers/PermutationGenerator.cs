using System;
using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.DataTransformers
{
    /// <summary>
    /// Generates all possible permutations of given number of elements.
    /// </summary>
    public class PermutationGenerator
    {
        /// <summary>
        /// Calculates factorial of given number.
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
        /// Swaps two elements of array
        /// </summary>
        /// <param name="componentArray">
        /// Source array
        /// </param>
        /// <param name="index">
        /// Index of element in array to swap
        /// </param>
        /// <param name="indexToSwap">
        /// Index of element in array to swap
        /// </param>
        public static void Swap(int[] componentArray, int index, int indexToSwap)
        {
            int temp = componentArray[index];
            componentArray[index] = componentArray[indexToSwap];
            componentArray[indexToSwap] = temp;
        }

        /// <summary>
        /// Generates one of permutation.
        /// </summary>
        /// <param name="componentArray">
        /// Set of elements to permute.
        /// </param>
        /// <param name="componentCount">
        /// Length of permutation.
        /// </param>
        /// <returns>
        /// Set of given elements in a certain order.
        /// </returns>
        public static bool NextSet(int[] componentArray, int componentCount)
        {
            int index = componentCount - 2;
            while (index != -1 && componentArray[index] >= componentArray[index + 1])
            {
                index--;
            }

            if (index == -1)
            {
                return false;
            }
            int indexToSwap = componentCount - 1;
            while (componentArray[index] >= componentArray[indexToSwap])
            {
                indexToSwap--;
            }
            Swap(componentArray, index, indexToSwap);
            int i = index + 1;
            int j = componentCount - 1;
            while (i < j)
            {
                Swap(componentArray, i++, j--);
            }
            return true;
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
            int orderCount = Factorial(componentCount);
            int[] componentSet = new int[componentCount];
            int[][] ordersArray = new int[orderCount][];
            for (int j = 0; j < orderCount; j++)
            {
                ordersArray[j] = new int[componentCount];
            }
            for (int j = 0; j < componentCount; j++)
            {
                componentSet[j] = j;
                ordersArray[0][j] = j;
            }
            int i = 1;
            while (NextSet(componentSet, componentCount))
            {
                for (int j = 0; j < componentCount; j++)
                {
                    ordersArray[i][j] = componentSet[j];
                }
                i++;
            }
            return ordersArray;
        }

    }
}
