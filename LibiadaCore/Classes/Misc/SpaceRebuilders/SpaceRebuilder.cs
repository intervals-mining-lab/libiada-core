using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public abstract class SpaceRebuilder<TChainTo, TChainFrom> 
        where TChainTo:BaseChain,new() where TChainFrom:BaseChain, new()
    {
        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public abstract TChainTo Rebuild(TChainFrom from);
    }
}