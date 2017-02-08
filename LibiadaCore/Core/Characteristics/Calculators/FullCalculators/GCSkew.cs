namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The gc ratio.
    /// </summary>
    public class GCSkew : IFullCalculator
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
        /// G+C skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var counter = new CongenericCalculators.ElementsCount();

            var g = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            var c = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);

            return g + c == 0 ? 0 : (g - c) / (double)(g + c);
        }
    }
}
