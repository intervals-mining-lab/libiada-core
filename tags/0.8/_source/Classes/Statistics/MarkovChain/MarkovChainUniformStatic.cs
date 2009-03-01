using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// Класс описывающий статичную однородную марковскую цепь
    ///</summary>
    ///<typeparam name="ChainGenerated">Тип генерируемой марковской цепи</typeparam>
    ///<typeparam name="ChainTeached">Тип обучающей цепи</typeparam>
    public class MarkovChainUniformStatic<ChainGenerated, ChainTeached> : MarkovChainNotUniformStatic<ChainGenerated, ChainTeached>
        where ChainGenerated : BaseChain, new()
        where ChainTeached : BaseChain, new()
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
