namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using SimpleTypes;

    public class GCRatio : IFullCalculator
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
            CheckAlphabet(chain.Alphabet);

            var g = counter.Calculate(chain.CongenericChain(new ValueString("G")), link);
            var c = counter.Calculate(chain.CongenericChain(new ValueString("C")), link);
            var l = counter.Calculate(chain, link);

            var result = (g+c)/l * 100;

            return result;
        }

        private static void CheckAlphabet(Alphabet alphabet)
        {
            if (alphabet.Cardinality > 4)
            {
                throw new Exception("Alphabet cardinality must be 4 or less");
            }

            var completeAlphabet = new Alphabet
            {
                new ValueString("A"),
                new ValueString("C"),
                new ValueString("T"),
                new ValueString("G")
            };

            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                if (!completeAlphabet.Contains(alphabet[i]))
                {
                    throw new Exception("Alphabet contains at least 1 wrong element: " + alphabet[i]);
                }
            }
        }
    }
}
