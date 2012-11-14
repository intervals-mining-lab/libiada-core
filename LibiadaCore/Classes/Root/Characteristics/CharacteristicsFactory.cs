using System.Collections;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics
{
    ///<summary>
    /// Статическая фабрика различных калькуляторов.
    ///</summary>
    public static class CharacteristicsFactory
    {

        ///<summary>
        /// Вероятность (частота).
        ///</summary>
        public static ICharacteristicCalculator P
        {
            get { return new Probability(); }
        }

        ///<summary>
        /// Количество интервалов в зависимости от привязки.
        ///</summary>
        public static ICharacteristicCalculator IntervalsCount
        {
            get { return new IntervalsCount(); }
        }

        ///<summary>
        /// Длина обрезания по Садовскому.
        ///</summary>
        public static ICharacteristicCalculator CutLength
        {
            get { return new CutLength(); }
        }

        ///<summary>
        /// Удалённость.
        ///</summary>
        public static ICharacteristicCalculator G
        {
            get { return new Depth(); }
        }

        ///<summary>
        /// Количество элементов.
        /// Для однородной цепи это количество 
        /// непустых элементов.
        /// Для неоднородной цепи это её длина.
        ///</summary>
        public static ICharacteristicCalculator n
        {
            get { return new Count(); }
        }

        ///<summary>
        /// Среднегеометрический интервал.
        ///</summary>
        public static ICharacteristicCalculator deltaG
        {
            get { return new GeometricMean(); }
        }

        ///<summary>
        /// Длинна как сумма длин интервалов.
        ///</summary>
        public static ICharacteristicCalculator Length
        {
            get { return new Length(); }
        }

        ///<summary>
        /// Среднее арифметическое значение длин интервалов.
        ///</summary>
        public static ICharacteristicCalculator deltaA
        {
            get { return new ArithmeticMean(); }
        }

        ///<summary>
        /// Число описательных информаций.
        ///</summary>
        public static ICharacteristicCalculator D
        {
            get { return new DescriptiveInformation(); }
        }

        ///<summary>
        /// Регулярность.
        ///</summary>
        public static ICharacteristicCalculator r
        {
            get { return new Regularity(); }
        }

        ///<summary>
        /// Среднегеометрическая удалённость.
        ///</summary>
        public static ICharacteristicCalculator g
        {
            get { return new AverageRemoteness(); }
        }

        ///<summary>
        /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
        /// Энтропия, количество информации.
        ///</summary>
        public static ICharacteristicCalculator H
        {
            get { return new IdentificationInformation(); }
        }

        ///<summary>
        /// Объём цепи. Произведение длин всех её интервалов.
        ///</summary>
        public static ICharacteristicCalculator V
        {
            get { return new Volume(); }
        }

        ///<summary>
        /// Мощность алфавита.
        ///</summary>
        public static ICharacteristicCalculator Power
        {
            get { return new AlphabetPower(); }
        }

        ///<summary>
        /// Удалённость приходящаяся на одно сообщение.
        ///</summary>
        public static ICharacteristicCalculator nG
        {
            get { return new NormalizedGamut(); }
        }


        ///<summary>
        /// Периодичность.
        ///</summary>
        public static ICharacteristicCalculator t
        {
            get { return new Periodicity(); }
        }

        ///<summary>
        /// Энтропия словаря по Садовскому.
        ///</summary>
        public static ICharacteristicCalculator CutLenVocEntropy
        {
            get { return new CutLengthVocabularyEntropy(); }
        }

        ///<summary>
        /// Список калькуляторов характеристик.
        ///</summary>
        public static ArrayList List
        {
            get
            {
                ArrayList temp = new ArrayList();

                temp.Add(D);
                temp.Add(deltaA);
                temp.Add(deltaG);
                temp.Add(g);
                temp.Add(G);
                temp.Add(H);
                temp.Add(IntervalsCount);
                temp.Add(Length);
                temp.Add(n);
                temp.Add(P);
                temp.Add(r);
                temp.Add(Power);
                temp.Add(nG);
                temp.Add(t);
                //temp.Add(PhChainCount);
                //temp.Add(CutLength);
                //temp.Add(V);
                //temp.Add(CutLenVocEntropy);
                return temp;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        ///<returns></returns>
        public static ICharacteristicCalculator Create(string type)
        {
            foreach (ICharacteristicCalculator calculator in List)
            {
                if ((type == calculator.GetType().ToString()) ||
                    ("LibiadaCore.Classes.Root.Characteristics.Calculators." + type == calculator.GetType().ToString()))
                {
                    return calculator;
                }
            }
            return null;
        }
    }
}