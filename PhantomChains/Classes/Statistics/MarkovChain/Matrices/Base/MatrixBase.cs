namespace PhantomChains.Classes.Statistics.MarkovChain.Matrices.Base
{
    using System.Collections;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Builders;

    /// <summary>
    /// ������� ����� ��� ������
    /// </summary>
    public abstract class MatrixBase
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        protected readonly int AlphabetCardinality;

        /// <summary>
        /// ������ ��������� ������.
        /// </summary>
        protected readonly ArrayList ValueList;

        /// <summary>
        /// ����������� �������.
        /// ������ ������.
        /// </summary>
        protected readonly int Rank;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixBase"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// �������� ��������
        /// </param>
        /// <param name="dimensionality">
        /// ����������� �������
        /// </param>
        /// <param name="builder">
        /// ������� �������� ������
        /// </param>
        public MatrixBase(int alphabetCardinality, int dimensionality, IMatrixBuilder builder)
        {
            this.AlphabetCardinality = alphabetCardinality;
            ValueList = new ArrayList();
            Rank = dimensionality;
            for (int i = 0; i < this.AlphabetCardinality; i++)
            {
                ValueList.Add(builder.Create(this.AlphabetCardinality, dimensionality - 1));
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// ���������� ������� ��������� �������.
        /// </summary>
        /// <param name="indexes">
        /// The indexes.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public abstract double FrequencyFromObject(int[] indexes);
    }
}