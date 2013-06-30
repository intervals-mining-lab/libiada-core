using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ����� ����������� ��������� ������������ ���������� ����
    ///</summary>
    ///<typeparam name="ChainGenerated">��� ������������ ����</typeparam>
    ///<typeparam name="ChainTeached">��� ��������� ����</typeparam>
    public class MarkovChainNotUniformStatic<ChainGenerated, ChainTeached> :
        MarkovChainBase<ChainGenerated, ChainTeached>
        where ChainGenerated : BaseChain, new()
        where ChainTeached : BaseChain, new()
    {
        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="rang">������� ���������� ����</param>
        ///<param name="uniformRang">�������������� ����</param>
        ///<param name="generator">���������</param>
        public MarkovChainNotUniformStatic(int rang, int uniformRang, IGenerator generator)
            : base(rang, uniformRang, generator)
        {
        }

        ///<summary>
        /// ��������� ���������� �������
        ///</summary>
        ///<param name="i">������ ������������ ����</param>
        ///<param name="chainRang">���� ������������ ����</param>
        ///<returns>��������������� ����</returns>
        public override ChainGenerated Generate(int i, int chainRang)
        {
            ChainGenerated temp = new ChainGenerated();
            temp.ClearAndSetNewLength(i);
            IteratorBase<ChainGenerated, ChainGenerated> read;
            if (Rank - 1 > 0)
            {
                read = new IteratorStart<ChainGenerated, ChainGenerated>(temp, Rank - 1, 1);
            }
            else
            {
                read = null; //new NullIteratorStart<ChainGenerated, ChainGenerated>(Temp, 1);
            }
            IteratorWritableStart<ChainGenerated, ChainGenerated> write =
                new IteratorWritableStart<ChainGenerated, ChainGenerated>(temp);
            if (read != null)
            {
                read.Reset();
                read.Next();
            }
            write.Reset();
            Generator.Resert();

            int m = 0;
            for (int j = 0; j < i; j++)
            {
                if (m == UniformRank + 1)
                    m = 0;
                m += 1;

                write.Next();

                if (j >= Rank)
                {
                    if (read != null) read.Next();
                }

                if (read != null)
                {
                    ChainGenerated chain = read.Current();
                    int[] indexedChain = new int[chain.Length];
                    for (int k = 0; k < chain.Length; k++)
                    {
                        indexedChain[k] = alphabet.IndexOf(chain[k]);
                    }

                    write.SetCurrent(GetObject(ProbabilityMatrix[m - 1].GetProbabilityVector(alphabet, indexedChain)));
                }
            }
            return temp;
        }
    }
}