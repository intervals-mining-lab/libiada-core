namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The at skew.
    /// </summary>
    public class ATSkew : NonLinkableFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// AT skew value as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var counter = new CongenericCalculators.ElementsCount();

            var a = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")));
            var t = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")));

            return a + t == 0 ? 0 : (a - t) / (double)(a + t);
        }
    }
}
