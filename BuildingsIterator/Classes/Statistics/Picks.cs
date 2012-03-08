using System.Collections.Generic;
using BuildingsIterator.Classes.Statistics.Calculators;

namespace BuildingsIterator.Classes.Statistics
{
    ///<summary>
    /// ����� �������
    ///</summary>
    public class Picks
    {
        private List<double> values;
        private string name;

        /// <summary>
        /// �����������
        /// </summary>
        public Picks(string name)
        {
            this.name = name;
            values = new List<double>();
        }

        ///<summary>
        /// ��������� ��������� ������� � �������
        ///</summary>
        ///<param name="value">�������� ������������ ��������</param>
        public void Add(double value)
        {
            values.Add(value);
        }

        ///<summary>
        /// �������� �������������� �������
        ///</summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        ///<summary>
        /// ��������� ������ ��������� �������� �������
        ///</summary>
        ///<param name="mass">����������� ������</param>
        public void FillList(List<string> mass)
        {
            List<double>.Enumerator iter = values.GetEnumerator();
            while (iter.MoveNext())
            {
                mass.Add(iter.Current.ToString());
            }
        }

        /// <summary>
        /// ���������� �������� �������������� �������
        /// </summary>
        /// <param name="calculator">����������� ����������� ��������������</param>
        /// <returns>�������� ��������������</returns>
        public double GetPicksCharacterisic(IOnePicksCalculator calculator)
        {
            return calculator.Calculate(values);
        }
    }
}