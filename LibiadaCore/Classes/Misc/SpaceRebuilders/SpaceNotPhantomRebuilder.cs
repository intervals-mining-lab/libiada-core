using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    ///<typeparam name="ChainTo"></typeparam>
    ///<typeparam name="ChainFrom"></typeparam>
    public class SpaceNotPhantomRebuilder<ChainTo, ChainFrom>: SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
    {
        public override ChainTo Rebuild(ChainFrom from)
        {
            ChainTo resent = new ChainTo();
            resent.ClearAndSetNewLength(from.Length);
            for (int i = 0; i < from.Length; i++)
            {
                if (from[i] is ValuePhantom)
                {
                    resent.Add(((ValuePhantom)from[i])[0], i);
                }else
                {
                    resent.Add(from[i], i);
                }
            }
            return resent;
        }
    }
}