using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;

namespace Segmentation.Classes
{
    public static class Calculator
    {
        //частота слова в тексте (текст должен быть свёрнут по этому слову)
        public static double frequency(Chain chain, Chain accord)
        {
            double counter = 0;

            for(int i=0;i<chain.Length;i++)
            {
                if (chain[i].Equals(accord)) 
                    counter = counter + 1;
            }
            double ans=counter/chain.Length;

            return ans;
        }

        //частота слова в тексте (текст НЕ должен быть свёрнут по этому слову)
        public static double frequency_of_accord(Chain chain, Chain accord)
        {
            double counter = 0;

            IteratorStart<Chain, Chain> it =
                new IteratorStart<Chain, Chain>(chain, accord.Length,1 );
            while (it.Next())
            {
                if (it.Current().Equals(accord))
                {
                    counter = counter + 1;
                    for (int i = 0; i < accord.Length; i++) it.Next();
                }
            }
            double ans=counter/(chain.Length-counter*accord.Length+counter);
            return ans;
        }


        //интервальная оценка (интервалы считаются в единицах "свёрнутой по предыдущим элементам" цепи)
        public static double interval_estimate(Chain chain, Chain accord)
        {
            Chain temp = (Chain)chain.Clone();
            ChainConvolutor cc = new ChainConvolutor();
            temp = cc.Convolute(temp, accord);

            double middle_geometrical_interval = (temp).UniformChain(accord).GetCharacteristic(LinkUp.Both, CharacteristicsFactory.deltaG);
            double answer=1 / middle_geometrical_interval;
            return answer;
        }

        //расчётно-ожидаемая частота
        public static double design_expected_frequency(Chain chain, Chain accord)
        {
            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(accord, accord.Length - 1, 1);
            it.Next();

            double design_expected_frequency = frequency_of_accord(chain, it.Current());
            it.Next();
            design_expected_frequency = design_expected_frequency * frequency_of_accord(chain, it.Current());
            if (accord.Length > 2)
            {
                it = new IteratorStart<Chain, Chain>(accord, accord.Length - 2, 1);
                it.Next();
                it.Next();
                design_expected_frequency = design_expected_frequency / frequency_of_accord(chain, it.Current());
            }
            return design_expected_frequency;
        }
    }
}
