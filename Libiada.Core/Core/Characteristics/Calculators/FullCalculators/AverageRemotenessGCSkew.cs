namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.DataTransformers;

    /// <summary>
    /// The GC skew of congeneric average remotenesses.
    /// </summary>
    public class AverageRemotenessGCSkew : IFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// G+C skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var congenericRemotenessCalculator = new CongenericCalculators.AverageRemoteness();

            double g = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            double c = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            return g + c == 0 ? 0 : (g - c) / (g + c);
        }
    }
}
