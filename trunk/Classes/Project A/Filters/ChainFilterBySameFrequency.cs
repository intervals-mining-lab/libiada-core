using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;

namespace MarkovCompare
{
    ///<summary>
    /// Фильтр отфильтровыва.ший цепи по равенству частот вхождения элементов
    ///</summary>
    public class ChainFilterBySameFrequency : IChainFilter
    {
        public bool IsValid(string building)
        {
            Chain ch = new Chain(building);

            double p = ch.IUniformChain(0).GetCharacteristic(LinkUp.Start, CharacteristicsFactory.P);
            for (int i = 1; i < ch.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.Power); i++)
            {
                if (p != ch.IUniformChain(i).GetCharacteristic(LinkUp.Start, CharacteristicsFactory.P))
                    return false;
            }
            return true;
        }
    }
}