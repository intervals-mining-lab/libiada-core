using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    public class SpacePhantomRebuilder<ChainTo, ChainFrom>:SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
    {
        public override ChainTo Rebuild(ChainFrom A)
        {
            ChainTo Resent = new ChainTo();
            Resent.ClearAndSetNewLength(A.Length);
            for (int i = 0; i < A.Length; i++)
            {
                ValuePhantom Mes = A[i].Clone() as ValuePhantom;

                if (Mes == null)
                {
                    Mes = new ValuePhantom();
                    Mes.Add(A[i]);
                }

                Resent.Add(Mes, i);
            }
            return Resent;
        }
    }
}
