using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Число возможных цепочек которые можно сгенерировать 
    /// из данной цепочки, содержащей фантомные сообщения.
    ///</summary>
    public class PhantomMessagesCount : ICalculator
    {
        public double Calculate(CongenericChain chain, Link link)
        {
            int count = 1;
            for(int i=0;i<chain.Length;i++)
            {
                var j = chain[i] as ValuePhantom;
                if(j!=null)
                {
                    count *= ((ValuePhantom)chain[i]).Power;
                }
            }
            return count;
        }

        public double Calculate(Chain chain, Link link)
        {
            int count = 1;
            for (int i = 0; i < chain.Length; i++)
            {
                var j = chain[i] as ValuePhantom;
                if(j!=null)
                {
                    count *= ((ValuePhantom)chain[i]).Power;
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
