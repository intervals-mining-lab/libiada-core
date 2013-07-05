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

        public override ChainTo Rebuild(ChainFrom from)
        {
            ChainTo temp = new ChainTo();
            temp.ClearAndSetNewLength(from.Length / blocksize);
            IteratorBase<ChainTo, ChainFrom> iteratorFrom;
            IWritableIterator<ChainTo, ChainTo> iteratorTo;

            if (Link != LinkUp.End)
            {
                iteratorFrom = new IteratorStart<ChainTo, ChainFrom>(from, blocksize, blocksize);
                iteratorTo = new IteratorWritableStart<ChainTo, ChainTo>(temp);
            }
            else
            {
                iteratorFrom = new IteratorEnd<ChainTo, ChainFrom>(from, blocksize, blocksize);
                iteratorTo = new IteratorWritableEnd<ChainTo, ChainTo>(temp);
            }

            NullValue psevdo = NullValue.Instance();
            while (iteratorTo.Next() && iteratorFrom.Next())
            {
                ValuePhantom message = new ValuePhantom {iteratorFrom.Current()};

                iteratorTo.SetCurrent(message.Power == 0 ? (IBaseObject) psevdo : message);
            }
            return temp;
        }
    }
}