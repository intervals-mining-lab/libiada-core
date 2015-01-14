namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.DataTransformers;

    using SimpleTypes;

    /// <summary>
    /// The ry skew.
    /// </summary>
    public class RYSkew : IFullCalculator
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
        /// RY skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessing.CheckDnaAlphabet(chain.Alphabet);

            var g = counter.Calculate(chain.CongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.CongenericChain(new ValueString("C")), link);
            var a = counter.Calculate(chain.CongenericChain(new ValueString("A")), link);
            var t = counter.Calculate(chain.CongenericChain(new ValueString("T")), link);
            var l = counter.Calculate(chain, link);

            var result = ((g + a) - (c + t)) / l;

            return result;
        }
    }
}
