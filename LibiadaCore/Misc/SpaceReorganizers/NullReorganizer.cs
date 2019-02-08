namespace LibiadaCore.Misc.SpaceReorganizers
{
    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// Reorganizer that does nothing.
    /// </summary>
    public class NullReorganizer : SpaceReorganizer
    {
        /// <summary>
        /// Reorganizes <see cref="AbstractChain"/> into <see cref="AbstractChain"/>.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractChain"/>.
        /// </returns>
        public override AbstractChain Reorganize(AbstractChain source)
        {
            var result = source.Clone() as AbstractChain;
            if (result != null)
            {
                return result;
            }

            result = new BaseChain();
            result.ClearAndSetNewLength(source.Length);

            var iteratorRead = new IteratorSimpleStart(source, 1);
            var iteratorWrite = new IteratorWritableStart(result);
            iteratorRead.Reset();
            iteratorWrite.Reset();
            iteratorRead.Next();
            iteratorWrite.Next();

            for (int i = 0; i < source.Length; i++)
            {
                iteratorWrite.WriteValue(iteratorRead.Current());
                iteratorRead.Next();
                iteratorWrite.Next();
            }

            return result;
        }
    }
}
