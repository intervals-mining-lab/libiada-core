using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    public class SpacePhantomRebuilder<ChainTo, ChainFrom>:SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
    {
        public override ChainTo Rebuild(ChainFrom from)
        {
            var resent = new ChainTo();
            resent.ClearAndSetNewLength(from.Length);
            for (int i = 0; i < from.Length; i++)
            {
                var message = from[i].Clone() as ValuePhantom ?? new ValuePhantom {from[i]};

                resent.Add(message, i);
            }
            return resent;
        }
    }
}
