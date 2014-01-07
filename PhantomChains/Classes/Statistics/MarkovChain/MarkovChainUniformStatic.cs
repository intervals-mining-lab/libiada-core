using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ����� ����������� ��������� ���������� ���������� ����
    ///</summary>
    ///<typeparam name="ChainGenerated">��� ������������ ���������� ����</typeparam>
    ///<typeparam name="ChainTaught">��� ��������� ����</typeparam>
    public class MarkovChainUniformStatic<ChainGenerated, ChainTaught> : MarkovChainNotUniformStatic<ChainGenerated, ChainTaught>
        where ChainGenerated : BaseChain, new()
        where ChainTaught : BaseChain, new()
    {
        ///<summary>
        ///</summary>
        ///<param name="rang">������� ���������� ����</param>
        ///<param name="generator">���������</param>
        public MarkovChainUniformStatic(int rang, IGenerator generator) : base(rang, 0, generator)
        {
        }
    }
}
