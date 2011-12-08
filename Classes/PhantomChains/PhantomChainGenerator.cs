using System;
using System.Collections.Generic;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.PhantomChains
{
    /// <summary>
    /// ��������� ���������� �����.
    /// </summary>
    /// <typeparam name="ChainTo">��� �������� � ���������� ����</typeparam>
    /// <typeparam name="ChainFrom">�������� ��� ����</typeparam>
    public class PhantomChainGenerator<ChainTo, ChainFrom>
        where ChainTo : BaseChain, new()
        where ChainFrom : BaseChain, new()
    {
        ///<summary>
        /// ���������� ��������� ��������� ��� ������ ����
        ///</summary>
        public readonly UInt64 variants = UInt64.MaxValue;
        private readonly ChainTo InternalChain = null;
        private readonly List<ChainTo> TempChains = new List<ChainTo>();
        private readonly IGenerator Gen = null;
        /// <summary>
        /// ������ ��������� ���������� ��� ��������� �������� ��������� ���� (������ 30 ���������)
        /// </summary>
        private List<TreeTop> Tree = new List<TreeTop>();
        private readonly int BasicChainLength = 30;
        private readonly int TotalLength = 0;

        /// <summary>
        /// ����������� ����������.
        /// </summary>
        /// <param name="chain">�������������� ����</param>
        /// <param name="gen">��������� ��������� �����</param>
        public PhantomChainGenerator(ChainFrom chain, IGenerator gen)
        {
            this.Gen = gen;
            SpacePhantomRebuilder<ChainTo, ChainFrom> rebuilder = new SpacePhantomRebuilder<ChainTo, ChainFrom>();
            InternalChain = rebuilder.Rebuild(chain);
            for(int w=0;w<InternalChain.Length;w++)
            {
                TotalLength += ((MessagePhantom) InternalChain[w])[0].ToString().Length;
            }
            UInt64 TempVariants = 1;
            int counter = 0;
            MessagePhantom TempMessage = null;
            for (int k = 0; k < (int)Math.Ceiling((double)InternalChain.Length / BasicChainLength); k++)
            {
                TempChains.Add(new ChainTo());
                TempChains[k].ClearAndSetNewLength(BasicChainLength);
                Tree.Add(null);
            }
            //���� �������� ��������� � ������ ������ 
            //� �������� ��������
            for (int i = 0; i < TempChains.Count; i++)
            {
                for (int j = 0; j < TempChains[i].Length;j++)
                {
                    if (counter < InternalChain.Length)
                    {
                        TempMessage = (MessagePhantom)InternalChain[counter];
                        TempChains[i][j] = TempMessage;
                    }
                    else
                    {
                        TempMessage = new MessagePhantom();
                        TempMessage.Add(new ValueChar('a'));
                        TempChains[i][j] = TempMessage;
                    }
                    TempVariants *= (uint)TempMessage.power;
                    counter++;
                }
                if ((i != TempChains.Count - 1) || (TempChains.Count==1))
                {
                    variants = Math.Min(variants, TempVariants);
                }
                TempVariants = 1;
                Tree[i] = new TreeTop(TempChains[i], Gen);
            }
        }

        ///<summary>
        /// ����� ������������ ��������� ��������� ���������� �����
        ///</summary>
        ///<param name="i">��������� ���������� ������������ �������������������</param>
        ///<returns>������ �������</returns>
        public List<BaseChain> Generate(UInt64 i)
        {
            if((i<0)||(i>variants))
            {
                throw new Exception();
            }
            List<BaseChain> Res = new List<BaseChain>();
            List<BaseChain> TempRes = new List<BaseChain>();
            for (int m = 0; m < Tree.Count;m++)
            {
                TempRes.Add(null);
            }
            Gen.Resert();
            int ChainCounter = 0;
            while (Res.Count != (uint)i)
            {
                int Counter = 0;
                Res.Add(new BaseChain(TotalLength));
                for (int l = 0; l < Tree.Count;l++)
                {
                    TempRes[l] = Tree[l].Generate();
                    for(int u=0;u<TempRes[l].Length;u++)
                    {
                        if(Counter<Res[ChainCounter].Length)
                        {
                            Res[ChainCounter][Counter] = TempRes[l][u];
                            Counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                ChainCounter++;
                if(Tree.Count!=1)
                {
                    Tree[Tree.Count-1] = new TreeTop(TempChains[TempChains.Count-1],Gen);
                }
            }
            for (int s = 0; s < Tree.Count;s++ )
            {
                Tree[s] = new TreeTop(TempChains[s], Gen);
            }
            return Res;
        }
    }
}