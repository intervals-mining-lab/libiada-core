namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Count of probable sequences that can be generated
    /// from given phantom chain (sequence containing phantom messages).
    /// </summary>
    public class VariationsCount : NonLinkableFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// Variations count as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
        {
            int count = 1;
            for (int i = 0; i < chain.GetLength(); i++)
            {
                var j = chain[i] as ValuePhantom;
                if (j != null)
                {
                    count *= ((ValuePhantom)chain[i]).Cardinality;
                }
            }

            return count;
        }
    }
}
