namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System;

    /// <summary>
    /// Abstract class for all not linkable full chain characteristics calculators.
    /// </summary>
    public abstract class NonLinkableFullCalculator : IFullCalculator
    {
        /// <summary>
        /// Calculates the characteristic.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link can only be <see cref="Link.NotApplied"/> in this case.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if wrong <see cref="Link"/> is provided.
        /// </exception>
        public double Calculate(Chain chain, Link link)
        {
            if (link != Link.NotApplied)
            {
                throw new ArgumentException("Not linkable characteristic calculator provided with link");
            }

            return Calculate(chain);
        }

        /// <summary>
        /// Main calculation method.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public abstract double Calculate(Chain chain);
    }
}
