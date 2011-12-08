using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// Класс описывающий статичную неоднородную марковскую цепь
    ///</summary>
    ///<typeparam name="ChainGenerated">Тип генерируемой цепи</typeparam>
    ///<typeparam name="ChainTeached">Тип обучающей цепи</typeparam>
    public class MarkovChainNotUniformStatic<ChainGenerated, ChainTeached> : MarkovChainBase<ChainGenerated, ChainTeached>
        where ChainGenerated : BaseChain, new()
        where ChainTeached : BaseChain, new()
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="rang">Порядок марковской цепи</param>
        ///<param name="uniformRang">Неоднородность цепи</param>
        ///<param name="generator">Генератор</param>
        public MarkovChainNotUniformStatic(int rang, int uniformRang, IGenerator generator) : base(rang, uniformRang, generator)
        {
        }

        ///<summary>
        /// Генерация марковской цепочки
        ///</summary>
        ///<param name="i">Длинна генерируемой цепи</param>
        ///<param name="rang">Ранг генерируемой цепи</param>
        ///<returns>Сгенерированная цепь</returns>
        public override ChainGenerated Generate(int i, int rang)
        {
            ChainGenerated Temp = new ChainGenerated();
            Temp.ClearAndSetNewLength(i);
            IteratorBase<ChainGenerated, ChainGenerated> IRead;
            if (rang - 1 > 0)
            {
                IRead = new IteratorStart<ChainGenerated, ChainGenerated>(Temp, rang - 1, 1);
            }
            else
            {
              //TODO: FIX MISSING OF FILE  IRead = new NullIteratorStart<ChainGenerated, ChainGenerated>(Temp, 1);
            }
            IteratorWritableStart<ChainGenerated, ChainGenerated> IWrite = new IteratorWritableStart<ChainGenerated, ChainGenerated>(Temp);
           // IRead.Reset();
           // IRead.Next();
            IWrite.Reset();
            pGenerator.Resert();

            int m = 0;
            for (int j = 0; j < i; j++)
            {
                if (m == uniformRang + 1)
                    m = 0;
                m += 1;

                IWrite.Next();

                if (j >= rang)
                {
                   // IRead.Next();
                }

               // ChainGenerated chain = IRead.Current();
               // int[] indexedChain = new int[chain.Length];
               // for (int k = 0; k < chain.Length; k++)
                {
               //     indexedChain[k] = alphabet.IndexOf(chain[k]);
                }

               // IWrite.SetCurrent(GetObject(ProbabilityMatrix[m-1].GetProbabilityVector(alphabet, indexedChain)));
            }
            return Temp;
        }
    }
}