namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// нормированная ассиметрия средних удаленностей или коэффициент ассиметрии
    /// (скошенность) распределения средних удаленностей однородных цепей.
    /// </summary>
    public class NormalizedRemotenessStandardDeviation : IFullCalculator
    {
        /// <summary>
        /// Normalized Remoteness Standard Deviation.
        /// </summary>
        private readonly IFullCalculator remotenessAsymmetry = new RemotenessAsymmetry();

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
        /// Standard Deviation <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return remotenessAsymmetry.Calculate(chain, link) /
                   Math.Pow(remotenessAsymmetry.Calculate(chain, link), 1 / 3.0);   
        }
    }
}