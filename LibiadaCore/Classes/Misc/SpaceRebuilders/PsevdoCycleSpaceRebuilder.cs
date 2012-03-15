using System;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    ///<typeparam name="ChainTo"></typeparam>
    ///<typeparam name="ChainFrom"></typeparam>
    public class PsevdoCycleSpaceRebuilder<ChainTo, ChainFrom> : SpaceRebuilder<ChainTo, ChainFrom> where ChainTo : BaseChain, new() where ChainFrom : BaseChain, new()
    {
        private int Level = 0;
        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        public PsevdoCycleSpaceRebuilder(int i)
        {
            Level = i;
        }

        public override ChainTo Rebuild(ChainFrom A)
        {
            if (Level < 0 )
            {
                throw new Exception("Markov Chain level <= 0");
            }else
            {
                if(Level == 0)
                {
                    return (ChainTo)((BaseChain)A);
                }
            }
            ChainTo Temp = new ChainTo();
            Temp.ClearAndSetNewLength(A.Length + Level);
            for (int i = 0; i < A.Length; i++)
            {
                Temp[i] = A[i];
            }
            IteratorStart<ChainTo, ChainFrom> It = new IteratorStart<ChainTo, ChainFrom>(A, Level, 1);
            It.Reset();
            It.Next();
            ChainTo Addition = It.Current();
            for (int i = 0; i < Addition.Length; i++)
            {
                Temp[A.Length + i] = Addition[i];
            }

            return Temp;
        }
    }
}