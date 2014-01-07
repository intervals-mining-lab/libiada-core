using LibiadaCore.Classes.Root;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    public class MarkovChainRandom<ChainGenerated, ChainTaught> : MarkovChainNotUniformStatic<ChainGenerated, ChainTaught>
        where ChainGenerated : BaseChain, new()
        where ChainTaught : BaseChain, new()
    {
        public MarkovChainRandom(int i, IGenerator generator) : base(1, 0, generator)
        {
        }

        public override void Teach(ChainTaught chain, TeachingMethod method)
        {
            var builder = new MatrixBuilder();
            var absoluteMatrix = (IAbsoluteMatrix)builder.Create(chain.Alphabet.Power, Rank);
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                int[] temp =new int[1]; 
                temp[0] = chain.Alphabet.IndexOf(chain.Alphabet[i]);

                absoluteMatrix.Add(temp);

            }

            ProbabilityMatrix[0] = absoluteMatrix.ProbabilityMatrix();
        }
    }
}