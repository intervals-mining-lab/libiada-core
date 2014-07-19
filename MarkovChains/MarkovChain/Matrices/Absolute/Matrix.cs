namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using System;
    using System.Collections;

    using MarkovChains.MarkovChain.Builders;
    using MarkovChains.MarkovChain.Matrices.Base;
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// Матрица целых значений. 
    /// </summary>
    public class Matrix : MatrixCommon, IAbsoluteMatrix, IOpenMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="alphabetPower">
        /// Алфавит для матрицы
        /// </param>
        /// <param name="dimensionality">
        /// Размерность матрицы
        /// </param>
        public Matrix(int alphabetPower, int dimensionality)
            : base(alphabetPower, dimensionality, new MatrixBuilder())
        {
        }

        /// <summary>
        /// Возвращает сумму элементов матрицы
        /// </summary>
        public double Count
        {
            get
            {
                double sum = 0;
                foreach (MatrixBase row in this.ValueList)
                {
                    sum += row.Value;
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
        /// Получить вероятностную матрицу из данной матрицы
        /// </summary>
        /// <returns>
        /// Веротяностая матрица
        /// </returns>
        public IProbabilityMatrix ProbabilityMatrix()
        {
            var temp = new ProbabilityMatrix(this.AlphabetCardinality, this.Rank);
            temp.Fill(this);
            return temp;
        }

        /// <summary>
        /// Увеличивает заначение матрицы на 1
        /// </summary>
        public void IncValue()
        {
            this.Value += 1;
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
            if (arrayToTeach == null || arrayToTeach.Length > this.Rank)
            {
                throw new ArgumentException();
            }

            int index = arrayToTeach[0];
            ((IAbsoluteMatrix)this.ValueList[index]).IncValue();

            if (arrayToTeach.Length <= 1)
            {
                return this.Value;
            }

            int[] newIndexes = this.GetChainLess(arrayToTeach);
            if (newIndexes[0] == -1)
            {
                return this.Value;
            }

            return ((IAbsoluteMatrix)this.ValueList[index]).Add(newIndexes);
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
            if (null != arrayOfIndexes && (arrayOfIndexes[0] != -1))
            {
                int index = arrayOfIndexes[0];
                int[] newArray = (arrayOfIndexes.Length == 1) ? null : this.GetChainLess(arrayOfIndexes);
                return ((IAbsoluteMatrix)this.ValueList[index]).Sum(newArray);
            }

            return this.Count;
        }
    }
}