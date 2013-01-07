using System;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.Statistics;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Глубина
    ///</summary>
    public class Depth : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            IDataForCalculator Data = pChain;

            FrequencyList CommonIntervaList = Data.CommonIntervals;
            FrequencyList StartInterval = Data.StartInterval;
            FrequencyList EndInterval = Data.EndInterval;

            double result = 0;
            for (int i = 0; i < CommonIntervaList.Power; i++)
            {
                result += (ValueInt) CommonIntervaList[i].Value*Math.Log((ValueInt) CommonIntervaList[i].Key, 2);
            }

            switch (Link)
            {
                case LinkUp.Start:
                    return result + Math.Log((ValueInt) StartInterval[0].Key, 2);
                case LinkUp.End:
                    return result + Math.Log((ValueInt) EndInterval[0].Key, 2);
                case LinkUp.Both:
                    return
                        result + Math.Log((ValueInt) StartInterval[0].Key, 2) +
                        Math.Log((ValueInt) EndInterval[0].Key, 2);
                default:
                    throw new Exception("Неизвестная привязка");
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
            double temp = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                temp += Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.G);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Depth;
        }
    }
}