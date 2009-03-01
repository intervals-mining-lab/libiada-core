using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
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
                if (A[i] is MessagePhantom)
                {
                    Resent.Add(((MessagePhantom) A[i])[0], i);
                }else
                {
                    Resent.Add(A[i], i);
                }
            }
            return Resent;
        }
    }
}