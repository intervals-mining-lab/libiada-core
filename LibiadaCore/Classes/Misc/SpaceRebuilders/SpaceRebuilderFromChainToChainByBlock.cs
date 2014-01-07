using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    public class SpaceRebuilderFromChainToChainByBlock<TChainTo ,TChainFrom> : SpaceRebuilder<TChainTo, TChainFrom>
        where TChainTo : BaseChain, new() where TChainFrom : BaseChain, new()
    {
        private readonly Link Link;
        private readonly int blocksize;

        public override TChainTo Rebuild(TChainFrom from)
        {
            var temp = new TChainTo();
            temp.ClearAndSetNewLength(from.Length / blocksize);
            IteratorBase<TChainTo, TChainFrom> iteratorFrom;
            IWritableIterator<TChainTo, TChainTo> iteratorTo;

            if (Link != Link.End)
            {
                iteratorFrom = new IteratorStart<TChainTo, TChainFrom>(from, blocksize, blocksize);
                iteratorTo = new IteratorWritableStart<TChainTo, TChainTo>(temp);
            }
            else
            {
                iteratorFrom = new IteratorEnd<TChainTo, TChainFrom>(from, blocksize, blocksize);
                iteratorTo = new IteratorWritableEnd<TChainTo, TChainTo>(temp);
            }

            while (iteratorTo.Next() && iteratorFrom.Next())
            {
                var message = new ValuePhantom {iteratorFrom.Current()};

                iteratorTo.SetCurrent(message.Power == 0 ? (IBaseObject)NullValue.Instance() : message);
            }
            return temp;
        }
    }
}