using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// Класс цепь
    ///</summary>
    [Serializable]
    public class Chain : ChainWithCharacteristic, IChainDataForCalculaton, IBaseObject
    {
        protected ArrayList pUniformChains = new ArrayList();
        protected ArrayList pNotUniformChains = new ArrayList();

        ///<summary>
        /// Конструктор 
        /// При указании длинны следует понимать что цепь начинается с 0 элемента.
        ///</summary>
        ///<param name="length">Длинна цепи</param>
        public Chain(int length) : base(length)
        {
        }

        ///<summary>
        ///</summary>
        public Chain()
        {
            
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        public new void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            pUniformChains = new ArrayList();
            pNotUniformChains = new ArrayList();
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public Chain(ChainBin Bin): base(Bin)
        {
            foreach (UniformChainBin uchain in Bin.UniformChains)
            {
                pUniformChains.Add(new UniformChain(uchain));
            }
        }

        ///<summary>
        /// Кнструктор, создает цепь из строки символов
        ///</summary>
        ///<param name="s"></param>
        public Chain(string s) : base(s)
        {
        }

        public override IBaseObject Clone()
        {
            Chain temp = new Chain(Length);
            FillClone(temp);
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp"></param>
        protected override void FillClone(IBaseObject temp)
        {
            Chain TempChain = temp as Chain;
            base.FillClone(TempChain);
            if (TempChain != null)
            {
                TempChain.pUniformChains = (ArrayList) pUniformChains.Clone();
            }
        }

        public override void CalculateCharacteristicList(ArrayList list)
        {
            base.CalculateCharacteristicList(list);
            foreach (UniformChain uniformChain in pUniformChains)
            {
                uniformChain.CalculateCharacteristicList(list);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="baseObject"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ChainWithCharacteristic UniformChain(IBaseObject baseObject)
        {
            ChainWithCharacteristic result = null;
            int pos = Alpahbet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (UniformChain) ((UniformChain) pUniformChains[pos]).Clone();
            }
            return result;
        }

        public override void AddItem(IBaseObject what, Place where)
        {
            base.AddItem(what, where);

            if (pUniformChains.Count != Alpahbet.power)
            {
                pUniformChains.Add(new UniformChain(Length, what));
            }

            foreach (UniformChain chain in pUniformChains)
            {
                chain.AddItem(what, where);
            }
        }

        protected override void BuildIntervals()
        {
            if (!IntervalsChanged) return;

            IntervalsChanged = false;

            foreach (UniformChain uniformChain in pUniformChains)
            {
                IDataForCalculator Datainterface = uniformChain;
                pIntervals.Sum(Datainterface.CommonIntervals);
                startinterval.Sum(Datainterface.StartInterval);
                endinterval.Sum(Datainterface.EndInterval);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public UniformChain GetUniformChain(int i)
        {
            return (UniformChain) ((UniformChain) pUniformChains[i]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public override double InjectIntoCharacteristic(Type type, LinkUp Link)
        {
            return ((Characteristic) CharacteristicSnapshot[type]).Value(this, Link);
        }


        public UniformChain IUniformChain(int i)
        {
            return (UniformChain) pUniformChains[i];
        }

        public void FillNotUniformChains()
        {
            if(pNotUniformChains.Count > 0)
                return;
            List<int> Counters = new List<int>();
            for (int j = 0; j < Alpahbet.power; j++)
            {
                Counters.Add(0);
            }

            for (int i = 0; i < vault.Length; i++)
            {
                int Element = ++Counters[(int)vault[i]];
                if(pNotUniformChains.Count < Element) 
                {
                    pNotUniformChains.Add(new Chain());
                }
                ((Chain)pNotUniformChains[Element]).Add(new ValueInt((int)vault[i]),i);
            }

        }

        public new IBin GetBin()
        {
            ChainBin Temp = new ChainBin();
            FillBin(Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public void FillBin(ChainBin Bin)
        {
            base.FillBin(Bin);
            foreach (UniformChain chain in pUniformChains)
            {
                Bin.UniformChains.Add(chain.GetBin());
            }
        }
    }

    ///<summary>
    ///</summary>
    public class ChainBin : ChainWithCharacteristicBin, IBin
    {
        public ArrayList UniformChains = new ArrayList();

        public new IBaseObject GetInstance()
        {
            return new Chain(this);
        }
    }
}