using System;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    /// Количество идентифицирующих информаций приходящихся на одно значащее сообщение.
    /// Энтропия, количество информации.
    ///</summary>
    public class IdentificationInformation : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return Math.Log(pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA), 2);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            IChainDataForCalculaton Data = pChain;
            double temp = 0;
            for (int i = 0; i < pChain.Alpahbet.power; i++)
            {
                double P = Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.P);
                double da =
                    Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.deltaA);
                temp += P*Math.Log(da, 2);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Entropy;
        }
    }
}