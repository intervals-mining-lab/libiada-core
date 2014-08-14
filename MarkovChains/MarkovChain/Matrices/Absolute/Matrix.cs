namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using System;
    using System.Collections;

    using MarkovChains.MarkovChain.Builders;
    using MarkovChains.MarkovChain.Matrices.Base;
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// ������� ����� ��������. 
    /// </summary>
    public class Matrix : MatrixCommon, IAbsoluteMatrix, IOpenMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="alphabetPower">
        /// ������� ��� �������
        /// </param>
        /// <param name="dimensionality">
        /// ����������� �������
        /// </param>
        public Matrix(int alphabetPower, int dimensionality)
            : base(alphabetPower, dimensionality, new MatrixBuilder())
        {
        }

        /// <summary>
        /// ���������� ����� ��������� �������
        /// </summary>
        public double Count
        {
            get
            {
                double sum = 0;
                foreach (MatrixBase row in ValueList)
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
        /// �������� ������������� ������� �� ������ �������
        /// </summary>
        /// <returns>
        /// ������������ �������
        /// </returns>
        public IProbabilityMatrix ProbabilityMatrix()
        {
            var temp = new ProbabilityMatrix(AlphabetCardinality, Rank);
            temp.Fill(this);
            return temp;
        }

        /// <summary>
        /// ����������� ��������� ������� �� 1
        /// </summary>
        public void IncValue()
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
            ((IAbsoluteMatrix)ValueList[index]).IncValue();

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
            if (null != arrayOfIndexes && (arrayOfIndexes[0] != -1))
            {
                int index = arrayOfIndexes[0];
                int[] newArray = (arrayOfIndexes.Length == 1) ? null : GetChainLess(arrayOfIndexes);
                return ((IAbsoluteMatrix)ValueList[index]).Sum(newArray);
            }

            return Count;
        }
    }
}