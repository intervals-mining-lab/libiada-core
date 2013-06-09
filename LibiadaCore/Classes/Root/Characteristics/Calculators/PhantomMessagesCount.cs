using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Число возможных цепочек которые можно сгенерировать 
    /// из данной цепочки, содержащей фантомные сообщения.
    ///</summary>
    public class PhantomMessagesCount : ICharacteristicCalculator
    {
        public double Calculate(UniformChain chain, LinkUp Link)
        {
            int count = 1;
            for(int i=0;i<chain.Length;i++)
            {
                ValuePhantom j = chain[i] as ValuePhantom;
                if(j!=null)
                {
                    count *= ((ValuePhantom)chain[i]).Power;
                }
            }
            return count;
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            int count = 1;
            for (int i = 0; i < pChain.Length; i++)
            {
                ValuePhantom j = pChain[i] as ValuePhantom;
                if(j!=null)
                {
                    count *= ((ValuePhantom)pChain[i]).Power;
                }
            }
            return count;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.PhantomMessageCount;
        }
    }
}
