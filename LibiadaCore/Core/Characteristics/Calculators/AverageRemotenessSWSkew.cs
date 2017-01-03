namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.DataTransformers;

    using SimpleTypes;

    /// <summary>
    /// The sw skew.
    /// </summary>
    public class AverageRemotenessSWSkew : IFullCalculator
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
        /// SW skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var g = remotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            var c = remotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            var a = remotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = remotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);
            var l = remotenessCalculator.Calculate(chain, link);

            return l == 0 ? 0 : ((g + c) - (a + t)) / l;
        }
    }
}
