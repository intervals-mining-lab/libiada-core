using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;

namespace BuildingsIterator.Classes.Filters
{
    ///<summary>
    /// Фильтр отфильтровывающий цепи по равенству частот вхождения элементов
    ///</summary>
    public class ChainFilterBySameFrequency : IChainFilter
    {
        public bool IsValid(string building)
        {
            Chain ch = new Chain(building);

            double p = ch.GetUniformChain(0).GetCharacteristic(LinkUp.Start, CharacteristicsFactory.P);
            for (int i = 1; i < ch.GetCharacteristic(LinkUp.Start, CharacteristicsFactory.Power); i++)
            {
                if (p != ch.GetUniformChain(i).GetCharacteristic(LinkUp.Start, CharacteristicsFactory.P))
                    return false;
            }
            return true;
        }
    }
}