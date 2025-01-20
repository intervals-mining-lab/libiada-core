namespace Libiada.Segmenter.Tests.Base.Collectors;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Extended;

/// <summary>
/// The frequency dictionary test.
/// </summary>
[TestFixture]
public class FrequencyDictionaryTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private readonly ComplexSequence sequence = new("AACAGGTGCCCCTTATTT");

    /// <summary>
    /// The put test.
    /// </summary>
    [Test]
    public void PutTest()
    {
        FrequencyDictionary alphabet = new(sequence);
        const string word = "string";
        const string unknown = "WOW";
        const int pos = 20;
        alphabet.Put(word, pos);

        Assert.Multiple(() =>
        {
            Assert.That(alphabet.Contains(word));
            Assert.That(!alphabet.Contains(unknown));
        });
    }

    /// <summary>
    /// The contains test.
    /// </summary>
    [Test]
    public void ContainsTest()
    {
        FrequencyDictionary alphabet = new(sequence);
        string[] words = ["A", "G", "C", "T", "WORD", "AG"];
        Assert.Multiple(() =>
        {
            Assert.That(alphabet.Contains(words[0]));
            Assert.That(alphabet.Contains(words[1]));
            Assert.That(alphabet.Contains(words[2]));
            Assert.That(alphabet.Contains(words[3]));
            Assert.That(!alphabet.Contains(words[4]));
            Assert.That(!alphabet.Contains(words[5]));
        });
    }

    /// <summary>
    /// The get test.
    /// </summary>
    [Test]
    public void GetTest()
    {
        // AACAGGTGCCCCTTATTT
        FrequencyDictionary alphabet = new(sequence);
        string[] words = ["A", "G", "C", "T", "WORD", "AG"];
        int[] positionsA = [0, 1, 3, 14];
        int[] positionsG = [4, 5, 7];
        int[] positionsC = [2, 8, 9, 10, 11];
        int[] positionsT = [6, 12, 13, 15, 16, 17];
        
        Assert.Multiple(() =>
        {
            Assert.That(Helper.ArraysEqual(positionsA, alphabet[words[0]].ToArray()));
            Assert.That(Helper.ArraysEqual(positionsG, alphabet[words[1]].ToArray()));
            Assert.That(Helper.ArraysEqual(positionsC, alphabet[words[2]].ToArray()));
            Assert.That(Helper.ArraysEqual(positionsT, alphabet[words[3]].ToArray()));
        });
    }

    /// <summary>
    /// The remove test.
    /// </summary>
    [Test]
    public void RemoveTest()
    {
        FrequencyDictionary alphabet = new(sequence);
        string[] words = ["A", "G", "C", "T", "WORD", "AG"];
        alphabet.Remove(words[0]);
        Assert.That(!alphabet.Contains(words[0]));
        alphabet.Remove(words[1]);
        Assert.That(!alphabet.Contains(words[1]));
        alphabet.Remove(words[2]);
        Assert.That(!alphabet.Contains(words[2]));
        alphabet.Remove(words[3]);
        Assert.That(!alphabet.Contains(words[3]));
        Assert.That(alphabet.Count, Is.EqualTo(0));
    }

    /// <summary>
    /// The get words test.
    /// </summary>
    [Test]
    public void GetWordsTest()
    {
        FrequencyDictionary alphabet = new(sequence);
        string[] words = ["A", "G", "C", "T"];
        List<string> alphabetWords = alphabet.GetWords();
        Assert.That(!words.Except(alphabetWords).Any());
    }

    /// <summary>
    /// The fill one test.
    /// </summary>
    [Test]
    public void FillOneTest()
    {
        string str = sequence.ToString();
        FrequencyDictionary alphabet1 = new(str);
        FrequencyDictionary alphabet2 = new(sequence);
        Assert.That(alphabet1, Is.EqualTo(alphabet2));
    }

    /// <summary>
    /// The fill two test.
    /// </summary>
    [Test]
    public void FillTwoTest()
    {
        FillOneTest();
    }

    /// <summary>
    /// The power test.
    /// </summary>
    [Test]
    public void PowerTest()
    {
        FrequencyDictionary alphabetSequence = new(sequence);
        const int power = 4;
        Assert.That(alphabetSequence.Count, Is.EqualTo(power));
    }

    /// <summary>
    /// The clear test.
    /// </summary>
    [Test]
    public void ClearTest()
    {
        FrequencyDictionary alphabet = new(sequence);
        alphabet.Clear();
        Assert.That(alphabet.Count, Is.EqualTo(0));
    }

    /// <summary>
    /// The add test.
    /// </summary>
    [Test]
    public void AddTest()
    {
        FrequencyDictionary alphabet = new();
        FrequencyDictionary alphabetTest = new(sequence);
        string[] words = ["A", "G", "C", "T"];
        const int power = 1;
        alphabet.Add(words[0], alphabetTest[words[0]]);
        alphabet.Add(words[0], alphabetTest[words[0]]);
        Assert.Multiple(() =>
        {
            Assert.That(alphabet.Contains(words[0]));
            Assert.That(alphabet.Count, Is.EqualTo(power));
        });
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        string str = sequence.ToString();
        FrequencyDictionary alphabet1 = new(str);
        FrequencyDictionary alphabet2 = new(sequence);
        FrequencyDictionary alphabet3 = alphabet2.Clone();
        Assert.Multiple(() =>
        {
            Assert.That(alphabet1, Is.EqualTo(alphabet2));
            Assert.That(alphabet3, Is.EqualTo(alphabet1));
        });
    }

    /// <summary>
    /// The equals test.
    /// </summary>
    [Test]
    public void EqualsTest()
    {
        string str = sequence.ToString();
        FrequencyDictionary alphabet1 = new(str);
        FrequencyDictionary alphabet2 = new(sequence);
        Assert.That(alphabet1, Is.EqualTo(alphabet2));
        alphabet1.Remove(alphabet1.GetWord(1));
        Assert.That(alphabet1, Is.Not.EqualTo(alphabet2));
    }

    /// <summary>
    /// The get word test.
    /// </summary>
    [Test]
    public void GetWordTest()
    {
        FrequencyDictionary alphabet = new(sequence);
        for (int index = 0; index < alphabet.Count; index++)
        {
            Assert.That(alphabet.Contains(alphabet.GetWord(index)));
        }
    }
}
