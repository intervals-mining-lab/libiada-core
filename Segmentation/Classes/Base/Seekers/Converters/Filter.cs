﻿using System;
using Segmentation.Classes.Base.Sequencies;

namespace Segmentation.Classes.Base.Seekers.Converters
{
    /// <summary>
    /// Filters a sequence of signs in compliance with set rules.
    /// The filter handles only words
    /// </summary>
    public class Filter
    {
        protected readonly ComplexChain Chain;
        protected String replacement = "";

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
            int len = Chain.ToString().Length;
            for (int index = Chain.Length; --index >= 0;)
            {
                Chain.Replace(index, Chain[index].ToString().Replace(str, replacement));
                if (Chain[index].ToString().Length == 0) Chain.Remove(index, 1);
            }
            return Hints(len, str);

        }

        private int Hints(int len, String str)
        {
            double per = (len - Chain.ToString().Length) / (double)(str.Length - replacement.Length);
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
            int hits;
            this.replacement = replacement;
            hits = FilterOut(str);
            this.replacement = "";

            return hits;
        }

        public ComplexChain GetChain()
        {
            return Chain.Clone();
        }
    }
}