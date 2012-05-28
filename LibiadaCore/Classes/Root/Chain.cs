using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
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
        /// Конструктор, создает цепь из строки символов
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
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (UniformChain) ((UniformChain) pUniformChains[pos]).Clone();
            }
            return result;
        }

        public override void AddItem(IBaseObject what, Place where)
        {
            base.AddItem(what, where);

            if (pUniformChains.Count != Alphabet.power)
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
            for (int j = 0; j < Alphabet.power; j++)
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

        public int Get(IBaseObject element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < Building.Length; i++)
            {
                if (this[i].Equals(element))
                {
                    entranceCount++;
                    if (entranceCount == entry)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="j">j</param>
        /// <param name="L">L</param>
        /// <param name="entry"></param>
        /// <returns></returns>
        public int GetBinaryInterval(IBaseObject j, IBaseObject L, int entry)
        {
            int jEntry = Get(j, entry);
            if (jEntry == -1)
            {
                return -1;
            }
            for (int i = jEntry + 1; i < Building.Length; i++)
            {
                if (j.Equals(this[i]))
                {
                    return - 1;
                }
                if (L.Equals(this[i]))
                {
                    return i - jEntry;
                }
            }
            return -1;
            //return this.Length - jEntry;
        }

        public double SpatialDependence(IBaseObject j, IBaseObject L)
        {
            int jElementCount = (int)UniformChain(j).GetCharacteristic(LinkUp.Start, new Count());
            int intervals = 1;
            int pairs = 0;
            for (int i = 1; i <= jElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(j, L, i);
                if(binaryInterval > 0)
                {
                    intervals *= binaryInterval;
                    pairs++;
                }
            }
            return Math.Pow(intervals, 1.0/pairs);
        }

        public int GetAfter(IBaseObject element, int from)
        {
            for (int i = from; i < Building.Length; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public double Redundancy(IBaseObject j, IBaseObject L)
        {
            UniformChain jChain = (UniformChain)UniformChain(j);
            int jElementCount = (int)jChain.GetCharacteristic(LinkUp.Start, new Count());
            int pairedj = 0;
            double avG = 1;
            int currentEntrance = 0;
            for (int i = 1; i <= jElementCount; i++ )
            {
                if(GetBinaryInterval(j, L, i) > 0)
                {
                    pairedj++;
                    if(currentEntrance == 0)
                    {
                        currentEntrance = GetAfter(L, Get(j, i));
                    }
                    else
                    {
                        int nextEntrance = GetAfter(L, Get(j, i));
                        avG *= nextEntrance - currentEntrance;
                        currentEntrance = nextEntrance;
                    }
                }
            }
            avG *= this.Length - currentEntrance;
            avG = Math.Pow(avG, 1.0/pairedj);
            return 1 - (SpatialDependence(j, L) / avG);
        }

        public double PartialDependenceCoefficient(IBaseObject j, IBaseObject L)
        {
            UniformChain jChain = (UniformChain)UniformChain(j);
            UniformChain LChain = (UniformChain)UniformChain(L);
            int jElementCount = (int)jChain.GetCharacteristic(LinkUp.Start, new Count());
            int LElementCount = (int)LChain.GetCharacteristic(LinkUp.Start, new Count());
            int intervals = 1;
            int pairs = 0;
            for (int i = 1; i <= jElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(j, L, i);
                if (binaryInterval > 0)
                {
                    intervals *= binaryInterval;
                    pairs++;
                }
            }
            return Redundancy(j, L) * pairs / LElementCount;
        }

        public double K2(IBaseObject j, IBaseObject L)
        {
            UniformChain jChain = (UniformChain)UniformChain(j);
            UniformChain LChain = (UniformChain)UniformChain(L);
            int jElementCount = (int)jChain.GetCharacteristic(LinkUp.Start, new Count());
            int LElementCount = (int)LChain.GetCharacteristic(LinkUp.Start, new Count());
            int intervals = 1;
            int pairs = 0;
            for (int i = 1; i <= jElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(j, L, i);
                if (binaryInterval > 0)
                {
                    intervals *= binaryInterval;
                    pairs++;
                }
            }
            return Redundancy(j, L) * (2 * pairs) / (jElementCount + LElementCount);
        }

        public double K3(IBaseObject j, IBaseObject L)
        {
            double firstK2 = K2(j, L);
            double secondK2 = K2(L, j);
            if(firstK2 < 0 || secondK2 < 0)
            {
                return 0;
            }
            return Math.Sqrt(firstK2*secondK2);
        }

        public List<List<double>> GetK1()
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < Alphabet.power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < Alphabet.power; j++)
                {
                    if(i != j)
                    {
                        result[i].Add(PartialDependenceCoefficient(Alphabet[i], Alphabet[j]));
                    }
                }
            }
            return result;
        }

        public List<List<double>> GetK2()
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < Alphabet.power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < Alphabet.power; j++)
                {
                    if (i != j)
                    {
                        result[i].Add(K2(Alphabet[i], Alphabet[j]));
                    }
                }
            }
            return result;
        }

        public List<List<double>> GetK3()
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < Alphabet.power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < Alphabet.power; j++)
                {
                    if (i != j)
                    {
                        result[i].Add(K3(Alphabet[i], Alphabet[j]));
                    }
                }
            }
            return result;
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