using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public abstract class SpaceRebuilder<ChainTo, ChainFrom> 
        where ChainTo:BaseChain,new() where ChainFrom:BaseChain, new()
    {
        ///<summary>
        ///</summary>
        ///<param name="A"></param>
        ///<returns></returns>
        public abstract ChainTo Rebuild(ChainFrom A);
    }
}