namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The sw skew.
    /// </summary>
    public class SWSkew : IFullCalculator
    {
        /// <summary>
        /// The elements counter.
        /// </summary>
        private readonly ICongenericCalculator counter = new CongenericCalculators.ElementsCount();

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
            var calculator = new ElementsCount();

            var g = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            var a = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);
            var l = calculator.Calculate(chain, link);

            return l == 0 ? 0 : ((g + c) - (a + t)) / l;
        }
    }
}
