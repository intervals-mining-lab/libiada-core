namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The gc ratio.
    /// </summary>
    public class AverageRemotenessGCRatio : IFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// G+C Ratio value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var congenericRemotenessCalculator = new CongenericCalculators.AverageRemoteness();
            var remotenessCalculator = new AverageRemoteness();

            double g = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            double c = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            double l = remotenessCalculator.Calculate(chain, link);
            return l == 0 ? 0 : 100 * (g + c) / l;
        }
    }
}
