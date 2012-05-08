using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes
{
    ///<summary>
    ///</summary>
    public class ChainConvolutor
    {

        ///<summary>
        ///</summary>
        ///<param name="chain_for_convolution"></param>
        ///<param name="one_symbol_chain"></param>
        ///<returns></returns>
        public Chain Convolute(Chain chain_for_convolution, Chain one_symbol_chain)
        {
            int actual_length = -1;
            Chain result_chain = new Chain(chain_for_convolution.Length);
            
            for (int i = 0; i < chain_for_convolution.Length; i++)
            {
                IteratorStart<Chain, Chain> it =
                    new IteratorStart<Chain, Chain>(chain_for_convolution, one_symbol_chain.Length, i);
                it.Next();
                if ((it.Next()) && (it.Current().Equals(one_symbol_chain)))
                {
                    actual_length++;
                    result_chain.Add(one_symbol_chain, actual_length);
                    i = i + one_symbol_chain.Length-1;
                }
                else
                {
                    actual_length++;
                    result_chain.Add(chain_for_convolution[i], actual_length);
                }
            }
            IteratorStart<Chain, Chain> it_result =
                new IteratorStart<Chain, Chain>(result_chain, actual_length+1, 1);
            it_result.Next();
            return it_result.Current();
        }


        ///<summary>
        ///</summary>
        ///<param name="chain_for_convolution"></param>
        ///<param name="one_symbol_chain"></param>
        ///<param name="data_for_convolution"></param>
        ///<returns></returns>
        public Chain Convolute(Chain chain_for_convolution, Chain one_symbol_chain,IDataForStd data_for_convolution)
        {
            Chain result_chain = new Chain((chain_for_convolution.Length - (data_for_convolution.n * (one_symbol_chain.Length - 1))));

            IteratorStart<Chain, Chain> it =
                    new IteratorStart<Chain, Chain>(chain_for_convolution, one_symbol_chain.Length, 1);
            IteratorSimpleStart<Chain> itread =
                    new IteratorSimpleStart<Chain>(chain_for_convolution, 1);
            IteratorWritableStart<Chain,Chain> ItWrite = new IteratorWritableStart<Chain, Chain>(result_chain);
            while(itread.Next() && ItWrite.Next())
            {
                it.Next();
                if (one_symbol_chain.Equals(it.Current()) && data_for_convolution.Positions.Contains(it.ActualPosition()))
                {
                    ItWrite.SetCurrent(one_symbol_chain);
                    it.Move(one_symbol_chain.Length - 1);
                    itread.Move(one_symbol_chain.Length - 1);
                }else
                {
                    ItWrite.SetCurrent(itread.Current());    
                }
            }

/*
            for (int i = ItWrite.ActualPosition(); i <  ItWrite.ActualPosition()+one_symbol_chain.Length;i++ )
            {
                result_chain.Add(chain_for_convolution[one_symbol_chain.Length + i-1],i);
            }
*/

            return result_chain;
        }
    }
}