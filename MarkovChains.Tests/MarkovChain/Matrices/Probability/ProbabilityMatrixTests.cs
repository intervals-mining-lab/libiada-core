namespace MarkovChains.Tests.MarkovChain.Matrices.Probability
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
    public class ProbabilityMatrixTests
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
        private ValueString a;

        /// <summary>
        /// The b.
        /// </summary>
        private ValueString b;

        /// <summary>
        /// The c.
        /// </summary>
        private ValueString c;

        /// <summary>
        /// The d.
        /// </summary>
        private ValueString d;

        /// <summary>
        /// The f.
        /// </summary>
        private ValueString f;

        /// <summary>
        /// The base chain.
        /// </summary>
        private BaseChain baseChain;

        /// <summary>
        /// The matrix.
        /// </summary>
        private Matrix matrix;

        /// <summary>
        /// The initialization method.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            alphabet = new Alphabet();
            a = new ValueString('a');
            b = new ValueString('b');
            c = new ValueString('c');
            d = new ValueString('d');
            f = new ValueString('f');

            testChain = new Chain(12);
            testChain.Set((ValueString)"a", 0);
            testChain.Set((ValueString)"d", 1);
            testChain.Set((ValueString)"b", 2);
            testChain.Set((ValueString)"a", 3);
            testChain.Set((ValueString)"a", 4);
            testChain.Set((ValueString)"c", 5);
            testChain.Set((ValueString)"b", 6);
            testChain.Set((ValueString)"b", 7);
            testChain.Set((ValueString)"a", 8);
            testChain.Set((ValueString)"a", 9);
            testChain.Set((ValueString)"c", 10);
            testChain.Set((ValueString)"a", 11);
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

            baseChain = new BaseChain(3);

            baseChain.Set(a, 0);
            baseChain.Set(b, 1);
            baseChain.Set(b, 2);

            matrix = new Matrix(alphabet.Cardinality, 2);
            var arrayCh = new int[baseChain.GetLength()];
            arrayCh[0] = alphabet.IndexOf(baseChain[0]);
            arrayCh[1] = alphabet.IndexOf(baseChain[1]);
            arrayCh[2] = alphabet.IndexOf(baseChain[2]);
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

            baseChain = new BaseChain(2);
            var ch1 = new BaseChain(2);
            var ch2 = new BaseChain(2);
            var ch3 = new BaseChain(2);

            var ch4 = new BaseChain(2);
            var ch5 = new BaseChain(1);
            var ch6 = new BaseChain(1);
            var ch7 = new BaseChain(1);

            baseChain.Set(a, 0);
            baseChain.Set(b, 1);

            ch1.Set(c, 0);
            ch1.Set(b, 1);

            ch2.Set(b, 0);
            ch2.Set(a, 1);

            ch3.Set(b, 0);
            ch3.Set(c, 1);

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
            arrayToTeach[0] = alphabet.IndexOf(baseChain[0]);
            arrayToTeach[1] = alphabet.IndexOf(baseChain[1]);
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

            ch4.Set(a, 0);
            ch4.Set(c, 1);

            arrayToTeach = new int[2];
            arrayToTeach[0] = alphabet.IndexOf(ch4[0]);
            arrayToTeach[1] = alphabet.IndexOf(ch4[1]);
            Assert.AreEqual(0, matrix.FrequencyFromObject(arrayToTeach));

            ch5.Set(b, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = alphabet.IndexOf(ch5[0]);
            Assert.AreEqual(3, matrix.FrequencyFromObject(arrayToTeach));

            ch6.Set(a, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = alphabet.IndexOf(ch6[0]);
            Assert.AreEqual(1, matrix.FrequencyFromObject(arrayToTeach));

            ch7.Set(c, 0);

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

            baseChain = new BaseChain(2);
            baseChain.Set(f, 0);
            baseChain.Set(c, 1);

            matrix = new Matrix(alphabet.Cardinality, 2);
            var array = new int[baseChain.GetLength()];
            array[0] = alphabet.IndexOf(baseChain[0]);
            array[1] = alphabet.IndexOf(baseChain[1]);
            matrix.FrequencyFromObject(array);
        }
    }
}
