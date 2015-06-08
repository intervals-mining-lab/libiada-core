namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.DataTransformers;

    using SimpleTypes;

    /// <summary>
    /// The ry skew.
    /// </summary>
    public class AverageRemotenessRYSkew : IFullCalculator
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
        /// RY skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var g = remotenessCalculator.Calculate(chain.CongenericChain(new ValueString("G")), link);
            var c = remotenessCalculator.Calculate(chain.CongenericChain(new ValueString("C")), link);
            var a = remotenessCalculator.Calculate(chain.CongenericChain(new ValueString("A")), link);
            var t = remotenessCalculator.Calculate(chain.CongenericChain(new ValueString("T")), link);
            var l = remotenessCalculator.Calculate(chain, link);

            var result = ((g + a) - (c + t)) / l;

            return result;
        }
    }
}
