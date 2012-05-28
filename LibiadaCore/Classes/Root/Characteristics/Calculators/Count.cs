using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Количество элементов.
    ///</summary>
    public class Count : ICharacteristicCalculator
    {
        /// <summary>
        /// Для однородной цепи это количество 
        /// непустых элементов.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain);
        }

        /// <summary>
        /// Для полной неоднородной цепи это её длина.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Count;
        }

        private double CommonCalculate(ChainWithCharacteristic pChain)
        {
            IDataForCalculator data = pChain;
            return data.CommonIntervals.Count + data.StartInterval.Count;
        }
    }
}