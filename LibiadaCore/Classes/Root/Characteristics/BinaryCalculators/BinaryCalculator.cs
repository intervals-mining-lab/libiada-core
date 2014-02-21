namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using System.Collections.Generic;

    /// <summary>
    /// Абстрактный класс в который вынесен общий 
    /// для всех бинарных калькуляторов 
    /// метод вычисления всех зависимостей цепочки
    /// </summary>
    public abstract class BinaryCalculator : IBinaryCalculator
    {
        /// <summary>
        /// Метод вычисления характеристики для пары элементов.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="firstElement">
        /// Первый элемент
        /// </param>
        /// <param name="secondElement">
        /// Второй элемент
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Значение характеристики
        /// </returns>
        public abstract double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link);

        /// <summary>
        /// Метод возвращает полную матрицу характеристик для всех пар элементов цепи.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Квадратная матрица значений характеристики
        /// </returns>
        public List<List<double>> Calculate(Chain chain, Link link)
        {
            var result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.Cardinality; j++)
                {
                    result[i].Add(Calculate(chain, chain.Alphabet[i], chain.Alphabet[j], link));
                }
            }

            return result;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public abstract BinaryCharacteristicsEnum GetCharacteristicName();
    }
}