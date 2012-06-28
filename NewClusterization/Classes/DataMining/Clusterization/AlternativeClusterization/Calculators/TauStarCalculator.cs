using System;
using System.Collections.Generic;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// ����� ��� ���������� ��������� ��������� �����
    /// � ����������� ������ ���� �����
    /// </summary>
    public class TauStarCalculator:ICalculator 
    {
        /// <summary>
        /// ����� ����������� ��������� ��������� ����� 
        /// � ����������� ������ ���� �����
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].tauStar = graph.Connections[i].distance / GetBmin(graph.Connections, graph.Elements.Count, graph.Connections[i].FirstElementIndex, graph.Connections[i].SecondElementIndex);
            }
           
        }

        /// <summary>
        /// ��������� ����������� ���������� �� ���� �����,
        /// �.�. ���� ����� �������� ����� ����� ������� ������ ������
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        /// <param name="elementsPower"> </param>
        /// <param name="firstElement">������ �����</param>
        /// <param name="secondElement">������ �����</param>
        /// <returns>Bmin - ����������� ����������</returns>
        private double GetBmin(List<Connection> graph, int elementsPower, int firstElement, int secondElement)
        {
             double min = Math.Min(SearchForMinimum(graph, elementsPower, firstElement, secondElement),
                                  SearchForMinimum(graph, elementsPower, secondElement, firstElement));
            return min;
        }

        private double SearchForMinimum(List<Connection> graph, int elementsPower, int element, int exceptedElement)
        {
            double min = double.MaxValue;//������� ����������� ����������

            int blockBegining = 0;
            for (int i = 0; i < element; i++)
            {
                blockBegining += BlockLength(i,elementsPower);//���� ������ ������� ��� �����
            }

            int blockSumm = 0;//����� ���� ���������� ������
            int shift = element - 1; //����� ������ �����

            //���� �������� ��������� �������� � ������� ��� ������ 
            for (int k=0, j = element - 1; shift >= 0; j = blockSumm + (--shift), k++)
            {
                if ((min > graph[j].distance) && (graph[j].SecondElementIndex != exceptedElement) && (graph[j].FirstElementIndex != exceptedElement))
                {
                    min = graph[j].distance;
                }
                blockSumm += BlockLength(k,elementsPower);
            }

            int ourBlockLength = BlockLength(element,elementsPower);//��������� ����� �����
            for (int k = blockBegining; k < blockBegining + ourBlockLength; k++)//������� ����� �� ������ �� �����
            {
                if ((min > graph[k].distance) && (graph[k].SecondElementIndex != exceptedElement) && (graph[k].FirstElementIndex != exceptedElement))
                {
                    min = graph[k].distance;
                }
            }
            return min;
        }

        private int BlockLength(int element, int power)
        {
            return power - (element + 1);
        }
    }
}
