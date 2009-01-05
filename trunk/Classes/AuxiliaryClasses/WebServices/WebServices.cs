using System;
using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.DataMining.Clusterization.KRAB;
using ChainAnalises.Classes.DivizionToAccords;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Statistics.MarkovChain;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices
{
    ///<summary>
    ///</summary>
    public class WebServices
    {
        ///<summary>
        ///</summary>
        ///<param name="Request"></param>
        ///<returns></returns>
        public AnswerChain Calculate(RequestFiles Request)
        {
            AnswerChain Answer = new AnswerChain();
            Answer.Error = ErrorType.CalculationsComplete;


            ElementStreamCreator ElStrFactory =
                ElementStreamBuilderFactory.Create((Request.Files).FileType);

            ElementStream ElStream = ElStrFactory.Create(Request.Files);

            ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
            OVB.LoadElements(ElStream);

            SpaceRebuilder<Chain, Chain> RebuildMethod = SpaceRebuilderFactory<Chain, Chain>.Create(Request.Action);

            OVB.RebuildSpace(RebuildMethod);

            OVB.Calculate();

            ChainBin Temp = (ChainBin) OVB.Chain.GetBin();

            for (int i = 0; i < Temp.Alphabet.Items.Count; i++)
            {
                for (int j = 0; j < ((MessagePhantomBin)Temp.Alphabet.Items[i]).Items.Count; j++)
                {
                    ChainBin Bin = (ChainBin)((MessagePhantomBin)Temp.Alphabet.Items[i]).Items[j];
                    Chain F = (Chain)Bin.GetInstance();
                    ArrayList temp = CharacteristicsFactory.List;
                    foreach (ICharacteristicCalculator Characteristic in temp)
                    {
                        F.GetCharacteristic(LinkUp.Start, Characteristic);
                    }
                    ((MessagePhantomBin)Temp.Alphabet.Items[i]).Items[j] = F.GetBin();
                }
                
            }

            Converter Convert = new Converter();
            Answer.Chain = Convert.ToChainOfChains(Temp);
            return Answer;
        }


        ///<summary>
        ///</summary>
        ///<param name="Request"></param>
        ///<returns></returns>
        public AnswerObjects CreateAlphabet(RequestFiles Request)
        {
            AnswerObjects Answer = new AnswerObjects();

            Answer.Error = ErrorType.CalculationsComplete;

            ElementStreamCreator ElStrFactory =
                ElementStreamBuilderFactory.Create((Request.Files).FileType);

            ElementStream ElStream = ElStrFactory.Create(Request.Files);

            ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
            OVB.LoadElements(ElStream);

            SpaceRebuilder<Chain, Chain> RebuildMethod = SpaceRebuilderFactory<Chain, Chain>.Create(Request.Action);

            OVB.RebuildSpace(RebuildMethod);


            AlphabetBin Temp = (AlphabetBin) OVB.Alphabet.GetBin();
            Converter Convert = new Converter();
            Answer.Alphabet = Convert.ToAlphabetChains(Temp);
            return Answer;
        }

        ///<summary>
        ///</summary>
        ///<param name="request"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public AnswerMarkovChain GenerateMarkovChains(RequestMarkovChain request)
        {
            AnswerMarkovChain Result = new AnswerMarkovChain();
            Result.Error = ErrorType.CalculationsComplete;
            Converter Convert = new Converter();
            ChainBin Bin = Convert.ToChainBin(request.Chain);

            Chain InputChain = (Chain) Bin.GetInstance();
            GeneratorFactory GeneratorFabric = new GeneratorFactory();
            IGenerator Generator = GeneratorFabric.Create(request.Generator);

            MarkovChainFactory<Chain, Chain> MarkovChainFabric = new MarkovChainFactory<Chain, Chain>();
            //TODO: Change 0 value of uniforRang to something.
            MarkovChainBase<Chain, Chain> MarkovChain = MarkovChainFabric.Create(request.Method, request.MarkovChainRang, 0, Generator);

            MarkovChain.Teach(InputChain, request.PreChanges);
            ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
            for (int i = 0; i < request.GenerateChainsCount; i++)
            {
                Chain Temp = MarkovChain.Generate(request.Length);
                OVB.Load(Temp);
                OVB.Calculate();
                Result.Chains.Add(Convert.ToChainOfChains((ChainBin) OVB.Chain.GetBin()));
            }
            return Result;
        }

        ///<summary>
        ///</summary>
        ///<param name="request"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public AnswerClusterization KRAB(RequestClusterization request)
        {
            Converter Convert = new Converter();
            DataTable Data = (DataTable) Convert.ToDataTableBin(request.DataTable).GetInstance();

            KrabCalusterization Clusterizator = new KrabCalusterization(Data);
            ClustarizationVariants Result;
            switch(request.Method)
            {
                case MethodClusterization.Simple:
                    Result = new ClustarizationVariants();
                    Result.Variants.Add(Clusterizator.Clusterizate(request.ClusterCount));
                    break;
                case MethodClusterization.Less:
                    Result = Clusterizator.ClusterizateVariantCountClustersBelow(request.ClusterCount);
                    break;
                case MethodClusterization.All:
                    Result = Clusterizator.ClusterizateAllVariants();
                    break;
                default : throw  new Exception("You try to clusterize using unavaliable method.");
            }
            AnswerClusterization Answer = new AnswerClusterization();
            Answer.Error = ErrorType.CalculationsComplete;
            Answer.Variant = Convert.ToSoapClusteriztionVariants((ClustarizationVariantsBin) Result.GetBin());
            return Answer;
        }

        ///<summary>
        ///</summary>
        ///<param name="request"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public AnswerPhantomChains PhantomChains(RequestPhantomChains request)
        {
            AnswerPhantomChains Answer = new AnswerPhantomChains();
            Answer.Error = ErrorType.CalculationsComplete;
            Converter Convert = new Converter();
            Chain SourceChain = (Chain) Convert.ToChainBin(request.Chain).GetInstance();
            PhantomChainGenerator<Chain, Chain> Generator = new PhantomChainGenerator<Chain, Chain>(SourceChain, new SimpleGenerator());
            ArrayList Temp = Generator.Generate(request.GenerateChainsCount);
            ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
            for (int i = 0; i < Temp.Count; i++)
            {
                Chain TempChain = (Chain)Temp[i];
                OVB.Load(TempChain);
                OVB.RebuildSpace(new SpacePhantomRebuilder<Chain,Chain>());
                OVB.Calculate();
                Answer.Chains.Add(Convert.ToChainOfChains((ChainBin)OVB.Chain.GetBin()));
            }

            return Answer;
        }


        ///<summary>
        ///</summary>
        ///<param name="request"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public AnswerSegmentation Segmentation(RequestSegmentation request)
        {
            AnswerSegmentation Result = new AnswerSegmentation();
            Result.Error = ErrorType.CalculationsComplete;

            AnswerChain Answer = new AnswerChain();
            Answer.Error = ErrorType.CalculationsComplete;


            ElementStreamCreator ElStrFactory =
                ElementStreamBuilderFactory.Create((request.Files).FileType);

            ElementStream ElStream = ElStrFactory.Create(request.Files);

            ObjectVirtualBase<Chain> OVB = new ObjectVirtualBase<Chain>();
            OVB.LoadElements(ElStream);

            Converter Convert = new Converter(); 
            Chain InputChain = OVB.Chain;

            Divider Divider =  new Divider(InputChain, request.BalanceFactor, request.StartLength, 
                request.Link, request.CalculateFrequenceMethod,request.RightValue,request.Eps);

            Divider.Divizion_with_inspection();

            SpaceRebuilder<Chain, Chain> Rebuilder = new SpacePhantomRebuilder<Chain, Chain>();
            Chain ResultChain = Rebuilder.Rebuild(Divider.divided_chain);
            
            OVB.Load(ResultChain);
            OVB.Calculate();
            Result.Chain = Convert.ToChainOfChains((ChainBin)OVB.Chain.GetBin());
            Result.BestDelta = Divider.best_delta;
            Result.BestLevel = Divider.best_level;
            Result.TheoryVolume = Divider.theory_volume;
            return Result;
        }
    }
}
