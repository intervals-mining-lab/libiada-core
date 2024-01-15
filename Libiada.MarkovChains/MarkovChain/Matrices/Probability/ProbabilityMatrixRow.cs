namespace MarkovChains.MarkovChain.Matrices.Probability
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Absolute;

    using Base;

    using Builders;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// One dimensional (row) probability matrix.
    /// </summary>
    public class ProbabilityMatrixRow : MatrixRowCommon, IProbabilityMatrix, IWritableMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityMatrixRow"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Alphabet cardinality.
        /// </param>
        /// <param name="dimensionality">
        /// The dimensionality of the matrix.
        /// </param>
        public ProbabilityMatrixRow(int alphabetCardinality, int dimensionality) : base(alphabetCardinality, dimensionality, new ProbabilityMatrixBuilder())
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
            double temp = matrix.ValueList.Cast<double>().Sum();

            for (int i = 0; i < ValueList.Count; i++)
            {
                ValueList[i] = (temp == 0) ? 0 : ((double)matrix.ValueList[i]) / temp;
            }
        }

        /// <summary>
        /// The get probability vector.
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="T:Dictionary{IBaseObject, double}"/>.
        /// </returns>
        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet)
        {
            return GetProbabilityVector(alphabet, new int[] { });
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
        /// The <see cref="T:Dictionary{IBaseObject, double}"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if alphabet cardinality is not equals AlphabetCardinality property of this object.
        /// </exception>
        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] pred)
        {
            if (alphabet.Cardinality != AlphabetCardinality)
            {
                throw new ArgumentException();
            }

            if (pred != null && !pred.Equals(NullValue.Instance()))
            {
                throw new Exception();
            }

            var result = new Dictionary<IBaseObject, double>();
            for (int i = 0; i < AlphabetCardinality; i++)
            {
                result.Add(alphabet[i], (double)ValueList[i]);
            }

            return result;
        }
    }
}
