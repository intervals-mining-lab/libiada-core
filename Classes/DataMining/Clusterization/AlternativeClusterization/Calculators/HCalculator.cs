using System;
using System.Collections.Generic;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Класс вычисляющий степень равномощности множеств
    /// </summary>
    public static class HCalculator
    {
        /// <summary>
        /// Метод для вычисления равномощности множеств
        /// </summary>
        /// <param name="manager">класс хранящий граф и список его точек</param>
        /// <returns>h</returns>
        public static double Calculate(GraphManager manager)
        {
            //Находим количество элементов в каждом таксоне
            List<int> TaxonPower = new List<int>();
            for (int i = 0; i < manager.GetNextTaxonNumber(); i++)
            {
                TaxonPower.Add(0);
            }
            for (int j = 0; j < manager.Elements.Count; j++)
            {
                int TaxonNumber = manager.Elements[j].TaxonNumber;
                TaxonPower[TaxonNumber]++;
            }
            // Находим общее число непустых таксонов
            int TaxonCount = 0;
            for (int k = 0; k < TaxonPower.Count; k++)
            {
                if (TaxonPower[k]>0)
                {
                    TaxonCount++;
                }
            }
            // Вычисляем характеристику равномощности таксонов - h
            //количество таксонов в степени количества таксонов
            double h = Math.Pow(TaxonCount, TaxonCount);
            for (int m = 0; m < TaxonPower.Count; m++)
            {
                if (TaxonPower[m]!=0)
                {
                    //мощность таксона, делёная на общее количество элементов
                    h *= (double)TaxonPower[m]/manager.Elements.Count;    
                } 
            }
            return h;
        }
    }
}