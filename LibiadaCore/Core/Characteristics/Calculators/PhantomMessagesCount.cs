﻿namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Count of probable sequences that can be generated 
    /// from given phantom chain (sequence containing phantom messages).
    /// </summary>
    public class PhantomMessagesCount : ICalculator
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
        /// Phantom chain count as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            int count = 1;
            for (int i = 0; i < chain.GetLength(); i++)
            {
                var j = chain[i] as ValuePhantom;
                if (j != null)
                {
                    count *= ((ValuePhantom)chain[i]).Cardinality;
                }
            }

            return count;
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
        /// Phantom chain count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int count = 1;
            for (int i = 0; i < chain.GetLength(); i++)
            {
                var j = chain[i] as ValuePhantom;
                if (j != null)
                {
                    count *= ((ValuePhantom)chain[i]).Cardinality;
                }
            }

            return count;
        }
    }
}
