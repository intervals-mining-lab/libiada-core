namespace PhantomChains.Statistics.MarkovChain.Matrices.Probability
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using global::PhantomChains.Statistics.MarkovChain.Builders;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Absolute;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Base;

    /// <summary>
    /// Матрица-строка веротяностей.
    /// </summary>
    public class ProbabilityMatrixRow : MatrixRowCommon, IProbabilityMatrix, IWritableMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityMatrixRow"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Мощность алфавита
        /// </param>
        /// <param name="dimensionality">
        /// Размерность матрицы
        /// </param>
        public ProbabilityMatrixRow(int alphabetCardinality, int dimensionality)
            : base(alphabetCardinality, dimensionality, new ProbabilityMatrixBuilder())
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        double IWritableMatrix.Value
        {
            get
            {
                return this.Value;
            }

            set
            {
                this.Value = value;
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
                temp += (double)matrix.ValueList[i];
            }

            for (int i = 0; i < this.ValueList.Count; i++)
            {
                this.ValueList[i] = (temp == 0) ? 0 : ((double)matrix.ValueList[i]) / temp;
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
            return this.GetProbabilityVector(alphabet, new int[] { });
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
            if (alphabet.Cardinality != this.AlphabetCardinality)
            {
                throw new ArgumentException();
            }

            if (pred != null && !pred.Equals(NullValue.Instance()))
            {
                throw new Exception();
            }

            var result = new Dictionary<IBaseObject, double>();
            for (int i = 0; i < this.AlphabetCardinality; i++)
            {
                result.Add(alphabet[i], (double)this.ValueList[i]);
            }

            return result;
        }
    }
}