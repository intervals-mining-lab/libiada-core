namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Abstract class common for all binary calculators.
    /// </summary>
    public abstract class BinaryCalculator : IBinaryCalculator
    {
        /// <summary>
        /// Calculation method for two congeneric chains.
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Characteristic value.
        /// </returns>
        public abstract double Calculate(BinaryIntervalsManager manager, Link link);

        /// <summary>
        /// Calculation method for complete matrix of all pairs of elements.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Square matrix of characteristics of all pairs of elements.
        /// </returns>
        public List<List<double>> CalculateAll(Chain chain, Link link)
        {
            var result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.Cardinality; j++)
                {
                    result[i].Add(this.Calculate(chain.GetRelationIntervalsManager(i + 1, j + 1), link));
                }
            }

            return result;
        }
    }
}