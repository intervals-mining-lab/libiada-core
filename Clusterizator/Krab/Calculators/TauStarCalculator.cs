namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ����� ��� ���������� ��������� ��������� �����
    /// � ����������� ������ ���� �����
    /// </summary>
    public class TauStarCalculator : ICalculator
    {
        /// <summary>
        /// ����� ����������� ��������� ��������� ����� 
        /// � ����������� ������ ���� �����
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                Connection connection = graph.Connections[i];
                double bMin = GetBmin(
                    graph.Connections,
                    graph.Elements.Count,
                    connection.FirstElementIndex,
                    connection.SecondElementIndex);
                connection.TauStar = connection.Distance / bMin;
            }
        }

        /// <summary>
        /// ��������� ����������� ���������� �� ���� �����,
        /// �.�. ���� ����� �������� ����� ����� ������� ������ ������
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����
        /// </param>
        /// <param name="elementsPower">
        /// Count of elements.
        /// </param>
        /// <param name="firstElement">
        /// ������ �����
        /// </param>
        /// <param name="secondElement">
        /// ������ �����
        /// </param>
        /// <returns>
        /// Bmin - ����������� ����������
        /// </returns>
        private double GetBmin(List<Connection> graph, int elementsPower, int firstElement, int secondElement)
        {
            double min = Math.Min(
                SearchForMinimum(graph, elementsPower, firstElement, secondElement),
                SearchForMinimum(graph, elementsPower, secondElement, firstElement));
            return min;
        }

        /// <summary>
        /// The search for minimum.
        /// </summary>
        /// <param name="graph">
        /// The graph.
        /// </param>
        /// <param name="elementsPower">
        /// The elements power.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="exceptedElement">
        /// The excepted element.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double SearchForMinimum(List<Connection> graph, int elementsPower, int element, int exceptedElement)
        {
            // ������� ����������� ����������
            double min = double.MaxValue; 

            int blockBeginning = 0;
            for (int i = 0; i < element; i++)
            {
                // ���� ������ ������� ��� �����
                blockBeginning += BlockLength(i, elementsPower); 
            }

            // ����� ���� ���������� ������
            int blockSum = 0;

            // ����� ������ �����
            int shift = element - 1; 

            // ���� �������� ��������� �������� � ������� ��� ������ 
            for (int k = 0, j = element - 1; shift >= 0; j = blockSum + (--shift), k++)
            {
                if ((min > graph[j].Distance) && 
                    (graph[j].SecondElementIndex != exceptedElement) &&
                    (graph[j].FirstElementIndex != exceptedElement))
                {
                    min = graph[j].Distance;
                }

                blockSum += BlockLength(k, elementsPower);
            }
            
            // ��������� ����� �����
            int ourBlockLength = BlockLength(element, elementsPower);

            // ������� ����� �� ������ �� �����
            for (int k = blockBeginning; k < blockBeginning + ourBlockLength; k++) 
            {
                if ((min > graph[k].Distance) && 
                    (graph[k].SecondElementIndex != exceptedElement) &&
                    (graph[k].FirstElementIndex != exceptedElement))
                {
                    min = graph[k].Distance;
                }
            }

            return min;
        }

        /// <summary>
        /// The block length.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="power">
        /// The power.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int BlockLength(int element, int power)
        {
            return power - (element + 1);
        }
    }
}