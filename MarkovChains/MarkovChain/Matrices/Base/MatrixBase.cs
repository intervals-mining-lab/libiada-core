namespace MarkovChains.MarkovChain.Matrices.Base
{
    using System.Collections;

    using Builders;

    /// <summary>
    /// Базовые класс для матриц
    /// </summary>
    public abstract class MatrixBase
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        protected readonly int AlphabetCardinality;

        /// <summary>
        /// Вектор элементов матриц.
        /// </summary>
        protected readonly ArrayList ValueList;

        /// <summary>
        /// Размерность матрицы.
        /// Только чтение.
        /// </summary>
        protected readonly int Rank;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixBase"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Мощность алфавита
        /// </param>
        /// <param name="dimensionality">
        /// Размерность матрицы
        /// </param>
        /// <param name="builder">
        /// Правило создания матриц
        /// </param>
        public MatrixBase(int alphabetCardinality, int dimensionality, IMatrixBuilder builder)
        {
            AlphabetCardinality = alphabetCardinality;
            ValueList = new ArrayList();
            Rank = dimensionality;
            for (int i = 0; i < AlphabetCardinality; i++)
            {
                ValueList.Add(builder.Create(AlphabetCardinality, dimensionality - 1));
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// Возвращает частоту появления объекта.
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
