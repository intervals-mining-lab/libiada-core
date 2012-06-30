using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    public class BinaryCharacteristicsFactory
    {
        ///<summary>
        /// Вероятность (частота).
        ///</summary>
        public static IBinaryCharacteristicCalculator GeometricMean
        {
            get { return new BinaryGeometricMean(); }
        }

        ///<summary>
        /// Количество интервалов в зависимости от привязки.
        ///</summary>
        public static IBinaryCharacteristicCalculator Redundancy
        {
            get { return new Redundancy(); }
        }

        ///<summary>
        /// Длина обрезания по Садовскому.
        ///</summary>
        public static IBinaryCharacteristicCalculator K1
        {
            get { return new PartialDependenceCoefficient(); }
        }

        ///<summary>
        /// Удалённость.
        ///</summary>
        public static IBinaryCharacteristicCalculator K2
        {
            get { return new InvolvedPartialDependenceCoefficient(); }
        }

        ///<summary>
        /// Количество элементов.
        /// Для однородной цепи это количество 
        /// непустых элементов.
        /// Для неоднородной цепи это её длина.
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
        ///</summary>
        ///<param name="type"></param>
        ///<returns></returns>
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