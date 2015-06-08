namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.DataTransformers;

    using SimpleTypes;

    /// <summary>
    /// The at skew.
    /// </summary>
    public class AverageRemotenessATSkew : IFullCalculator
    {
        /// <summary>
        /// The elements counter.
        /// </summary>
        private readonly ICalculator remotenessCalculator = new AverageRemoteness();

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

            var a = remotenessCalculator.Calculate(chain.CongenericChain(new ValueString("A")), link);
            var t = remotenessCalculator.Calculate(chain.CongenericChain(new ValueString("T")), link);

            var result = (a - t) / (a + t);

            return result;
        }
    }
}
