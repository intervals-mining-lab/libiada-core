using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    /// ����� ��� IteratorEnd
    ///</summary>
    [TestFixture]
    public class TestIteratorEnd
    {
        private Chain ChainToIterate;

        ///<summary>
        /// �������������  
        ///</summary>
        [SetUp]
        public void Init()
        {
            // ������ ���� ��� ��������� 12
            // ���� = 121331212231
            ChainToIterate = new Chain(12);
            ChainToIterate.Add(new ValueChar('1'), 0);
            ChainToIterate.Add(new ValueChar('2'), 1);
            ChainToIterate.Add(new ValueChar('1'), 2);

            ChainToIterate.Add(new ValueChar('3'), 3);
            ChainToIterate.Add(new ValueChar('3'), 4);
            ChainToIterate.Add(new ValueChar('1'), 5);

            ChainToIterate.Add(new ValueChar('2'), 6);
            ChainToIterate.Add(new ValueChar('1'), 7);
            ChainToIterate.Add(new ValueChar('2'), 8);

            ChainToIterate.Add(new ValueChar('2'), 9);
            ChainToIterate.Add(new ValueChar('3'), 10);
            ChainToIterate.Add(new ValueChar('1'), 11);
        }

        ///<summary>
        /// ��������� ���������� l-�������� 
        ///</summary>
        [Test]
        public void TestReadWindowMode()
        {
            // ������ ������������� ��������� 3
            int length = 3;
            // ��� �������� 1
            int step = 1;
            IteratorEnd<Chain, Chain> Iterator = new IteratorEnd<Chain, Chain>(ChainToIterate, length, step);
            // ���-�� ��������� 12 - 3 + 1
            Chain[] Message2 = new Chain[10];
            // � ����� 
            // ������������ �������� 121
            // |121|331212231
            Message2[9] = new Chain(3);
            Message2[9].Add(new ValueChar('1'), 0);
            Message2[9].Add(new ValueChar('2'), 1);
            Message2[9].Add(new ValueChar('1'), 2);

            Message2[8] = new Chain(3);
            // ������������ �������� 213
            // 1|213|31212231
            Message2[8].Add(new ValueChar('2'), 0);
            Message2[8].Add(new ValueChar('1'), 1);
            Message2[8].Add(new ValueChar('3'), 2);

            // ������������ �������� 133
            // 12|133|1212231
            Message2[7] = new Chain(3);
            Message2[7].Add(new ValueChar('1'), 0);
            Message2[7].Add(new ValueChar('3'), 1);
            Message2[7].Add(new ValueChar('3'), 2);

            // ������������ �������� 331
            // 121|331|212231
            Message2[6] = new Chain(3);
            Message2[6].Add(new ValueChar('3'), 0);
            Message2[6].Add(new ValueChar('3'), 1);
            Message2[6].Add(new ValueChar('1'), 2);

            // ������������ �������� 331
            // 1213|312|12231
            Message2[5] = new Chain(3);
            Message2[5].Add(new ValueChar('3'), 0);
            Message2[5].Add(new ValueChar('1'), 1);
            Message2[5].Add(new ValueChar('2'), 2);

            Message2[4] = new Chain(3);
            // ������������ �������� 121
            // 12133|121|2231
            Message2[4].Add(new ValueChar('1'), 0);
            Message2[4].Add(new ValueChar('2'), 1);
            Message2[4].Add(new ValueChar('1'), 2);

            // ������������ �������� 212
            // 121331|212|231
            Message2[3] = new Chain(3);
            Message2[3].Add(new ValueChar('2'), 0);
            Message2[3].Add(new ValueChar('1'), 1);
            Message2[3].Add(new ValueChar('2'), 2);

            // ������������ �������� 122
            // 1213312|122|31
            Message2[2] = new Chain(3);
            Message2[2].Add(new ValueChar('1'), 0);
            Message2[2].Add(new ValueChar('2'), 1);
            Message2[2].Add(new ValueChar('2'), 2);

            Message2[1] = new Chain(3);
            // ������������ �������� 223
            // 12133121|223|1
            Message2[1].Add(new ValueChar('2'), 0);
            Message2[1].Add(new ValueChar('2'), 1);
            Message2[1].Add(new ValueChar('3'), 2);

            // ������������ �������� 231
            // 121331212|231|
            Message2[0] = new Chain(3);
            Message2[0].Add(new ValueChar('2'), 0);
            Message2[0].Add(new ValueChar('3'), 1);
            Message2[0].Add(new ValueChar('1'), 2);

            int i = -1; // ������ ����  -1 ��������
            while (Iterator.Next()) // ��������� ������� ���������.
            {
                i++; // ��������� ��������� �� �������
                BaseChain Message1 = Iterator.Current(); // ������� �������� ����
                Assert.AreEqual(Message1, Message2[i]); // ������������
            }

            Assert.AreEqual(9, i); // ���� 10 �������� ������� � 0 = 9
        }

        ///<summary>
        /// ��������� ���������� �������
        ///</summary>
        [Test]
        public void TestReadBlockMode()
        {
            // ������ ������������� ��������� 3
            int length = 3;
            // ��� �������� 1
            int step = 3;
            IteratorEnd<Chain, Chain> Iterator = new IteratorEnd<Chain, Chain>(ChainToIterate, length, step);
            // ���-�� ��������� 12 / 3 
            Chain[] Message2 = new Chain[4];

            // ������������ �������� 121
            // |121|331212231
            Message2[3] = new Chain(3);
            Message2[3].Add(new ValueChar('1'), 0);
            Message2[3].Add(new ValueChar('2'), 1);
            Message2[3].Add(new ValueChar('1'), 2);

            // ������������ �������� 331
            // 121|331|212231
            Message2[2] = new Chain(3);
            Message2[2].Add(new ValueChar('3'), 0);
            Message2[2].Add(new ValueChar('3'), 1);
            Message2[2].Add(new ValueChar('1'), 2);

            // ������������ �������� 212
            // 121331|212|231
            Message2[1] = new Chain(3);
            Message2[1].Add(new ValueChar('2'), 0);
            Message2[1].Add(new ValueChar('1'), 1);
            Message2[1].Add(new ValueChar('2'), 2);

            // ������������ �������� 231
            // 121331212|231|
            Message2[0] = new Chain(3);
            Message2[0].Add(new ValueChar('2'), 0);
            Message2[0].Add(new ValueChar('3'), 1);
            Message2[0].Add(new ValueChar('1'), 2);

            int i = -1;  // ������ ����  -1 ��������
            while (Iterator.Next()) // ��������� ������� ���������.
            {
                i++; // ��������� ��������� �� �������
                BaseChain Message1 = Iterator.Current(); // ������� �������� ����
                Assert.AreEqual(Message1, Message2[i]); // �������� �� ���������������
            }

            Assert.AreEqual(3, i);// ���� 4 �������� ������� � 0 = 3
        }
    }
}