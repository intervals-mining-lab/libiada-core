using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.Statistics.MarkovChain;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using PhantomChainsTest.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChainsTest.Classes.Statistics.MarkovChain
{
    /**
     * ��������� ������������ ���������� ���� 
     * ������������ ���������� ���� ������������ ����� 
     * ��������� ���������� ���������� ����� ������ �� ������� 
     * ����������� �� ������������ ����
     * 
     **/
    [TestFixture]
    public class TestMarkovChainNotUniform
    {
        // �������� ���� �� ������� ����� ����������� ��������
        private Chain TestChain;
        private Chain TestChain2;

        [SetUp]
        public void Init()
        {
            // ������� ���� ������� 12
            // |a|d|b|a|a|c|b|b|a|a|c|a|
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

            TestChain2 = new Chain(12);
            TestChain2.Add((ValueString)"a", 0);
            TestChain2.Add((ValueString)"a", 1);
            TestChain2.Add((ValueString)"a", 2);
            TestChain2.Add((ValueString)"a", 3);
            TestChain2.Add((ValueString)"a", 4);
            TestChain2.Add((ValueString)"a", 5);
            TestChain2.Add((ValueString)"b", 6);
            TestChain2.Add((ValueString)"a", 7);
            TestChain2.Add((ValueString)"a", 8);
            TestChain2.Add((ValueString)"a", 9);
            TestChain2.Add((ValueString)"b", 10);
            TestChain2.Add((ValueString)"a", 11);
        }

        [Test]
        public void TestMarkovChainNotUniform0Rang2()
        {
            // ���������� ��������� ��������
            IGenerator generator = new MockGenerator();
            // ������� ���� 2 
            // ������ ��� ������ ������� ������� �� ������ �����������
            int MarkovChainRang = 2;
            // �������������� 1 
            // ������������� ��������� ������� 2 ������ ��� ������ � �������� �������
            int NoUniformRang = 0;
            // ������� ���������� ������ ��������� � ����, �������������� � ���������
            MarkovChainNotUniformStatic<Chain, Chain> markovChain = new MarkovChainNotUniformStatic<Chain, Chain>(MarkovChainRang, NoUniformRang, generator);

            // ������ ������������ ����
            int Length = 30;
            // ������� ���� 
            // TeachingMethod.None ������ �� ����� ��������������� ��������� ���� �� ����������
            markovChain.Teach(TestChain2, TeachingMethod.Cycle);

            Chain temp = markovChain.Generate(Length);

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
            Chain resultTheory = new Chain(30);
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

        [Test]
        public void TestMarkovChainNotUniform1Rang2()
        {
            // ���������� ��������� ��������
            IGenerator generator = new MockGenerator();
            // ������� ���� 2 
            // ������ ��� ������ ������� ������� �� ������ �����������
            const int markovChainRang = 2;
            // �������������� 1 
            // ������������� ��������� ������� 2 ������ ��� ������ � �������� �������
            const int noUniformRang = 1;
            // ������� ���������� ������ ��������� � ����, �������������� � ���������
            MarkovChainNotUniformStatic<Chain, Chain> markovChain = new MarkovChainNotUniformStatic<Chain, Chain>(markovChainRang, noUniformRang, generator);

            // ������ ������������ ����
            int Length = 12;
            // ������� ���� 
            // TeachingMethod.None ������ �� ����� ��������������� ��������� ���� �� ����������
            markovChain.Teach(TestChain, TeachingMethod.None);

            Chain temp = markovChain.Generate(Length);

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
            Chain result = new Chain(12);
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

        [Test]
        public void TestMarkovChainNotUniformDynamic0Rang2()
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
            Chain resultTheory = new Chain(30);
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

        [Test]
        public void TestMarkovChainNotUniformDynamic1Rang2()
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
            Chain result = new Chain(12);
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