namespace Libiada.MarkovChains.MarkovChain.Matrices.Absolute;

using MarkovChains.MarkovChain.Builders;
using MarkovChains.MarkovChain.Matrices.Base;
using MarkovChains.MarkovChain.Matrices.Probability;

/// <summary>
/// Matrix of integer values.
/// </summary>
public class Matrix : MatrixCommon, IAbsoluteMatrix, IOpenMatrix
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Matrix"/> class.
    /// </summary>
    /// <param name="alphabetCardinality">
    /// Count of elements in matrix dimension.
    /// </param>
    /// <param name="dimensionality">
    /// Count of dimensions in matrix.
    /// </param>
    public Matrix(int alphabetCardinality, int dimensionality) : base(alphabetCardinality, dimensionality, new MatrixBuilder())
    {
    }

    /// <summary>
    /// Gets sum of matrix elements.
    /// </summary>
    public double Count
    {
        get
        {
            return ValueList.Cast<MatrixBase>().Sum(row => row.Value);
        }
    }

    /// <summary>
    /// Gets the value list.
    /// </summary>
    List<object> IOpenMatrix.ValueList
    {
        get
        {
            return new List<object>(ValueList);
        }
    }

    /// <summary>
    /// Gets the rank.
    /// </summary>
    int IOpenMatrix.Rank
    {
        get
        {
            return this.Rank;
        }
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    double IOpenMatrix.Value
    {
        get
        {
            return this.Value;
        }
    }

    /// <summary>
    /// Calculates probability matrix from this matrix.
    /// </summary>
    /// <returns>
    /// Matrix of probabilities.
    /// </returns>
    public IProbabilityMatrix ProbabilityMatrix()
    {
        ProbabilityMatrix temp = new(AlphabetCardinality, Rank);
        temp.Fill(this);
        return temp;
    }

    /// <summary>
    /// Increments matrix value by 1.
    /// </summary>
    public void IncrementValue()
    {
        Value += 1;
    }

    /// <summary>
    /// The add.
    /// </summary>
    /// <param name="arrayToTeach">
    /// The array to teach.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if arrayToTeach is null or its length greater than rank.
    /// </exception>
    public double Add(int[] arrayToTeach)
    {
        if (arrayToTeach == null || arrayToTeach.Length > Rank)
        {
            throw new ArgumentException();
        }

        int index = arrayToTeach[0];
        ((IAbsoluteMatrix)ValueList[index]).IncrementValue();

        if (arrayToTeach.Length <= 1)
        {
            return Value;
        }

        int[] newIndexes = GetChainLess(arrayToTeach);
        if (newIndexes[0] == -1)
        {
            return Value;
        }

        return ((IAbsoluteMatrix)ValueList[index]).Add(newIndexes);
    }

    /// <summary>
    /// The sum.
    /// </summary>
    /// <param name="arrayOfIndexes">
    /// The array of indexes.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Sum(int[] arrayOfIndexes)
    {
        if (arrayOfIndexes != null && (arrayOfIndexes[0] != -1))
        {
            int index = arrayOfIndexes[0];
            int[] newArray = (arrayOfIndexes.Length == 1) ? null : GetChainLess(arrayOfIndexes);
            return ((IAbsoluteMatrix)ValueList[index]).Sum(newArray);
        }

        return Count;
    }
}
