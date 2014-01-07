using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// Класс описывающий статичную неоднородную марковскую цепь
    ///</summary>
    ///<typeparam name="ChainGenerated">Тип генерируемой цепи</typeparam>
    ///<typeparam name="ChainTaught">Тип обучающей цепи</typeparam>
    public class MarkovChainNotUniformStatic<ChainGenerated, ChainTaught> :
        MarkovChainBase<ChainGenerated, ChainTaught>
        where ChainGenerated : BaseChain, new()
        where ChainTaught : BaseChain, new()
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="rang">Порядок марковской цепи</param>
        ///<param name="uniformRang">Неоднородность цепи</param>
        ///<param name="generator">Генератор</param>
        public MarkovChainNotUniformStatic(int rang, int uniformRang, IGenerator generator)
            : base(rang, uniformRang, generator)
        {
        }

        ///<summary>
        /// Генерация марковской цепочки
        ///</summary>
        ///<param name="i">Длинна генерируемой цепи</param>
        ///<param name="chainRang">Ранг генерируемой цепи</param>
        ///<returns>Сгенерированная цепь</returns>
        public override ChainGenerated Generate(int i, int chainRang)
        {
            var temp = new ChainGenerated();
            temp.ClearAndSetNewLength(i);
            var read = Rank > 1 ? new IteratorStart<ChainGenerated, ChainGenerated>(temp, Rank - 1, 1) : null;
            var write = new IteratorWritableStart<ChainGenerated, ChainGenerated>(temp);
            if (read != null)
            {
                read.Reset();
                read.Next();
            }
            write.Reset();
            Generator.Reset();

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