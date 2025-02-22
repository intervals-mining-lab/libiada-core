namespace Libiada.MarkovChains.MarkovChain.Matrices.Probability;

using Absolute;

using Base;

using Builders;

using Libiada.Core.Core;

/// <summary>
/// Matrix of probabilities.
/// </summary>
public class ProbabilityMatrix : MatrixCommon, IProbabilityMatrix, IWritableMatrix
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProbabilityMatrix"/> class.
    /// </summary>
    /// <param name="alphabetPower">
    /// Alphabet of the matrix.
    /// </param>
    /// <param name="dimensionality">
    /// Dimensionality of the matrix.
    /// </param>
    public ProbabilityMatrix(int alphabetPower, int dimensionality) : base(alphabetPower, dimensionality, new ProbabilityMatrixBuilder())
    {
    }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    double IWritableMatrix.Value
    {
        get
        {
            return Value;
        }

        set
        {
            Value = value;
        }
    }

    /// <summary>
    /// The fill.
    /// </summary>
    /// <param name="matrix">
    /// The matrix.
    /// </param>
    public void Fill(IOpenMatrix matrix)
    {
        double temp = 0;
        for (int i = 0; i < matrix.ValueList.Count; i++)
        {
            temp += ((IOpenMatrix)matrix.ValueList[i]).Value;
        }

        for (int i = 0; i < ValueList.Count; i++)
        {
            ((IWritableMatrix)ValueList[i]).Value = (temp == 0) ? 0 : ((IOpenMatrix)matrix.ValueList[i]).Value / temp;
            ((IProbabilityMatrix)ValueList[i]).Fill((IOpenMatrix)matrix.ValueList[i]);
        }
    }

    /// <summary>
    /// The get probability vector.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <param name="pred">
    /// The pred.
    /// </param>
    /// <returns>
    /// The <see cref="Dictionary{Libiada.Core.Core.IBaseObject, Double}"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if pred length is 0 or pred length is more than Rank - 1.
    /// </exception>
    public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] pred)
    {
        Dictionary<IBaseObject, double> result = [];
        if ((pred.Length > Rank - 1) || (pred.Length == 0))
        {
            throw new ArgumentException();
        }

        if (pred[0] != -1)
        {
            int[] newIndexes = (pred.Length == 1) ? null : GetChainLess(pred);
            return ((IProbabilityMatrix)ValueList[pred[0]]).GetProbabilityVector(alphabet, newIndexes);
        }

        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            result.Add(alphabet[i], ((MatrixBase)ValueList[i]).Value);
        }

        return result;
    }
}
