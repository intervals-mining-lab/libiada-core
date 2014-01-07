using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// Класс описывающий статичную однородную марковскую цепь
    ///</summary>
    ///<typeparam name="ChainGenerated">Тип генерируемой марковской цепи</typeparam>
    ///<typeparam name="ChainTaught">Тип обучающей цепи</typeparam>
    public class MarkovChainUniformStatic<ChainGenerated, ChainTaught> : MarkovChainNotUniformStatic<ChainGenerated, ChainTaught>
        where ChainGenerated : BaseChain, new()
        where ChainTaught : BaseChain, new()
    {
        ///<summary>
        ///</summary>
        ///<param name="rang">Порядок марковской цепи</param>
        ///<param name="generator">Генератор</param>
        public MarkovChainUniformStatic(int rang, IGenerator generator) : base(rang, 0, generator)
        {
        }
    }
}
