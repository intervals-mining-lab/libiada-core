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
        public override ChainTo Rebuild(ChainFrom A)
        {
            ChainFrom Temp = (ChainFrom) A.Clone();
            ChainTo Result = Temp as ChainTo;
            if (Result != null)
            {
                return Result;
            }
            else
            {
                // TODO: Realize variant when we have Chain Rebuild(BaseChain A)
                ChainTo TempChainTo = new ChainTo();
                TempChainTo.ClearAndSetNewLength(A.Length);
                IteratorSimpleStart<ChainFrom> IteratorRead = new IteratorSimpleStart<ChainFrom>(Temp, 1);
                IteratorWritableStart<ChainFrom, ChainTo> IteratorWrite = new IteratorWritableStart<ChainFrom, ChainTo>(TempChainTo);
                IteratorRead.Reset();
                IteratorWrite.Reset();
                IteratorRead.Next();
                IteratorWrite.Next();
                for (int i = 0; i < Temp.Length;i++)
                {
                    IteratorWrite.SetCurrent(IteratorRead.Current());
                    IteratorRead.Next();
                    IteratorWrite.Next();
                }
                return TempChainTo;
            }
    
        }
    }
}