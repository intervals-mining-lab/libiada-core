namespace Clusterizator.Classes.AlternativeClusterization
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Класс хранящий граф и список его вершин,
    /// а также оперирующий с этими вершинами
    /// </summary>
    public class GraphManager
    {
        /// <summary>
        /// Граф
        /// </summary>
        public readonly List<Connection> Connections;

        /// <summary>
        /// Список вершин
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
        /// Метод соединяющий две вершины
        /// </summary>
        /// <param name="index1">
        /// Индекс первой вершины
        /// </param>
        /// <param name="index2">
        /// Индекс второй вершины
        /// </param>
        public void Connect(int index1, int index2)
        {
            // если вершины уже в одном таксоне
            if ((Elements[index1].TaxonNumber == Elements[index2].TaxonNumber) && (Elements[index1].TaxonNumber != 0))
            {
                return;
            }

            // если обе не входят ни в один таксон
            if ((Elements[index1].TaxonNumber == 0) && (Elements[index2].TaxonNumber == 0))
            {
                // создаём новый таксон
                Elements[index1].TaxonNumber = GetNextTaxonNumber();
                Elements[index2].TaxonNumber = Elements[index1].TaxonNumber;
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index1].TaxonNumber == 0)
            {
                // если только первый элемент никуда не входит
                // прикрепляем первый элемент к существующему таксону
                Elements[index1].TaxonNumber = Elements[index2].TaxonNumber;
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index2].TaxonNumber == 0)
            {
                // если только второй никуда не входит
                // прикрепляем второй элемент к существующему таксону
                Elements[index2].TaxonNumber = Elements[index1].TaxonNumber;
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index1].TaxonNumber > Elements[index2].TaxonNumber)
            {
                // если первый элемент в таксоне с большим номером
                // перенумеруем таксон первого элемента
                Renumber(index1, Elements[index2].TaxonNumber);
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
            else if (Elements[index2].TaxonNumber > Elements[index1].TaxonNumber)
            {
                // если второй в таксоне с большим номером
                // перенумеруем таксон второго элемента
                Renumber(index2, Elements[index1].TaxonNumber);
                Connections[SearchConnection(index1, index2)].Connected = true;
            }
        }
        
        /// <summary>
        /// Метод ищущий соединение по паре вершин
        /// </summary>
        /// <param name="element1">
        /// Первая вершина
        /// </param>
        /// <param name="element2">
        /// Вторая вершина
        /// </param>
        /// <returns>Соединение пары вершин
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
        /// Метод вычисляющий номер для нового таксона
        /// </summary>
        /// <returns>
        /// Ещё не занятый минимальный номер
        /// </returns>
        public int GetNextTaxonNumber()
        {
            return Elements.Max(i => i.TaxonNumber) + 1;
        }

        /// <summary>
        /// Метод разрывающий связь между парой вершин и 
        /// перенумеровывающий получившиеся таксоны
        /// </summary>
        /// <param name="element1">
        /// Первая вершина
        /// </param>
        /// <param name="element2">
        /// Вторая вершина
        /// </param>
        public void Cut(GraphElement element1, GraphElement element2)
        {
            Connection connection = Connections[SearchConnection(element1, element2)];
            Cut(connection);
        }

        /// <summary>
        /// Метод разрывает связь между указанной парой вершин и 
        /// перенумеровывает получившиеся таксоны
        /// </summary>
        /// <param name="connection">
        /// Пара вершин
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
        /// Метод возвращает копию объекта
        /// </summary>
        /// <returns>
        /// копия графа
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
        /// Метод строит кратчайший незамкнутый путь (КНП)
        /// </summary>
        public void ConnectGraph()
        {
            for (int i = 0; i < Elements.Count - 1; i++)
            {
                var minDistance = double.MaxValue;
                int pointNumber = -1;

                // поиск кратчайшего ребра доступного для соединения
                for (int j = 0; j < Connections.Count; j++)
                {
                    // проверка на то что вершины не принадлежат одному графу
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
        /// Метод рекурсивно перенумерующий связанные вершины графа
        /// </summary>
        /// <param name="index">
        /// Номер элемента для перенумерования
        /// </param>
        /// <param name="newNumber">
        /// Новый номер таксона
        /// </param>
        private void Renumber(int index, int newNumber)
        {
            // меняем таксон текушего элемента
            Elements[index].TaxonNumber = newNumber;
            for (int i = 0; i < Connections.Count; i++)
            {
                // для всех соединённых пар вершин
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
        /// Метод поиска соединения по индексам вершин
        /// </summary>
        /// <param name="index1">
        /// индекс первого элемента
        /// </param>
        /// <param name="index2">
        /// индекс второго элемента
        /// </param>
        /// <returns></returns>
        private int SearchConnection(int index1, int index2)
        {
            return SearchConnection(Elements[index1], Elements[index2]);
        }
    }
}