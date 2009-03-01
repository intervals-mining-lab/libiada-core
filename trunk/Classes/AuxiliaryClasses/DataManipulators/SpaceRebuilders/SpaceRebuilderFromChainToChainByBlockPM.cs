using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public class SpaceRebuilderFromChainToChainByBlockPM<ChainTo ,ChainFrom> : SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new() where ChainFrom : BaseChain, new()
    {
        private readonly LinkUp Link;
        private readonly int blocksize;

        ///<summary>
        ///</summary>
        public SpaceRebuilderFromChainToChainByBlockPM(LinkUp link, int BlockSize)
        {
            Link = link;
            blocksize = BlockSize;
        }

        public override ChainTo Rebuild(ChainFrom A)
        {
            if (A.GetPlacePattern().Count != 1)
            {
                throw new Exception();
            }
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

            PsevdoValue Psevdo = PsevdoValue.Instance();
            MessagePhantom Message = null;
            while (To.Next() && From.Next())
            {
                Message = new MessagePhantom();

                Message.Add(From.Current());
                To.SetCurrent(Message.power == 0 ? (IBaseObject) Psevdo : Message);
            }
            return temp;
        }
    }
}