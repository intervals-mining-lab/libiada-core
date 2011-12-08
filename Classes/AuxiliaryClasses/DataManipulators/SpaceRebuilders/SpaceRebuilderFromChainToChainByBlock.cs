using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public class SpaceRebuilderFromChainToChainByBlock<ChainTo, ChainFrom, ChainItem> :
        SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
        where ChainItem : BaseChain, new()
    {
        private readonly int blocksize;
        private readonly LinkUp Link;

        ///<summary>
        ///</summary>
        public SpaceRebuilderFromChainToChainByBlock(LinkUp link, int BlockSize)
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
            temp.ClearAndSetNewLength(A.Length/blocksize);
            IteratorBase<ChainItem, ChainFrom> From;
            IWritableIterator<ChainTo, ChainTo> To;

            if (Link != LinkUp.End)
            {
                From = new IteratorStart<ChainItem, ChainFrom>(A, blocksize, blocksize);
                To = new IteratorWritableStart<ChainTo, ChainTo>(temp);
            }
            else
            {
                From = new IteratorEnd<ChainItem, ChainFrom>(A, blocksize, blocksize);
                To = new IteratorWritableEnd<ChainTo, ChainTo>(temp);
            }

            while (To.Next() && From.Next())
            {
                To.SetCurrent(From.Current());
            }
            return temp;
        }
    }
}