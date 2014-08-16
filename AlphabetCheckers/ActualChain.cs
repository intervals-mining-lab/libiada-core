namespace AlphabetCheckers
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// Class representing actual chain.
    /// </summary>
    public class ActualChain : ICloneable 
    {
        /// <summary>
        /// The result chain.
        /// </summary>
        private BaseChain resultChain;

        /// <summary>
        /// The actual length.
        /// </summary>
        private int actualLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActualChain"/> class.
        /// </summary>
        /// <param name="source">
        /// The source chain.
        /// </param>
        public ActualChain(BaseChain source)
        {
            Source = (BaseChain)source.Clone();
            actualLength = 0;
            resultChain = new BaseChain(source.GetLength());
        }

        /// <summary>
        /// Gets the source chain.
        /// </summary>
        public BaseChain Source { get; private set; }

        /// <summary>
        /// Removes character.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        public void RemoveCharacter(int length)
        {
            if (Source.GetLength() == length)
            {
                resultChain.Add(Source, actualLength);
                Source = null;
            }
            else
            {
                var it1 = new IteratorStart(Source, length, 1);
                it1.Next();
                resultChain.Add(it1.Current(), actualLength);
                var it2 = new IteratorEnd(Source, Source.GetLength() - length, 1);
                it2.Next();
                Source = (BaseChain)it2.Current();
            }

            actualLength++;
        }

        /// <summary>
        /// The get result.
        /// </summary>
        /// <returns>
        /// The <see cref="BaseChain"/>.
        /// </returns>
        public BaseChain GetResult()
        {
            var it = new IteratorStart(resultChain, actualLength, 1);
            it.Next();
            return (BaseChain)it.Current();
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Clone()
        {
            var clone = new ActualChain((BaseChain)Source.Clone())
                {
                    resultChain = (BaseChain)resultChain.Clone(),
                    actualLength = actualLength
                };
            return clone;
        }
    }
}