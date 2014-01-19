using System;

namespace Clusterizator.Classes.AlternativeClusterization
{
    ///<summary>
    ///Класс-контейнер хранящий пару точек и различные расстояния между ними 
    ///</summary>
    public class Connection
    {
        ///<summary>
        /// Характеризует соединена ли данная пара точек
        ///</summary>
        public bool Connected;
        /// <summary>
        /// Евклидово расстояние
        /// </summary>
        public double Distance = double.NaN;
        /// <summary>
        /// Нормированное Эвклидово расстояние
        /// </summary>
        public double NormalizedDistance = double.NaN;
        /// <summary>
        /// Локальная плотность точек
        /// </summary>
        public double TauStar = double.NaN;
        /// <summary>
        /// Нормированная локальная плотность точек
        /// </summary>
        public double Tau = double.NaN;
        /// <summary>
        /// Лямбда-расстояние
        /// </summary>
        public double lambda = double.NaN;
        private readonly int firstElementIndex;
        private readonly int secondElementIndex;


        /// <summary>
        /// Индекс первой точки
        /// </summary>
        public int FirstElementIndex
        {
            get
            {
                return firstElementIndex;
            }
        }

        /// <summary>
        /// Индекс второй точки
        /// </summary>
        public int SecondElementIndex
        {
            get
            {
                return secondElementIndex;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="element1">Индекс первого объекта</param>
        /// <param name="element2">Индекс второго объекта</param>
        public Connection(int element1, int element2)
        {
            if ((element1<0)||(element2<0))
            {
                throw new Exception("Индекс не может быть отрицательным");
            }
            Connected = false;
            firstElementIndex = element1;
            secondElementIndex = element2;
        }

        ///<summary>
        /// Метод возвращает копию объекта
        ///</summary>
        ///<returns>копия соединения</returns>
        public Connection Clone()
        {
            var clone = new Connection(firstElementIndex,secondElementIndex)
                {
                    Connected = Connected,
                    Distance = Distance,
                    NormalizedDistance = NormalizedDistance,
                    TauStar = TauStar,
                    Tau = Tau,
                    lambda = lambda
                };
            return clone;
        }
    }
}