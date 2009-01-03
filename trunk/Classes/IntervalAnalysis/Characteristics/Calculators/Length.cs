using System;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;
using ChainAnalises.Classes.Root.SimpleTypes;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class Length : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            switch(Link)
            {
                case LinkUp.Start:
                    IDataForCalculator tempStart = pChain;
                    return pChain.Length - ((ValueInt)tempStart.EndInterval.Keys[0]) + 1;
                case LinkUp.End:
                    IDataForCalculator tempEnd = pChain;
                    return pChain.Length - ((ValueInt)tempEnd.StartInterval.Keys[0]) + 1;
                case LinkUp.Both:
                    return pChain.Length;
                default: throw new Exception();
            }
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return pChain.Length;
        }
    }
}