namespace MarkovChains.MarkovChain.Matrices.Probability
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using MarkovChains.MarkovChain.Builders;
    using MarkovChains.MarkovChain.Matrices.Absolute;
    using MarkovChains.MarkovChain.Matrices.Base;

    /// <summary>
    /// Матрица веротяностей. 
    /// </summary>
    public class ProbabilityMatrix : MatrixCommon, IProbabilityMatrix, IWritableMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityMatrix"/> class.
        /// </summary>
        /// <param name="alphabetPower">
        /// Мощность алфавита
        /// </param>
        /// <param name="dimensionality">
        /// Размерность матрицы
        /// </param>
        public ProbabilityMatrix(int alphabetPower, int dimensionality)
            : base(alphabetPower, dimensionality, new ProbabilityMatrixBuilder())
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
                temp += ((IOpenMatrix)matrix.ValueList[i]).Value;
            }

            for (int i = 0; i < this.ValueList.Count; i++)
            {
                ((IWritableMatrix)this.ValueList[i]).Value = (temp == 0)
                                                            ? 0
                                                            : ((IOpenMatrix)matrix.ValueList[i]).Value / temp;
                ((IProbabilityMatrix)this.ValueList[i]).Fill((IOpenMatrix)matrix.ValueList[i]);
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
        /// The <see cref="T:Dictionary{IBaseObject, double}"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] pred)
        {
            var result = new Dictionary<IBaseObject, double>();
            if ((pred.Length > this.Rank - 1) || (pred.Length == 0))
            {
                throw new ArgumentException();
            }

            if (pred[0] != -1)
            {
                int[] newIndexes = (pred.Length == 1) ? null : this.GetChainLess(pred);
                return ((IProbabilityMatrix)this.ValueList[pred[0]]).GetProbabilityVector(alphabet, newIndexes);
            }

            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                result.Add(alphabet[i], ((MatrixBase)this.ValueList[i]).Value);
            }

            return result;
        }
    }
}