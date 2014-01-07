using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    ///<typeparam name="ChainTo"></typeparam>
    ///<typeparam name="ChainFrom"></typeparam>
    public class NullRebuilder<ChainTo, ChainFrom> : SpaceRebuilder<ChainTo, ChainFrom> where ChainTo : BaseChain, new() where ChainFrom : BaseChain, new()
    {
        public override ChainTo Rebuild(ChainFrom from)
        {
            var result = from.Clone() as ChainTo;
            if (result != null)
            {
                return result;
            }
            // TODO: Realize variant when we have Chain Rebuild(BaseChain A)
            var tempChainTo = new ChainTo();
            tempChainTo.ClearAndSetNewLength(from.Length);
            var iteratorRead = new IteratorSimpleStart<ChainFrom>(from, 1);
            var iteratorWrite = new IteratorWritableStart<ChainFrom, ChainTo>(tempChainTo);
            iteratorRead.Reset();
            iteratorWrite.Reset();
            iteratorRead.Next();
            iteratorWrite.Next();
            for (int i = 0; i < from.Length;i++)
            {
                iteratorWrite.SetCurrent(iteratorRead.Current());
                iteratorRead.Next();
                iteratorWrite.Next();
            }
            return tempChainTo;
        }
    }
}