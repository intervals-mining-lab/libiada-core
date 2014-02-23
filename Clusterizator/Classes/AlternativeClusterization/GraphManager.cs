namespace Clusterizator.Classes.AlternativeClusterization
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ����� �������� ���� � ������ ��� ������,
    /// � ����� ����������� � ����� ���������
    /// </summary>
    public class GraphManager
    {
        /// <summary>
        /// ����
        /// </summary>
        public readonly List<Connection> Connections;

        /// <summary>
        /// ������ ������
        /// </summary>
        public readonly List<GraphElement> Elements;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphManager"/> class.
        /// </summary>
        /// <param name="connections">
        /// The connections.
        /// </param>
        /// <param name="elements">
        /// The elements.
        /// </param>
        public GraphManager(List<Connection> connections, List<GraphElement> elements)
        {
            Connections = connections;
            Elements = elements;
        }

        /// <summary>
        /// ����� ����������� ��� �������
        /// </summary>
        /// <param name="index1">
        /// ������ ������ �������
        /// </param>
        /// <param name="index2">
        /// ������ ������ �������
        /// </param>
        public void Connect(int index1, int index2)
        {
            // ���� ������� ��� � ����� �������
            if ((Elements[index1].TaxonNumber == Elements[index2].TaxonNumber) && (Elements[index1].TaxonNumber != 0))
            {
                return;
            }

            // ���� ��� �� ������ �� � ���� ������
            if ((Elements[index1].TaxonNumber == 0) && (Elements[index2].TaxonNumber == 0))
            {
                // ������ ����� ������
                Elements[index1].TaxonNumber = GetNextTaxonNumber();
                Elements[index2].TaxonNumber = Elements[index1].TaxonNumber;
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index1].TaxonNumber == 0)
            {
                // ���� ������ ������ ������� ������ �� ������
                // ����������� ������ ������� � ������������� �������
                Elements[index1].TaxonNumber = Elements[index2].TaxonNumber;
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index2].TaxonNumber == 0)
            {
                // ���� ������ ������ ������ �� ������
                // ����������� ������ ������� � ������������� �������
                Elements[index2].TaxonNumber = Elements[index1].TaxonNumber;
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index1].TaxonNumber > Elements[index2].TaxonNumber)
            {
                // ���� ������ ������� � ������� � ������� �������
                // ������������ ������ ������� ��������
                Renumber(index1, Elements[index2].TaxonNumber);
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index2].TaxonNumber > Elements[index1].TaxonNumber)
            {
                // ���� ������ � ������� � ������� �������
                // ������������ ������ ������� ��������
                Renumber(index2, Elements[index1].TaxonNumber);
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
        }
        
        /// <summary>
        /// ����� ������ ���������� �� ���� ������
        /// </summary>
        /// <param name="element1">
        /// ������ �������
        /// </param>
        /// <param name="element2">
        /// ������ �������
        /// </param>
        /// <returns>���������� ���� ������
        /// </returns>
        public int SearchConnection(GraphElement element1, GraphElement element2)
        {
            for (int i = 0; i < Connections.Count; i++)
            {
                bool normalOrder = element1.Id.Equals(Elements[Connections[i].FirstElementIndex].Id) &&
                                   element2.Id.Equals(Elements[Connections[i].SecondElementIndex].Id);

                bool inverseOrder = element2.Id.Equals(Elements[Connections[i].FirstElementIndex].Id) &&
                                    element1.Id.Equals(Elements[Connections[i].SecondElementIndex].Id);
                if (normalOrder || inverseOrder)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// ����� ����������� ����� ��� ������ �������
        /// </summary>
        /// <returns>
        /// ��� �� ������� ����������� �����
        /// </returns>
        public int GetNextTaxonNumber()
        {
            return Elements.Max(i => i.TaxonNumber) + 1;
        }

        /// <summary>
        /// ����� ����������� ����� ����� ����� ������ � 
        /// ������������������ ������������ �������
        /// </summary>
        /// <param name="element1">
        /// ������ �������
        /// </param>
        /// <param name="element2">
        /// ������ �������
        /// </param>
        public void Cut(GraphElement element1, GraphElement element2)
        {
            Connection connection = Connections[SearchConnection(element1, element2)];
            Cut(connection);
        }

        /// <summary>
        /// ����� ��������� ����� ����� ��������� ����� ������ � 
        /// ���������������� ������������ �������
        /// </summary>
        /// <param name="connection">
        /// ���� ������
        /// </param>
        public void Cut(Connection connection)
        {
            if (!connection.Connected)
            {
                return;
            }

            connection.Connected = false;
            Renumber(connection.FirstElementIndex, GetNextTaxonNumber());
        }

        /// <summary>
        /// ����� ���������� ����� �������
        /// </summary>
        /// <returns>
        /// ����� �����
        /// </returns>
        public GraphManager Clone()
        {
            var tempConnections = new List<Connection>();
            var tempGraphElements = new List<GraphElement>();
            for (int i = 0; i < Connections.Count; i++)
            {
                tempConnections.Add(Connections[i].Clone());
            }

            for (int j = 0; j < Elements.Count; j++)
            {
                tempGraphElements.Add(Elements[j].Clone());
            }

            return new GraphManager(tempConnections, tempGraphElements);
        }

        /// <summary>
        /// ����� ������ ���������� ����������� ���� (���)
        /// </summary>
        public void ConnectGraph()
        {
            for (int i = 0; i < Elements.Count - 1; i++)
            {
                var minDistance = double.MaxValue;
                int pointNumber = -1;

                // ����� ����������� ����� ���������� ��� ����������
                for (int j = 0; j < Connections.Count; j++)
                {
                    // �������� �� �� ��� ������� �� ����������� ������ �����
                    bool taxonNumberCheck = (Elements[Connections[j].FirstElementIndex].TaxonNumber !=
                                             Elements[Connections[j].SecondElementIndex].TaxonNumber)
                                            || (Elements[Connections[j].FirstElementIndex].TaxonNumber == 0);
                    if ((Connections[j].Lambda < minDistance) && taxonNumberCheck)
                    {
                        minDistance = Connections[j].Lambda;
                        pointNumber = j;
                    }
                }

                Connect(Connections[pointNumber].FirstElementIndex, Connections[pointNumber].SecondElementIndex);
            }
        }

        /// <summary>
        /// ����� ���������� �������������� ��������� ������� �����
        /// </summary>
        /// <param name="index">
        /// ����� �������� ��� ���������������
        /// </param>
        /// <param name="newNumber">
        /// ����� ����� �������
        /// </param>
        private void Renumber(int index, int newNumber)
        {
            // ������ ������ �������� ��������
            Elements[index].TaxonNumber = newNumber;
            for (int i = 0; i < Connections.Count; i++)
            {
                // ��� ���� ���������� ��� ������
                if (Connections[i].Connected)
                {
                    if ((Connections[i].FirstElementIndex == index)
                        && (Elements[Connections[i].SecondElementIndex].TaxonNumber != newNumber))
                    {
                        Renumber(Connections[i].SecondElementIndex, newNumber);
                    }
                    else if ((Connections[i].SecondElementIndex == index) &&
                            (Elements[Connections[i].FirstElementIndex].TaxonNumber != newNumber))
                    {
                        Renumber(Connections[i].FirstElementIndex, newNumber);
                    }
                }
            }
        }

        /// <summary>
        /// ����� ������ ���������� �� �������� ������
        /// </summary>
        /// <param name="index1">
        /// ������ ������� ��������
        /// </param>
        /// <param name="index2">
        /// ������ ������� ��������
        /// </param>
        /// <returns></returns>
        private int SearchConnection(int index1, int index2)
        {
            return SearchConnection(Elements[index1], Elements[index2]);
        }
    }
}