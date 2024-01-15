namespace Libiada.Segmenter.Base.Collectors;

using Segmenter.Base.Sequences;
using Segmenter.Extended;

/// <summary>
/// The finite set of unique words were extracted from a sequence of characters.
/// </summary>
public class FrequencyDictionary
{
    /// <summary>
    /// The words.
    /// </summary>
    private Dictionary<string, List<int>> words = new Dictionary<string, List<int>>();

    /// <summary>
    /// Initializes a new instance of the <see cref="FrequencyDictionary"/> class.
    /// </summary>
    public FrequencyDictionary()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrequencyDictionary"/> class.
    /// </summary>
    /// <param name="source">
    /// The source string.
    /// </param>
    public FrequencyDictionary(string source)
    {
        Fill(source);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrequencyDictionary"/> class.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public FrequencyDictionary(ComplexChain sequence)
    {
        Fill(sequence);
    }

    /// <summary>
    /// Gets the number of words in this FrequencyDictionary.
    /// </summary>
    /// <returns>the number of words in this FrequencyDictionary.</returns>
    public int Count
    {
        get { return words.Count; }
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
    public List<int> this[string str]
    {
        get { return new List<int>(words[str]); }
    }

    /// <summary>
    /// Extracts new chars and their places of occurrence from a current char sequence
    /// </summary>
    /// <param name="str">the current char sequence</param>
    public void Fill(string str)
    {
        Clear();
        for (int index = 0; index < str.Length; index++)
        {
            Put(str[index].ToString(), index);
        }
    }

    /// <summary>
    /// Extracts new words and their places of occurrence from a current word sequence
    /// </summary>
    /// <param name="sequence">the current word sequence</param>
    public void Fill(ComplexChain sequence)
    {
        Clear();
        for (int index = 0; index < sequence.Length; index++)
        {
            Put(sequence[index].ToString(), index);
        }
    }

    /// <summary>
    /// Returns all words positions
    /// </summary>
    /// <returns>a list of all words positions</returns>
    public List<List<int>> GetWordsPositions()
    {
        return new List<List<int>>(words.Values);
    }

    /// <summary>
    /// The sort by power.
    /// </summary>
    /// <returns>
    /// The <see cref="T:List{KeyValuePair{String, List{Int32}}}"/>.
    /// </returns>
    public List<KeyValuePair<string, List<int>>> SortByPower()
    {
        var list = new List<KeyValuePair<string, List<int>>>(words);
        list.Sort((firstPair, nextPair) => firstPair.Value.Count.CompareTo(nextPair.Value.Count));

        list.Reverse();
        return list;
    }

    /// <summary>
    /// Returns a list of words of this FrequencyDictionary.
    /// Be careful! The new word can not be added to the end of the list as the data are hashed
    /// </summary>
    /// <returns>a list of words of this FrequencyDictionary.</returns>
    public List<string> GetWords()
    {
        if (words.Count == 0)
        {
            return new List<string>();
        }

        return new List<string>(words.Keys);
    }

    /// <summary>
    /// Returns the word to the index at a given
    /// </summary>
    /// <param name="index">a specified cursorPosition of word</param>
    /// <returns>the word to the index at a given</returns>
    public string GetWord(int index)
    {
        string str = string.Empty;
        try
        {
            str = GetWords()[index];
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
    public void Put(string str, int pos)
    {
        try
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            if (!words.ContainsKey(str))
            {
                var wordPositions = new List<int> { pos };
                words.Add(str, wordPositions);
            }
            else
            {
                List<int> modified = words[str];
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
    public bool Contains(string str)
    {
        return words.ContainsKey(str);
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
    public bool Contains(List<string> str)
    {
        return words.ContainsKey(Helper.ToString(str));
    }

    /// <summary>
    /// Removes the word (and its corresponding a list of positions) from this FrequencyDictionary.
    /// This method does nothing if the key is not in the FrequencyDictionary.
    /// </summary>
    /// <param name="str">the word that needs to be removed</param>
    public void Remove(string str)
    {
        try
        {
            words.Remove(str);
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// Clears this FrequencyDictionary so that it contains no words.
    /// </summary>
    public void Clear()
    {
        words.Clear();
    }

    /// <summary>
    /// Maps the specified word to the specified list of cursorPosition in a sequence.
    /// </summary>
    /// <param name="str">the new word</param>
    /// <param name="pos">word's positions in the sequence</param>
    public void Add(string str, List<int> pos)
    {
        try
        {
            words.Add(str, new List<int>(pos));
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="FrequencyDictionary"/>.
    /// </returns>
    public FrequencyDictionary Clone()
    {
        var alphabet = new FrequencyDictionary();
        for (IEnumerator<string> e = words.Keys.GetEnumerator(); e.MoveNext();)
        {
            string word = e.Current;
            List<int> wordPositions = this[word];
            alphabet.Add(word, new List<int>(wordPositions));
        }

        return alphabet;
    }

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="other">
    /// The other frequency dictionary.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool Equals(FrequencyDictionary other)
    {
        if (other.Count != words.Count)
        {
            return false;
        }

        for (int index = 0; index < Count; index++)
        {
            if (!other.Contains(GetWord(index)))
            {
                return false;
            }
        }

        return true;
    }
}
