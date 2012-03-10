using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Среднее арифметическое значение длин интервалов.
    ///</summary>
    public class ArithmeticMean : ICharacteristicCalculator
    {
        /// <summary>
        /// Для однородной цепи данная характеристика 
        /// вычисляется как 1/вероятность или чеастоту её элемента.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain chain, LinkUp Link)
        {
            double n = chain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);
            double n_j = chain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.n);
            double result = n/n_j;
            return result;
        }

        ///<summary>
        /// Вычисляется как среднее значение от среднего интервала однородных цепей
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            IChainDataForCalculaton Data = pChain;
            double sum = 0;
            for (int i = 0; i < pChain.Alpahbet.power; i++)
            {
                sum += Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.deltaA);
            }
            return sum/pChain.Alpahbet.power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}