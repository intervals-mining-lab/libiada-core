namespace MarkovChains.MarkovChain.Matrices.Base
{
    using System;

    using MarkovChains.MarkovChain.Builders;

    /// <summary>
    /// Row of the matrix containing doubles as values.
    /// Dimensionality = 1.
    /// </summary>
    public class MatrixRowCommon : MatrixBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixRowCommon"/> class.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Alphabet of the matrix.
        /// </param>
        /// <param name="dimensionality">
        /// Dimensionality of the matrix.
        /// </param>
        /// <param name="builder">
        ///  Creation rule for the matrix.
        /// </param>
        public MatrixRowCommon(int alphabetCardinality, int dimensionality, IMatrixBuilder builder) : base(alphabetCardinality, dimensionality, builder)
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
                throw new ArgumentNullException("indexes", "Addressing error");
            }

            return (double)ValueList[indexes[0]];
        }
    }
}
