namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The gc ratio.
    /// </summary>
    public class GCSkew : NonLinkableFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// G+C skew value as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var counter = new CongenericCalculators.ElementsCount();

            var g = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
            var c = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));

            return g + c == 0 ? 0 : (g - c) / (double)(g + c);
        }
    }
}
