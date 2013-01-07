using System;
using Segmentation.Classes.Base.Sequencies;

namespace Segmentation.Classes.Base.Seekers.Converters
{
    /// <summary>
    /// Filters a sequence of signs in compliance with set rules.
    /// The filter handles only words
    /// </summary>
    public class Filter
    {
        protected ComplexChain chain;
        protected String replacement = "";

        public Filter(ComplexChain chain)
        {
            this.chain = (ComplexChain)chain.Clone();
        }

        /// <summary>
        /// Removes all specified entry letters in any word
        /// </summary>
        /// <param name="str">str specified substring</param>
        /// <returns>number of hints</returns>
        public int filterout(String str)
        {
            int len = chain.ToString().Length;
            for (int index = chain.Length; --index >= 0;)
            {
                chain.Replace(index, chain.elementAt(index).Replace(str, replacement));
                if (chain.elementAt(index).Length == 0) chain.Remove(index, 1);
            }
            return hints(len, str);

        }

        private int hints(int len, String str)
        {
            double per = (len - chain.ToString().Length) / (double)(str.Length - replacement.Length);
            return (int) per;
        }

        /// <summary>
        /// Replaces all specified entry letters in any word
        /// </summary>
        /// <param name="str">specified substring</param>
        /// <param name="replacement">something that must be replaced</param>
        /// <returns>number of hints</returns>
        public int replace(String str, String replacement)
        {
            int hits;
            this.replacement = replacement;
            hits = filterout(str);
            this.replacement = "";

            return hits;
        }

        public ComplexChain getChain()
        {
            return chain;
        }
    }
}