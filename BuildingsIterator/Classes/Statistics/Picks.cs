using System.Collections.Generic;
using BuildingsIterator.Classes.Statistics.Calculators;

namespace BuildingsIterator.Classes.Statistics
{
    ///<summary>
    /// Класс выборки
    ///</summary>
    public class Picks
    {
        private List<double> values;
        private string name;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Picks(string name)
        {
            this.name = name;
            values = new List<double>();
        }

        ///<summary>
        /// Добавляет очередной элемент к выборке
        ///</summary>
        ///<param name="value">Значение добавляемого элемента</param>
        public void Add(double value)
        {
            values.Add(value);
        }

        ///<summary>
        /// Название характеристики выборки
        ///</summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        ///<summary>
        /// Заполняет массив строковых значений выборки
        ///</summary>
        ///<param name="mass">Заполняемый массив</param>
        public void FillList(List<string> mass)
        {
            List<double>.Enumerator iter = values.GetEnumerator();
            while (iter.MoveNext())
            {
                mass.Add(iter.Current.ToString());
            }
        }

        /// <summary>
        /// Возвращает заданную характеристику выборки
        /// </summary>
        /// <param name="calculator">Калькулятор вычисляющий характеристику</param>
        /// <returns>Значение характеристики</returns>
        public double GetPicksCharacterisic(IOnePicksCalculator calculator)
        {
            return calculator.Calculate(values);
        }
    }
}