namespace Clusterizator.Krab
{
    using System;

    /// <summary>
    /// Класс-контейнер хранящий пару точек и различные расстояния между ними 
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="firstElement">
        /// Индекс первого объекта.
        /// </param>
        /// <param name="secondElement">
        /// Индекс второго объекта.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if element or elements are negative.
        /// </exception>
        public Connection(int firstElement, int secondElement)
        {
            if ((firstElement < 0) || (secondElement < 0))
            {
                throw new ArgumentException("Индекс не может быть отрицательным");
            }

            Connected = false;
            FirstElementIndex = firstElement;
            SecondElementIndex = secondElement;
        }

        /// <summary>
        /// Gets or sets a value indicating whether pair of points connected or not..
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// Евклидово расстояние.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Нормированное Эвклидово расстояние.
        /// </summary>
        public double NormalizedDistance { get; set; }

        /// <summary>
        /// Локальная плотность точек.
        /// </summary>
        public double TauStar { get; set; }

        /// <summary>
        /// Нормированная локальная плотность точек.
        /// </summary>
        public double Tau { get; set; }

        /// <summary>
        /// Gets or sets the lambda distance.
        /// </summary>
        public double Lambda { get; set; }

        /// <summary>
        /// Gets index of first point.
        /// </summary>
        public int FirstElementIndex { get; private set; }

        /// <summary>
        /// Gets index of second point.
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
            var clone = new Connection(FirstElementIndex, SecondElementIndex)
                {
                    Connected = Connected, 
                    Distance = Distance, 
                    NormalizedDistance = NormalizedDistance, 
                    TauStar = TauStar, 
                    Tau = Tau, 
                    Lambda = Lambda
                };
            return clone;
        }
    }
}
