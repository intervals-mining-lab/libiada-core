using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    /// <summary>
    /// Абстрактный класс в который вынесен общий 
    /// для всех бинарных калькуляторов 
    /// метод вычисления всех зависимостей цепочки
    /// </summary>
    public abstract class BinaryCharacteristicCalculator:IBinaryCharacteristicCalculator
    {
        /// <summary>
        /// Метод вычисления характеристики для пары элементов.
        /// </summary>
        /// <param name="chain">Последовательность</param>
        /// <param name="firstElement">Первый элемент</param>
        /// <param name="secondElement">Второй элемент</param>
        /// <param name="linkUp">Привязка</param>
        /// <returns>Значение характеристики</returns>
        public abstract double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp);

        /// <summary>
        /// Метод возвращает полную матрицу характеристик для всех пар элементов цепи.
        /// </summary>
        /// <param name="chain">Последовательность</param>
        /// <param name="linkUp">Привязка</param>
        /// <returns>Квадратная матрица значений характеристики</returns>
        public List<List<double>> Calculate(Chain chain, LinkUp linkUp)
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.Power; j++)
                {
                    result[i].Add(Calculate(chain, chain.Alphabet[i], chain.Alphabet[j], linkUp));
                }
            }
            return result;
        }

        public abstract BinaryCharacteristicsEnum GetCharacteristicName();
    }
}