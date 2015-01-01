namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ����� ��� ���������� �������������� ����������� ���������� 
    /// </summary>
    public class NormalizedLinearCalculator : ICalculator
    {
        /// <summary>
        /// ����� ����������� ������������� ���������� 
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            double diameter = GetDiameter(graph.Connections);
            if (Math.Abs(diameter - 0) < 0.00001)
            {
                return;
            }

            // ������������ �������� ���������� � ��������� (0;1]
            foreach (Connection connection in graph.Connections)
            {
                connection.NormalizedDistance = connection.Distance / diameter;
            }
        }

        /// <summary>
        /// ����� ��� ���������� �������� �����
        /// (���������� ���� �����)
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����
        /// </param>
        /// <returns>
        /// d - ������������ ����������
        /// </returns>
        private double GetDiameter(IEnumerable<Connection> graph)
        {
            return graph.Max(i => i.Distance);
        }
    }
}
