using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
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
        /// Для неоднородной цепи это её длина.
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
            IDataForCalculator datа = pChain;
            return datа.CommonIntervals.Count + datа.StartInterval.Count;
        }
    }
}