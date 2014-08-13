namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
    /// Энтропия, количество информации по Шеннону.
    /// </summary>
    public class IdentificationInformation : ICalculator
    {
        /// <summary>
        /// Average arithmetic interval length calculator.
        /// </summary>
        private readonly ICalculator arithmeticMean = new ArithmeticMean();

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
        /// Identification informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            double mean = arithmeticMean.Calculate(chain, link);
            return (-1 / mean) * Math.Log(1 / mean, 2);
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
        /// Identification informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 0;

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}