namespace PhantomChains.Classes.Statistics.MarkovChain.Matrices.Probability
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Builders;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Absolute;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Base;

    /// <summary>
    /// �������-������ ������������.
    /// </summary>
    public class ProbabilityMatrixRow : MatrixRowCommon, IProbabilityMatrix, IWritableMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityMatrixRow"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// �������� ��������
        /// </param>
        /// <param name="dimensionality">
        /// ����������� �������
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
                temp += (double)matrix.ValueList[i];
            }

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
        /// Thrown if alphabet cardinality is not equels AlphabetCardinality property of this object.
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
                result.Add(alphabet[i], (double)ValueList[i]);
            }

            return result;
        }
    }
}