namespace Segmentator.Base.Seekers.Converters
{
    using LibiadaCore.Core.SimpleTypes;

    using Segmentator.Base.Sequencies;

    /// <summary>
    /// Filters a sequence of signs in compliance with set rules.
    /// The filter handles only words
    /// </summary>
    public class Filter
    {
        protected readonly ComplexChain Chain;

        protected string replacement = string.Empty;

        public Filter(ComplexChain chain)
        {
            this.Chain = chain.Clone();
        }

        /// <summary>
        /// Removes all specified entry letters in any word
        /// </summary>
        /// <param name="str">str specified substring</param>
        /// <returns>number of hints</returns>
        public int FilterOut(string str)
        {
            int len = this.Chain.ToString().Length;
            for (int index = this.Chain.Length; --index >= 0;)
            {
                this.Chain[index] = new ValueString(this.Chain[index].ToString().Replace(str, this.replacement));
                if (this.Chain[index].ToString().Length == 0)
                {
                    this.Chain.Remove(index, 1);
                }
            }

            return this.Hints(len, str);
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
            int hits = this.FilterOut(str);
            this.replacement = string.Empty;

            return hits;
        }

        public ComplexChain GetChain()
        {
            return this.Chain.Clone();
        }

        private int Hints(int len, string str)
        {
            double per = (len - this.Chain.ToString().Length) / (double)(str.Length - this.replacement.Length);
            return (int)per;
        }
    }
}