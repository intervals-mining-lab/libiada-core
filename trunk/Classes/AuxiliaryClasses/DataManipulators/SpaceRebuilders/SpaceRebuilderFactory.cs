using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public static class SpaceRebuilderFactory<ChainTo, ChainFrom> where ChainTo:BaseChain,new() where ChainFrom:BaseChain, new()
    {
        ///<summary>
        ///</summary>
        ///<param name="Method"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public static SpaceRebuilder<ChainTo, ChainFrom> Create(ActionType Method)
        {
            switch (Method.GetHashCode())
            {
                case -1667684723:
                    return new SpaceRebuilderFromChainToChainByBlock<ChainTo, ChainFrom>(Method);
                case -772858697:
                    return new SpaceRebuilderFromChainToChainByBlock<ChainTo, ChainFrom>(Method);
                default:
                    throw new Exception("Неизвестный метод");
            }
        }
    }
}