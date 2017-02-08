﻿namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;

    /// <summary>
    /// The at skew.
    /// </summary>
    public class AverageRemotenessATSkew : IFullCalculator
    {
        /// <summary>
        /// The elements counter.
        /// </summary>
        private readonly ICongenericCalculator remotenessCalculator = new CongenericCalculators.AverageRemoteness();

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

            var a = remotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = remotenessCalculator.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);

            return (int)(a + t) == 0 ? 0 : (a - t) / (a + t);
        }
    }
}
