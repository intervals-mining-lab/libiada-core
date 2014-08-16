namespace MarkovChains.Tests.MarkovChain
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.Iterators;
    using LibiadaCore.Misc.SpaceReorganizers;

    using MarkovChains.MarkovChain.Matrices.Absolute;
    using MarkovChains.MarkovChain.Matrices.Probability;

    using NUnit.Framework;

    /// <summary>
    /// The iteration matrix tests.
    /// </summary>
    [TestFixture]
    public class IterationMatrixTests
    {
        /// <summary>
        /// The test chain.
        /// </summary>
        private BaseChain testChain;

        /// <summary>
        /// The alphabet.
        /// </summary>
        private Alphabet alphabet;

        /// <summary>
        /// The a.
        /// </summary>
        private ValueChar a;

        /// <summary>
        /// The b.
        /// </summary>
        private ValueChar b;

        /// <summary>
        /// The c.
        /// </summary>
        private ValueChar c;

        /// <summary>
        /// The d.
        /// </summary>
        private ValueChar d;

        /// <summary>
        /// The f.
        /// </summary>
        private ValueChar f;

        /// <summary>
        /// The ch.
        /// </summary>
        private BaseChain ch;

        /// <summary>
        /// The matrix.
        /// </summary>
        private Matrix matrix;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            alphabet = new Alphabet();
            a = new ValueChar('a');
            b = new ValueChar('b');
            c = new ValueChar('c');
            d = new ValueChar('d');
            f = new ValueChar('f');

            testChain = new Chain(12);
            testChain.Add((ValueString)"a", 0);
            testChain.Add((ValueString)"d", 1);
            testChain.Add((ValueString)"b", 2);
            testChain.Add((ValueString)"a", 3);
            testChain.Add((ValueString)"a", 4);
            testChain.Add((ValueString)"c", 5);
            testChain.Add((ValueString)"b", 6);
            testChain.Add((ValueString)"b", 7);
            testChain.Add((ValueString)"a", 8);
            testChain.Add((ValueString)"a", 9);
            testChain.Add((ValueString)"c", 10);
            testChain.Add((ValueString)"a", 11);
        }

        /// <summary>
        /// The add length more than chain rang test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLengthMoreThanChainRangTest()
        {
            alphabet.Add(a);
            alphabet.Add(b);
            alphabet.Add(c);
            alphabet.Add(d);

            ch = new BaseChain(3);

            ch.Add(a, 0);
            ch.Add(b, 1);
            ch.Add(b, 2);

            matrix = new Matrix(alphabet.Cardinality, 2);
            var arrayCh = new int[ch.GetLength()];
            arrayCh[0] = alphabet.IndexOf(ch[0]);
            arrayCh[1] = alphabet.IndexOf(ch[1]);
            arrayCh[2] = alphabet.IndexOf(ch[2]);
            matrix.Add(arrayCh);
        }

        /// <summary>
        /// The get with indexes test.
        /// </summary>
        [Test]
        public void GetWithIndexesTest() 
        {
            alphabet.Add(a); // 0 => a
            alphabet.Add(b); // 1 => b
            alphabet.Add(c); // 2 => c
            alphabet.Add(d); // 3 => d

            ch = new BaseChain(2);
            var ch1 = new BaseChain(2);
            var ch2 = new BaseChain(2);
            var ch3 = new BaseChain(2);

            var ch4 = new BaseChain(2);
            var ch5 = new BaseChain(1);
            var ch6 = new BaseChain(1);
            var ch7 = new BaseChain(1);

            ch.Add(a, 0);
            ch.Add(b, 1);

            ch1.Add(c, 0);
            ch1.Add(b, 1);

            ch2.Add(b, 0);
            ch2.Add(a, 1);

            ch3.Add(b, 0);
            ch3.Add(c, 1);

            matrix = new Matrix(alphabet.Cardinality, 2);

            var arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch1[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch1[1]);
            matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch2[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch2[1]);
            matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch[1]);
            matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch3[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch3[1]);
            matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch1[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch1[1]);
            matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch3[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch3[1]);
            matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch1[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch1[1]);
            Assert.AreEqual(2, matrix.FrequencyFromObject(arrayToTeach));

            ch4.Add(a, 0);
            ch4.Add(c, 1);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch4[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch4[1]);
            Assert.AreEqual(0, matrix.FrequencyFromObject(arrayToTeach));

            ch5.Add(b, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = alphabet.IndexOf(ch5[0]);
            Assert.AreEqual(3, matrix.FrequencyFromObject(arrayToTeach));

            ch6.Add(a, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = alphabet.IndexOf(ch6[0]);
            Assert.AreEqual(1, matrix.FrequencyFromObject(arrayToTeach));

            ch7.Add(c, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = alphabet.IndexOf(ch7[0]);
            Assert.AreEqual(2, matrix.FrequencyFromObject(arrayToTeach));
        }

        /// <summary>
        /// The get third level chain test.
        /// </summary>
        [Test]
        public void GetThirdLevelChainTest()
        {
            matrix = new Matrix(testChain.Alphabet.Cardinality, 3);

            var reorganizer = new NullCycleSpaceReorganizer(2);
            testChain = (BaseChain)reorganizer.Reorganize(testChain);

            var it = new IteratorStart(testChain, 3, 1);
            while (it.Next())
            {
                var chain = it.Current();
                var arrayToTeach = new int[chain.GetLength()];
                for (var i = 0; i < chain.GetLength(); i++)
                {
                    arrayToTeach[i] = testChain.Alphabet.IndexOf(chain[i]);
                }

                matrix.Add(arrayToTeach);
            }

            var toGet = new int[1];

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(6, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(3, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet = new int[2];

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(3, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet = new int[3];

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matrix.FrequencyFromObject(toGet));
        }

        /// <summary>
        /// The get probability matrix test.
        /// </summary>
        [Test]
        public void GetProbabilityMatrixTest()
        {
            matrix = new Matrix(testChain.Alphabet.Cardinality, 3);

            var reorganizer = new NullCycleSpaceReorganizer(2);
            testChain = (BaseChain)reorganizer.Reorganize(testChain);

            var it = new IteratorStart(testChain, 3, 1);
            while (it.Next())
            {
                var chain = it.Current();
                var arrayToTeach = new int[chain.GetLength()];
                for (var i = 0; i < chain.GetLength(); i++)
                {
                    arrayToTeach[i] = testChain.Alphabet.IndexOf(chain[i]);
                }

                matrix.Add(arrayToTeach);
            }

            var probabilityMatrix = (ProbabilityMatrix)matrix.ProbabilityMatrix();

            var toGet = new int[1];

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.25, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(1 / (double)6, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)12, probabilityMatrix.FrequencyFromObject(toGet));

            toGet = new int[2];

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(1 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)6, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet = new int[3];

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));
        }

        /// <summary>
        /// The larger n test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LargerNTest()
        {
            alphabet.Add(a);
            alphabet.Add(b);
            alphabet.Add(c);
            alphabet.Add(d);

            ch = new BaseChain(2);
            ch.Add(f, 0);
            ch.Add(c, 1);

            matrix = new Matrix(alphabet.Cardinality, 2);
            var array = new int[ch.GetLength()];
            array[0] = alphabet.IndexOf(ch[0]);
            array[1] = alphabet.IndexOf(ch[1]);
            matrix.FrequencyFromObject(array);
        }
    }
}