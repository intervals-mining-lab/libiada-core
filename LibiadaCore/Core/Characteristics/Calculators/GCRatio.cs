using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibiadaCore.Core.SimpleTypes;

namespace LibiadaCore.Core.Characteristics.Calculators
{
    class GCRatio : IFullCalculator
    {
        private ICalculator counter = new ElementsCount();
        

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
            if (chain.Alphabet.Cardinality > 4)
            {
                    throw new Exception("Alphabet cardinality must be 4 or less");
            }

            var g = counter.Calculate(chain.CongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.CongenericChain(new ValueString("C")), link);
            var l = counter.Calculate(chain, link);

            var result = (g+c)/l * 100;

            return result;
        }
    }
}
