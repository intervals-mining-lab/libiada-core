namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс вычисляющий степень равномощности множеств
    /// </summary>
    public static class EquipotencyCalculator
    {
        /// <summary>
        /// Метод для вычисления равномощности множеств
        /// </summary>
        /// <param name="manager">
        /// класс хранящий граф и список его точек
        /// </param>
        /// <returns>
        /// Equipotency of sets. 
        /// </returns>
        public static double Calculate(GraphManager manager)
        {
            // Находим количество элементов в каждом таксоне
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

            // Находим общее число непустых таксонов
            int taxonCount = 0;
            for (int k = 0; k < taxonPower.Count; k++)
            {
                if (taxonPower[k] > 0)
                {
                    taxonCount++;
                }
            }

            // Вычисляем характеристику равномощности таксонов - h
            // количество таксонов в степени количества таксонов
            double h = Math.Pow(taxonCount, taxonCount);
            for (int m = 0; m < taxonPower.Count; m++)
            {
                if (taxonPower[m] != 0)
                {
                    // мощность таксона, делёная на общее количество элементов
                    h *= (double)taxonPower[m] / manager.Elements.Count;
                }
            }

            return h;
        }
    }
}
