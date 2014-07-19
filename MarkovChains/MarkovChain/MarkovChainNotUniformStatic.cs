namespace MarkovChains.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// ����� ����������� ��������� ������������ ���������� ����
    /// </summary>
    /// <typeparam name="TChainGenerated">
    /// ��� ������������ ����
    /// </typeparam>
    /// <typeparam name="TChainTaught">
    /// ��� ��������� ����
    /// </typeparam>
    public class MarkovChainNotCongenericStatic : MarkovChainBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkovChainNotCongenericStatic{ChainGenerated,ChainTaught}"/> class.
        /// </summary>
        /// <param name="rang">
        /// ������� ���������� ����
        /// </param>
        /// <param name="congenericRang">
        /// �������������� ����
        /// </param>
        /// <param name="generator">
        /// ���������
        /// </param>
        public MarkovChainNotCongenericStatic(int rang, int congenericRang, IGenerator generator)
            : base(rang, congenericRang, generator)
        {
        }

        /// <summary>
        /// ��������� ���������� �������
        /// </summary>
        /// <param name="i">
        /// ������ ������������ ����
        /// </param>
        /// <param name="chainRang">
        /// ���� ������������ ����
        /// </param>
        /// <returns>
        /// ��������������� ����
        /// </returns>
        public override BaseChain Generate(int i, int chainRang)
        {
            var temp = new BaseChain();
            temp.ClearAndSetNewLength(i);
            var read = this.Rank > 1 ? new IteratorStart(temp, this.Rank - 1, 1) : null;
            var write = new IteratorWritableStart(temp);
            if (read != null)
            {
                read.Reset();
                read.Next();
            }

            write.Reset();
            this.Generator.Reset();

            int m = 0;
            for (int j = 0; j < i; j++)
            {
                if (m == this.CongenericRank + 1)
                {
                    m = 0;
                }

                m += 1;

                write.Next();

                if (j >= this.Rank)
                {
                    if (read != null)
                    {
                        read.Next();
                    }
                }

                if (read != null)
                {
                    BaseChain chain = (BaseChain)read.Current();
                    var indexedChain = new int[chain.GetLength()];
                    for (int k = 0; k < chain.GetLength(); k++)
                    {
                        indexedChain[k] = this.Alphabet.IndexOf(chain[k]);
                    }

                    write.WriteValue(
                        this.GetObject(this.ProbabilityMatrix[m - 1].GetProbabilityVector(this.Alphabet, indexedChain)));
                }
            }

            return temp;
        }
    }
}