namespace Libiada.MarkovChains.MarkovChain.Matrices.Base;

using MarkovChains.MarkovChain.Builders;

/// <summary>
/// Matrix containing other matrixes as elements.
/// Dimensionality is greater than 1.
/// </summary>
public class MatrixCommon : MatrixBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixCommon"/> class.
    /// </summary>
    /// <param name="alphabetCardinality">
    /// Alphabet of the matrix.
    /// </param>
    /// <param name="dimensionality">
    /// Dimensionality of the matrix.
    /// </param>
    /// <param name="builder">
    /// Rule for creation of the matrix.
    /// </param>
    public MatrixCommon(int alphabetCardinality, int dimensionality, IMatrixBuilder builder) : base(alphabetCardinality, dimensionality, builder)
    {
    }

    /// <summary>
    /// The frequency from object.
    /// </summary>
    /// <param name="indexes">
    /// The indexes.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override double FrequencyFromObject(int[] indexes)
    {
        if (indexes.Length > 1)
        {
            int[] newIndexes = GetChainLess(indexes);
            return ((MatrixBase)ValueList[indexes[0]]).FrequencyFromObject(newIndexes);
        }

        return ((MatrixBase)ValueList[indexes[0]]).Value;
    }

    /// <summary>
    /// The get chain less.
    /// </summary>
    /// <param name="indexes">
    /// The indexes.
    /// </param>
    /// <returns>
    /// The <see cref="T:int[]"/>.
    /// </returns>
    protected int[] GetChainLess(int[] indexes)
    {
        int[] newIndexes = new int[indexes.Length - 1];
        for (int i = 0; i < indexes.Length - 1; i++)
        {
            newIndexes[i] = indexes[i + 1];
        }

        return newIndexes;
    }
}
