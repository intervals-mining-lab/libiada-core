namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ����� ����������� ������� ������������� ��������
    /// </summary>
    public static class EquipotencyCalculator
    {
        /// <summary>
        /// ����� ��� ���������� ������������� ��������
        /// </summary>
        /// <param name="manager">
        /// ����� �������� ���� � ������ ��� �����
        /// </param>
        /// <returns>
        /// Equipotency of sets. 
        /// </returns>
        public static double Calculate(GraphManager manager)
        {
            // ������� ���������� ��������� � ������ �������
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

            // ������� ����� ����� �������� ��������
            int taxonCount = 0;
            for (int k = 0; k < taxonPower.Count; k++)
            {
                if (taxonPower[k] > 0)
                {
                    taxonCount++;
                }
            }

            // ��������� �������������� ������������� �������� - h
            // ���������� �������� � ������� ���������� ��������
            double h = Math.Pow(taxonCount, taxonCount);
            for (int m = 0; m < taxonPower.Count; m++)
            {
                if (taxonPower[m] != 0)
                {
                    // �������� �������, ������ �� ����� ���������� ���������
                    h *= (double)taxonPower[m] / manager.Elements.Count;
                }
            }

            return h;
        }
    }
}
