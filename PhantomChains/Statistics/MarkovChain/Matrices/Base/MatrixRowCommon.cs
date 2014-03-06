namespace PhantomChains.Statistics.MarkovChain.Matrices.Base
{
    using System;

    using global::PhantomChains.Statistics.MarkovChain.Builders;

    /// <summary>
    /// Матрица-строка содержит вещетвенные числа в качестве элементов. 
    /// Размерность = 1.
    /// </summary>
    public class MatrixRowCommon : MatrixBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixRowCommon"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Мощность алфавита
        /// </param>
        /// <param name="dimensionality">
        /// размерность матрицы
        /// </param>
        /// <param name="builder">
        /// Правило создания матриц
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
                throw new ArgumentNullException("indexes", "Ошибка адресации");
            }

            return (double)this.ValueList[indexes[0]];
        }
    }
}