using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ����� ����������� ��������� ���������� ���������� ����
    ///</summary>
    ///<typeparam name="ChainGenerated">��� ������������ ���������� ����</typeparam>
    ///<typeparam name="ChainTeached">��� ��������� ����</typeparam>
    public class MarkovChainUniformStatic<ChainGenerated, ChainTeached> : MarkovChainNotUniformStatic<ChainGenerated, ChainTeached>
        where ChainGenerated : BaseChain, new()
        where ChainTeached : BaseChain, new()
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
