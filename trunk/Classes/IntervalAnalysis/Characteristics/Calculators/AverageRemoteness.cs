using System;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    /// Среднегеометрическая удалённость,
    /// логарифм по основанию 2 от среднегеометрического интервала.
    ///</summary>
    public class AverageRemoteness : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return Math.Log(pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG), 2);
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            // return CommonCalculate(pChain, Link);
            IChainDataForCalculaton Data = pChain;
            double temp = 0;
            double n = pChain.GetCharacteristic(Link, CharacteristicsFactory.IntervalsCount);
            for (int i = 0; i < pChain.Alpahbet.power; i++)
            {
                double Uniformdg =
                    Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.deltaG);
                double n_j =
                    Data.IUniformChain(i).GetCharacteristic(Link,
                                                            CharacteristicsFactory.IntervalsCount);
                temp += n_j/n*Math.Log(Uniformdg, 2);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverangeRemoteness;
        }
    }
}