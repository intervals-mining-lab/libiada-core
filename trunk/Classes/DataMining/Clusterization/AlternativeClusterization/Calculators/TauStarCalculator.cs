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
            double min=double.MaxValue;
            for (int i = 0; i < graph.Count; i++)
            {
                bool FirstFirst = graph[i].FirstElementIndex == firstElement;
                bool FirstSecond = graph[i].FirstElementIndex == secondElement;
                bool SecondFirst = graph[i].SecondElementIndex == firstElement;
                bool SecondSecond = graph[i].SecondElementIndex == secondElement;
                //��������� ���� �� � ���� ���� �� ���� �� ��������� ����� 
                //� ��� ���� �� �������� ��� ����� ������������
                if (((FirstFirst)||(FirstSecond)||(SecondFirst)||(SecondSecond))&&!((FirstFirst)&&(SecondSecond))&&!((SecondFirst)&&(FirstSecond)))
                {
                    if (min > graph[i].distance)
                    {
                        min = graph[i].distance;
                    } 
                }   
            }
            return min;
        }
    }
}