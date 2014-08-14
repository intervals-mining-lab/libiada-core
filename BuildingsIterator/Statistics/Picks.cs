namespace BuildingsIterator.Statistics
{
    using System.Collections.Generic;

    using BuildingsIterator.Statistics.Calculators;

    /// <summary>
    /// Класс выборки
    /// </summary>
    public class Picks
    {
        /// <summary>
        /// The values.
        /// </summary>
        private readonly List<double> values;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Picks"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Picks(string name)
        {
            this.name = name;
            values = new List<double>();
        }

        /// <summary>
        /// Добавляет очередной элемент к выборке
        /// </summary>
        /// <param name="value">Значение добавляемого элемента</param>
        public void Add(double value)
        {
            values.Add(value);
        }

        /// <summary>
        /// Заполняет массив строковых значений выборки
        /// </summary>
        /// <param name="mass">Заполняемый массив</param>
        public void FillList(List<string> mass)
        {
            List<double>.Enumerator iterator = values.GetEnumerator();
            while (iterator.MoveNext())
            {
                mass.Add(iterator.Current.ToString());
            }
        }

        /// <summary>
        /// Возвращает заданную характеристику выборки
        /// </summary>
        /// <param name="calculator">Калькулятор вычисляющий характеристику</param>
        /// <returns>Значение характеристики</returns>
        public double GetPicksCharacteristic(IOnePicksCalculator calculator)
        {
            return calculator.Calculate(values);
        }
    }
}