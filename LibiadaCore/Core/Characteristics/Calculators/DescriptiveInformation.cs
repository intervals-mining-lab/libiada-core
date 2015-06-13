namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Mazur's descriptive information.
    /// </summary>
    public class DescriptiveInformation : ICalculator
    {
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
        /// Descriptive informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var calculator = new ArithmeticMean();
            double arithmeticMean = calculator.Calculate(chain, link);
            return arithmeticMean == 0 ? 1 : Math.Pow(arithmeticMean, 1 / arithmeticMean);
        }

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
        /// Descriptive informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 1;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result *= Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}
