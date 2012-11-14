using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class BinaryGeometricMean : IBinaryCharacteristicCalculator
    {
        /// <summary>
        /// Среднегеометрический интервал 
        /// между двумя компонентами бинарно-однородной цепи
        /// </summary>
        /// <param name="chain">Цепочка</param>
        /// <param name="firstElement">Первый элемент</param>
        /// <param name="secondElement">Второй элемент</param>
        /// <param name="linkUp">Привязка</param>
        /// <returns>Среднегеометрический интервал</returns>
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            //зависимость компонента от самого себя равна нулю
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            //число вхождений первого компонента
            int firstElementCount = (int)chain.UniformChain(firstElement).GetCharacteristic(linkUp, new Count());
            //вычисляем логариф произведения интервалов между элементами
            double intervals = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = chain.GetBinaryInterval(firstElement, secondElement, i);
                if (binaryInterval > 0)
                {
                    intervals += Math.Log(binaryInterval, 2);
                }
            }
            //получаем количество пар
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            //
            return Math.Pow(2, pairs == 0 ? 0 : intervals / pairs);
        }

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

        public BinaryCharacteristicsEnum GetCharacteristicName()
        {
            throw new System.NotImplementedException();
        }
    }
}