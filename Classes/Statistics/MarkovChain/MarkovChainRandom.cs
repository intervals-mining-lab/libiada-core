using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace ChainAnalises.Classes.Statistics.MarkovChain
{
    public class MarkovChainRandom<ChainGenerated, ChainTeached> : MarkovChainNotUniformStatic<ChainGenerated, ChainTeached>
        where ChainGenerated : BaseChain, new()
        where ChainTeached : BaseChain, new()
    {
        public MarkovChainRandom(int i, IGenerator generator) : base(1, 0, generator)
        {
        }

        public override void Teach(ChainTeached chain, TeachingMethod Method)
        {
            MatrixBuilder Builder = new MatrixBuilder();
            IAbsoluteMatrix AbsoluteMatrix = (IAbsoluteMatrix)Builder.Create(chain.Alpahbet.power, rang);
            for (int i = 0; i < chain.Alpahbet.power; i++)
            {
                int[] Temp =new int[1]; 
                Temp[0] = chain.Alpahbet.IndexOf(chain.Alpahbet[i]);

                AbsoluteMatrix.Add(Temp);

            }

            ProbabilityMatrix[0] = AbsoluteMatrix.ProbabilityMatrix();
        }
    }
}