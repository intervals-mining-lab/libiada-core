using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Extended;

namespace TestSegmentation.Classes
{
    [TestFixture]
    public class FrequencyDictionaryTest
    {
        private ComplexChain chain = new ComplexChain("AACAGGTGCCCCTTATTT");

        [Test]
        public void testPut()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            String word = "string";
            String unknown = "WOW";
            int pos = 20;
            alphabet.put(word, pos);

            Assert.True(alphabet.contains(word));
            Assert.True(!alphabet.contains(unknown));
        }

        [Test]
        public void testContains()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            String[] words = { "A", "G", "C", "T", "WORD", "AG" };
            Assert.True(alphabet.contains(words[0]));
            Assert.True(alphabet.contains(words[1]));
            Assert.True(alphabet.contains(words[2]));
            Assert.True(alphabet.contains(words[3]));
            Assert.True(!alphabet.contains(words[4]));
            Assert.True(!alphabet.contains(words[5]));
        }

        [Test]
        public void testGet()
        {                                     //AACAGGTGCCCCTTATTT
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            String[] words = { "A", "G", "C", "T", "WORD", "AG" };
            int[] positionsA = { 0, 1, 3, 14 };
            int[] positionsG = { 4, 5, 7 };
            int[] positionsC = { 2, 8, 9, 10, 11 };
            int[] positionsT = { 6, 12, 13, 15, 16, 17 };
            Helper.ArraysEqual(positionsA, alphabet.get(words[0]).ToArray());
            Assert.True(Helper.ArraysEqual(positionsA, alphabet.get(words[0]).ToArray()));
            Assert.True(Helper.ArraysEqual(positionsG, alphabet.get(words[1]).ToArray()));
            Assert.True(Helper.ArraysEqual(positionsC, alphabet.get(words[2]).ToArray()));
            Assert.True(Helper.ArraysEqual(positionsT, alphabet.get(words[3]).ToArray()));
        }

        [Test]
        public void testRemove()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            String[] words = { "A", "G", "C", "T", "WORD", "AG" };
            alphabet.remove(words[0]);
            Assert.True(!alphabet.contains(words[0]));
            alphabet.remove(words[1]);
            Assert.True(!alphabet.contains(words[1]));
            alphabet.remove(words[2]);
            Assert.True(!alphabet.contains(words[2]));
            alphabet.remove(words[3]);
            Assert.True(!alphabet.contains(words[3]));
            Assert.True(alphabet.power() == 0);
        }

        [Test]
        public void testGetWords()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            String[] words = { "A", "G", "C", "T" };
            List<String> alphabetWords = alphabet.getWords();
            Assert.True(!words.Except(alphabetWords).Any());

        }

        [Test]
        public void testFill1()
        {
            String str = chain.ToString();
            FrequencyDictionary alphabet1 = new FrequencyDictionary(str);
            FrequencyDictionary alphabet2 = new FrequencyDictionary(chain);
            Assert.True(alphabet1.Equals(alphabet2));


        }

        [Test]
        public void testFill2()
        {
            testFill1();
        }

        [Test]
        public void testPower()
        {
            FrequencyDictionary alphabetChain = new FrequencyDictionary(chain);
            int power = 4;
            Assert.True(alphabetChain.power() == power);
            Assert.True(FrequencyDictionary.power(chain.GetUniformChain(0)) == 1);
        }

        [Test]
        public void testClear()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            alphabet.clear();
            Assert.True(alphabet.power() == 0);
        }

        [Test]
        public void testAdd()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary();
            FrequencyDictionary alphabetTest = new FrequencyDictionary(chain);
            String[] words = { "A", "G", "C", "T" };
            int power = 1;
            alphabet.add(words[0], alphabetTest.get(words[0]));
            alphabet.add(words[0], alphabetTest.get(words[0]));
            Assert.True(alphabet.contains(words[0]) && alphabet.power() == power);
        }

        [Test]
        public void testClone()
        {
            String str = chain.ToString();
            FrequencyDictionary alphabet1 = new FrequencyDictionary(str);
            FrequencyDictionary alphabet2 = new FrequencyDictionary(chain);
            FrequencyDictionary alphabet3 = (FrequencyDictionary)alphabet2.Clone();
            Assert.True(alphabet1.Equals(alphabet2) && alphabet3.Equals(alphabet1));
        }

        [Test]
        public void testEquals()
        {
            String str = chain.ToString();
            FrequencyDictionary alphabet1 = new FrequencyDictionary(str);
            FrequencyDictionary alphabet2 = new FrequencyDictionary(chain);
            Assert.True(alphabet1.Equals(alphabet2));
            alphabet1.remove(alphabet1.getWord(1));
            Assert.True(!alphabet1.Equals(alphabet2));

        }

        [Test]
        public void testGetWord()
        {
            FrequencyDictionary alphabet = new FrequencyDictionary(chain);
            for (int index = 0; index < alphabet.power(); index++)
            {
                Assert.True(alphabet.contains(alphabet.getWord(index)));
            }

        } 
    }
}