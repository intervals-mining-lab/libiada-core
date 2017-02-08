namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The mk skew.
    /// </summary>
    public class MKSkew : IFullCalculator
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
        /// MK skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var congenericCounter = new CongenericCalculators.ElementsCount();
            var counter = new ElementsCount();

            var g = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            var c = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            var a = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);
            var l = (int)counter.Calculate(chain, link);

            return l == 0 ? 0 : ((c + a) - (g + t)) / (double)l;
        }
    }
}
