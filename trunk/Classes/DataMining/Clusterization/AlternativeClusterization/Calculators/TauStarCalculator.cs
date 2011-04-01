using System;
using System.Collections.Generic;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
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
                graph.Connections[i].tauStar = graph.Connections[i].distance/GetBmin(graph.Connections,graph.Connections[i].FirstElementIndex, graph.Connections[i].SecondElementIndex);
            }
           
        }

        /// <summary>
        /// ��������� ����������� ���������� �� ���� �����,
        /// �.�. ���� ����� �������� ����� ����� ������� ������ ������
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        /// <param name="firstElement">������ �����</param>
        /// <param name="secondElement">������ �����</param>
        /// <returns>Bmin - ����������� ����������</returns>
        private double GetBmin(List<Connection> graph,int firstElement,int secondElement)
        {
            double min = Math.Min(SearchForMinimum(graph, firstElement, secondElement),
                                  SearchForMinimum(graph, secondElement, firstElement));
            return min;
        }

        private double SearchForMinimum(List<Connection> graph,int Element,int ExceptedElement)
        {
            double min = double.MaxValue;//������� ����������� ����������

            int BlockBegining = 0;
            for (int i = 0; i < Element; i++)
            {
                int blockLength = graph.Count - (i + 1);//graph.Count - �������� �������� 
                                                        //��������� ����� �����, ��� �� ������ ����� ����� ���� � ��� �� �������
                BlockBegining += blockLength;//���� ������ ������� ��� �����
            }

            int blockSumm = 0;//����� ���� ���������� ������
            int shift = Element - 1; //����� ������ �����

            //���� �������� ��������� �������� � ������� ��� ������ 
            for (int k=0, j = Element - 1; shift >= 0; j = blockSumm + (--shift), k++)
            {
                if ((min > graph[j].distance) && (graph[j].SecondElementIndex != ExceptedElement) && (graph[j].FirstElementIndex != ExceptedElement))
                {
                    min = graph[j].distance;
                }
                blockSumm += graph.Count - (k + 1);
            }

            int OurBlockLength = graph.Count - (Element + 1);//��������� ����� �����
            for (int k = BlockBegining; k < BlockBegining + OurBlockLength; k++)//������� ����� �� ������ �� �����
            {
                if ((min > graph[k].distance) && (graph[k].SecondElementIndex != ExceptedElement) && (graph[k].FirstElementIndex != ExceptedElement))
                {
                    min = graph[k].distance;
                }
            }
            return min;
        }
    }
}
