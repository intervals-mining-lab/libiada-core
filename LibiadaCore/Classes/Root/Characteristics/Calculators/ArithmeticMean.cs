namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднее арифметическое значение длин интервалов.
    ///</summary>
    public class ArithmeticMean : ICalculator
    {
        /// <summary>
        /// Для однородной цепи данная характеристика 
        /// вычисляется как сумма длин всех интервалов делёное на количество интервалов.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            IntervalsSum sumator = new IntervalsSum();
            double sum = sumator.Calculate(chain, linkUp);
            IntervalsCount counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain,linkUp);
            return sum/intervalsCount;
        }

        ///<summary>
        /// Вычисляется как среднее значение от среднего интервала однородных цепей
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            IntervalsSum sumator = new IntervalsSum();
            double sum = sumator.Calculate(chain, linkUp);
            IntervalsCount counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain, linkUp);
            return sum / intervalsCount;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}