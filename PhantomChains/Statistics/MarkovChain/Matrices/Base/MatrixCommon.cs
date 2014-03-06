namespace PhantomChains.Statistics.MarkovChain.Matrices.Base
{
    using global::PhantomChains.Statistics.MarkovChain.Builders;

    /// <summary>
    /// Матрица содержащая в качестве элементов другие матрицы. 
    /// Размерность более 1.
    /// </summary>
    public class MatrixCommon : MatrixBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixCommon"/> class.
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
        public MatrixCommon(int alphabetCardinality, int dimensionality, IMatrixBuilder builder)
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
        public override double FrequencyFromObject(int[] indexes)
        {
            if (indexes.Length > 1)
            {
                int[] newIndexes = this.GetChainLess(indexes);
                return ((MatrixBase)this.ValueList[indexes[0]]).FrequencyFromObject(newIndexes);
            }

            return ((MatrixBase)this.ValueList[indexes[0]]).Value;
        }

        /// <summary>
        /// The get chain less.
        /// </summary>
        /// <param name="indexes">
        /// The indexes.
        /// </param>
        /// <returns>
        /// The <see cref="T:int[]"/>.
        /// </returns>
        protected int[] GetChainLess(int[] indexes)
        {
            var newIndexes = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                newIndexes[i] = indexes[i + 1];
            }

            return newIndexes;
        }
    }
}