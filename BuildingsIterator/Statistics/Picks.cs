namespace BuildingsIterator.Statistics
{
    using System.Collections.Generic;

    using BuildingsIterator.Statistics.Calculators;

    /// <summary>
    /// ����� �������
    /// </summary>
    public class Picks
    {
        /// <summary>
        /// The values.
        /// </summary>
        private readonly List<double> values;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Picks"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Picks(string name)
        {
            this.name = name;
            values = new List<double>();
        }

        /// <summary>
        /// ��������� ��������� ������� � �������
        /// </summary>
        /// <param name="value">�������� ������������ ��������</param>
        public void Add(double value)
        {
            values.Add(value);
        }

        /// <summary>
        /// ��������� ������ ��������� �������� �������
        /// </summary>
        /// <param name="mass">����������� ������</param>
        public void FillList(List<string> mass)
        {
            List<double>.Enumerator iterator = values.GetEnumerator();
            while (iterator.MoveNext())
            {
                mass.Add(iterator.Current.ToString());
            }
        }

        /// <summary>
        /// ���������� �������� �������������� �������
        /// </summary>
        /// <param name="calculator">����������� ����������� ��������������</param>
        /// <returns>�������� ��������������</returns>
        public double GetPicksCharacteristic(IOnePicksCalculator calculator)
        {
            return calculator.Calculate(values);
        }
    }
}