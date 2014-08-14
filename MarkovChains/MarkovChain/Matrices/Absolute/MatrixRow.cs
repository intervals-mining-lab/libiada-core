namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using System;
    using System.Collections;

    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain.Builders;
    using MarkovChains.MarkovChain.Matrices.Base;
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// Матрица-строка абсолютных значений.
    /// </summary>
    public class MatrixRow : MatrixRowCommon, IAbsoluteMatrix, IOpenMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixRow"/> class.
        /// </summary>
        /// <param name="alphabetPower">
        /// Алфавит для матрицы
        /// </param>
        /// <param name="dimensionality">
        /// Размерность матрицы
        /// </param>
        public MatrixRow(int alphabetPower, int dimensionality)
            : base(alphabetPower, dimensionality, new MatrixBuilder())
        {
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public double Count
        {
            get
            {
                double sum = 0;
                foreach (double i in ValueList)
                {
                    sum += i;
                }

                return sum;
            }
        }

        /// <summary>
        /// Gets the value list.
        /// </summary>
        ArrayList IOpenMatrix.ValueList
        {
            get
            {
                return (ArrayList)this.ValueList.Clone();
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
        /// The inc value.
        /// </summary>
        public void IncValue()
        {
            this.Value += 1;
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
        /// <exception cref="ArgumentException">
        /// Thrown if arrayOfIndexes is not null and not NullValue.
        /// </exception>
        public double Sum(int[] arrayOfIndexes)
        {
            if (arrayOfIndexes != null && !arrayOfIndexes.Equals(NullValue.Instance()))
            {
                throw new ArgumentException();
            }

            return Count;
        }

        /// <summary>
        /// The probability matrix.
        /// </summary>
        /// <returns>
        /// The <see cref="IProbabilityMatrix"/>.
        /// </returns>
        public IProbabilityMatrix ProbabilityMatrix()
        {
            var temp = new ProbabilityMatrixRow(AlphabetCardinality, 1);
            temp.Fill(this);
            return temp;
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
        /// <exception cref="Exception">
        /// Thrown if arrayToTeach is null or its length greater than rank.
        /// </exception>
        public double Add(int[] arrayToTeach)
        {
            if (arrayToTeach == null || arrayToTeach.Length > Rank)
            {
                throw new ArgumentException();
            }

            if (arrayToTeach[0] == -1)
            {
                return Value;
            }

            double result = ((double)ValueList[arrayToTeach[0]]) + 1;
            ValueList[arrayToTeach[0]] = result;
            return result;
        }
    }
}