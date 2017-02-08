using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;
using LibiadaCore.Core.SimpleTypes;
using LibiadaCore.Misc.DataTransformers;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The at skew.
    /// </summary>
    public class ATSkew : IFullCalculator
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
        /// AT skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var a = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);

            return (int)(a + t) == 0 ? 0 : (a - t) / (a + t);
        }
    }
}
