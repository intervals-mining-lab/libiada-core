namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The at skew.
    /// </summary>
    public class ATSkew : IFullCalculator
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

            var counter = new CongenericCalculators.ElementsCount();

            var a = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);

            return a + t == 0 ? 0 : (a - t) / (double)(a + t);
        }
    }
}
