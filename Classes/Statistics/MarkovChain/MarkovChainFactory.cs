using System;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// Фабрика создающая марковскую цепь
    ///</summary>
    public class MarkovChainFactory<ChainGenerated, ChainTeached>
        where ChainTeached : BaseChain, new()
        where ChainGenerated : BaseChain, new()
    {
        ///<summary>
        /// Создать марковскую цепь
        ///</summary>
        ///<param name="method">Тип цепи</param>
        ///<param name="rang">Порядок</param>
        ///<param name="uniformRang">Неоднородность цепи</param>
        ///<param name="Generator">Генератор используемый в цепи</param>
        ///<returns>Марковская цепь</returns>
        ///<exception cref="Exception">В случае если тип цепи не зарегистирован в фабрике</exception>
        public MarkovChainBase<ChainGenerated, ChainTeached> Create(GeneratingMethod method, int rang, int uniformRang, IGenerator Generator)
        {
            switch(method)
            {
                case GeneratingMethod.DynamicNotUniform:
      //TODO: FIX MISSING OF FILE              return new MarkovChainNotUniformDynamic<ChainGenerated, ChainTeached>(rang, uniformRang, Generator);
                case GeneratingMethod.StaticNotUniform:
                    return new MarkovChainNotUniformStatic<ChainGenerated, ChainTeached>(rang, uniformRang, Generator);
                case GeneratingMethod.DynamicUniform:
     //TODO: FIX MISSING OF FILE            return new MarkovChainUniformDynamic<ChainGenerated, ChainTeached>(rang, Generator);
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
