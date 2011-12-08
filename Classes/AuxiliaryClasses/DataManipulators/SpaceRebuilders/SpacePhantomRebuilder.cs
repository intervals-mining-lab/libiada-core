using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    class SpacePhantomRebuilder<ChainTo, ChainFrom>:SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
    {
        public override ChainTo Rebuild(ChainFrom A)
        {
            ChainTo Resent = new ChainTo();
            Resent.ClearAndSetNewLength(A.Length);
            for (int i = 0; i < A.Length; i++)
            {
                MessagePhantom Mes = A[i].Clone() as MessagePhantom;

                if (Mes == null)
                {
                    Mes = new MessagePhantom();
                    Mes.Add(A[i]);
                }

                Resent.Add(Mes, i);
            }
            return Resent;
        }
    }
}
