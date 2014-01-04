using System;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    ///<typeparam name="ChainTo"></typeparam>
    ///<typeparam name="ChainFrom"></typeparam>
    public class NullCycleSpaceRebuilder<ChainTo, ChainFrom> : SpaceRebuilder<ChainTo, ChainFrom> where ChainTo : BaseChain, new() where ChainFrom : BaseChain, new()
    {
        private int Level;
        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        public NullCycleSpaceRebuilder(int i)
        {
            Level = i;
        }

        public override ChainTo Rebuild(ChainFrom from)
        {
            if (Level < 0 )
            {
                throw new Exception("Markov Chain level <= 0");
            }
            if (Level == 0)
            {
                return (ChainTo)((BaseChain)from);
            }
            ChainTo chainTo = new ChainTo();
            chainTo.ClearAndSetNewLength(from.Length + Level);
            for (int i = 0; i < from.Length; i++)
            {
                chainTo[i] = from[i];
            }
            var iterator = new IteratorStart<ChainTo, ChainFrom>(from, Level, 1);
            iterator.Reset();
            iterator.Next();
            ChainTo addition = iterator.Current();
            for (int i = 0; i < addition.Length; i++)
            {
                chainTo[from.Length + i] = addition[i];
            }

            return chainTo;
        }
    }
}