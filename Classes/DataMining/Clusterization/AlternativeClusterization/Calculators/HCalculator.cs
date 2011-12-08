using System;
using System.Collections.Generic;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// ����� ����������� ������� ������������� ��������
    /// </summary>
    public static class HCalculator
    {
        /// <summary>
        /// ����� ��� ���������� ������������� ��������
        /// </summary>
        /// <param name="manager">����� �������� ���� � ������ ��� �����</param>
        /// <returns>h</returns>
        public static double Calculate(GraphManager manager)
        {
            //������� ���������� ��������� � ������ �������
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
            // ������� ����� ����� �������� ��������
            int TaxonCount = 0;
            for (int k = 0; k < TaxonPower.Count; k++)
            {
                if (TaxonPower[k]>0)
                {
                    TaxonCount++;
                }
            }
            // ��������� �������������� ������������� �������� - h
            //���������� �������� � ������� ���������� ��������
            double h = Math.Pow(TaxonCount, TaxonCount);
            for (int m = 0; m < TaxonPower.Count; m++)
            {
                if (TaxonPower[m]!=0)
                {
                    //�������� �������, ������ �� ����� ���������� ���������
                    h *= (double)TaxonPower[m]/manager.Elements.Count;    
                } 
            }
            return h;
        }
    }
}