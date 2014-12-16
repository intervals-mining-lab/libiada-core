using LibiadaCore.Misc.DataTransformers;

namespace LibiadaCore.Core.Characteristics.Calculators
{
    using SimpleTypes;

    public class GCRatio : IFullCalculator
    {
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
        /// G+C Ratio <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessing.CheckDnaAlphabet(chain.Alphabet);

            var g = counter.Calculate(chain.CongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.CongenericChain(new ValueString("C")), link);
            var l = counter.Calculate(chain, link);

            var result = (g+c)/l * 100;

            return result;
        }
    }
}
