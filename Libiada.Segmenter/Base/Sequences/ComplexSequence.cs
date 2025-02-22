namespace Libiada.Segmenter.Base.Sequences;

using System.Text;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The complex sequence.
/// </summary>
public class ComplexSequence : ComposedSequence
{
    /// <summary>
    /// The anchor.
    /// </summary>
    public Link Anchor = Link.Start;

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplexSequence"/> class.
    /// </summary>
    /// <param name="accord">
    /// The accord.
    /// </param>
    public ComplexSequence(List<int> accord)
    {
        for (int i = 0; i < accord.Count; i++)
        {
            Set(new ValueInt(accord[i]), i);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplexSequence"/> class.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public ComplexSequence(string sequence)
        : base(sequence)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplexSequence"/> class.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public ComplexSequence(List<string> sequence)
        : base(sequence.Count)
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            Set(new ValueString(sequence[i]), i);
        }
    }

    /// <summary>
    /// The substring.
    /// </summary>
    /// <param name="beginIndex">
    /// The begin index.
    /// </param>
    /// <param name="endIndex">
    /// The end index.
    /// </param>
    /// <returns>
    /// The <see cref="List{string}"/>.
    /// </returns>
    public List<string> Substring(int beginIndex, int endIndex)
    {
        List<string> sequence = null;
        try
        {
            sequence = new List<string>(ToList().GetRange(beginIndex, endIndex - beginIndex));
        }
        catch (Exception)
        {
        }

        return sequence;
    }

    /// <summary>
    /// The to list.
    /// </summary>
    /// <returns>
    /// The <see cref="List{string}"/>.
    /// </returns>
    public List<string> ToList()
    {
        List<string> result = new(Length);
        for (int i = 0; i < Length; i++)
        {
            result.Add(this[i].ToString());
        }

        return result;
    }

    /// <summary>
    /// The clear at.
    /// </summary>
    /// <param name="index">
    /// The index.
    /// </param>
    public override void DeleteAt(int index)
    {
        try
        {
            base.DeleteAt(index);
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The <see cref="ComplexSequence"/>.
    /// </returns>
    public new ComplexSequence Clone()
    {
        ComplexSequence sequence = new(ToList()) { Anchor = Anchor };

        return sequence;
    }

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="complexSequence">
    /// The complex sequence.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool Equals(ComplexSequence complexSequence)
    {
        if (complexSequence.Length != Length)
        {
            return false;
        }

        for (int index = 0; index < complexSequence.Length; index++)
        {
            if (!this[index].ToString().Equals(complexSequence[index].ToString()))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// The concat.
    /// </summary>
    /// <param name="str">
    /// The string.
    /// </param>
    /// <returns>
    /// The <see cref="ComplexSequence"/>.
    /// </returns>
    public ComplexSequence Concat(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return this;
        }

        ComplexSequence temp = Clone();
        ClearAndSetNewLength(Length + 1);
        for (int i = 0; i < temp.Length; i++)
        {
            this[i] = temp[i];
        }

        this[Length - 1] = new ValueString(str);
        return this;
    }

    /// <summary>
    /// The concat.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <returns>
    /// The <see cref="ComplexSequence"/>.
    /// </returns>
    public ComplexSequence Concat(ComplexSequence sequence)
    {
        if (sequence.IsEmpty())
        {
            return this;
        }

        ComplexSequence temp = Clone();

        ClearAndSetNewLength(Length + sequence.Length);
        for (int i = 0; i < temp.Length; i++)
        {
            this[i] = temp[i];
        }

        for (int j = 0; j < sequence.Length; j++)
        {
            this[j + temp.Length] = sequence[j];
        }

        return this;
    }

    /// <summary>
    /// The is empty.
    /// </summary>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool IsEmpty() => Length == 0;

    /// <summary>
    /// Cuts a range of words from position to position + len cursorPosition
    /// </summary>
    /// <param name="pos">start cursor position</param>
    /// <param name="len">count of words cut out</param>
    public void Remove(int pos, int len)
    {
        if ((pos + len) > Length)
        {
            return;
        }

        for (int index = pos; index < len + pos; index++)
        {
            DeleteAt(pos);
        }
    }

    /// <summary>
    /// Joins some elements of the sequence to whole composed string
    /// </summary>
    /// <param name="pos">cursorPosition in the sequence at which to begin the gluing</param>
    /// <param name="len">how many words need to join including first word</param>
    public void Join(int pos, int len)
    {
        int wordEnd = pos + len;
        StringBuilder temporarySplice = new();
        temporarySplice.Clear();
        if (wordEnd > Length)
        {
            return;
        }

        for (int index = pos; index < wordEnd; index++)
        {
            temporarySplice.Append(this[index]);
        }

        for (int i = 0; i < len - 1; i++)
        {
            DeleteAt(pos);
        }

        Set(new ValueString(temporarySplice.ToString()), pos);
    }

    /// <summary>
    /// The original.
    /// </summary>
    /// <returns>
    /// The <see cref="ComplexSequence"/>.
    /// </returns>
    public ComplexSequence Original()
    {
        return new ComplexSequence(ToString());
    }

    /// <summary>
    /// Joins all hits from the start of the sequence to whole composed string
    /// Very fast for long sequence, because there is no index check!
    /// </summary>
    /// <param name="word">
    /// list of letters to compose
    /// </param>
    public void JoinAll(List<string> word)
    {
        int length = word.Count;
        int index = 0;
        while (true)
        {
            try
            {
                if (ToList().GetRange(index, length - index).Equals(word))
                {
                    Join(index, length);
                }

                index++;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
