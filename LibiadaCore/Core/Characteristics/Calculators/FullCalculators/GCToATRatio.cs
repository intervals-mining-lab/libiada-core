namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The gc ratio.
    /// </summary>
    public class GCToATRatio : NonLinkableFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// G+C Ratio value as <see cref="double"/> .
        /// </returns>
        public override double Calculate(Chain chain)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var counter = new CongenericCalculators.ElementsCount();

            var g = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
            var c = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));
            var a = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")));
            var t = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")));

            return a + t == 0 ? 0 : (g + c) / (double)(a + t);
        }
    }
}
