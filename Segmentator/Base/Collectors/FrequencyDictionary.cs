namespace Segmentator.Base.Collectors
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Base.Sequencies;
    using Segmentator.Extended;

    /// <summary>
    /// The finite set of unique words were extracted from a sequence of characters.
    /// </summary>
    public class FrequencyDictionary
    {
        protected Dictionary<String, List<int>> Words = new Dictionary<String, List<int>>();


        public FrequencyDictionary()
        {
        }

        public FrequencyDictionary(String str)
        {
            this.Fill(str);
        }

        public FrequencyDictionary(ComplexChain sequence)
        {
            this.Fill(sequence);
        }

        /// <summary>
        /// Extracts new chars and their places of occurrence from a current char sequence
        /// </summary>
        /// <param name="str">the current char sequence</param>
        public void Fill(String str)
        {
            this.Clear();
            for (int index = 0; index < str.Length; index++)
            {
                this.Put(str[index].ToString(), index);
            }
        }

        /// <summary>
        /// Extracts new words and their places of occurrence from a current word sequence
        /// </summary>
        /// <param name="sequence">the current word sequence</param>
        public void Fill(ComplexChain sequence)
        {
            this.Clear();
            for (int index = 0; index < sequence.Length; index++)
            {
                this.Put(sequence[index].ToString(), index);
            }
        }

        /// <summary>
        /// Returns all words positions
        /// </summary>
        /// <returns>a list of all words positions</returns>
        public List<List<int>> GetWordsPositions()
        {
            return new List<List<int>>(this.Words.Values);
        }

        public List<KeyValuePair<String, List<int>>> SortByPower()
        {
            List<KeyValuePair<String, List<int>>> list = new List<KeyValuePair<String, List<int>>>(this.Words);
            list.Sort(
                delegate(KeyValuePair<string, List<int>> firstPair,
                         KeyValuePair<string, List<int>> nextPair)
                    {
                        return firstPair.Value.Count.CompareTo(nextPair.Value.Count);
                    });
            
            list.Reverse();
            return list;
        }

        /// <summary>
        /// Returns a list of words of this FrequencyDictionary.
        /// Be careful! The new word can not be added to the end of the list as the data are hashed
        /// </summary>
        /// <returns>a list of words of this FrequencyDictionary.</returns>
        public List<String> GetWords()
        {
            if (this.Words.Count == 0) return new List<String>();
            return new List<String>(this.Words.Keys);

        }

        /// <summary>
        /// Returns the word to the index at a given
        /// </summary>
        /// <param name="index">a specified cursorPosition of word</param>
        /// <returns>the word to the index at a given</returns>
        public String GetWord(int index)
        {
            String str = "";
            try
            {
                str = this.GetWords()[index];
            }
            catch (Exception)
            {
            }

            return str;
        }

        /// <summary>
        /// Maps the specified word to the specified cursorPosition in a sequence.
        /// </summary>
        /// <param name="str">a new word</param>
        /// <param name="pos">a cursorPosition of the word in the sequence</param>
        public void Put(String str, int pos)
        {
            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return;
                }
                if (!this.Words.ContainsKey(str))
                {
                    List<int> wordPositions = new List<int> {pos};
                    this.Words.Add(str, wordPositions);
                }
                else
                {
                    List<int> modified = this.Words[str];
                    if (!modified.Contains(pos))
                    {
                        modified.Add(pos);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        
        /// <summary>
        /// Returns true if this FrequencyDictionary contains the specified word.
        /// More formally, returns true if and only if this FrequencyDictionary contains at least one word.
        /// </summary>
        /// <param name="str">word whose presence in this FrequencyDictionary is to be tested</param>
        /// <returns>true if this FrequencyDictionary contains the specified word</returns>
        public bool Contains(String str)
        {
            return this.Words.ContainsKey(str);
        }

        /// <summary>
        /// Returns true if this FrequencyDictionary contains the specified word.
        /// More formally, returns true if and only if this FrequencyDictionary contains at least one word.
        /// </summary>
        /// <param name="str">
        /// word is built from letters 
        /// whose presence in this FrequencyDictionary is to be tested
        /// </param>
        /// <returns>true if this FrequencyDictionary contains the specified word</returns>
        public bool Contains(List<String> str)
        {
            return this.Words.ContainsKey(Helper.ToString(str));
        }

        /// <summary>
        /// Returns the list of positions to which the specified word is mapped, or null
        /// if this FrequencyDictionary contains no mapping for the word.
        /// </summary>
        /// <param name="str">the word whose associated the list of positions is to be returned</param>
        /// <returns>
        /// the list of positions to which the specified word is mapped, or null
        /// if this FrequencyDictionary contains no mapping for the word
        /// </returns>
        public List<int> this[String str]
        {
            get { return new List<int>(this.Words[str]); }
        }

        /// <summary>
        /// Removes the word (and its corresponding a list of positions) from this FrequencyDictionary.
        /// This method does nothing if the key is not in the FrequencyDictionary.
        /// </summary>
        /// <param name="str">the word that needs to be removed</param>
        public void Remove(String str)
        {
            try
            {
                this.Words.Remove(str);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Returns the number of words in this FrequencyDictionary.
        /// </summary>
        /// <returns>the number of words in this FrequencyDictionary.</returns>
        public int Count
        {
            get { return this.Words.Count; }
        }

        /// <summary>
        /// Clears this FrequencyDictionary so that it contains no words.
        /// </summary>
        public void Clear()
        {
            this.Words.Clear();
        }

        /// <summary>
        /// Maps the specified word to the specified list of cursorPosition in a sequence.
        /// </summary>
        /// <param name="str">the new word</param>
        /// <param name="pos">word's positions in the sequence</param>
        public void Add(String str, List<int> pos)
        {
            try
            {
                this.Words.Add(str, new List<int>(pos));
            }
            catch (Exception)
            {
            }
        }

        public FrequencyDictionary Clone()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary();
            for (IEnumerator<String> e = this.Words.Keys.GetEnumerator(); e.MoveNext();)
            {
                String word = e.Current;
                List<int> wordPositions = this[word];
                alphabet.Add(word, new List<int>(wordPositions));
            }

            return alphabet;
        }

        public bool Equals(FrequencyDictionary obj)
        {
            if (obj.Count != this.Words.Count) return false;
            for (int index = 0; index < this.Count; index++)
            {
                if (!(obj.Contains(this.GetWord(index)))) return false;
            }

            return true;
        }
    }
}