namespace MarkovChains.MarkovChain.Matrices.Base
{
    using System.Collections;

    using Builders;

    /// <summary>
    /// Base class of matrixes.
    /// </summary>
    public abstract class MatrixBase
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        protected readonly int AlphabetCardinality;

        /// <summary>
        /// Array of matrix elements.
        /// </summary>
        protected readonly ArrayList ValueList;

        /// <summary>
        /// Dimensionality of the matrix.
        /// </summary>
        protected readonly int Rank;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixBase"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Alphabet of the matrix.
        /// </param>
        /// <param name="dimensionality">
        /// Dimensionality of the matrix.
        /// </param>
        /// <param name="builder">
        /// Rule for creating the matrix.
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
        /// Gets frequency of the object.
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
