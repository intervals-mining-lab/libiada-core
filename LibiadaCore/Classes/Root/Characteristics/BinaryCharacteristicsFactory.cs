using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    public class BinaryCharacteristicsFactory
    {
        ///<summary>
        /// Среднегеометрическая удалённость между парой элементов.
        ///</summary>
        public static IBinaryCharacteristicCalculator GeometricMean
        {
            get { return new BinaryGeometricMean(); }
        }

        ///<summary>
        /// Избыточность кодировки второго элемента относительно себя
        /// по сравнению с кодированием относително первого элемента.
        ///</summary>
        public static IBinaryCharacteristicCalculator Redundancy
        {
            get { return new Redundancy(); }
        }

        ///<summary>
        /// Коэффициент частичной зависимости.
        ///</summary>
        public static IBinaryCharacteristicCalculator K1
        {
            get { return new PartialDependenceCoefficient(); }
        }

        ///<summary>
        /// Степень зависимости одной цепи от другой, 
        /// с учетом «полноты её участия» в составе обеих однородных цепей.
        ///</summary>
        public static IBinaryCharacteristicCalculator K2
        {
            get { return new InvolvedPartialDependenceCoefficient(); }
        }

        ///<summary>
        /// Коэффициент взаимной зависимости.
        ///</summary>
        public static IBinaryCharacteristicCalculator K3
        {
            get { return new MutualDependenceCoefficient(); }
        }

        

        ///<summary>
        /// Список калькуляторов характеристик.
        ///</summary>
        public static List<IBinaryCharacteristicCalculator> List
        {
            get
            {
                var temp = new List<IBinaryCharacteristicCalculator>();

                temp.Add(GeometricMean);
                temp.Add(Redundancy);
                temp.Add(K1);
                temp.Add(K2);
                temp.Add(K3);
                return temp;
            }
        }

        ///<summary>
        /// Создаёт калькулятор с заданным именем.
        ///</summary>
        ///<param name="type">Имя класса или путь в пространстве имён</param>
        ///<returns>Калькулатор бинарной характеристики</returns>
        public static IBinaryCharacteristicCalculator Create(string type)
        {
            foreach (IBinaryCharacteristicCalculator calculator in List)
            {
                if ((type == calculator.GetType().ToString()) ||
                    ("LibiadaCore.Classes.Root.Characteristics.BinaryCalculators." + type == calculator.GetType().ToString()))
                {
                    return calculator;
                }
            }
            return null;
        } 
    }
}