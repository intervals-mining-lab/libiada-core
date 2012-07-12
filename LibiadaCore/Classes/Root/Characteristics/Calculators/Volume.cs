using System;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Statistics;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Объём цепи. Произведение длин всех её интервалов.
    ///</summary>
    public class Volume : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            IDataForCalculator Data = pChain;

            FrequencyList CommonIntervaList = Data.CommonIntervals;
            FrequencyList StartInterval = Data.StartInterval;
            FrequencyList EndInterval = Data.EndInterval;

            double result = 1;
            for (int i = 0; i < CommonIntervaList.Power; i++)
            {
                result =  result * Math.Pow((ValueInt)CommonIntervaList[i].Key, (ValueInt)CommonIntervaList[i].Value);
            }

            switch (Link)
            {
                case LinkUp.Start:
                    return result * (ValueInt)StartInterval[0].Key;
                case LinkUp.End:
                    return result * (ValueInt)EndInterval[0].Key;
                case LinkUp.Both:
                    return
                        result * (ValueInt)StartInterval[0].Key * (ValueInt)EndInterval[0].Key;
                default:
                    throw new Exception("Супер странная ошибка :)");
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            IChainDataForCalculaton Data = pChain;
            double temp = 1;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp = temp * Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.V);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Volume;
        }
    }
}