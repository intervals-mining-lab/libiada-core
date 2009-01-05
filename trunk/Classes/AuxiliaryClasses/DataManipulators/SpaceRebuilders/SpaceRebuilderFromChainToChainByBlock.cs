using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public class SpaceRebuilderFromChainToChainByBlock<ChainTo, ChainFrom> : SpaceRebuilder<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
    {
        private readonly LinkUp Link;
        private readonly int blocksize;

        ///<summary>
        ///</summary>
        ///<param name="act"></param>
        public SpaceRebuilderFromChainToChainByBlock(ActionType act)
        {
            Link = act.LinkUp;
            blocksize = act.BlockSize;
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

            while (To.Next() && From.Next())
            {
                To.SetCurrent(From.Current());
            }
            return temp;
        }
    }
}