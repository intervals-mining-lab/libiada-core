using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class BinaryGeometricMean : BinaryCalculator
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
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            //зависимость компонента от самого себя равна нулю
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            Count count = new Count();
            //число вхождений первого компонента
            int firstElementCount = (int)count.Calculate(chain.UniformChain(firstElement), linkUp);
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
            
            return Math.Pow(2, pairs == 0 ? 0 : intervals / pairs);
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.BinaryGeometricMean;
        }
    }
}