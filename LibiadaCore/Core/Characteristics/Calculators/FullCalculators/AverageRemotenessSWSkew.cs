namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The sw skew.
    /// </summary>
    public class AverageRemotenessSWSkew : IFullCalculator
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
        /// SW skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var congenericRemotenessCalculator = new CongenericCalculators.AverageRemoteness();
            var remotenessCalculator = new AverageRemoteness();

            double g = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            double c = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            double a = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            double t = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);
            double l = remotenessCalculator.Calculate(chain, link);
            return l == 0 ? 0 : ((g + c) - (a + t)) / l;
        }
    }
}
