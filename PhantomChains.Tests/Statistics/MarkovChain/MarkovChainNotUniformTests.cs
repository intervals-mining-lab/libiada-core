namespace PhantomChains.Tests.Statistics.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    using global::PhantomChains.Statistics.MarkovChain;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    using global::PhantomChains.Tests.Statistics.MarkovChain.Generators;

    /// <summary>
    /// ��������� ������������ ���������� ���� 
    /// ������������ ���������� ���� ������������ ����� 
    /// ��������� ���������� ���������� ����� ������ �� ������� 
    /// ����������� �� ������������ ����
    /// </summary>
    [TestFixture]
    public class MarkovChainNotUniformTests
    {
        /// <summary>
        /// �������� ���� �� ������� ����� ����������� ��������
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// The test chain 2.
        /// </summary>
        private Chain testChain2;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            // ������� ���� ������� 12
            // |a|d|b|a|a|c|b|b|a|a|c|a|
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

            this.testChain2 = new Chain(12);
            this.testChain2.Add((ValueString)"a", 0);
            this.testChain2.Add((ValueString)"a", 1);
            this.testChain2.Add((ValueString)"a", 2);
            this.testChain2.Add((ValueString)"a", 3);
            this.testChain2.Add((ValueString)"a", 4);
            this.testChain2.Add((ValueString)"a", 5);
            this.testChain2.Add((ValueString)"b", 6);
            this.testChain2.Add((ValueString)"a", 7);
            this.testChain2.Add((ValueString)"a", 8);
            this.testChain2.Add((ValueString)"a", 9);
            this.testChain2.Add((ValueString)"b", 10);
            this.testChain2.Add((ValueString)"a", 11);
        }

        /// <summary>
        /// The markov chain not uniform zero rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformZeroRangTwoTest()
        {
            // ���������� ��������� ��������
            IGenerator generator = new MockGenerator();

            // ������� ���� 2 
            // ������ ��� ������ ������� ������� �� ������ �����������
            const int MarkovChainRang = 2;

            // �������������� 1 
            // ������������� ��������� ������� 2 ������ ��� ������ � �������� �������
            const int NoUniformRang = 0;

            // ������� ���������� ������ ��������� � ����, �������������� � ���������
            var markovChain = new MarkovChainNotUniformStatic(MarkovChainRang, NoUniformRang, generator);

            // ������ ������������ ����
            const int Length = 30;

            // ������� ���� 
            // TeachingMethod.None ������ �� ����� ��������������� ��������� ���� �� ����������
            markovChain.Teach(this.testChain2, TeachingMethod.Cycle);

            var temp = markovChain.Generate(Length);

            /* 
             * 1. ���� a a a a a a b a a a b a
             *   ������ ������� (����������� �����������)
             *   
             *    a| 10/12 (0,83333)  �� ����� 0,83333| 
             *    b| 2/12 (0,16667)  �� ����� 1|
             * 
             *   ������ ������� (�������� � ������ 1 ����������� ��������)
             * 
             *    |   a  |   b  |
             * ---|------|------|
             *  a |7/9(7)|2/9(2)|
             * ---|------|------|
             *  b |1,0(1)|0,0(0)|
             * ---|------|------|
             */

            // ���� ������� ����� ��������
            var resultTheory = new Chain(30);
            resultTheory[0] = (ValueString)"a"; // "a" 0.77;
            resultTheory[1] = (ValueString)"a"; // "a" 0.15;
            resultTheory[2] = (ValueString)"b"; // "b" 0.96;
            resultTheory[3] = (ValueString)"a"; // "a" 0.61;
            resultTheory[4] = (ValueString)"a"; // "a" 0.15;
            resultTheory[5] = (ValueString)"b"; // "b" 0.85;
            resultTheory[6] = (ValueString)"a"; // "a" 0.67;
            resultTheory[7] = (ValueString)"a"; // "a" 0.51;
            resultTheory[8] = (ValueString)"a"; // "a" 0.71;
            resultTheory[9] = (ValueString)"a"; // "a" 0.2;
            resultTheory[10] = (ValueString)"a"; // "a" 0.77;
            resultTheory[11] = (ValueString)"a"; // "a" 0.15;
            resultTheory[12] = (ValueString)"b"; // "b" 0.96;
            resultTheory[13] = (ValueString)"a"; // "a" 0.61;
            resultTheory[14] = (ValueString)"a"; // "a" 0.15;
            resultTheory[15] = (ValueString)"b"; // "b" 0.85;
            resultTheory[16] = (ValueString)"a"; // "a" 0.67;
            resultTheory[17] = (ValueString)"a"; // "a" 0.51;
            resultTheory[18] = (ValueString)"a"; // "a" 0.71;
            resultTheory[19] = (ValueString)"a"; // "a" 0.2;
            resultTheory[20] = (ValueString)"a"; // "a" 0.77;
            resultTheory[21] = (ValueString)"a"; // "a" 0.15;
            resultTheory[22] = (ValueString)"b"; // "b" 0.96;
            resultTheory[23] = (ValueString)"a"; // "a" 0.61;
            resultTheory[24] = (ValueString)"a"; // "a" 0.15;
            resultTheory[25] = (ValueString)"b"; // "b" 0.85;
            resultTheory[26] = (ValueString)"a"; // "a" 0.67;
            resultTheory[27] = (ValueString)"a"; // "a" 0.51;
            resultTheory[28] = (ValueString)"a"; // "a" 0.71;
            resultTheory[29] = (ValueString)"a"; // "a" 0.2; 

            Assert.AreEqual(resultTheory, temp);
        }

        /// <summary>
        /// The markov chain not uniform one rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformOneRangTwoTest()
        {
            // ���������� ��������� ��������
            IGenerator generator = new MockGenerator();

            // ������� ���� 2 
            // ������ ��� ������ ������� ������� �� ������ �����������
            const int MarkovChainRang = 2;

            // �������������� 1 
            // ������������� ��������� ������� 2 ������ ��� ������ � �������� �������
            const int NoUniformRang = 1;

            // ������� ���������� ������ ��������� � ����, �������������� � ���������
            var markovChain = new MarkovChainNotUniformStatic(MarkovChainRang, NoUniformRang, generator);

            // ������ ������������ ����
            const int Length = 12;

            // ������� ���� 
            // TeachingMethod.None ������ �� ����� ��������������� ��������� ���� �� ����������
            markovChain.Teach(this.testChain, TeachingMethod.None);

            var temp = markovChain.Generate(Length);

            /**
             * ������ ������������ ���������� ���� ���������� n ���������� ���������� �����. n - ������� �������������� ����
             * ������� ������ ���������� ����� ����� ������� ������������ ����
             * ���������� ���� ������������ �� ������� ��� ��� �������� ��� �  ��� ���������.
             * 
             * � ������ ����� ������ ������������ ���������� ���� ���� 2 ���������� ����.
             * ������� ���������� ������������ (� ������� ������� ���-�� �������� ��� ��������) � ��� �����
             * 
             * 1. ���� 
             *   ������ ������� (����������� �����������)
             *   
             *    a| 1/2 (3) |
             *    b| 1/3 (2) |
             *    c| 1/6 (1) |
             *    d| 0 (0)   |
             * 
             *   ������ ������� (�������� � ������ 1 ����������� ��������)
             * 
             *    |   a  |   b  |  �   |  d   |
             * ---|------|------|------|------|
             *  a |0,3(1)| 0(0) |0,3(1)|0,3(1)|
             * ---|------|------|------|------|
             *  b |0,5(1)|0,5(1)| 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             * 
             * 2. ���� 
             *   ������ ������� (����������� �����������)
             *   
             *    a| 2/5 (2) |
             *    b| 1/5 (1) |
             *    c| 1/5 (1) |
             *    d| 1/5 (1) |
             * 
             *   ������ ������� (�������� � ������ 1 ����������� ��������)
             * 
             *    |   a  |   b  |  �   |  d   |
             * ---|------|------|------|------|
             *  a |0,5(1)| 0(0) |0,5(1)| 0(0) |
             * ---|------|------|------|------|
             *  b | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             * 
             * 
             * ��� �������� ��� ����� ���������� ��������� 
             *   |-| |-| |-| |-| |-|   <>- �� ������ ����
             * a d b a a c b b a a c a
             * |_| |_| |_| |_| |_| |_| <>- � ������ ����
             * 
             */

            // ���� ������� ����� ��������
            var result = new Chain(12);
            result.Add((ValueString)"b", 0); // 1 ���� ����������� �� ������� ������. ������  0,77 �������� b
            result.Add((ValueString)"a", 1); // 2 ���� ����������� �� ������� ������. ������  0.15 �������� a
            result.Add((ValueString)"c", 2); // 1 ���� ����������� �� ������� ������. ������  0.96 �������� �
            result.Add((ValueString)"b", 3); // 2 ���� ����������� �� ������� ������. ������  0.61 �������� b
            result.Add((ValueString)"a", 4); // 1 ���� ����������� �� ������� ������. ������  0.15 �������� a
            result.Add((ValueString)"c", 5); // 2 ���� ����������� �� ������� ������. ������  0.85 �������� c
            result.Add((ValueString)"a", 6); // 1 ���� ����������� �� ������� ������. ������  0.67 �������� a
            result.Add((ValueString)"c", 7); // 2 ���� ����������� �� ������� ������. ������  0.51 �������� c
            result.Add((ValueString)"a", 8); // 1 ���� ����������� �� ������� ������. ������  0.71 �������� a
            result.Add((ValueString)"a", 9); // 2 ���� ����������� �� ������� ������. ������  0.2 �������� a
            result.Add((ValueString)"c", 10); // 1 ���� ����������� �� ������� ������. ������  0.77 �������� �
            result.Add((ValueString)"b", 11); // 2 ���� ����������� �� ������� ������. ������  0.15 �������� b

            Assert.AreEqual(result, temp);
        }

        /// <summary>
        /// The markov chain not uniform dynamic zero rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformDynamicZeroRangTwoTest()
        {
            /*  // ���������� ��������� ��������
            IGenerator Generator = new MockGenerator();
            // ������� ���� 2 
            // ������ ��� ������ ������� ������� �� ������ �����������
            int MarkovChainRang = 2;
            // �������������� 1 
            // ������������� ��������� ������� 2 ������ ��� ������ � �������� �������
            int NoUniformRang = 0;
            // ������� ���������� ������ ��������� � ����, �������������� � ���������
            MarkovChainNotUniformDynamic<Chain, Chain> MarkovChain = new MarkovChainNotUniformDynamic<Chain, Chain>(MarkovChainRang, NoUniformRang, Generator);

            // ������ ������������ ����
            int Length = 30;
            // ������� ���� 
            // TeachingMethod.None ������ �� ����� ��������������� ��������� ���� �� ����������
            MarkovChain.Teach(TestChain2, TeachingMethod.Cycle);

            Chain Temp = MarkovChain.Generate(Length);*/

            /* 
             * 1. ���� a a a a a a b a a a b a
             *   ������ ������� (����������� �����������)
             *   
             *    a| 10/12 (0,83333)  �� ����� 0,83333| 
             *    b| 2/12 (0,16667)  �� ����� 1|
             * 
             *   ������ ������� (�������� � ������ 1 ����������� ��������)
             * 
             *    |   a  |   b  |
             * ---|------|------|
             *  a |7/9(7)|2/9(2)|
             * ---|------|------|
             *  b |1,0(1)|0,0(0)|
             * ---|------|------|
             */

            // ���� ������� ����� ��������
            var resultTheory = new Chain(30);
            resultTheory[0] = (ValueString)"a"; // "a" 0.77;
            resultTheory[1] = (ValueString)"a"; // "a" 0.15;
            resultTheory[2] = (ValueString)"b"; // "b" 0.96;
            resultTheory[3] = (ValueString)"a"; // "a" 0.61;
            resultTheory[4] = (ValueString)"a"; // "a" 0.15;
            resultTheory[5] = (ValueString)"b"; // "b" 0.85;
            resultTheory[6] = (ValueString)"a"; // "a" 0.67;
            resultTheory[7] = (ValueString)"a"; // "a" 0.51;
            resultTheory[8] = (ValueString)"a"; // "a" 0.71;
            resultTheory[9] = (ValueString)"a"; // "a" 0.2;
            resultTheory[10] = (ValueString)"a"; // "a" 0.77;
            resultTheory[11] = (ValueString)"a"; // "a" 0.15;
            resultTheory[12] = (ValueString)"b"; // "b" 0.96;
            resultTheory[13] = (ValueString)"a"; // "a" 0.61;
            resultTheory[14] = (ValueString)"a"; // "a" 0.15;
            resultTheory[15] = (ValueString)"b"; // "b" 0.85;
            resultTheory[16] = (ValueString)"a"; // "a" 0.67;
            resultTheory[17] = (ValueString)"a"; // "a" 0.51;
            resultTheory[18] = (ValueString)"a"; // "a" 0.71;
            resultTheory[19] = (ValueString)"a"; // "a" 0.2;
            resultTheory[20] = (ValueString)"a"; // "a" 0.77;
            resultTheory[21] = (ValueString)"a"; // "a" 0.15;
            resultTheory[22] = (ValueString)"b"; // "b" 0.96;
            resultTheory[23] = (ValueString)"a"; // "a" 0.61;
            resultTheory[24] = (ValueString)"a"; // "a" 0.15;
            resultTheory[25] = (ValueString)"b"; // "b" 0.85;
            resultTheory[26] = (ValueString)"a"; // "a" 0.67;
            resultTheory[27] = (ValueString)"a"; // "a" 0.51;
            resultTheory[28] = (ValueString)"a"; // "a" 0.71;
            resultTheory[29] = (ValueString)"a"; // "a" 0.2; 
        }

        /// <summary>
        /// The markov chain not uniform dynamic one rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformDynamicOneRangTwoTest()
        {
            /*   // ���������� ��������� ��������
            IGenerator Generator = new MockGenerator();
            // ������� ���� 2 
            // ������ ��� ������ ������� ������� �� ������ �����������
            int MarkovChainRang = 2;
            // �������������� 1 
            // ������������� ��������� ������� 2 ������ ��� ������ � �������� �������
            int NoUniformRang = 1;
            // ������� ���������� ������ ��������� � ����, �������������� � ���������
            MarkovChainNotUniformDynamic<Chain, Chain> MarkovChain = new MarkovChainNotUniformDynamic<Chain, Chain>(MarkovChainRang, NoUniformRang, Generator);

            // ������ ������������ ����
            int Length = 12;
            // ������� ���� 
            // TeachingMethod.None ������ �� ����� ��������������� ��������� ���� �� ����������
            MarkovChain.Teach(TestChain, TeachingMethod.None);

            Chain Temp = MarkovChain.Generate(Length);*/

            /**
             * ������ ������������ ���������� ���� ���������� n ���������� ���������� �����. n - ������� �������������� ����
             * ������� ������ ���������� ����� ����� ������� ������������ ����
             * ���������� ���� ������������ �� ������� ��� ��� �������� ��� �  ��� ���������.
             * 
             * � ������ ����� ������ ������������ ���������� ���� ���� 2 ���������� ����.
             * ������� ���������� ������������ (� ������� ������� ���-�� �������� ��� ��������) � ��� �����
             * 
             * 1. ���� 
             *   ������ ������� (����������� �����������)
             *   
             *    a| 1/2 (3) |
             *    b| 1/3 (2) |
             *    c| 1/6 (1) |
             *    d| 0 (0)   |
             * 
             *   ������ ������� (�������� � ������ 1 ����������� ��������)
             * 
             *    |   a  |   b  |  �   |  d   |
             * ---|------|------|------|------|
             *  a |0,3(1)| 0(0) |0,3(1)|0,3(1)|
             * ---|------|------|------|------|
             *  b |0,5(1)|0,5(1)| 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             * 
             * 2. ���� 
             *   ������ ������� (����������� �����������)
             *   
             *    a| 2/5 (2) |
             *    b| 1/5 (1) |
             *    c| 1/5 (1) |
             *    d| 1/5 (1) |
             * 
             *   ������ ������� (�������� � ������ 1 ����������� ��������)
             * 
             *    |   a  |   b  |  �   |  d   |
             * ---|------|------|------|------|
             *  a |0,5(1)| 0(0) |0,5(1)| 0(0) |
             * ---|------|------|------|------|
             *  b | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             * 
             * 
             * ��� �������� ��� ����� ���������� ��������� 
             *   |-| |-| |-| |-| |-|   <>- �� ������ ����
             * a d b a a c b b a a c a
             * |_| |_| |_| |_| |_| |_| <>- � ������ ����
             * 
             */

            // ���� ������� ����� ��������
            var result = new Chain(12);
            result.Add((ValueString)"b", 0); // 1 ���� ����������� �� ������� ������. ������  0,77 �������� b
            result.Add((ValueString)"a", 1); // 2 ���� ����������� �� ������� ������. ������  0.15 �������� a
            result.Add((ValueString)"c", 2); // 1 ���� ����������� �� ������� ������. ������  0.96 �������� �
            result.Add((ValueString)"b", 3); // 2 ���� ����������� �� ������� ������. ������  0.61 �������� b
            result.Add((ValueString)"a", 4); // 1 ���� ����������� �� ������� ������. ������  0.15 �������� a
            result.Add((ValueString)"c", 5); // 2 ���� ����������� �� ������� ������. ������  0.85 �������� c
            result.Add((ValueString)"a", 6); // 1 ���� ����������� �� ������� ������. ������  0.67 �������� a
            result.Add((ValueString)"c", 7); // 2 ���� ����������� �� ������� ������. ������  0.51 �������� c
            result.Add((ValueString)"a", 8); // 1 ���� ����������� �� ������� ������. ������  0.71 �������� a
            result.Add((ValueString)"a", 9); // 2 ���� ����������� �� ������� ������. ������  0.2 �������� a
            result.Add((ValueString)"c", 10); // 1 ���� ����������� �� ������� ������. ������  0.77 �������� �
            result.Add((ValueString)"b", 11); // 2 ���� ����������� �� ������� ������. ������  0.15 �������� b
        }
    }
}