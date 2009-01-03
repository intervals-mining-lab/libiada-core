using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;
using ChainAnalises.Classes.DivizionToAccords.Criteria;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords
{
    public class SimpleDivider
    {
        private readonly Chain chain_for_divizion;
        public Chain convoluted_chain;
        private readonly double balance_factor;
        private readonly int start_length;

        private LinkUp interval_link;
        private Method calc_frecuncy_method;

        /*модификации:
            1 - подсчёт интервалов с привязкой:
         *         - к началу
         *         - к концу
         *         - к обоим
         *  2 - подсчёт частот:
         *         - созвучие является элементом длиной 1
         *         - элементы созвучия считаются как отдельные элементы
         */
        public SimpleDivider(Chain chain, double balance_factor, int start_length, LinkUp interval_link, Method calc_frecuncy_method)
        {
            chain_for_divizion = chain;
            this.balance_factor = balance_factor;
            this.start_length = start_length;
            this.interval_link = interval_link;
            this.calc_frecuncy_method = calc_frecuncy_method;
        }

        private AlphabetChain alphabet = new AlphabetChain();
        //private AlphabetChain badAlphabet = new AlphabetChain();



        public AlphabetChain DivideToAccords(double level)
        {
            convoluted_chain = chain_for_divizion;

            //int act_length = -1;
            ChainConvolutor convolutor = new ChainConvolutor();

            for (int l = start_length; l > 1; l--)//цикл перебирающий длины "окошка"
            {
                bool flag = true;
                while (flag)
                {
                    StdCalculator calc = new StdCalculator();
                    DictionaryEntry? entry =  calc.CalcStds(convoluted_chain,l,calc_frecuncy_method,interval_link,balance_factor,alphabet,level);
                    flag = entry != null;
                    if (flag)
                    {
                        alphabet.Add((Chain)((DictionaryEntry)entry).Key);
                        convoluted_chain = convolutor.Convolute(convoluted_chain, (Chain)((DictionaryEntry)entry).Key, (IDataForStd)((DictionaryEntry)entry).Value);
                    }
                }
            }
            
            //оставшиеся символы загоняем в alphabet
            for (int i = 0; i < convoluted_chain.Length; i++)
            {
                //не работает проверка наличия в алфавите этих цепей
                if (!((convoluted_chain[i]) is Chain))
                {
                    Chain temp = new Chain(1);
                    temp[0] = convoluted_chain[i];
                    if (!alphabet.Contains(temp))
                    {
                        alphabet.Add(temp);
                        convoluted_chain = convolutor.Convolute(convoluted_chain, temp);
                    }
                }
            }
            return alphabet;
        }
    }
}
