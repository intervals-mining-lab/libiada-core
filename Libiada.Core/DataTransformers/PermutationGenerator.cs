namespace Libiada.Core.DataTransformers;

/// <summary>
/// Generates all possible permutations of given number of elements.
/// </summary>
public class PermutationGenerator
{
    /// <summary>
    /// Generates all possible permutations of given count of elements.
    /// </summary>
    /// <param name="componentsCount">
    /// Number of elements to permute.
    /// </param>
    /// <returns>
    /// All possible orders of given number of elements.
    /// </returns>
    public static int[][] GetOrders(int componentsCount)
    {
        int orderCount = Factorial(componentsCount);
        int[] componentSet = new int[componentsCount];
        int[][] ordersArray = new int[orderCount][];

        for (int j = 0; j < orderCount; j++)
        {
            ordersArray[j] = new int[componentsCount];
        }

        for (int j = 0; j < componentsCount; j++)
        {
            componentSet[j] = j;
            ordersArray[0][j] = j;
        }

        int i = 1;
        while (NextPermutation(componentSet, componentsCount))
        {
            for (int j = 0; j < componentsCount; j++)
            {
                ordersArray[i][j] = componentSet[j];
            }

            i++;
        }

        return ordersArray;
    }

    /// <summary>
    /// Calculates factorial of given number.
    /// </summary>
    /// <param name="number">
    /// Number to calculate factorial.
    /// </param>
    /// <returns>
    /// Factorial of given number.
    /// </returns>
    private static int Factorial(int number)
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
    private static void Swap(int[] componentArray, int index, int indexToSwap)
    {
        int temp = componentArray[index];
        componentArray[index] = componentArray[indexToSwap];
        componentArray[indexToSwap] = temp;
    }

    /// <summary>
    /// Generates next permutation.
    /// </summary>
    /// <param name="componentArray">
    /// Set of elements to permute.
    /// </param>
    /// <param name="componentsCount">
    /// Length of permutation.
    /// </param>
    /// <returns>
    /// Set of given elements in a certain order.
    /// </returns>
    private static bool NextPermutation(int[] componentArray, int componentsCount)
    {
        // TODO: try to optimize or refactor this code.

        int index = componentsCount - 2;
        while (index != -1 && componentArray[index] >= componentArray[index + 1])
        {
            index--;
        }

        if (index == -1)
        {
            return false;
        }

        int indexToSwap = componentsCount - 1;
        while (componentArray[index] >= componentArray[indexToSwap])
        {
            indexToSwap--;
        }

        Swap(componentArray, index, indexToSwap);
        int i = index + 1;
        int j = componentsCount - 1;
        while (i < j)
        {
            Swap(componentArray, i++, j--);
        }

        return true;
    }
}
