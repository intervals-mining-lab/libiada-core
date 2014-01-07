using System;
using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ������� ��������� ���������� ����
    ///</summary>
    public class MarkovChainFactory<ChainGenerated, ChainTaught>
        where ChainTaught : BaseChain, new()
        where ChainGenerated : BaseChain, new()
    {
        ///<summary>
        /// ������� ���������� ����
        ///</summary>
        ///<param name="method">��� ����</param>
        ///<param name="rang">�������</param>
        ///<param name="uniformRang">�������������� ����</param>
        ///<param name="generator">��������� ������������ � ����</param>
        ///<returns>���������� ����</returns>
        ///<exception cref="Exception">� ������ ���� ��� ���� �� �������������� � �������</exception>
        public MarkovChainBase<ChainGenerated, ChainTaught> Create(GeneratingMethod method, int rang, int uniformRang, IGenerator generator)
        {
            switch(method)
            {
                case GeneratingMethod.DynamicNotUniform:
                    return null;// new MarkovChainNotUniformDynamic<ChainGenerated, ChainTeached>(rang, uniformRang, Generator);
                case GeneratingMethod.StaticNotUniform:
                    return new MarkovChainNotUniformStatic<ChainGenerated, ChainTaught>(rang, uniformRang, generator);
                case GeneratingMethod.DynamicUniform:
                    return null; //new MarkovChainUniformDynamic<ChainGenerated, ChainTeached>(rang, Generator);
                case GeneratingMethod.StaticUniform:
                    return new MarkovChainUniformStatic<ChainGenerated, ChainTaught>(rang, generator);
                case GeneratingMethod.Random:
                    return new MarkovChainRandom<ChainGenerated, ChainTaught>(rang, generator);
                default: 
                    throw new Exception("This type of markov chain does not registered in system");
            }
        }
    }
}
