namespace LibiadaCore.Classes.Root.Characteristics
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;

    public class BinaryCalculatorsFactory
    {
        /// <summary>
        /// Среднегеометрическая удалённость между парой элементов.
        /// </summary>
        public static IBinaryCalculator GeometricMean
        {
            get { return new BinaryGeometricMean(); }
        }

        /// <summary>
        /// Избыточность кодировки второго элемента относительно себя
        /// по сравнению с кодированием относително первого элемента.
        /// </summary>
        public static IBinaryCalculator Redundancy
        {
            get { return new Redundancy(); }
        }

        /// <summary>
        /// Коэффициент частичной зависимости.
        /// </summary>
        public static IBinaryCalculator K1
        {
            get { return new PartialDependenceCoefficient(); }
        }

        /// <summary>
        /// Нормализованный коэффициент частичной зависимости.
        /// </summary>
        public static IBinaryCalculator NormalizedK1
        {
            get { return new NormalizedPartialDependenceCoefficient(); }
        }

        /// <summary>
        /// Степень зависимости одной цепи от другой, 
        /// с учетом «полноты её участия» в составе обеих однородных цепей.
        /// </summary>
        public static IBinaryCalculator K2
        {
            get { return new InvolvedPartialDependenceCoefficient(); }
        }

        /// <summary>
        /// Коэффициент взаимной зависимости.
        /// </summary>
        public static IBinaryCalculator K3
        {
            get { return new MutualDependenceCoefficient(); }
        }

        

        /// <summary>
        /// Список калькуляторов характеристик.
        /// </summary>
        public static List<IBinaryCalculator> List
        {
            get
            {
                var temp = new List<IBinaryCalculator> {GeometricMean, Redundancy, K1, NormalizedK1, K2, K3};

                return temp;
            }
        }

        /// <summary>
        /// Создаёт калькулятор с заданным именем.
        /// </summary>
        ///<param name="type">Имя класса или путь в пространстве имён</param>
        ///<returns>Калькулатор бинарной характеристики</returns>
        public static IBinaryCalculator Create(string type)
        {
            foreach (IBinaryCalculator calculator in List)
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