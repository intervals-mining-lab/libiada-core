﻿namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.DataTransformers;

    using SimpleTypes;

    /// <summary>
    /// The mk skew.
    /// </summary>
    public class MKSkew : IFullCalculator
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
        /// MK skew value as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var g = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")), link);
            var a = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")), link);
            var t = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")), link);
            var l = counter.Calculate(chain, link);

            var result = ((c + a) - (g + t)) / l;

            return result;
        }
    }
}
