using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Extended;

namespace Segmentation.Classes.Base.Collectors
{
    public class FrequencyDictionary
    {
        protected Dictionary<String, List<int>> words = new Dictionary<String, List<int>>();


        public FrequencyDictionary()
        {
        }

        /**
     * Returns all words positions
     *
     * @return a list of all words positions
     */

        public List<List<int>> getWordsPositions()
        {
            return new List<List<int>>(words.Values);
        }

        public List<KeyValuePair<String, List<int>>> sortByPower()
        {
            List<KeyValuePair<String, List<int>>> list = new List<KeyValuePair<String, List<int>>>(words);
            list.Sort(
                delegate(KeyValuePair<string, List<int>> firstPair,
                         KeyValuePair<string, List<int>> nextPair)
                    {
                        return firstPair.Value.Count.CompareTo(nextPair.Value.Count);
                    });
            
            list.Reverse();
            return list;
        }

        /**
     * Returns a list of words of this FrequencyDictionary.
     * Be careful! The new word can not be added to the end of the list as the data are hashed
     *
     * @return a list of words of this FrequencyDictionary.
     */

        public List<String> getWords()
        {
            if (words.Count == 0) return new List<String>();
            return new List<String>(words.Keys);

        }

        /**
     * Looks number of unique elements
     *
     * @param chain chain which will look
     * @return number of unique elements
     */

        public static double power(ComplexChain chain)
        {
            List<String> df = new List<String>(chain.substring(0, chain.Length)); // fast
            return df.Count;
        }

        /**
     * Returns obviously
     *
     * @param chain chain which will look
     * @return chain power
     */

        public static double power(UniformChain chain)
        {
            return 1;
        }

        public FrequencyDictionary(String str)
        {
            fill(str);
        }

        public FrequencyDictionary(ComplexChain sequence)
        {
            fill(sequence);
        }

        /**
     * Extracts new words and their places of occurrence from a current word sequence
     *
     * @param sequence the current word sequence
     */

        public void fill(ComplexChain sequence)
        {
            clear();
            for (int index = 0; index < sequence.Length; index++)
            {
                put(sequence.elementAt(index), index);
            }
        }

        /**
     * Extracts new chars and their places of occurrence from a current char sequence
     *
     * @param str the current char sequence
     */

        public void fill(String str)
        {
            clear();
            for (int index = 0; index < str.Length; index++)
            {
                put(str[index].ToString(), index);
            }
        }

        /**
     * Maps the specified word to the specified cursorPosition in a sequence.
     *
     * @param str a new word
     * @param pos a cursorPosition of the word in the sequence
     */

        public void put(String str, int pos)
        {
            try
            {
                if (String.IsNullOrEmpty(str)) return;
                if (!words.ContainsKey(str))
                {
                    List<int> wordPositions = new List<int>();
                    wordPositions.Add(pos);
                    words.Add(str, wordPositions);
                }
                List<int> modified = words[str];
                if (!modified.Contains(pos)) modified.Add(pos);
            }
            catch (Exception e)
            {
            }
        }

        /**
     * Returns true if this FrequencyDictionary contains the specified word.
     * More formally, returns true if and only if this FrequencyDictionary contains at least one word
     *
     * @param str word whose presence in this FrequencyDictionary is to be tested
     * @return true if this FrequencyDictionary contains the specified word
     */

        public bool contains(String str)
        {
            return words.ContainsKey(str);
        }

        /**
     * Returns true if this FrequencyDictionary contains the specified word.
     * More formally, returns true if and only if this FrequencyDictionary contains at least one word
     *
     * @param str word is built from letters whose presence in this FrequencyDictionary is to be tested
     * @return true if this FrequencyDictionary contains the specified word
     */

        public bool contains(List<String> str)
        {
            return words.ContainsKey(Helper.ToString(str));
        }

        /**
     * Returns the list of positions to which the specified word is mapped, or null
     * if this FrequencyDictionary contains no mapping for the word.
     *
     * @param str the word whose associated the list of positions is to be returned
     * @return the list of positions to which the specified word is mapped, or null
     *         if this FrequencyDictionary contains no mapping for the word
     */

        public List<int> get(String str)
        {
            try
            {
                return words[str];
            }
            catch (Exception e)
            {
            }

            return null;
        }

        /**
     * Removes the word (and its corresponding a list of positions) from this FrequencyDictionary.
     * This method does nothing if the key is not in the FrequencyDictionary.
     *
     * @param str the word that needs to be removed
     */

        public void remove(String str)
        {
            try
            {
                words.Remove(str);
            }
            catch (Exception e)
            {
            }
        }

        /**
     * Returns the number of words in this FrequencyDictionary.
     *
     * @return the number of words in this FrequencyDictionary.
     */

        public int power()
        {
            return words.Count;
        }

        /**
     * Clears this FrequencyDictionary so that it contains no words.
     */

        public void clear()
        {
            words.Clear();
        }

        /**
     * Maps the specified word to the specified list of cursorPosition in a sequence.
     *
     * @param str the new word
     * @param pos word's positions in the sequence
     */

        public void add(String str, List<int> pos)
        {
            try
            {
                words.Add(str, new List<int>(pos));
            }
            catch (Exception e)
            {
            }
        }

        public FrequencyDictionary Clone()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary();
            for (IEnumerator<String> e = this.words.Keys.GetEnumerator(); e.MoveNext();)
            {
                String word = e.Current;
                List<int> wordPositions = get(word);
                alphabet.add(word, new List<int>(wordPositions));
            }

            return alphabet;
        }

        public bool Equals(FrequencyDictionary obj)
        {
            if (obj.power() != words.Count) return false;
            for (int index = 0; index < power(); index++)
            {
                if (!(obj.contains(getWord(index)))) return false;
            }

            return true;
        }

        /**
     * Returns the word to the index at a given
     *
     * @param index a specified cursorPosition of word
     * @return the word to the index at a given
     */

        public String getWord(int index)
        {
            String str = "";
            try
            {
                str = getWords()[index];
            }
            catch (Exception e)
            {
            }

            return str;
        }
    }
}