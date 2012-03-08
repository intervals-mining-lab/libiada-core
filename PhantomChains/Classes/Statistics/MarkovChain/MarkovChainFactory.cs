using System;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ������� ��������� ���������� ����
    ///</summary>
    public class MarkovChainFactory<ChainGenerated, ChainTeached>
        where ChainTeached : BaseChain, new()
        where ChainGenerated : BaseChain, new()
    {
        ///<summary>
        /// ������� ���������� ����
        ///</summary>
        ///<param name="method">��� ����</param>
        ///<param name="rang">�������</param>
        ///<param name="uniformRang">�������������� ����</param>
        ///<param name="Generator">��������� ������������ � ����</param>
        ///<returns>���������� ����</returns>
        ///<exception cref="Exception">� ������ ���� ��� ���� �� �������������� � �������</exception>
        public MarkovChainBase<ChainGenerated, ChainTeached> Create(GeneratingMethod method, int rang, int uniformRang, IGenerator Generator)
        {
            switch(method)
            {
                case GeneratingMethod.DynamicNotUniform:
                    return null;// new MarkovChainNotUniformDynamic<ChainGenerated, ChainTeached>(rang, uniformRang, Generator);
                case GeneratingMethod.StaticNotUniform:
                    return new MarkovChainNotUniformStatic<ChainGenerated, ChainTeached>(rang, uniformRang, Generator);
                case GeneratingMethod.DynamicUniform:
                    return null; //new MarkovChainUniformDynamic<ChainGenerated, ChainTeached>(rang, Generator);
                case GeneratingMethod.StaticUniform:
                    return new MarkovChainUniformStatic<ChainGenerated, ChainTeached>(rang, Generator);
                case GeneratingMethod.Random:
                    return new MarkovChainRandom<ChainGenerated, ChainTeached>(rang, Generator);
                default: 
                    throw new Exception("This type of markov chain does not registated in system");
            }
        }
    }
}
