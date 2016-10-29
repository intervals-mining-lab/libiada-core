namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class calculating equipotency of sets
    /// (disproportion of elements counts of sets).
    /// </summary>
    public static class EquipotencyCalculator
    {
        /// <summary>
        /// Equipotency calculation method.
        /// </summary>
        /// <param name="manager">
        /// Storage of graph nodes and connections.
        /// </param>
        /// <returns>
        /// Equipotency of sets.
        /// </returns>
        public static double Calculate(GraphManager manager)
        {
            // calculating nodes count in each group
            var taxonPower = new List<int>();
            for (int i = 0; i < manager.GetNextTaxonNumber(); i++)
            {
                taxonPower.Add(0);
            }

            for (int j = 0; j < manager.Elements.Count; j++)
            {
                int taxonNumber = manager.Elements[j].TaxonNumber;
                taxonPower[taxonNumber]++;
            }

            // calculating number of not empty groups
            int taxonCount = 0;
            for (int k = 0; k < taxonPower.Count; k++)
            {
                if (taxonPower[k] > 0)
                {
                    taxonCount++;
                }
            }

            // calculating equipotency of groups - h
            // groups count to the power of groups count.
            double h = Math.Pow(taxonCount, taxonCount);
            for (int m = 0; m < taxonPower.Count; m++)
            {
                if (taxonPower[m] != 0)
                {
                    // Elements count in group divided by elements count in whole graph.
                    h *= (double)taxonPower[m] / manager.Elements.Count;
                }
            }

            return h;
        }
    }
}
