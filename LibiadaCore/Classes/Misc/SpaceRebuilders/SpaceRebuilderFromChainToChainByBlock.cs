using System;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public class SpaceRebuilderFromChainToChainByBlock<ChainTo ,ChainFrom> : SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new() where ChainFrom : BaseChain, new()
    {
        private readonly LinkUp Link;
        private readonly int blocksize;

        public override ChainTo Rebuild(ChainFrom A)
        {
            ChainTo temp = new ChainTo();
            temp.ClearAndSetNewLength(A.Length / blocksize);
            IteratorBase<ChainTo, ChainFrom> From;
            IWritableIterator<ChainTo, ChainTo> To;

            if (Link != LinkUp.End)
            {
                From = new IteratorStart<ChainTo, ChainFrom>(A, blocksize, blocksize);
                To = new IteratorWritableStart<ChainTo, ChainTo>(temp);
            }
            else
            {
                From = new IteratorEnd<ChainTo, ChainFrom>(A, blocksize, blocksize);
                To = new IteratorWritableEnd<ChainTo, ChainTo>(temp);
            }

            NullValue Psevdo = NullValue.Instance();
            ValuePhantom Message = null;
            while (To.Next() && From.Next())
            {
                Message = new ValuePhantom();

                Message.Add(From.Current());
                To.SetCurrent(Message.Power == 0 ? (IBaseObject) Psevdo : Message);
            }
            return temp;
        }
    }
}