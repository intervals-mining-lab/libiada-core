namespace PhantomChains.Tests.Statistics.MarkovChain
{
    using System;

    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Misc.SpaceReorganizers;
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Absolute;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Probability;

    /// <summary>
    /// The iteration matrix tests.
    /// </summary>
    [TestFixture]
    public class IterationMatrixTests
    {
        /// <summary>
        /// The test chain.
        /// </summary>
        private Chain testChain;

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
            this.alphabet = new Alphabet();
            this.a = new ValueChar('a');
            this.b = new ValueChar('b');
            this.c = new ValueChar('c');
            this.d = new ValueChar('d');
            this.f = new ValueChar('f');

            this.testChain = new Chain(12);
            this.testChain.Add((ValueString)"a", 0);
            this.testChain.Add((ValueString)"d", 1);
            this.testChain.Add((ValueString)"b", 2);
            this.testChain.Add((ValueString)"a", 3);
            this.testChain.Add((ValueString)"a", 4);
            this.testChain.Add((ValueString)"c", 5);
            this.testChain.Add((ValueString)"b", 6);
            this.testChain.Add((ValueString)"b", 7);
            this.testChain.Add((ValueString)"a", 8);
            this.testChain.Add((ValueString)"a", 9);
            this.testChain.Add((ValueString)"c", 10);
            this.testChain.Add((ValueString)"a", 11);
        }

        /// <summary>
        /// The add length more than chain rang test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLengthMoreThanChainRangTest()
        {
            this.alphabet.Add(this.a);
            this.alphabet.Add(this.b);
            this.alphabet.Add(this.c);
            this.alphabet.Add(this.d);

            this.ch = new BaseChain(3);

            this.ch.Add(this.a, 0);
            this.ch.Add(this.b, 1);
            this.ch.Add(this.b, 2);

            this.matrix = new Matrix(this.alphabet.Cardinality, 2);
            var arrayCh = new int[this.ch.Length];
            arrayCh[0] = this.alphabet.IndexOf(this.ch[0]);
            arrayCh[1] = this.alphabet.IndexOf(this.ch[1]);
            arrayCh[2] = this.alphabet.IndexOf(this.ch[2]);
            this.matrix.Add(arrayCh);
        }

        /// <summary>
        /// The get with indexes test.
        /// </summary>
        [Test]
        public void GetWithIndexesTest() 
        {
            this.alphabet.Add(this.a); // 0 => a
            this.alphabet.Add(this.b); // 1 => b
            this.alphabet.Add(this.c); // 2 => c
            this.alphabet.Add(this.d); // 3 => d

            this.ch = new BaseChain(2);
            var ch1 = new BaseChain(2);
            var ch2 = new BaseChain(2);
            var ch3 = new BaseChain(2);

            var ch4 = new BaseChain(2);
            var ch5 = new BaseChain(1);
            var ch6 = new BaseChain(1);
            var ch7 = new BaseChain(1);

            this.ch.Add(this.a, 0);
            this.ch.Add(this.b, 1);

            ch1.Add(this.c, 0);
            ch1.Add(this.b, 1);

            ch2.Add(this.b, 0);
            ch2.Add(this.a, 1);

            ch3.Add(this.b, 0);
            ch3.Add(this.c, 1);

            this.matrix = new Matrix(this.alphabet.Cardinality, 2);

            var arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch1[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch1[1]);
            this.matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch2[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch2[1]);
            this.matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(this.ch[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(this.ch[1]);
            this.matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch3[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch3[1]);
            this.matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch1[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch1[1]);
            this.matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch3[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch3[1]);
            this.matrix.Add(arrayToTeach);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch1[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch1[1]);
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(arrayToTeach));

            ch4.Add(this.a, 0);
            ch4.Add(this.c, 1);

            arrayToTeach = new int[2];
            arrayToTeach[0] = this.alphabet.IndexOf(ch4[0]);
            arrayToTeach[1] = this.alphabet.IndexOf(ch4[1]);
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(arrayToTeach));

            ch5.Add(this.b, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = this.alphabet.IndexOf(ch5[0]);
            Assert.AreEqual(3, this.matrix.FrequencyFromObject(arrayToTeach));

            ch6.Add(this.a, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = this.alphabet.IndexOf(ch6[0]);
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(arrayToTeach));

            ch7.Add(this.c, 0);

            arrayToTeach = new int[1];
            arrayToTeach[0] = this.alphabet.IndexOf(ch7[0]);
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(arrayToTeach));
        }

        /// <summary>
        /// The get third level chain test.
        /// </summary>
        [Test]
        public void GetThirdLevelChainTest()
        {
            this.matrix = new Matrix(this.testChain.Alphabet.Cardinality, 3);

            var reorganizer = new NullCycleSpaceReorganizer<Chain, Chain>(2);
            this.testChain = reorganizer.Reorganize(this.testChain);

            var it = new IteratorStart<Chain, Chain>(this.testChain, 3, 1);
            while (it.Next())
            {
                var chain = it.Current();
                var arrayToTeach = new int[chain.Length];
                for (var i = 0; i < chain.Length; i++)
                {
                    arrayToTeach[i] = this.testChain.Alphabet.IndexOf(chain[i]);
                }

                this.matrix.Add(arrayToTeach);
            }

            var toGet = new int[1];

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(6, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(3, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet = new int[2];

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(3, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet = new int[3];

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, this.matrix.FrequencyFromObject(toGet));
        }

        /// <summary>
        /// The get probability matrix test.
        /// </summary>
        [Test]
        public void GetProbabilityMatrixTest()
        {
            this.matrix = new Matrix(this.testChain.Alphabet.Cardinality, 3);

            var reorganizer = new NullCycleSpaceReorganizer<Chain, Chain>(2);
            this.testChain = reorganizer.Reorganize(this.testChain);

            var it = new IteratorStart<Chain, Chain>(this.testChain, 3, 1);
            while (it.Next())
            {
                var chain = it.Current();
                var arrayToTeach = new int[chain.Length];
                for (var i = 0; i < chain.Length; i++)
                {
                    arrayToTeach[i] = this.testChain.Alphabet.IndexOf(chain[i]);
                }

                this.matrix.Add(arrayToTeach);
            }

            var probabilityMatrix = (ProbabilityMatrix)this.matrix.ProbabilityMatrix();

            var toGet = new int[1];

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.25, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(1 / (double)6, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)12, probabilityMatrix.FrequencyFromObject(toGet));

            toGet = new int[2];

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(1 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)6, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet = new int[3];

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)3, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));

            toGet[0] = this.testChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = this.testChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, probabilityMatrix.FrequencyFromObject(toGet));
        }

        /// <summary>
        /// The larger n test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LargerNTest()
        {
            this.alphabet.Add(this.a);
            this.alphabet.Add(this.b);
            this.alphabet.Add(this.c);
            this.alphabet.Add(this.d);

            this.ch = new BaseChain(2);
            this.ch.Add(this.f, 0);
            this.ch.Add(this.c, 1);

            this.matrix = new Matrix(this.alphabet.Cardinality, 2);
            var array = new int[this.ch.Length];
            array[0] = this.alphabet.IndexOf(this.ch[0]);
            array[1] = this.alphabet.IndexOf(this.ch[1]);
            this.matrix.FrequencyFromObject(array);
        }
    }
}