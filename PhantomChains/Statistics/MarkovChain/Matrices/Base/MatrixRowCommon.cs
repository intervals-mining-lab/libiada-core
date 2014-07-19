namespace PhantomChains.Statistics.MarkovChain.Matrices.Base
{
    using System;

    using global::PhantomChains.Statistics.MarkovChain.Builders;

    /// <summary>
    /// �������-������ �������� ����������� ����� � �������� ���������. 
    /// ����������� = 1.
    /// </summary>
    public class MatrixRowCommon : MatrixBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixRowCommon"/> class.
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
        public MatrixRowCommon(int alphabetCardinality, int dimensionality, IMatrixBuilder builder)
            : base(alphabetCardinality, dimensionality, builder)
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
        /// <exception cref="ArgumentNullException">
        /// Thrown if indexes is null.
        /// </exception>
        public override double FrequencyFromObject(int[] indexes)
        {
            if (indexes == null)
            {
                throw new ArgumentNullException("indexes", "������ ���������");
            }

            return (double)this.ValueList[indexes[0]];
        }
    }
}