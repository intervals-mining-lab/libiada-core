using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.PhantomChains
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
                TotalLength += ((ValuePhantom) InternalChain[w])[0].ToString().Length;
            }
            UInt64 TempVariants = 1;
            int counter = 0;
            ValuePhantom TempMessage = null;
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
                        TempMessage = (ValuePhantom)InternalChain[counter];
                        TempChains[i][j] = TempMessage;
                    }
                    else
                    {
                        TempMessage = new ValuePhantom();
                        TempMessage.Add(new ValueChar('a'));
                        TempChains[i][j] = TempMessage;
                    }
                    TempVariants *= (uint)TempMessage.Power;
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
            if(i>variants)
            {
                throw new Exception();
            }
            List<BaseChain> res = new List<BaseChain>();
            List<BaseChain> tempRes = new List<BaseChain>();
            for (int m = 0; m < Tree.Count;m++)
            {
                tempRes.Add(null);
            }
            Gen.Resert();
            int chainCounter = 0;
            while (res.Count != (uint)i)
            {
                int counter = 0;
                res.Add(new BaseChain(TotalLength));
                for (int l = 0; l < Tree.Count;l++)
                {
                    tempRes[l] = Tree[l].Generate();
                    for(int u=0;u<tempRes[l].Length;u++)
                    {
                        if(counter<res[chainCounter].Length)
                        {
                            res[chainCounter][counter] = tempRes[l][u];
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                chainCounter++;
                if(Tree.Count!=1)
                {
                    Tree[Tree.Count-1] = new TreeTop(TempChains[TempChains.Count-1],Gen);
                }
            }
            for (int s = 0; s < Tree.Count;s++ )
            {
                Tree[s] = new TreeTop(TempChains[s], Gen);
            }
            return res;
        }
    }
}