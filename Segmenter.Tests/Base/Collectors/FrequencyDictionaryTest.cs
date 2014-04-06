namespace Segmenter.Tests.Base.Collectors
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequencies;
    using Segmenter.Extended;

    [TestFixture]
    public class FrequencyDictionaryTest
    {
        private ComplexChain chain = new ComplexChain("AACAGGTGCCCCTTATTT");

        [Test]
        public void PutTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            string word = "string";
            string unknown = "WOW";
            int pos = 20;
            alphabet.Put(word, pos);

            Assert.True(alphabet.Contains(word));
            Assert.True(!alphabet.Contains(unknown));
        }

        [Test]
        public void ContainsTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            string[] words = { "A", "G", "C", "T", "WORD", "AG" };
            Assert.True(alphabet.Contains(words[0]));
            Assert.True(alphabet.Contains(words[1]));
            Assert.True(alphabet.Contains(words[2]));
            Assert.True(alphabet.Contains(words[3]));
            Assert.True(!alphabet.Contains(words[4]));
            Assert.True(!alphabet.Contains(words[5]));
        }

        [Test]
        public void GetTest()
        {                                     
            // AACAGGTGCCCCTTATTT
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            string[] words = { "A", "G", "C", "T", "WORD", "AG" };
            int[] positionsA = { 0, 1, 3, 14 };
            int[] positionsG = { 4, 5, 7 };
            int[] positionsC = { 2, 8, 9, 10, 11 };
            int[] positionsT = { 6, 12, 13, 15, 16, 17 };
            Helper.ArraysEqual(positionsA, alphabet[words[0]].ToArray());
            Assert.True(Helper.ArraysEqual(positionsA, alphabet[words[0]].ToArray()));
            Assert.True(Helper.ArraysEqual(positionsG, alphabet[words[1]].ToArray()));
            Assert.True(Helper.ArraysEqual(positionsC, alphabet[words[2]].ToArray()));
            Assert.True(Helper.ArraysEqual(positionsT, alphabet[words[3]].ToArray()));
        }

        [Test]
        public void RemoveTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            string[] words = { "A", "G", "C", "T", "WORD", "AG" };
            alphabet.Remove(words[0]);
            Assert.True(!alphabet.Contains(words[0]));
            alphabet.Remove(words[1]);
            Assert.True(!alphabet.Contains(words[1]));
            alphabet.Remove(words[2]);
            Assert.True(!alphabet.Contains(words[2]));
            alphabet.Remove(words[3]);
            Assert.True(!alphabet.Contains(words[3]));
            Assert.True(alphabet.Count == 0);
        }

        [Test]
        public void GetWordsTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            string[] words = { "A", "G", "C", "T" };
            List<string> alphabetWords = alphabet.GetWords();
            Assert.True(!words.Except(alphabetWords).Any());
        }

        [Test]
        public void FillOneTest()
        {
            string str = this.chain.ToString();
            FrequencyDictionary alphabet1 = new FrequencyDictionary(str);
            FrequencyDictionary alphabet2 = new FrequencyDictionary(this.chain);
            Assert.True(alphabet1.Equals(alphabet2));
        }

        [Test]
        public void FillTwoTest()
        {
            this.FillOneTest();
        }

        [Test]
        public void PowerTest()
        {
            FrequencyDictionary alphabetChain = new FrequencyDictionary(this.chain);
            int power = 4;
            Assert.True(alphabetChain.Count == power);
        }

        [Test]
        public void ClearTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            alphabet.Clear();
            Assert.True(alphabet.Count == 0);
        }

        [Test]
        public void AddTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary();
            FrequencyDictionary alphabetTest = new FrequencyDictionary(this.chain);
            string[] words = { "A", "G", "C", "T" };
            int power = 1;
            alphabet.Add(words[0], alphabetTest[words[0]]);
            alphabet.Add(words[0], alphabetTest[words[0]]);
            Assert.True(alphabet.Contains(words[0]) && alphabet.Count == power);
        }

        [Test]
        public void CloneTest()
        {
            string str = this.chain.ToString();
            FrequencyDictionary alphabet1 = new FrequencyDictionary(str);
            FrequencyDictionary alphabet2 = new FrequencyDictionary(this.chain);
            FrequencyDictionary alphabet3 = alphabet2.Clone();
            Assert.True(alphabet1.Equals(alphabet2) && alphabet3.Equals(alphabet1));
        }

        [Test]
        public void EqualsTest()
        {
            string str = this.chain.ToString();
            FrequencyDictionary alphabet1 = new FrequencyDictionary(str);
            FrequencyDictionary alphabet2 = new FrequencyDictionary(this.chain);
            Assert.True(alphabet1.Equals(alphabet2));
            alphabet1.Remove(alphabet1.GetWord(1));
            Assert.True(!alphabet1.Equals(alphabet2));
        }

        [Test]
        public void GetWordTest()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(this.chain);
            for (int index = 0; index < alphabet.Count; index++)
            {
                Assert.True(alphabet.Contains(alphabet.GetWord(index)));
            }
        } 
    }
}