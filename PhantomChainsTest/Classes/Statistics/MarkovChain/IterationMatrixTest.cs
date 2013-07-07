using System;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;
using NUnit.Framework;

namespace PhantomChainsTest.Classes.Statistics.MarkovChain
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class IterationMatrixTest
    {
        private Chain TestChain;
        private Alphabet alph;
        private ValueChar a;
        private ValueChar b;
        private ValueChar c;
        private ValueChar d;
        private ValueChar f;
        private BaseChain ch;
        private Matrix matr;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            alph = new Alphabet();
            a = new ValueChar('a');
            b = new ValueChar('b');
            c = new ValueChar('c');
            d = new ValueChar('d');
            f = new ValueChar('f');

            TestChain = new Chain(12);
            TestChain.Add((ValueString)"a", 0);
            TestChain.Add((ValueString)"d", 1);
            TestChain.Add((ValueString)"b", 2);
            TestChain.Add((ValueString)"a", 3);
            TestChain.Add((ValueString)"a", 4);
            TestChain.Add((ValueString)"c", 5);
            TestChain.Add((ValueString)"b", 6);
            TestChain.Add((ValueString)"b", 7);
            TestChain.Add((ValueString)"a", 8);
            TestChain.Add((ValueString)"a", 9);
            TestChain.Add((ValueString)"c", 10);
            TestChain.Add((ValueString)"a", 11);
        }

        ///<summary>
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void AddLengthMoreThanChainRangTest()
        {
            alph.Add(a);
            alph.Add(b);
            alph.Add(c);
            alph.Add(d);

            ch = new BaseChain(3);

            ch.Add(a, 0);
            ch.Add(b, 1);
            ch.Add(b, 2);

            matr = new Matrix(alph.Power, 2);
            int[] arrayCh = new int[ch.Length];
            arrayCh[0] = alph.IndexOf(ch[0]);
            arrayCh[1] = alph.IndexOf(ch[1]);
            arrayCh[2] = alph.IndexOf(ch[2]);
            matr.Add(arrayCh);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void GetWithIndexesTest()
        {
            alph.Add(a); // 0 => a
            alph.Add(b); // 1 => b
            alph.Add(c); // 2 => c
            alph.Add(d); // 3 => d

                      ch = new BaseChain(2);
            BaseChain ch1 = new BaseChain(2); 
            BaseChain ch2 = new BaseChain(2); 
            BaseChain ch3 = new BaseChain(2); 

            
            BaseChain ch4 = new BaseChain(2);
            BaseChain ch5 = new BaseChain(1); 
            BaseChain ch6 = new BaseChain(1);
            BaseChain ch7 = new BaseChain(1); 

            ch.Add(a, 0);  
            ch.Add(b, 1);  

            ch1.Add(c, 0); 
            ch1.Add(b, 1); 


            ch2.Add(b, 0); 
            ch2.Add(a, 1); 


            ch3.Add(b, 0);
            ch3.Add(c, 1);



            matr = new Matrix(alph.Power, 2);

            int[] arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch1[0]);
            arrayToTeach[1] = alph.IndexOf(ch1[1]);
            matr.Add(arrayToTeach);  

            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch2[0]);
            arrayToTeach[1] = alph.IndexOf(ch2[1]);
            matr.Add(arrayToTeach); 

            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch[0]);
            arrayToTeach[1] = alph.IndexOf(ch[1]);
            matr.Add(arrayToTeach); 


            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch3[0]);
            arrayToTeach[1] = alph.IndexOf(ch3[1]);
            matr.Add(arrayToTeach); 

            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch1[0]);
            arrayToTeach[1] = alph.IndexOf(ch1[1]);
            matr.Add(arrayToTeach); 



            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch3[0]);
            arrayToTeach[1] = alph.IndexOf(ch3[1]);
            matr.Add(arrayToTeach); 

            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch1[0]);
            arrayToTeach[1] = alph.IndexOf(ch1[1]);
            Assert.AreEqual(2, matr.FrequencyFromObject(arrayToTeach));


            ch4.Add(a, 0); 
            ch4.Add(c, 1);


            arrayToTeach = new int[2];
            arrayToTeach[0] = alph.IndexOf(ch4[0]);
            arrayToTeach[1] = alph.IndexOf(ch4[1]);
            Assert.AreEqual(0, matr.FrequencyFromObject(arrayToTeach));


            ch5.Add(b, 0);


            arrayToTeach = new int[1];
            arrayToTeach[0] = alph.IndexOf(ch5[0]);
            Assert.AreEqual(3, matr.FrequencyFromObject(arrayToTeach));

            ch6.Add(a, 0); 


            arrayToTeach = new int[1];
            arrayToTeach[0] = alph.IndexOf(ch6[0]);
            Assert.AreEqual(1, matr.FrequencyFromObject(arrayToTeach));

            ch7.Add(c, 0); 

            arrayToTeach = new int[1];
            arrayToTeach[0] = alph.IndexOf(ch7[0]);
            Assert.AreEqual(2, matr.FrequencyFromObject(arrayToTeach));
        }



        ///<summary>
        ///</summary>
        [Test]
        public void GetThirdLevelChainTest()
        {
            matr = new Matrix(TestChain.Alphabet.Power, 3);

            PsevdoCycleSpaceRebuilder<Chain, Chain> rebuilder = new PsevdoCycleSpaceRebuilder<Chain, Chain>(2);
            TestChain = rebuilder.Rebuild(TestChain);

            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(TestChain, 3, 1);
            while(it.Next())
            {
                Chain chain = it.Current();
                int[] arrayToTeach = new int[chain.Length];
                for (int i = 0; i < chain.Length; i++)
                {
                    arrayToTeach[i] = TestChain.Alphabet.IndexOf(chain[i]);
                }
                matr.Add(arrayToTeach);
            }

            int[] toGet = new int[1];

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(6, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(3, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet = new int[2];

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(3, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet = new int[3];

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(toGet));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void GetPropabilityMatixTest()
        {
            matr = new Matrix(TestChain.Alphabet.Power, 3);

            PsevdoCycleSpaceRebuilder<Chain, Chain> rebuilder = new PsevdoCycleSpaceRebuilder<Chain, Chain>(2);
            TestChain = rebuilder.Rebuild(TestChain);

            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(TestChain, 3, 1);
            while (it.Next())
            {
                Chain chain = it.Current();
                int[] arrayToTeach = new int[chain.Length];
                for (int i = 0; i < chain.Length; i++)
                {
                    arrayToTeach[i] = TestChain.Alphabet.IndexOf(chain[i]);
                }
                matr.Add(arrayToTeach);
            }

            ProbabilityMatrix pMatrix = (ProbabilityMatrix) matr.ProbabilityMatrix();

            int[] toGet = new int[1];

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.25, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(1/(double)6, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)12, pMatrix.FrequencyFromObject(toGet));

            toGet = new int[2];

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(1 / (double)3, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)6, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(2 / (double)3, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1 / (double)3, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet = new int[3];

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(2 / (double)3, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)3, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"a");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"c");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

            toGet[0] = TestChain.Alphabet.IndexOf((ValueString)"d");
            toGet[1] = TestChain.Alphabet.IndexOf((ValueString)"b");
            toGet[2] = TestChain.Alphabet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, pMatrix.FrequencyFromObject(toGet));

        }

        ///<summary>
        ///</summary>
        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void ILargerNTest()
        {
            alph.Add(a);
            alph.Add(b);
            alph.Add(c);
            alph.Add(d);

            ch = new BaseChain(2);
            ch.Add(f, 0);
            ch.Add(c, 1);

            matr = new Matrix(alph.Power, 2);
            int[] array = new int[ch.Length];
            array[0] = alph.IndexOf(ch[0]);
            array[1] = alph.IndexOf(ch[1]);
            matr.FrequencyFromObject(array);
        }
    }
}