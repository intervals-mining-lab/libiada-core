﻿namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.DataTransformers;

    /// <summary>
    /// Statistical genetic characteristic RY skew.
    /// </summary>
    public class RYSkew : NonLinkableFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// RY skew value as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
        {
            DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

            var congenericCounter = new CongenericCalculators.ElementsCount();
            var counter = new ElementsCount();

            var g = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
            var c = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));
            var a = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")));
            var t = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")));
            var l = (int)counter.Calculate(chain);

            return l == 0 ? 0 : ((g + a) - (c + t)) / (double)l;
        }
    }
}
