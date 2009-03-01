using System;
using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    public class PhantomChainGenerator<ChainTo,ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new() 
    {
        readonly Int64 variants = 1;
        private readonly ChainTo InternalChain = null;
        private readonly IGenerator Gen = null;
        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<exception cref="NotImplementedException"></exception>
        ///<param name="Gen"></param>
        public PhantomChainGenerator(ChainFrom chain, IGenerator Gen)
        {
            this.Gen = Gen;
            SpacePhantomRebuilder<ChainTo, ChainFrom> rebuilder  = new SpacePhantomRebuilder<ChainTo, ChainFrom>();
            InternalChain = rebuilder.Rebuild(chain);
            for (int i = 0; i < InternalChain.Length; i++)
            {
                variants *= ((MessagePhantom)InternalChain[i]).power;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ArrayList Generate(int i)
        {
            ArrayList Res = new ArrayList();
           
               
               Gen.Resert();
               while(Res.Count!=i)
               {
                   ChainTo Resent = new ChainTo();
                   Resent.ClearAndSetNewLength(InternalChain.Length);

                   for (int j = 0; j < InternalChain.Length; j++)
                   {
                       Double value = Gen.Next();
                       MessagePhantom Temp = (MessagePhantom) InternalChain[j];
                       int N = (int) Math.Floor(value*Temp.power);
                       Resent.Add(Temp[N], j);
                   }

                   if( !Res.Contains(Resent))
                   {
                       Res.Add(Resent);
                   }
                   
               }
           
            return  Res;
        }
    }
}