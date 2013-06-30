using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    public class MarkovChainRandom<ChainGenerated, ChainTeached> : MarkovChainNotUniformStatic<ChainGenerated, ChainTeached>
        where ChainGenerated : BaseChain, new()
        where ChainTeached : BaseChain, new()
    {
        public MarkovChainRandom(int i, IGenerator generator) : base(1, 0, generator)
        {
        }

        public override void Teach(ChainTeached chain, TeachingMethod method)
        {
            MatrixBuilder builder = new MatrixBuilder();
            IAbsoluteMatrix absoluteMatrix = (IAbsoluteMatrix)builder.Create(chain.Alphabet.Power, Rank);
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                int[] Temp =new int[1]; 
                Temp[0] = chain.Alphabet.IndexOf(chain.Alphabet[i]);

                absoluteMatrix.Add(Temp);

            }

            ProbabilityMatrix[0] = absoluteMatrix.ProbabilityMatrix();
        }
    }
}