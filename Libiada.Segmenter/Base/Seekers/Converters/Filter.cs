namespace Segmenter.Base.Seekers.Converters
{
    using LibiadaCore.Core.SimpleTypes;

    using Sequences;

    /// <summary>
    /// Filters a sequence of signs in compliance with set rules.
    /// The filter handles only words
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// The chain.
        /// </summary>
        protected readonly ComplexChain Chain;

        /// <summary>
        /// The replacement.
        /// </summary>
        protected string replacement = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public Filter(ComplexChain chain)
        {
            Chain = chain.Clone();
        }

        /// <summary>
        /// Removes all specified entry letters in any word
        /// </summary>
        /// <param name="str">specified substring</param>
        /// <returns>number of hints</returns>
        public int FilterOut(string str)
        {
            int len = Chain.ToString().Length;
            for (int index = Chain.Length; --index >= 0;)
            {
                Chain[index] = new ValueString(Chain[index].ToString().Replace(str, replacement));
                if (Chain[index].ToString().Length == 0)
                {
                    Chain.Remove(index, 1);
                }
            }

            return Hints(len, str);
        }

        /// <summary>
        /// Replaces all specified entry letters in any word
        /// </summary>
        /// <param name="str">specified substring</param>
        /// <param name="replacement">something that must be replaced</param>
        /// <returns>number of hints</returns>
        public int Replace(string str, string replacement)
        {
            this.replacement = replacement;
            int hits = FilterOut(str);
            this.replacement = string.Empty;

            return hits;
        }

        /// <summary>
        /// The get chain.
        /// </summary>
        /// <returns>
        /// The <see cref="ComplexChain"/>.
        /// </returns>
        public ComplexChain GetChain()
        {
            return Chain.Clone();
        }

        /// <summary>
        /// The hints.
        /// </summary>
        /// <param name="len">
        /// The len.
        /// </param>
        /// <param name="str">
        /// The string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int Hints(int len, string str)
        {
            double per = (len - Chain.ToString().Length) / (double)(str.Length - replacement.Length);
            return (int)per;
        }
    }
}
