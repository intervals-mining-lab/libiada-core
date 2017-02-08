namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The at skew.
    /// </summary>
    public class AverageRemotenessATSkew : IFullCalculator
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
        /// AT skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var congenericRemotenessCalculator = new CongenericCalculators.AverageRemoteness();

            double a = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            double t = congenericRemotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);
            return a + t == 0 ? 0 : (a - t) / (a + t);
        }
    }
}
