using LibiadaCore.Core.SimpleTypes;
using LibiadaCore.Misc.DataTransformers;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The gc ratio.
    /// </summary>
    public class GCSkew : IFullCalculator
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
        /// G+C skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var g = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);

            return g + c == 0 ? 0 : (g - c) / (g + c);
        }
    }
}
