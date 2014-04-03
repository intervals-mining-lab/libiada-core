namespace Segmentator.Base.Seekers.Converters
{
    using System;

    using LibiadaCore.Core.SimpleTypes;

    using Segmentator.Base.Sequencies;

    /// <summary>
    /// Filters a sequence of signs in compliance with set rules.
    /// The filter handles only words
    /// </summary>
    public class Filter
    {
        protected readonly ComplexChain Chain;
        protected String Replacement = "";

        public Filter(ComplexChain chain)
        {
            this.Chain = chain.Clone();
        }

        /// <summary>
        /// Removes all specified entry letters in any word
        /// </summary>
        /// <param name="str">str specified substring</param>
        /// <returns>number of hints</returns>
        public int FilterOut(String str)
        {
            int len = this.Chain.ToString().Length;
            for (int index = this.Chain.Length; --index >= 0;)
            {
                this.Chain[index] = new ValueString(this.Chain[index].ToString().Replace(str, this.Replacement));
                if (this.Chain[index].ToString().Length == 0) this.Chain.Remove(index, 1);
            }
            return this.Hints(len, str);

        }

        private int Hints(int len, String str)
        {
            double per = (len - this.Chain.ToString().Length) / (double)(str.Length - this.Replacement.Length);
            return (int) per;
        }

        /// <summary>
        /// Replaces all specified entry letters in any word
        /// </summary>
        /// <param name="str">specified substring</param>
        /// <param name="replacement">something that must be replaced</param>
        /// <returns>number of hints</returns>
        public int Replace(String str, String replacement)
        {
            this.Replacement = replacement;
            int hits = this.FilterOut(str);
            this.Replacement = "";

            return hits;
        }

        public ComplexChain GetChain()
        {
            return this.Chain.Clone();
        }
    }
}