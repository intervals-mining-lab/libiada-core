namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.DataTransformers;

    using SimpleTypes;

    /// <summary>
    /// The at skew.
    /// </summary>
    public class ATSkew : IFullCalculator
    {
        /// <summary>
        /// The elements counter.
        /// </summary>
        private readonly ICalculator counter = new ElementsCount();

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
            DnaProcessing.CheckDnaAlphabet(chain.Alphabet);

            var a = counter.Calculate(chain.CongenericChain(new ValueString("A")), link);
            var t = counter.Calculate(chain.CongenericChain(new ValueString("T")), link);

            var result = (a - t) / (a + t);

            return result;
        }
    }
}
