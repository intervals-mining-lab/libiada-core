using System;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Число описательных информаций.
    ///</summary>
    public class DescriptiveInformation : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            double P = pChain.GetCharacteristic(Link, CharacteristicsFactory.P);
            double Result = Math.Pow(pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA), P);
            //Если вся цепь заполнена одинаковыми сообщениями
            //то вероятность равна 1 и считать описательные информации не имеет смысла.
            if (1!=P)
            {
                double P_1 = 1 - P;
                double A_1 = 1 / P_1;
                Result *= Math.Pow(A_1, P_1);
            }
            return Result;
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
                double D = Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.deltaA);
                double P = Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.P);
                temp *= Math.Pow(D,P) ;
            }
            double P_sum = pChain.GetCharacteristic(Link, CharacteristicsFactory.P);
            if (1!= P_sum)
            {
                temp *= Math.Pow(1 / (1 - P_sum), 1 - P_sum);
            }
            return temp;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.DescriptiveInformation;
        }
    }
}