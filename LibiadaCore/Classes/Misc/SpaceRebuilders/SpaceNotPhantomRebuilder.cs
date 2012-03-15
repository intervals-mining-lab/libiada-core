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
        public override ChainTo Rebuild(ChainFrom A)
        {
            ChainTo Resent = new ChainTo();
            Resent.ClearAndSetNewLength(A.Length);
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] is ValuePhantom)
                {
                    Resent.Add(((ValuePhantom)A[i])[0], i);
                }else
                {
                    Resent.Add(A[i], i);
                }
            }
            return Resent;
        }
    }
}