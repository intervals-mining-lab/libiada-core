using System;

namespace Clusterizator.Krab
{
    /// <summary>
    /// Класс-контейнер хранящий пару точек и различные расстояния между ними 
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="element1">
        /// Индекс первого объекта
        /// </param>
        /// <param name="element2">
        /// Индекс второго объекта
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if element or elements are ntgative.
        /// </exception>
        public Connection(int element1, int element2)
        {
            if ((element1 < 0) || (element2 < 0))
            {
                throw new ArgumentException("Индекс не может быть отрицательным");
            }

            Connected = false;
            this.FirstElementIndex = element1;
            this.SecondElementIndex = element2;
        }

        /// <summary>
        /// Характеризует соединена ли данная пара точек
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// Евклидово расстояние
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Нормированное Эвклидово расстояние
        /// </summary>
        public double NormalizedDistance { get; set; }

        /// <summary>
        /// Локальная плотность точек
        /// </summary>
        public double TauStar { get; set; }

        /// <summary>
        /// Нормированная локальная плотность точек
        /// </summary>
        public double Tau { get; set; }

        /// <summary>
        /// Лямбда-расстояние
        /// </summary>
        public double Lambda { get; set; }

        /// <summary>
        /// Индекс первой точки
        /// </summary>
        public int FirstElementIndex { get; private set; }

        /// <summary>
        /// Индекс второй точки
        /// </summary>
        public int SecondElementIndex { get; private set; }

        /// <summary>
        /// Метод возвращает копию объекта
        /// </summary>
        /// <returns>
        /// копия соединения
        /// </returns>
        public Connection Clone()
        {
            var clone = new Connection(this.FirstElementIndex, this.SecondElementIndex)
                {
                    Connected = Connected, 
                    Distance = Distance, 
                    NormalizedDistance = NormalizedDistance, 
                    TauStar = TauStar, 
                    Tau = Tau, 
                    Lambda = this.Lambda
                };
            return clone;
        }
    }
}